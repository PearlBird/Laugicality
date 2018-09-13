using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class PlutoDestruction : ModProjectile
    {
        public override void SetDefaults()
        {
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 56;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.penetrate = 8;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        

        public override void AI()
        {
            projectile.rotation += .1f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Frost"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
        
    }
}