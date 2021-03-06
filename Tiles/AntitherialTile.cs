using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Tiles
{
    public class AntitherialTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            //Main.tileMerge[56][mod.TileType("ObsidiumOreBlock")] = true;
            //Main.tileMerge[mod.TileType("ObsidiumOreBlock")][56] = true;
            //Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Obsidium Ore");
            //AddMapEntry(new Color(150, 50, 50), name);
            mineResist = .5f;
            minPick = 0;
            dustType = 90;
            drop = mod.ItemType("AntitherialBlock");
        }
        
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.2f;
            b = 0.3f;
        }
        
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
            if(LaugicalityWorld.downedEtheria == false)
            {
                Main.tileSolid[Type] = true;
            }
            else 
            {
                Main.tileSolid[Type] = false;
            }
            if(LaugicalityWorld.downedEtheria == false)
            {
			    return true;
            }
            else 
            {
                return false;
            }
		}

        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
		{

            if(LaugicalityWorld.downedEtheria == false)
            {
			    return true;
            }
            else 
            {
                return false;
            }
		}
    }
}