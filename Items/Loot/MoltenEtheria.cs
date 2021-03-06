using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class MoltenEtheria : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+8 Defense, +60% Throwing Velocity and Mystic Duration while in the Etherial");
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
            if (modPlayer.etherial || modPlayer.etherable)
            {
                modPlayer.mysticDuration += 0.6f;
                player.statDefense += 8;
                player.thrownVelocity += 0.6f;
            }
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