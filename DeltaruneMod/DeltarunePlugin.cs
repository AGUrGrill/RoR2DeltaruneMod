using BepInEx;
using R2API;
using RoR2;
using System.Collections.Generic;
using System.Reflection;
using System.Timers;
using UnityEngine;

public class MainClass : BaseUnityPlugin
{
    public static PluginInfo PInfo { get; private set; }
    public void Awake()
    {
        PInfo = Info;
    }
}

namespace DeltarunePlugin
{
    [BepInDependency(ItemAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    public class DeltarunePlugin : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "AGU";
        public const string PluginName = "DeltarunePlugin";
        public const string PluginVersion = "1.0.0";

        private static ItemDef BigShotItem;

        public void Awake()
        {
            Assets.Init();
            BigShotItem = Assets.GetItems("bigshot");

            // Every 10 Seconds Check for and Apply [Big Shot]
            System.Timers.Timer bigShotTimer = new System.Timers.Timer();
            bigShotTimer.Elapsed += new ElapsedEventHandler(BigShotEffect);
            bigShotTimer.Interval = 10000;
            bigShotTimer.Enabled = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                var transform = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;
                Log.Info($"Player pressed F2. Spawning our custom item at coordinates {transform.position}");
                PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(BigShotItem.itemIndex), transform.position, transform.forward * 20f);
            }
         }

        private void BigShotEffect(object source, ElapsedEventArgs e)
        {
            foreach (var characterBody in CharacterBody.readOnlyInstancesList)
            {
                if (characterBody.inventory)
                {
                    var itemCount = characterBody.inventory.GetItemCount(BigShotItem.itemIndex);
                    if (itemCount > 0)
                    {
                        List<BuffDef> allBuffs = new List<BuffDef>();
                        FieldInfo[] fields = typeof(RoR2Content.Buffs).GetFields(BindingFlags.Public | BindingFlags.Static);

                        // Add all buffs to list
                        foreach (var field in fields)
                        {
                            if (field.GetValue(null) is BuffDef buffDef)
                            {
                                allBuffs.Add(buffDef);
                            }
                        }

                        // Get random buff
                        BuffDef randomBuff = allBuffs[UnityEngine.Random.Range(0, allBuffs.Count)];

                        // Add random buff
                        characterBody.AddTimedBuff(randomBuff, 10 + ((itemCount - 0) * 5));
                        Debug.Log($"Added random buff: {randomBuff.name} to {characterBody.name}");
                    }
                }
            }
        }
    }
}
