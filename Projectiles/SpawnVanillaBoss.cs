using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class SpawnVanillaBoss : ModProjectile
	{
        int id = 1;
		public override void SetDefaults()
		{
            id = 1;
			projectile.width = 6;
			projectile.height = 6;
			projectile.aiStyle = 1;
			projectile.scale = 1f;
			projectile.penetrate = 1;
			projectile.timeLeft = 20;
			projectile.tileCollide = false;
			aiType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.ai[1]++;
			
			if (projectile.ai[1] >= 0)
			{
				Main.PlaySound(15, (int)player.position.X, (int)player.position.Y-50, 0);
				NPC.SpawnOnPlayer(player.whoAmI, id);
				projectile.ai[1] = -30;
			}
		}
	}
}