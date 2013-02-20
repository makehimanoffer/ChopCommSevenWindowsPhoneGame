using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace ChopComm7
{
    public class RankManager
    {
        int Once = 0;
        SoundEffectInstance upgrade;
        SoundEffectInstance missileUpgrade;
        public int i=0;
        SoundEffectInstance lvlUp;
        bool overlayAlive;
        float transparency = 1f;
        float missileOverlayTransparency = 1f;
        float missileOverTrans = 1f;
       // Box1, Box2, Box3, Chopper1, Chopper2, Chopper3, Bullet1, Bullet2, Bullet3, CollectedAll, Jet1, Jet2, Jet3, Para1, Para2, Para3;
        //public bool box1true, box2true, box3true, chopper1true, chopper2true, bullet1true, bullet2true, bullet3true, collectedalltrue, jet1true, jet2true, jet3true, para1true, para2true, para3true;
        public Texture2D[] medals = new Texture2D[20];
        public static Texture2D[] medals1 = new Texture2D[20];
        public bool[] medalstrue = new bool[20];
        public static bool[] medalstrue1 = new bool[20];
        public enum Rank
        {
            Private, Specialist, Corporal, Sergeant, StaffSergeant, SergeantFirstClass, MasterSergeant, FirstSergeant,
            SergeantMajor, CommandSergeantMajor, SecondLieutenant, FirstLieutenant, Captain, Major,
            LieutenantColonel, Colonel, ColonelFirstClass, BrigadierGeneral, BrigadierGeneralFirstClass,
            LieutenantGeneral, MajorGeneral, MajorGeneralFirstClass, General, ChopperCommander
        };

        
            
       

        public Rank RankOfYourGuy;
        public int bla;
       
        public Texture2D Private, Specialist, Corporal, Sergeant, StaffSergeant, SergeantFirstClass, MasterSergeant, FirstSergeant,
            SergeantMajor, CommandSergeantMajor, SecondLieutenant, FirstLieutenant, Captain, Major,
            LieutenantColonel, Colonel, ColonelFirstClass, BrigadierGeneral, BrigadierGeneralFirstClass,
            LieutenantGeneral, MajorGeneral, MajorGeneralFirstClass, General, ChopperCommander;
        public Texture2D Box1, Box2, Box3, Chopper1, Chopper2, Chopper3, Bullet1, Bullet2, Bullet3, CollectedAll;
        // public Texture2D BulletUpgrade
        public SpriteFont textual;
        public RankManager()
        {



        }

        public void LoadContent(ContentManager Content)
        {
            upgrade = Content.Load<SoundEffect>("Sounds/BulletUpgrade").CreateInstance();
            lvlUp = Content.Load<SoundEffect>("Sounds/LevelUp").CreateInstance();
            missileUpgrade = Content.Load<SoundEffect>("Sounds/MissileUpgrade").CreateInstance();
            RankOfYourGuy = Rank.Private;
            textual = Content.Load<SpriteFont>("Sprites/font");
            for (int i = 0; i < medalstrue.Length; i++)
            {
                medalstrue[i] = false;
            }
            medals[0] = Content.Load<Texture2D>("Medals/BoxBreaker");
            medals[1] = Content.Load<Texture2D>("Medals/BoxCrusher");
            medals[2] = Content.Load<Texture2D>("Medals/BoxDestroyer");
            medals[3] = Content.Load<Texture2D>("Medals/GameFinished");
            medals[4] = Content.Load<Texture2D>("Medals/BulletMaster");
            medals[5] = Content.Load<Texture2D>("Medals/BulletMasterMid");
            medals[6] = Content.Load<Texture2D>("Medals/HereComesTheBulletMaster,PlugHimIn");
            medals[7] = Content.Load<Texture2D>("Medals/ChopperKiller");
            medals[8] = Content.Load<Texture2D>("Medals/ChopperKillerMid");
            medals[9] = Content.Load<Texture2D>("Medals/ChopperKillerPro");
            medals[10] = Content.Load<Texture2D>("Medals/NeedsMoreSplosionsBro");
            medals[11] = Content.Load<Texture2D>("Medals/NeedsMoreSplosionsBroMid");
            medals[12] = Content.Load<Texture2D>("Medals/NeedsMoreSplosionsBroPro");
            medals[13] = Content.Load<Texture2D>("Medals/parakiller");
            medals[14] = Content.Load<Texture2D>("Medals/paramid");
            medals[15] = Content.Load<Texture2D>("Medals/parapro");
            medals[16] = Content.Load<Texture2D>("Medals/JetKillernoob");
            medals[17] = Content.Load<Texture2D>("Medals/JetKillerMid");
            medals[18] = Content.Load<Texture2D>("Medals/jetpro");
            medals[19] = Content.Load<Texture2D>("Medals/GottaCollectEmAll");
            





            Private = Content.Load<Texture2D>("Ranks/private");
            Specialist = Content.Load<Texture2D>("Ranks/Speciallist");
            Corporal = Content.Load<Texture2D>("Ranks/Corperal");
            Sergeant = Content.Load<Texture2D>("Ranks/Sergeant");
            StaffSergeant = Content.Load<Texture2D>("Ranks/StaffSergeant");
            SergeantFirstClass = Content.Load<Texture2D>("Ranks/SergeantFirstClass");
            MasterSergeant = Content.Load<Texture2D>("Ranks/MasterSergeant");
            FirstSergeant = Content.Load<Texture2D>("Ranks/FirstSergeant");
            SergeantMajor = Content.Load<Texture2D>("Ranks/SergeantMajor");
            CommandSergeantMajor = Content.Load<Texture2D>("Ranks/CommanderSergeantMajor");
            SecondLieutenant = Content.Load<Texture2D>("Ranks/2ndLieutenant");
            FirstLieutenant = Content.Load<Texture2D>("Ranks/1stLieutenant");
            Captain = Content.Load<Texture2D>("Ranks/Captain");
            Major = Content.Load<Texture2D>("Ranks/Major");
            LieutenantColonel = Content.Load<Texture2D>("Ranks/LieutenantColonel");
            Colonel = Content.Load<Texture2D>("Ranks/Colonel");
            ColonelFirstClass = Content.Load<Texture2D>("Ranks/ColonelFirstClass");
            BrigadierGeneral = Content.Load<Texture2D>("Ranks/BrigadierGeneral");
            BrigadierGeneralFirstClass = Content.Load<Texture2D>("Ranks/BrigadierGeneralFirstClass");
            LieutenantGeneral = Content.Load<Texture2D>("Ranks/LieutenantGeneral");
            MajorGeneral = Content.Load<Texture2D>("Ranks/MajorGeneral");
            MajorGeneralFirstClass = Content.Load<Texture2D>("Ranks/MajorGeneralFirstClass");
            General = Content.Load<Texture2D>("Ranks/General");
            ChopperCommander = Content.Load<Texture2D>("Ranks/ChopperCommander");

           
            overlayAlive = false;

        }

        public void Update(Crosshair crosshair, HUD h1, WaveManager wm, DropBoxManager dbm)
        {

            medalstrue1 = medalstrue;
            medals1 = medals;


            #region MissileUpgrades
            if (crosshair.amountMissileShot == 5)
            {if(i==0){
                missileUpgrade.Play();
                
                missileOverTrans -= .05f;
                crosshair.missile.state = MissileUpgradeState.Normal;
                
                   
                    
                    i = 1;
                
               
            }
            }
            if (crosshair.amountMissileShot == 20)
            {
                if (i == 1)
                {
                    missileUpgrade.Play();
                    
                    missileOverTrans -= .05f;
                    crosshair.missile.state = MissileUpgradeState.Upgraded;
                    if (missileOverTrans < -2f)
                    {
                       
                        transparency = 1f;
                        i = 2;
                    }
                }
            }


            #endregion
            #region CrossHairPowerUpgraded
            if (crosshair.amountShot == 10)
            {
                if (i == 2)
                {
                    upgrade.Play();
                    overlayAlive = true;
                    transparency -= .05f;
                    crosshair.power = CrossHairPowerState.SixHitKill;
                    if (transparency < -2f)
                    {
                        overlayAlive = false;
                        transparency = 1f;
                        i = 3;
                    }
                }
            }
            if (crosshair.amountShot == 20)
            {
                if (i == 3)
                {
                    upgrade.Play();
                    overlayAlive = true;
                    transparency -= .05f;

                    if (transparency < -2f)
                    {
                        overlayAlive = false;
                        transparency = 1f;
                        i = 4;
                    }
                    crosshair.power = CrossHairPowerState.FiveHitKill;
                }
            }
            if (crosshair.amountShot == 30)
            {
                if (i == 4)
                {
                    upgrade.Play();
                    overlayAlive = true;
                    transparency -= .05f;
                    crosshair.power = CrossHairPowerState.FourHitKill;
                    if (transparency < -2f)
                    {
                        overlayAlive = false;
                        transparency = 1f;
                        i = 5;
                    }
                }
            }
            if (crosshair.amountShot == 40)
            {
                if (i == 5)
                {
                    upgrade.Play();
                    overlayAlive = true;
                    transparency -= .05f;
                    crosshair.power = CrossHairPowerState.ThreeHitKill;
                    if (transparency < -2f)
                    {
                        overlayAlive = false;
                        transparency = 1f;
                        i = 6;
                    }
                }
            }
            if (crosshair.amountShot == 50)
            {
                if (i == 6)
                {
                    upgrade.Play();
                    overlayAlive = true;
                    transparency -= .05f;
                    crosshair.power = CrossHairPowerState.TwoHitKill;
                    if (transparency < -2f)
                    {
                        overlayAlive = false;
                        transparency = 1f;
                        i = 7;
                    }
                }
            }
            if (crosshair.amountShot == 70)
            {
                if (i == 7)
                {
                    upgrade.Play();
                    overlayAlive = true;
                    transparency -= .02f;
                    crosshair.power = CrossHairPowerState.OneHitKill;
                    if (transparency < -2f)
                    {
                        overlayAlive = false;
                        transparency = 1f;
                        i = 8;
                    }
                }
            }
            #endregion
            #region CrosshairSizeUpgraded
            if (wm.waveNumber == 2 && wm.WaveEnemies.Count == 0)
            {
                upgrade.Play();
                overlayAlive = true;
                transparency -= .05f;
                if (transparency < -2f)
                {
                    overlayAlive = false;
                    transparency = 1f;
                }
                crosshair.size = CrossHairSizeState.OneAndAHalfBigger;
            }

            if (wm.waveNumber == 12 && wm.WaveEnemies.Count == 0)
            {
                upgrade.Play();
                overlayAlive = true;
                transparency -= .05f;
                if (transparency < -2f)
                {
                    overlayAlive = false;
                    transparency = 1f;
                }
                crosshair.size = CrossHairSizeState.TwoTimes;
            }
            #endregion
            #region RankAssignment
            
            if (crosshair.totalKilled >= 2&&crosshair.totalKilled<7)
            {
                if (Once == 0)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.Specialist;
                    h1.score += 100000;
                    Once=1;
                }
            }
            if (crosshair.totalKilled >= 7 && crosshair.totalKilled < 17)
            {
                if (Once == 1)
                { 
               
                    lvlUp.Play();
                    RankOfYourGuy = Rank.Corporal;
               
                        h1.score += 175000;
                    Once=2;
                }
            }
            if (crosshair.totalKilled >= 17 && crosshair.totalKilled < 30)
            {
                if (Once == 2){
                    lvlUp.Play();
                    RankOfYourGuy = Rank.Sergeant; 
               
                h1.score += 75000;
                    Once = 3;
                }
            }
            if (crosshair.totalKilled >= 30 && crosshair.totalKilled < 34)
            {
                if (Once == 3)
                { 
                    lvlUp.Play();
                    RankOfYourGuy = Rank.StaffSergeant;
                h1.score += 40000;
                    Once = 4;
                }
            }
            if (crosshair.totalKilled >= 34 && crosshair.totalKilled < 45)
            {
                if (Once == 4)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.SergeantFirstClass;
                
                h1.score += 40000;
                    Once = 5;
                }
            }
            if (crosshair.totalKilled >= 45 && crosshair.totalKilled < 55)
            {
                 if (Once == 5)
                {
                    lvlUp.Play();
                RankOfYourGuy = Rank.MasterSergeant; h1.score += 40000;
                Once = 6;
                 }
            }
            if (crosshair.totalKilled >= 55 && crosshair.totalKilled < 67)
            {
                if (Once == 6)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.FirstSergeant; h1.score += 40000;
                    Once = 7;
                }
            }
            if (crosshair.totalKilled >= 67 && crosshair.totalKilled < 80)
            {
                if (Once == 7)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.SergeantMajor; h1.score += 40000;
                    Once=8;
                }
            }
            if (crosshair.totalKilled >= 80 && crosshair.totalKilled < 100)
            {
                if (Once == 8)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.CommandSergeantMajor; h1.score += 25000;
                    Once=9;
                }
            }
            if (crosshair.totalKilled >= 100 && crosshair.totalKilled < 122)
            {
                 if (Once == 9)
                {
                    lvlUp.Play();
                RankOfYourGuy = Rank.SecondLieutenant; h1.score += 25000;
                 Once=10;
                 }
            }

            if (crosshair.totalKilled >= 122 && crosshair.totalKilled < 143)
            {
                if (Once == 10)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.FirstLieutenant; h1.score += 25000;
                    Once=11;
                }
            }
            if (crosshair.totalKilled >= 143 && crosshair.totalKilled < 162)
            {
                if (Once == 11)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.Captain; h1.score += 25000;
                    Once=12;
                }
            }
            if (crosshair.totalKilled >= 162 && crosshair.totalKilled < 186)
            {
                if (Once == 12)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.Major; h1.score += 25000;
                    Once=13;
                }
            }
            if (crosshair.totalKilled >= 186 && crosshair.totalKilled < 206)
            {
                if (Once == 13)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.LieutenantColonel; h1.score += 25000;
                    Once=14;
                }
            }
            if (crosshair.totalKilled >= 206 && crosshair.totalKilled < 230)
            {
                if (Once == 14)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.Colonel; h1.score += 25000;
                    Once=15;
                }
            }
            if (crosshair.totalKilled >= 230 && crosshair.totalKilled < 260)
            {
                if (Once == 15)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.ColonelFirstClass; h1.score += 25000;
                    Once=16;
                }
            }
            if (crosshair.totalKilled >= 260 && crosshair.totalKilled < 291)
            {
                if (Once == 16)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.BrigadierGeneral; h1.score += 25000;
                    Once=17;
                }
            }
            if (crosshair.totalKilled >= 291 &&crosshair.totalKilled < 320)
            {
                if (Once == 17)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.BrigadierGeneralFirstClass; h1.score += 25000;
                    Once=18;
                }
            }
            if (crosshair.totalKilled >= 320&&crosshair.totalKilled<329)
            {
                if (Once == 18)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.LieutenantGeneral; h1.score += 25000;
                    Once=19;
                }
            }
            if (crosshair.totalKilled >= 329 && crosshair.totalKilled < 354)
            {
                if (Once == 19)
                {
                    lvlUp.Play();

                    RankOfYourGuy = Rank.General; h1.score += 25000;
                    Once=20;
                }
            }
            if (crosshair.totalKilled >= 354 && crosshair.totalKilled < 378)
            {
                if (Once == 20)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.MajorGeneral; h1.score += 25000;
                    Once=21;
                }
            }
            if (crosshair.totalKilled >= 378 && crosshair.totalKilled < 400)
            {
                if (Once == 21)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.MajorGeneralFirstClass; h1.score += 25000;
                    Once=22;
                }
            }
            if (crosshair.totalKilled >= 400)
            {
                if (Once == 22)
                {
                    lvlUp.Play();
                    RankOfYourGuy = Rank.ChopperCommander; h1.score = 990000;
                    Once=23;
                }
            }


            #endregion
            #region Medals
            if (dbm.DropBoxesHit > 1)
            {
                medalstrue[0] = true;
            }
            if (dbm.DropBoxesHit > 3)
            {
                medalstrue[1] = true;
            }
            if (dbm.DropBoxesHit > 5)
            {
                medalstrue[2] = true;
            }
            if (crosshair.amountShot > 50)
            {
                medalstrue[4] = true;
            }
            if (crosshair.amountShot > 75)
            {
                medalstrue[5] = true;
            }
            if (crosshair.amountShot > 100)
            {
                medalstrue[6] = true;
            }

            if (wm.choppersKilled > 20)
            {
                medalstrue[7] = true;
            }
            if (wm.choppersKilled > 60)
            {
                medalstrue[8] = true;
            }
            if (wm.choppersKilled > 100)
            {
                medalstrue[9] = true;
            }
            if (crosshair.amountMissileShot > 20)
            {
                medalstrue[10] = true;
            }
            if (crosshair.amountMissileShot > 40)
            {
                medalstrue[11] = true;
            }
            if (crosshair.amountMissileShot > 60)
            {
                medalstrue[12] = true;
            }
            if (wm.paratroopersKilled > 1)
            {
                medalstrue[13] = true;
            }
            if (wm.paratroopersKilled > 2)
            {
                medalstrue[14] = true;
            }
            if (wm.paratroopersKilled > 3)
            {
                medalstrue[15] = true;
            }
            if (wm.jetsKilled > 1)
            {
                medalstrue[16] = true;
            }
            if (wm.jetsKilled > 3)
            {
                medalstrue[17] = true;
            }
            if (wm.jetsKilled > 5)
            {
                medalstrue[18] = true;
            }
           


            #endregion

            #region HudUpgrades
            if(h1.score >= 150000 && h1.score <500000)
            {
                h1.HudUpg = HudUpgradeState.modernAge;
            }
            else if (h1.score >= 500000 && h1.score <= 999999)
            {
                h1.HudUpg = HudUpgradeState.nanoAge;
            }
            else
            {
                h1.HudUpg = HudUpgradeState.stoneAge;
            }

            #endregion





           

        }


        public void Draw(SpriteBatch spriteBatch, HUD h1)
        {
            #region RankDrawing
            if (RankOfYourGuy == Rank.Private)
            {
                spriteBatch.Draw(Private, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.Specialist)
            {
                spriteBatch.Draw(Specialist, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.Corporal)
            {
                spriteBatch.Draw(Corporal, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            //1,2,3
            if (RankOfYourGuy == Rank.Sergeant)
            {
                spriteBatch.Draw(Sergeant, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.StaffSergeant)
            {
                spriteBatch.Draw(StaffSergeant, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.SergeantFirstClass)
            {
                spriteBatch.Draw(SergeantFirstClass, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            //4,5,6
            if (RankOfYourGuy == Rank.MasterSergeant)
            {
                spriteBatch.Draw(MasterSergeant, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.FirstSergeant)
            {
                spriteBatch.Draw(FirstSergeant, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.SergeantMajor)
            {
                spriteBatch.Draw(SergeantMajor, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            //6,7,8



            if (RankOfYourGuy == Rank.CommandSergeantMajor)
            {
                spriteBatch.Draw(CommandSergeantMajor, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.SecondLieutenant)
            {
                spriteBatch.Draw(SecondLieutenant, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.FirstLieutenant)
            {
                spriteBatch.Draw(FirstLieutenant, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            //9,10,11



            if (RankOfYourGuy == Rank.Captain)
            {
                spriteBatch.Draw(Captain, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.Major)
            {
                spriteBatch.Draw(Major, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.LieutenantColonel)
            {
                spriteBatch.Draw(LieutenantColonel, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            //12,13,14
            if (RankOfYourGuy == Rank.Colonel)
            {
                spriteBatch.Draw(Colonel, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.ColonelFirstClass)
            {
                spriteBatch.Draw(ColonelFirstClass, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.BrigadierGeneral)
            {
                spriteBatch.Draw(BrigadierGeneral, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            //15,16,17


            if (RankOfYourGuy == Rank.BrigadierGeneralFirstClass)
            {
                spriteBatch.Draw(BrigadierGeneralFirstClass, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            if (RankOfYourGuy == Rank.LieutenantGeneral)
            {
                spriteBatch.Draw(LieutenantGeneral, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            //18,19,20

            if (RankOfYourGuy == Rank.General)
            {
                spriteBatch.Draw(General, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            if (RankOfYourGuy == Rank.MajorGeneral)
            {
                spriteBatch.Draw(MajorGeneral, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            if (RankOfYourGuy == Rank.MajorGeneralFirstClass)
            {
                spriteBatch.Draw(MajorGeneralFirstClass, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }

            //21,22,23
            if (RankOfYourGuy == Rank.ChopperCommander)
            {
                spriteBatch.Draw(ChopperCommander, new Vector2(h1.Position.X + 30, h1.Position.Y + 300), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            //24


            #endregion
            
        }




    }
}
