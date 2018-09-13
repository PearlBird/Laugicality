using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class FireDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Dust");
            Tooltip.SetDefault("All attacks inflict 'On Fire!'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.obsidium = true;
        }
    }
}