using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Loot
{
    public class EtherialConjurationCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% Conjuration Damage and +2 Conjuration Power while in the Etherial");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial || modPlayer.etherable)
            {
                modPlayer.conjurationDamage += .2f;
                modPlayer.conjurationPower += 2;
            }
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ConjurationCore", 1);
            recipe.AddIngredient(null, "EtherialEssence", 6);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}