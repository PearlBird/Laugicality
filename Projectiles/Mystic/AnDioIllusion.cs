using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.Projectiles.Mystic
{
    public class AnDioIllusion : ModProjectile
    {
        public bool bitherial = true;
        public int delay = 4;
        //public bool zImmune = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ande Laser");
        }
        public override void SetDefaults()
        {
            //zImmune = true;
            delay = 4;
            LaugicalityVars.EProjectiles.Add(projectile.type);
            //LaugicalityVars.ZProjectiles.Add(projectile.type);
            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            //zImmune = true;
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Blue"), 0f, 0f);
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1400f;
            bool target = false;
            for (int i = 0; i < 200; i++)
                {
                    NPC npcT = Main.npc[i];
                    //If the npc is hostile
                    if (!npcT.friendly)
                    {
                        Vector2 newMove = npcT.Center - projectile.Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            distance = distanceTo;
                            target = true;
                        }
                    }
                }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
                projectile.velocity *=3;
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);

        }


        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }
    }
}