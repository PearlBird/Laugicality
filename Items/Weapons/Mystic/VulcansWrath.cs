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
	public class VulcansWrath : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vulcan's Wrath");
            Tooltip.AddLine("'Unleash his fury'");
            Tooltip.AddLine("Illusion inflicts 'Steamy'");
            Tooltip.AddLine("Fires different projectiles based on Mysticism");
        }

		public override void SetMysticDefaults()
		{
			item.damage = 48;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = false; 
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 1) {
                int numberProjectiles = Main.rand.Next(2, 5);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                    // If you want to randomize the speed to stagger the projectiles
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 242, damage, knockBack, player.whoAmI);
                }

            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 46 + 8 * modPlayer.destructionPower;
            item.damage = (int)(item.damage * modPlayer.destructionDamage);
            item.useTime = 36 - (3 * modPlayer.destructionPower);
            if (item.useTime <= 0)
                item.useTime = 2;
            item.useAnimation = (int)(item.useTime / 2);
            item.knockBack = 4 + 2 * modPlayer.destructionPower;
            item.shootSpeed = 14f;
            item.shoot = 242;
            item.UseSound = SoundID.Item1;
            item.scale = 1.5f;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 48;
            item.damage = (int)(item.damage * modPlayer.illusionDamage);
            item.useTime = 10;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 18f;
            item.shoot = mod.ProjectileType("VulcanIllusion");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 48;
            item.damage = (int)(item.damage * modPlayer.conjurationDamage);
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 20f;
            item.shoot = mod.ProjectileType("VulcanConjuration");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(null, "SoulOfWrought", 8);
            recipe.AddIngredient(null, "SoulOfFraught", 8);
            recipe.AddIngredient(null, "Gear", 12);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}