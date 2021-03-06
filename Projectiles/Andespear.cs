﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class Andespear : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Andespear");
        }
        public override void SetDefaults()
        {
            projectile.height = 74;
            projectile.width = 74;  
			projectile.aiStyle = 19;
			projectile.melee = true;  
			projectile.timeLeft = 90;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.ownerHitCheck = true;
			projectile.hide = true;
        }

        public float movementFactor // Change this value to alter how fast the spear moves
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        public override void AI()
        {
            //Thanks ExampleMod :thumbsup:
            
            Player projOwner = Main.player[projectile.owner];
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f) 
                {
                    movementFactor = 3f; 
                    projectile.netUpdate = true; 
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) 
                {
                    movementFactor -= 2.4f;
                }
                else 
                {
                    movementFactor += 2.1f;
                }
            }
            
            projectile.position += projectile.velocity * movementFactor;
            
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            /*
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
            // Offset by 90 degrees here
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
            */
            
        
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f - (float)Math.PI / 2;
        	if(projectile.spriteDirection == -1)
        	{
        		projectile.rotation -= 1.57f;
        	}
        }
    }
}