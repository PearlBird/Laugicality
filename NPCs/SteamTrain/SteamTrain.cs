using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.SteamTrain
{
    [AutoloadBossHead]
    public class SteamTrain : ModNPC
    {
        public static Random rnd = new Random();
        public int spawn = 0;
        public bool stage2 = false;
        public int phase = 0;
        public int dir = 0;
        public int vdir = 0;
        public float accel = 0f;
        public float maxAccel = 20f;
        public float vaccel = 0f;
        public float maxVaccel = 20f;
        public bool boosted = false;
        public int delay = 0;
        public int maxDelay = 60;
        public int range = 2000;
        public bool bitherial = true;
        public int plays = 0;
        int despawn = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.ENPCs.Add(npc.type);
            DisplayName.SetDefault("Steam Train");
        }

        public override void SetDefaults()
        {
            despawn = 0;
            plays = 1;
            bitherial = true;
            maxDelay = 60;
            range = 2200;
            maxAccel = 20f;
            maxVaccel = 20f;
            accel = 0f;
            vaccel = 0f;
            spawn = 0;
            phase = 0;
            dir = 0;
            vdir = 0;
            delay = 0;
            boosted = false;
            npc.width = 1680;
            npc.height = 124;
            npc.damage = 90;
            npc.defense = 30;
            npc.aiStyle = 0;
            npc.lifeMax = 42000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.npcSlots = 15f;
            npc.value = 12f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.netAlways = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SteamTrain");
            bossBag = mod.ItemType("SteamTrainTreasureBag");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            plays = numPlayers;
            npc.lifeMax = 50000 + numPlayers * 6000;
            npc.damage = 100;
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override void AI()
        {
            bitherial = true;
            npc.spriteDirection = 0;

            //Retarget (borrowed from Dan <3)
            Player P = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;

            //DESPAWN
            if (!Main.player[npc.target].active || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
                if (!Main.player[npc.target].active || Main.player[npc.target].dead)
                {
                    if (despawn == 0)
                        despawn++;
                }
            }
            if (despawn >= 1)
            {
                despawn++;
                npc.noTileCollide = true;
                npc.velocity.Y = 8f;
                if (despawn >= 300)
                    npc.active = false;
            }
            Vector2 delta = Main.player[npc.target].Center - npc.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
            //Main.NewText(accel.ToString(), 250, 0, 0);  


            //Checking which direction to move when spawned
            if (dir == 0)
            {
                if (delta.X < 0) dir = 1;
                else dir = -1;
            }

            //Horizontal Movement
            npc.velocity.X = accel;
            if(dir == 1)
            {
                if(accel < maxAccel/2)
                {
                    accel += .2f;
                }
                else
                {
                    if(boosted == false) //Play boosted sound effect
                    {
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/train_whistle"));
                        boosted = true;
                    }
                    accel = maxAccel;
                }
                if (delta.X < -range)
                {
                    boosted = false;
                    dir = -1;
                }
            }
            if (dir == -1)
            {
                if (accel > maxAccel / -2)
                {
                    accel -= .2f;
                }
                else
                {
                    if (boosted == false) //Play boosted sound effect
                    {
                        Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/train_whistle"));
                        boosted = true;
                    }
                    accel = -maxAccel;
                }
                if (delta.X > range)
                {
                    boosted = false;
                    dir = 1;
                }
            }

            //Vertical Movement
            npc.velocity.Y = vaccel;
            if (boosted == false)
            {
                if (Math.Abs(delta.Y) > 40)
                {
                    if (delta.Y > 40)
                    {
                        if (vaccel < maxVaccel) vaccel += .4f;
                    }
                    if (delta.Y < -40)
                    {
                        if (vaccel < maxVaccel) vaccel -= .4f;
                    }
                }
                else
                {
                    if (Math.Abs(vaccel) > .01f) vaccel *= .5f;
                    else vaccel = 0f;
                }
            }
            else vaccel = 0;

            //Attacking

            if(boosted)delay += 1;
            if (delay >= maxDelay && Main.netMode != 1)
            {

                if (delta.Y < 0)
                {
                    Main.PlaySound(SoundID.Item34, (int)npc.position.X, (int)npc.position.Y);
                    Projectile.NewProjectile(npc.position.X + 312, npc.position.Y + 60, 0, -8, mod.ProjectileType("GasBallUp"), npc.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X + 522, npc.position.Y + 60, 0, -8, mod.ProjectileType("GasBallUp"), npc.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X + 732, npc.position.Y + 60, 0, -8, mod.ProjectileType("GasBallUp"), npc.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X + 942, npc.position.Y + 60, 0, -8, mod.ProjectileType("GasBallUp"), npc.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X + 1156, npc.position.Y + 60, 0, -8, mod.ProjectileType("GasBallUp"), npc.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X + 1372, npc.position.Y + 60, 0, -8, mod.ProjectileType("GasBallUp"), npc.damage / 3, 3f, Main.myPlayer);
                }
                else
                {
                    //Projectile.NewProjectile(npc.position.X + 312, npc.position.Y + 60, 0, 8, mod.ProjectileType("Coginator"), npc.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X + 522, npc.position.Y + 60, 0, 8, mod.ProjectileType("SteamyShadow"), npc.damage / 3, 3f, Main.myPlayer);
                    //Projectile.NewProjectile(npc.position.X + 732, npc.position.Y + 60, 0, 8, mod.ProjectileType("Coginatore"), npc.damage / 3, 3f, Main.myPlayer);
                    //Projectile.NewProjectile(npc.position.X + 942, npc.position.Y + 60, 0, 8, mod.ProjectileType("Coginator"), npc.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X + 1156, npc.position.Y + 60, 0, 8, mod.ProjectileType("SteamyShadow"), npc.damage / 3, 3f, Main.myPlayer);
                    //Projectile.NewProjectile(npc.position.X + 1372, npc.position.Y + 60, 0, 8, mod.ProjectileType("Coginator"), npc.damage / 3, 3f, Main.myPlayer);
                }
                if (phase > 0) { 
                Projectile.NewProjectile(npc.position.X + 1572, npc.position.Y + 60, 0, -8, mod.ProjectileType("Coginator"), npc.damage / 3, 3f, Main.myPlayer);
                Projectile.NewProjectile(npc.position.X + 102, npc.position.Y + 60, 0, -8, mod.ProjectileType("Coginator"), npc.damage / 3, 3f, Main.myPlayer);
                }
             delay = 0;

            }

            //Health Phases
            if (npc.life < npc.lifeMax * .67 && phase == 0)
            {
                phase = 1; Main.NewText("Superdrive.", 150, 0, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
            }
            if (npc.life < npc.lifeMax * .33 && phase == 1) { phase = 2; Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0); Main.NewText("Hyperdrive.", 200, 0, 0); }
            if (npc.life < npc.lifeMax * .10 && phase == 2 && Main.expertMode)
            {
                phase = 3; Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0); Main.NewText("Warpdrive.", 250, 0, 0);
                npc.life = (int)(npc.lifeMax * .15);
            }
            //Phase Stat Changing
            if (phase == 1)
            {
                range = 1800;
                maxAccel = 26f;
                maxVaccel = 26f;
                maxDelay = 50;
                npc.defense = 25;
                if (!Main.expertMode)
                {
                    npc.damage = 100;
                }
                else
                {
                    npc.damage = 120;
                }
            }

            if(phase == 2)
            {
                range = 1400;
                maxAccel = 32f;
                maxVaccel = 32f;
                maxDelay = 40;
                npc.defense = 24;
                if (!Main.expertMode)
                {
                    npc.damage = 110;
                }
                else
                {
                    npc.damage = 130;
                }
            }
            if (phase == 3)
            {
                range = 1000;
                maxAccel = 38f;
                maxVaccel = 38f;
                maxDelay = 30;
                npc.defense = 18;
                if (!Main.expertMode)
                {
                    npc.damage = 120;
                }
                else
                {
                    npc.damage = 140;
                }
            }
        }


        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            if (Main.expertMode)
            {
                int debuff = mod.BuffType("Steamy");
                if (debuff >= 0)
                {
                    player.AddBuff(debuff, 90, true);
                }
            }
        }

        public override void NPCLoot()
        {
            if (plays == 0)
                plays = 1;
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherialTank"), 1);
            }
            if (!Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SteamBar"), Main.rand.Next(15, 30));
                
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfWrought"), Main.rand.Next(20, 40));
            }

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            LaugicalityWorld.downedSteamTrain = true;

        }


        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 499;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }
        /*
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}*/
    }
}
