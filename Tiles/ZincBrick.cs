using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Tiles
{
    public class ZincBrick : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(80, 130, 100));
            mineResist = 1f;
            minPick = 20;
            drop = mod.ItemType("ZincBrick");
            soundType = 21;
            dustType = 1;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        

    }
}