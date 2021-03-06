using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class LebenCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases heart pickup range \nIncreases life regeneration \nIncreases max life by 20% \nEquip in last slot for maximum effectiveness");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 3;
            item.accessory = true;
            item.lifeRegen = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeMagnet = true;
            player.statLifeMax2 += (player.statLifeMax + player.statLifeMax2) / 5 / 20 * 20 - (player.statLifeMax / 5 / 20 * 20);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LifeforceGem", 1);
            recipe.AddIngredient(null, "HeartreachGem", 1);
            recipe.AddIngredient(null, "RegenerationGem", 1);
            recipe.AddTile(null, "CrystalineInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}