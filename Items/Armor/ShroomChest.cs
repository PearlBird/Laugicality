using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ShroomChest : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroom Amalgam");
            Tooltip.SetDefault("+2% Mystic Damage\n+20 Max Mana");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 1;
			item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticDamage += .02f;
            player.statManaMax2 += 20;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(183, 16);
            recipe.AddIngredient(176, 12);
            recipe.AddIngredient(109, 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}