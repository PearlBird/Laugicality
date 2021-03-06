using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Laugicality.NPCs
{
	[AutoloadHead]
	public class Conductor : ModNPC
	{
        /*
		public override string Texture
		{
			get
			{
				return "ExampleMod/NPCs/ExamplePerson";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "ExampleMod/NPCs/ExamplePerson_Alt_1" };
			}
		}*/

		public override bool Autoload(ref string name)
		{
			name = "Conductor";
			return mod.Properties.Autoload;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Conductor");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 5;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 1000;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 30;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
        }

        public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 50;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Steam"));
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
                    if (LaugicalityWorld.downedAnnihilator && LaugicalityWorld.downedSlybertron && LaugicalityWorld.downedSteamTrain)
                    {
                        return true;
                    }
				}
			}
			return false;
		}
        /*
		public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			int score = 0;
			for (int x = left; x <= right; x++)
			{
				for (int y = top; y <= bottom; y++)
				{
					int type = Main.tile[x, y].type;
					if (type == mod.TileType("ExampleBlock") || type == mod.TileType("ExampleChair") || type == mod.TileType("ExampleWorkbench") || type == mod.TileType("ExampleBed") || type == mod.TileType("ExampleDoorOpen") || type == mod.TileType("ExampleDoorClosed"))
					{
						score++;
					}
					if (Main.tile[x, y].wall == mod.WallType("ExampleWall"))
					{
						score++;
					}
				}
			}
			return score >= (right - left) * (bottom - top) / 2;
		}*/

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Lord Charles III";
				case 1:
					return "Sir Christopher";
				case 2:
					return "Earl Crane";
                case 3:
                    return "Lord Crimblesworth";
                default:
					return "Baron Chester von Kingsly";
			}
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			int steampunker = NPC.FindFirstNPC(NPCID.Steampunker);
			if (steampunker >= 0 && Main.rand.Next(3) == 0)
			{
                switch (Main.rand.Next(3))
                {
                    case 0:
				        return "Oh, of course. My wares are much more valueable than that " + Main.npc[steampunker].GivenName + "'s.";
                    case 1:
                        return "I bet " + Main.npc[steampunker].GivenName + " hasn't even invented a sentient machine yet.";
                    default:
                        return "A jetpack? Please. Tell " + Main.npc[steampunker].GivenName + " those went out of style a few centuries ago. Jetboots are the best transportation that modern technology can get you! Besides trains, of course.";
                }
			}
			switch (Main.rand.Next(5))
			{
				case 0:
					return "Spiffing!";
                case 1:
                    return "Trains are all the rage in Vetruvia these days.";
                case 2:
                    return "A train ride a day keeps the Steam Train away!";
                case 3:
                    return "All aboard!";
                default:
					return "Would you like to talk about Trains?";
			}
		}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.Next(4) == 0)
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
            shop.item[nextSlot].SetDefaults(mod.ItemType("Gear"));
            nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ToyTrain"));
			nextSlot++;
            shop.item[nextSlot].SetDefaults(544);
            shop.item[nextSlot].value = 50000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(556);
            shop.item[nextSlot].value = 50000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(557);
            shop.item[nextSlot].value = 50000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("MechanicalMonitor"));
            shop.item[nextSlot].value = 60000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("SteamCrown"));
            shop.item[nextSlot].value = 60000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("SuspiciousTrainWhistle"));
            shop.item[nextSlot].value = 60000;
            nextSlot++;


            /*
			if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>(mod).ZoneExample)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleWings"));
				nextSlot++;
			}
            
			if (Main.moonPhase < 2)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleSword"));
				nextSlot++;
			}
			else if (Main.moonPhase < 4)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleGun"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleBullet"));
				nextSlot++;
			}
			else if (Main.moonPhase < 6)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleStaff"));
				nextSlot++;
			}
			else
			{
			}
			// Here is an example of how your npc can sell items from other mods.
			if (ModLoader.GetLoadedMods().Contains("SummonersAssociation"))
			{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SummonersAssociation").ItemType("BloodTalisman"));
				nextSlot++;
			}*/
        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 50;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 12;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("ConductorProjectile");
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}