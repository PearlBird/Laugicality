using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class Pyramind : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases your minion capacity \n+40 Mana \nUnleash a Sandstorm when struck");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.sandy = true;
            player.maxMinions += 1;
            player.statManaMax2 += 40;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2328, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}