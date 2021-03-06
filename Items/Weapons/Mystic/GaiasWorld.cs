using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Laugicality;

namespace Laugicality.Items.Weapons.Mystic
{
    public class GaiasWorld : MysticItem
    {
        public string tt = "";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaia's World");
            Tooltip.SetDefault("The World is in your hands\nIllusion inflicts a random elemental debuff\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetMysticDefaults()
        {
            item.damage = 30;
            //item.magic = true;
            item.mana = 6;
            item.width = 40;
            item.height = 40;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = 10000;
            item.rare = 3;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GaiaDestruction");
            item.shootSpeed = 6f;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 25 + 7 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.mana = 6;
            item.useTime = 30 - (2 * modPlayer.destructionPower);
            if (item.useTime <= 0)
                item.useTime = 1;
            item.useAnimation = item.useTime;
            item.knockBack = 4 + (2 * modPlayer.destructionPower);
            item.shootSpeed = 8f + (float)(2 * modPlayer.destructionPower);
            item.shoot = mod.ProjectileType("GaiaDestruction");
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 28;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.mana = 6;
            item.useTime = 20;
            item.useAnimation = item.useTime;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("GaiaIllusion");
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 32;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.mana = 6;
            item.useTime = 24;
            item.useAnimation = 24;
            item.knockBack = 3;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("GaiaConjuration");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 8);
            recipe.AddIngredient(null, "AncientShard", 2);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}