using R2API;
using RoR2;
using System.Collections.Generic;
using System.Reflection;
using System.Timers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DeltaruneMod
{
    public static class LancerCardItem
    {
        private static GameObject LancerCardPrefab;
        private static Sprite LancerCardIcon;
        private static ItemDef lancerCardItemDef;

        public static void Init()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DeltaruneMod.lancer_card")) 
            {
                var bundle = AssetBundle.LoadFromStream(stream);

                LancerCardPrefab = bundle.LoadAsset<GameObject>("Assets/Import/lancer_spade/lancer_card.prefab");
                LancerCardIcon = bundle.LoadAsset<Sprite>("Assets/Import/lancer_spade/lancer_card_icon.png");
            }

            LancerCardAsLunarTierItem();
            AddLanguageTokens();
            LancerCardEffect();
        }

        public static void StartTimer()
        {
            // Every 1 Seconds Check for and delete gold
            System.Timers.Timer lancerTimer = new System.Timers.Timer();
            lancerTimer.Elapsed += new ElapsedEventHandler(LancerCardDebuffEffect);
            lancerTimer.Interval = 1000;
            lancerTimer.Enabled = true;
        }

        private static void LancerCardAsLunarTierItem()
        {
            lancerCardItemDef = ScriptableObject.CreateInstance<ItemDef>();
            lancerCardItemDef.name = "LancerCard";
            lancerCardItemDef.tier = ItemTier.Lunar;
            lancerCardItemDef.deprecatedTier = ItemTier.Lunar;
            lancerCardItemDef.pickupModelPrefab = LancerCardPrefab;
            lancerCardItemDef.pickupIconSprite = LancerCardIcon;
            lancerCardItemDef.nameToken = "LANCERCARD_NAME";
            lancerCardItemDef.pickupToken = "LANCERCARD_PICKUP";
            lancerCardItemDef.descriptionToken = "LANCERCARD_DESC";
            lancerCardItemDef.loreToken = "LANCERCARD_LORE";
            lancerCardItemDef.tags = new[]
            {
                ItemTag.Utility
            };
            lancerCardItemDef._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/LunarDef.asset").WaitForCompletion();


            var itemDisplay = LancerCardPrefab.AddComponent<RoR2.ItemDisplay>();
            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();
            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
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
                    followerPrefab = LancerCardPrefab,
                    childName = "Head",
                    localPos = new Vector3(-0.01619F, -0.62815F, 0.30422F),
                    localAngles = new Vector3(4.056F, 154.1342F, 354.7828F),
                    localScale = new Vector3(8F, 8F, 8F)

                }
            });
          
            var lancerCard = new R2API.CustomItem(lancerCardItemDef, rules);

            ItemAPI.Add(lancerCard); // ItemAPI sends back the ItemIndex of your item
        }

        private static void AddLanguageTokens()
        {
            //The Name should be self explanatory
            LanguageAPI.Add("LANCERCARD_NAME", "Jack of Spades");
            //The Pickup is the short text that appears when you first pick this up. This text should be short and to the point, nuimbers are generally ommited.
            LanguageAPI.Add("LANCERCARD_PICKUP", "Gain a random effect every 10 seconds for 10 seconds...");
            //The Description is where you put the actual numbers and give an advanced description.
            LanguageAPI.Add("LANCERCARD_DESC",
                "Grants <style=cDeath>[Big Shot]</style> every 10 seconds.\n<style=cDeath>[Big Shot]</style>: Gain a random effect every 10 seconds.\nIncreases by +5 seconds per stack.");
            //The Lore is, well, flavor. You can write pretty much whatever you want here.
            LanguageAPI.Add("LANCERCARD_LORE",
                "It's just a card, but you do hear a faint hohoho coming from it...");
        }

        private static void LancerCardEffect()
        {
            var body = PlayerCharacterMasterController.instances[0].master.GetBody();
            var master = PlayerCharacterMasterController.instances[0].master;
            if (body.inventory)
            {
                var itemCount = body.inventory.GetItemCount(lancerCardItemDef.itemIndex);
                if (itemCount > 0)
                {
                    body.AddBuff(RoR2Content.Buffs.SmallArmorBoost);
                    body.AddFreeChestBuff();

                    
                    Debug.Log($"Added lancer effect to {body.name}");
                }
            }
        }

        private static void LancerCardDebuffEffect(object source, ElapsedEventArgs e)
        {
            var body = PlayerCharacterMasterController.instances[0].master.GetBody();
            var master = PlayerCharacterMasterController.instances[0].master;
            if (body.inventory)
            {
                var moners = master.money;
                if (moners > 0) master.GiveMoney((uint)(-moners));
            }
            
        }
    }
}
