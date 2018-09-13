using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class ManaRegenerationGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases mana regeneration");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaRegenBonus += 25;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(293, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}