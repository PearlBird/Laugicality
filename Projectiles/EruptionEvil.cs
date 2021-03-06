using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class EruptionEvil : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = false;
            projectile.hostile = true;
			projectile.magic = true;
			//projectile.penetrate = 4;
			projectile.timeLeft = 240;
		}

		public override void AI()
		{
            if(projectile.velocity.Y < 12)
                projectile.velocity.Y += .15f;
			if(Main.rand.Next(4) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Magma"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = -oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = -oldVelocity.Y;
			}
			Main.PlaySound(SoundID.Item10, projectile.position);
			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Magma"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item10, projectile.position);
		}

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 80);		//Add Onfire buff to the NPC for 1 second
		}
	}
}