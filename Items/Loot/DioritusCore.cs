using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Laugicality.Items.Loot
{
    public class DioritusCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dioritus Core");
            Tooltip.SetDefault("For Glory!");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(mod.BuffType("ForGlory"), 1, true);
        }

        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(77);
            recipe.AddIngredient(null, "ObsidiumOre", 3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

    }
}