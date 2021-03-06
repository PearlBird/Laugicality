using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
    public class TheSnowflake : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowflake");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 30;           
            item.thrown = true;             
            item.noMelee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 45;      
            item.useAnimation = 45;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = 1;   
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            item.shoot = mod.ProjectileType("TheSnowflake"); 
            item.shootSpeed = 6f;     
            item.useTurn = true;
            item.maxStack = 999;       
            item.consumable = true;  
            item.noUseGraphic = true;

        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ChilledBar", 4);
            recipe.AddIngredient(null, "FrostShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this, 80);
            recipe.AddRecipe();
        }
    }
}