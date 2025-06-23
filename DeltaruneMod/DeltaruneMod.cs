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

namespace DeltaruneMod
{
    [BepInDependency(ItemAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    public class DeltaruneMod : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "AGU";
        public const string PluginName = "DeltaruneMod";
        public const string PluginVersion = "1.3.0";

        public void Awake()
        {
            Log.Init(Logger);
            try
            {
                LancerCardItem.Init();
                LancerCardItem.StartTimer();
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"[LancerCardItem] Init failed: {ex.Message}\n{ex.StackTrace}");
            }
            try
            {
                BigShotItem.Init();
                BigShotItem.StartTimer();
            }
            catch
            {
                Log.Message("Error making Big Shot");
            }
            
        }

        private void Update()
        {
        }
    }
}
