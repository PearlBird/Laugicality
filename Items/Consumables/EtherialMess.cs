﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Items.Consumables
{
	public class EtherialMess : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Etherial Crown");
            Tooltip.SetDefault("Summons Ragnar");
        }
        public override void SetDefaults()
		{
			item.width = 16;
			item.height = 20;
			item.maxStack = 20;
			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			//item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = mod.ProjectileType("Nothing");
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial)
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Ragnar"));
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            return (modPlayer.ZoneObsidium && modPlayer.etherial);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EtherialEssence", 3);
            recipe.AddTile(26);
            recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}