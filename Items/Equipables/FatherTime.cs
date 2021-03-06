using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class FatherTime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Father Time");
            Tooltip.SetDefault("Increases Movement Speed when Time is stopped\nReduces cooldown between Time Stops\nIncreases Duration of Time Stop\n'Mastery of Time'");
        }

        public override void SetDefaults()
        {
            item.width = 58;
            item.height = 64;
            item.value = 100;
            item.rare = 6;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if((NPC.CountNPCS(mod.NPCType("ZaWarudo")) >= 1))
            {
                player.moveSpeed += 3f;
                player.maxRunSpeed += 3f;
                player.jumpSpeedBoost += 3f;
            }
            LaugicalityWorld.zWarudo += 100;
            modPlayer.zCoolDown -= 140;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TimeWinder", 1);
            recipe.AddIngredient(null, "Clockface", 1);
            recipe.AddIngredient(null, "HandsOfTime", 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddIngredient(null, "Gear", 20);
            recipe.AddIngredient(ItemID.Cog, 20);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}