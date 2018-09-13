using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
	//imported from my tAPI mod because I'm lazy
	public class Antenna : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a TV to fight for you.");
		}

		public override void SetDefaults()
		{
			item.damage = 55;
			item.summon = true;
			item.mana = 16;
			item.width = 48;
			item.height = 48;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 25, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("TV");
			item.shootSpeed = 12f;
			item.buffType = mod.BuffType("TV");	//The buff added to player after used the item
			item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return player.altFunctionUse != 2;
		}
		
		public override bool UseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(134);
            recipe.AddIngredient(null, "SteamBar", 12);
            recipe.AddIngredient(null, "SoulOfThought", 20);
            recipe.AddIngredient(1344, 40);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
