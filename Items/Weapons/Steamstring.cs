using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
	public class Steamstring : ModItem
	{
        //public bool steam = true;
        //public int steamTier = 1;
        //public int steamCost = 60;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Steaming Frenzy' \nTurns all Arrows into Brass Arrows\n20% chance to not consume ammo");
		}

		public override void SetDefaults()
        {
            //steam = true;
            //steamTier = 1;
            //steamCost = 60;
            item.scale *= 1.2f;
            item.damage = 42;
			item.ranged = true;
			item.width = 40;
			item.height = 62;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item10;
			item.autoReuse = true;
			item.shoot = 10; 
			item.shootSpeed = 16f;
			item.useAmmo = 40;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(null, "SoulOfSought", 8);
            recipe.AddIngredient(null, "SoulOfThought", 8);
            recipe.AddIngredient(null, "Gear", 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
        /*
        //Steam item
        //VV
        public override bool CanUseItem(Player player)
        {

            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (steam)
            {
                if (modPlayer.connected >= steamTier && LaugicalityWorld.power >= steamCost)
                    return true;
                else
                    return false;
            }
            return true;
        }

        public override bool UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            LaugicalityWorld.power -= steamCost;
            if (LaugicalityWorld.power < 0)
                LaugicalityWorld.power = 0;
            return true;
        }
        //^^
        //Steam Item end
        */
            
        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .20f;
		}

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);

            //Main.NewText("Steam Tier: " + steamTier.ToString(), 0, 250, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = Main.rand.Next(1, 3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); 
                                                                                                                
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                if(Main.netMode != 1)
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BrassArrow"), damage, knockBack, player.whoAmI);
            }


            return false; 
        }
    }
}
