using BepInEx;
using R2API;
using RoR2;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AddressableAssets;

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
    // This is an example plugin that can be put in
    // BepInEx/plugins/ExamplePlugin/ExamplePlugin.dll to test out.
    // It's a small plugin that adds a relatively simple item to the game,
    // and gives you that item whenever you press F2.

    // This attribute specifies that we have a dependency on a given BepInEx Plugin,
    // We need the R2API ItemAPI dependency because we are using for adding our item to the game.
    // You don't need this if you're not using R2API in your plugin,
    // it's just to tell BepInEx to initialize R2API before this plugin so it's safe to use R2API.
    [BepInDependency(ItemAPI.PluginGUID)]

    // This one is because we use a .language file for language tokens
    // More info in https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
    [BepInDependency(LanguageAPI.PluginGUID)]

    // This attribute is required, and lists metadata for your plugin.
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    // This is the main declaration of our plugin class.
    // BepInEx searches for all classes inheriting from BaseUnityPlugin to initialize on startup.
    // BaseUnityPlugin itself inherits from MonoBehaviour,
    // so you can use this as a reference for what you can declare and use in your plugin class
    // More information in the Unity Docs: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class DeltarunePlugin : BaseUnityPlugin
    {
        // The Plugin GUID should be a unique ID for this plugin,
        // which is human readable (as it is used in places like the config).
        // If we see this PluginGUID as it is on thunderstore,
        // we will deprecate this mod.
        // Change the PluginAuthor and the PluginName !
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "AGU";
        public const string PluginName = "DeltarunePlugin";
        public const string PluginVersion = "1.0.0";

        // We need our item definition to persist through our functions, and therefore make it a class field.
        private static ItemDef BigShotItem;

        // The Awake() method is run at the very start when the game is initialized.
        public void Awake()
        {
            Assets.Init();
            Hooks.Init();
            BigShotItem = Assets.GetItems();

            GlobalEventManager.onCharacterDeathGlobal += GlobalEventManager_onCharacterDeathGlobal;
        }

        private void GlobalEventManager_onCharacterDeathGlobal(DamageReport report)
        {
            // If a character was killed by the world, we shouldn't do anything.
            if (!report.attacker || !report.attackerBody)
            {
                return;
            }

            var attackerCharacterBody = report.attackerBody;

            // We need an inventory to do check for our item
            if (attackerCharacterBody.inventory)
            {
                // Store the amount of our item we have
                var garbCount = attackerCharacterBody.inventory.GetItemCount(BigShotItem.itemIndex);
                if (garbCount > 0)
                    // Roll for our 50% chance.
                    // && Util.CheckRoll(50, attackerCharacterBody.master))
                {
                    // Since we passed all checks, we now give our attacker the cloaked buff.
                    // Note how we are scaling the buff duration depending on the number of the custom item in our inventory
                    List<BuffDef> allBuffs = new List<BuffDef>();
                    FieldInfo[] fields = typeof(RoR2Content.Buffs).GetFields(BindingFlags.Public | BindingFlags.Static);

                    foreach (var field in fields)
                    {
                        if (field.GetValue(null) is BuffDef buffDef)
                        {
                            allBuffs.Add(buffDef);
                        }
                    }

                    BuffDef randomBuff = allBuffs[UnityEngine.Random.Range(0, allBuffs.Count)];

                    attackerCharacterBody.AddTimedBuff(randomBuff, 10 + ((garbCount-0) * 5));
                    Debug.Log($"Added random buff: {randomBuff.name} to {attackerCharacterBody.name}");
                }
            }
        }

        // The Update() method is run on every frame of the game.
        private void Update()
        {
            // This if statement checks if the player has currently pressed F2.
            if (Input.GetKeyDown(KeyCode.F2))
            {
                // Get the player body to use a position:
                var transform = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;

                // And then drop our defined item in front of the player.

                Log.Info($"Player pressed F2. Spawning our custom item at coordinates {transform.position}");
                PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(BigShotItem.itemIndex), transform.position, transform.forward * 20f);
            }
        }
    }
}
