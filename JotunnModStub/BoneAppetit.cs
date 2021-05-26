﻿using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using Jotunn.Utils;
using System.Reflection;
using Jotunn.Entities;
using Jotunn.Configs;
using Jotunn.Managers;
using System;

namespace Boneappetit
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    internal class Grills : BaseUnityPlugin
    {
        public const string PluginGUID = "com.rockerkitten.boneappetit";
        public const string PluginName = "BoneAppetit";
        public const string PluginVersion = "1.1.0";
        public AssetBundle assetBundle;
        private AssetBundle customfood;
        private void Awake()
        {
            AssetLoad();
            LoadItem();
            LoadGriddle();
            IceCream();
            PorkRind();
            Kabob();
            FriedLox();
            GlazedCarrot();
            Bacon();
            SmokedFish();
            Pancakes();

        }

        private void AssetLoad()
        {
            assetBundle = AssetUtils.LoadAssetBundleFromResources("grill", typeof(Grills).Assembly);
            customfood = AssetUtils.LoadAssetBundleFromResources("customfood", Assembly.GetExecutingAssembly());

        }

        private void LoadItem()
        {
            //piece_grill

            var grillfab = assetBundle.LoadAsset<GameObject>("rk_grill");
            var grill = new CustomPiece(grillfab,
                new PieceConfig
                {
                    CraftingStation = "forge",
                    AllowedInDungeons = false,
                    Enabled = true,
                    PieceTable = "_HammerPieceTable",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 10, Recover = true },
                        new RequirementConfig { Item = "Iron", Amount = 1, Recover = true }
                    }
                });
            PieceManager.Instance.AddPiece(grill);
        }
        private void LoadGriddle()
        {
            //piece_griddle

            var griddlefab = assetBundle.LoadAsset<GameObject>("rk_griddle");
            var griddle = new CustomPiece(griddlefab,
                new PieceConfig
                {
                    CraftingStation = "",
                    AllowedInDungeons = false,
                    Enabled = true,
                    PieceTable = "_HammerPieceTable",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 10, Recover = true }
                    }
                });
            PieceManager.Instance.AddPiece(griddle);
        }
        private void IceCream()
        {
            var icecream_prefab = customfood.LoadAsset<GameObject>("rk_icecream");
            var icecream = new CustomItem(icecream_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Ice Cream",
                    Amount = 2,
                    CraftingStation = "piece_cauldron",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "FreezeGland", Amount = 4},
                        new RequirementConfig { Item = "Blueberries", Amount = 8},
                        new RequirementConfig { Item = "Honey", Amount = 2}
                    }
                });

            ItemManager.Instance.AddItem(icecream);

        }
        private void PorkRind()
        {
            var porkrind_prefab = customfood.LoadAsset<GameObject>("rk_porkrind");
            var porkrind = new CustomItem(porkrind_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Pork Rinds",
                    Amount = 2,
                    CraftingStation = "rk_griddle",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "LeatherScraps", Amount = 1}
                    }
                });

            ItemManager.Instance.AddItem(porkrind);

        }
        private void Kabob()
        {
            var kabob_prefab = customfood.LoadAsset<GameObject>("rk_kabob");
            var kabob = new CustomItem(kabob_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Kabob",
                    Amount = 1,
                    CraftingStation = "rk_grill",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Turnip", Amount = 1},
                        new RequirementConfig { Item = "Carrot", Amount = 2},
                        new RequirementConfig { Item = "RawMeat", Amount = 1},
                        new RequirementConfig { Item = "BoneFragments", Amount = 2}
                    }
                });

            ItemManager.Instance.AddItem(kabob);

        }
        private void FriedLox()
        {
            var friedlox_prefab = customfood.LoadAsset<GameObject>("rk_friedloxmeat");
            var friedlox = new CustomItem(friedlox_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Country Fried Lox Meat",
                    Amount = 1,
                    CraftingStation = "rk_grill",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "LoxMeat", Amount = 2},
                        new RequirementConfig { Item = "BarleyFlour", Amount = 2},
                        new RequirementConfig { Item = "Thistle", Amount = 1},
                        new RequirementConfig { Item = "Cloudberry", Amount = 2}
                    }
                });

            ItemManager.Instance.AddItem(friedlox);

        }
        private void GlazedCarrot()
        {
            var glazedcarrot_prefab = customfood.LoadAsset<GameObject>("rk_glazedcarrots");
            var glazedcarrot = new CustomItem(glazedcarrot_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Honey Glazed Carrots",
                    Amount = 1,
                    CraftingStation = "rk_griddle",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Carrot", Amount = 2},
                        new RequirementConfig { Item = "Honey", Amount = 2},
                        new RequirementConfig { Item = "Dandelion", Amount = 1 }
                    }
                });

            ItemManager.Instance.AddItem(glazedcarrot);

        }
        private void Bacon()
        {
            var bacon_prefab = customfood.LoadAsset<GameObject>("rk_bacon");
            var bacon = new CustomItem(bacon_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Bacon",
                    Amount = 2,
                    CraftingStation = "rk_griddle",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RawMeat", Amount = 1}
                    }
                });

            ItemManager.Instance.AddItem(bacon);
        }
        private void SmokedFish()
        {
            var smokedfish_prefab = customfood.LoadAsset<GameObject>("rk_smokedfish");
            var smokedfish = new CustomItem(smokedfish_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Country Fried Lox Meat",
                    Amount = 1,
                    CraftingStation = "rk_grill",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RawFish", Amount = 1}
                    }
                });

            ItemManager.Instance.AddItem(smokedfish);

        }
        private void Pancakes()
        {
            var pancake_prefab = customfood.LoadAsset<GameObject>("rk_pancake");
            var pancake = new CustomItem(pancake_prefab, fixReference: false,
                new ItemConfig
                {
                    Name = "Pancakes",
                    Amount = 1,
                    CraftingStation = "rk_grill",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Honey", Amount = 2},
                        new RequirementConfig { Item = "BarleyFlour", Amount = 3},
                        new RequirementConfig { Item = "Cloudberry", Amount = 5}
                    }
                });

            ItemManager.Instance.AddItem(pancake);

        }
    }
}