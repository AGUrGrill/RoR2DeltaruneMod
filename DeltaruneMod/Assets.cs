using R2API;
using RoR2;
using System.Reflection;
using UnityEngine;

namespace DeltarunePlugin
{
    internal static class Assets
    {
        internal static GameObject BigShotPrefab;
        internal static Sprite BigShotIcon;
        internal static ItemDef BigShotItemDef;
        public static GameObject ItemBodyModelPrefab;

        private const string ModPrefix = "@DeltarunePlugin:";

        internal static void Init()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DeltarunePlugin.big_shot")) 
            {
                var bundle = AssetBundle.LoadFromStream(stream);

                BigShotPrefab = bundle.LoadAsset<GameObject>("Assets/Import/big_shot/big_shot.prefab");
                BigShotIcon = bundle.LoadAsset<Sprite>("Assets/Import/big_shot_icon/big_shot_icon.png");
            }

            BigShotAsLunarTierItem();

            AddLanguageTokens();
        }

        internal static ItemDef GetItems(string name)
        {
            if (name == "bigshot") return BigShotItemDef;
            else return BigShotItemDef; // Fallback Item
        }

        private static void BigShotAsLunarTierItem()
        {
            BigShotItemDef = new ItemDef
            {
                name = "BigShot",
                tier = ItemTier.Lunar,
                pickupModelPrefab = BigShotPrefab,
                pickupIconSprite = BigShotIcon,
                nameToken = "BIGSHOT_NAME",
                pickupToken = "BIGSHOT_PICKUP",
                descriptionToken = "BIGSHOT_DESC",
                loreToken = "BIGSHOT_LORE",
                tags = new[]
                {
                    ItemTag.Utility
                }
            };

            ItemBodyModelPrefab = BigShotPrefab;
            var itemDisplay = ItemBodyModelPrefab.AddComponent<RoR2.ItemDisplay>();

            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();

            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
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
                    followerPrefab = ItemBodyModelPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.01619F, -0.62815F, 0.30422F),
                    localAngles = new Vector3(4.056F, 154.1342F, 354.7828F),
                    localScale = new Vector3(8F, 8F, 8F)

                }
            });
          
            var bigShot = new R2API.CustomItem(BigShotItemDef, rules);

            ItemAPI.Add(bigShot); // ItemAPI sends back the ItemIndex of your item
        }

        private static void AddLanguageTokens()
        {
            //The Name should be self explanatory
            LanguageAPI.Add("BIGSHOT_NAME", "[Big Shot]");
            //The Pickup is the short text that appears when you first pick this up. This text should be short and to the point, nuimbers are generally ommited.
            LanguageAPI.Add("BIGSHOT_PICKUP", "Gain random effect every 10 seconds.");
            //The Description is where you put the actual numbers and give an advanced description.
            LanguageAPI.Add("BIGSHOT_DESC",
                "Grants <style=cDeath>[Big Shot]</style> every 10 seconds.\n<style=cDeath>[Big Shot]</style>: Gain a random effect every 10 seconds.\nIncreases by +5 seconds per stack.");
            //The Lore is, well, flavor. You can write pretty much whatever you want here.
            LanguageAPI.Add("BIGSHOT_LORE",
                "As days became more dull, and bussiness starts to dry, a call comes in. It's your chance... a once in a lifetime chance to become a... [Big Shot].");
        }
    }
}
