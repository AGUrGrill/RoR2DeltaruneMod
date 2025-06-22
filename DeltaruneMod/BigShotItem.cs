using R2API;
using RoR2;
using System.Collections.Generic;
using System.Reflection;
using System.Timers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DeltaruneMod
{
    public static class BigShotItem
    {
        private static GameObject BigShotPrefab;
        private static Sprite BigShotIcon;
        private static ItemDef bigShotItemDef;

        public static void Init()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DeltaruneMod.big_shot")) 
            {
                var bundle = AssetBundle.LoadFromStream(stream);

                BigShotPrefab = bundle.LoadAsset<GameObject>("Assets/Import/big_shot/big_shot.prefab");
                BigShotIcon = bundle.LoadAsset<Sprite>("Assets/Import/big_shot_icon/big_shot_icon.png");
            }

            BigShotAsLunarTierItem();
            AddLanguageTokens();
        }

        public static void StartTimer()
        {
            // Every 10 Seconds Check for and Apply [Big Shot]
            System.Timers.Timer bigShotTimer = new System.Timers.Timer();
            bigShotTimer.Elapsed += new ElapsedEventHandler(BigShotEffect);
            bigShotTimer.Interval = 10100;
            bigShotTimer.Enabled = true;
        }

        private static void BigShotAsLunarTierItem()
        {
            bigShotItemDef = ScriptableObject.CreateInstance<ItemDef>();
            bigShotItemDef.name = "BigShot";
            bigShotItemDef.tier = ItemTier.Lunar;
            bigShotItemDef.deprecatedTier = ItemTier.Lunar;
            bigShotItemDef.pickupModelPrefab = BigShotPrefab;
            bigShotItemDef.pickupIconSprite = BigShotIcon;
            bigShotItemDef.nameToken = "BIGSHOT_NAME";
            bigShotItemDef.pickupToken = "BIGSHOT_PICKUP";
            bigShotItemDef.descriptionToken = "BIGSHOT_DESC";
            bigShotItemDef.loreToken = "BIGSHOT_LORE";
            bigShotItemDef.tags = new[]
            {
                ItemTag.Utility
            };
            bigShotItemDef._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/LunarDef.asset").WaitForCompletion();


            var itemDisplay = BigShotPrefab.AddComponent<RoR2.ItemDisplay>();
            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();
            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.04222F, -0.44262F, 0.35685F),
                    localAngles = new Vector3(11.85053F, 148.0504F, 351.0004F),
                    localScale = new Vector3(7F, 7F, 7F)
                }
            });
            rules.Add("mdlHuntress", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.61995F, 0.23677F, 0.12246F),
                    localAngles = new Vector3(50.48947F, 179.8686F, 88.65546F),
                    localScale = new Vector3(6F, 6F, 6F)

                }
            });
            rules.Add("mdlToolbot", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.75843F, 0.44873F, -5.97378F),
                    localAngles = new Vector3(48.64816F, 311.6693F, 319.3044F),
                    localScale = new Vector3(60F, 60F, 60F)

                }
            });
            rules.Add("mdlEngi", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "HeadCenter",
                    localPos = new Vector3(-0.07696F, -0.82386F, 0.0362F),
                    localAngles = new Vector3(350.3063F, 149.1217F, 7.03048F),
                    localScale = new Vector3(8F, 8F, 8F)

                }
            });
            rules.Add("mdlMage", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.02684F, -0.25777F, 0.1529F),
                    localAngles = new Vector3(0.99506F, 146.1651F, 359.0777F),
                    localScale = new Vector3(3F, 3F, 3F)

                }
            });
            rules.Add("mdlMerc", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.05516F, -0.36669F, 0.19114F),
                    localAngles = new Vector3(0.78083F, 149.236F, 1.34581F),
                    localScale = new Vector3(5F, 5F, 5F)

                }
            });
            rules.Add("mdlTreebot", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "FlowerBase",
                    localPos = new Vector3(-0.07465F, -1.96628F, 0.74331F),
                    localAngles = new Vector3(3.95929F, 149.5434F, 357.3385F),
                    localScale = new Vector3(10F, 10F, 10F)

                }
            });
            rules.Add("mdlLoader", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.03695F, -0.38561F, 0.19133F),
                    localAngles = new Vector3(358.3326F, 145.6386F, 1.02962F),
                    localScale = new Vector3(5F, 5F, 5F)

                }
            });
            rules.Add("mdlCroco", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.31579F, 6.3261F, -2.34545F),
                    localAngles = new Vector3(39.29791F, 216.9755F, 205.7235F),
                    localScale = new Vector3(50F, 50F, 50F)

                }
            });
            rules.Add("mdlCaptain", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.04942F, -0.43712F, 0.1296F),
                    localAngles = new Vector3(358.6895F, 151.388F, 1.96694F),
                    localScale = new Vector3(5F, 5F, 5F)

                }
            });
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.02233F, -0.43605F, 0.13625F),
                    localAngles = new Vector3(359.8591F, 149.4673F, 358.1331F),
                    localScale = new Vector3(4.6F, 4.6F, 4.6F)

                }
            });
            rules.Add("mdlHeretic", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(0.02105F, -0.87071F, 0.01385F),
                    localAngles = new Vector3(355.2848F, 47.55381F, 355.0908F),
                    localScale = new Vector3(0.20392F, 0.20392F, 0.20392F)

                }
            });
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.04595F, -0.25266F, 0.13105F),
                    localAngles = new Vector3(3.30229F, 153.9347F, 3.33027F),
                    localScale = new Vector3(3F, 3F, 3F)

                }
            });
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.0316F, -0.32915F, 0.44771F),
                    localAngles = new Vector3(26.42275F, 153.9711F, 348.9298F),
                    localScale = new Vector3(6F, 5F, 5F)

                }
            });
            rules.Add("mdlChef", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.81985F, 0.20914F, -0.05524F),
                    localAngles = new Vector3(55.56215F, 357.1792F, 266.0527F),
                    localScale = new Vector3(7F, 6F, 6F)

                }
            });
            rules.Add("mdlSeeker", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.04614F, -0.32434F, 0.20333F),
                    localAngles = new Vector3(4.86292F, 154.7291F, 0.52935F),
                    localScale = new Vector3(4.5F, 4F, 4F)

                }
            });
            rules.Add("mdlFalseSon", new RoR2.ItemDisplayRule[]
            {
                new RoR2.ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = BigShotPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.01619F, -0.62815F, 0.30422F),
                    localAngles = new Vector3(4.056F, 154.1342F, 354.7828F),
                    localScale = new Vector3(8F, 8F, 8F)

                }
            });
          
            var bigShot = new R2API.CustomItem(bigShotItemDef, rules);

            ItemAPI.Add(bigShot); // ItemAPI sends back the ItemIndex of your item
        }

        private static void AddLanguageTokens()
        {
            //The Name should be self explanatory
            LanguageAPI.Add("BIGSHOT_NAME", "[Big Shot]");
            //The Pickup is the short text that appears when you first pick this up. This text should be short and to the point, nuimbers are generally ommited.
            LanguageAPI.Add("BIGSHOT_PICKUP", "Gain a random effect every 10 seconds for 10 seconds...");
            //The Description is where you put the actual numbers and give an advanced description.
            LanguageAPI.Add("BIGSHOT_DESC",
                "Grants <style=cDeath>[Big Shot]</style> every 10 seconds.\n<style=cDeath>[Big Shot]</style>: Gain a random effect every 10 seconds.\nIncreases by +5 seconds per stack.");
            //The Lore is, well, flavor. You can write pretty much whatever you want here.
            LanguageAPI.Add("BIGSHOT_LORE",
                "As the days became more dull, and bussiness started to dry, a call came in. \"It's your chance... a once in a lifetime chance... to become a <style=cDeath>[Big Shot]</style>.\"");
        }

        private static void BigShotEffect(object source, ElapsedEventArgs e)
        {
            var body = PlayerCharacterMasterController.instances[0].master.GetBody();
            if (body.inventory)
            {
                var itemCount = body.inventory.GetItemCount(bigShotItemDef.itemIndex);
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
                    body.AddTimedBuff(randomBuff, 8 + ((itemCount - 0) * 5));
                    Debug.Log($"Added random buff: {randomBuff.name} to {body.name}");
                }
            }
        }

        private static void seanEffect(object source, ElapsedEventArgs e)
        {
            var body = PlayerCharacterMasterController.instances[0].master.GetBody();
            var player = PlayerCharacterMasterController.instances[0].master;
            if (body.inventory)
            {
                var itemCount = body.inventory.GetItemCount(bigShotItemDef.itemIndex);
                if (itemCount > 0 && Util.CheckRoll(50, body.master))
                {
                    Debug.Log($"Buffed Primary of {body.name}");
                }
            }

        }
    }
}
