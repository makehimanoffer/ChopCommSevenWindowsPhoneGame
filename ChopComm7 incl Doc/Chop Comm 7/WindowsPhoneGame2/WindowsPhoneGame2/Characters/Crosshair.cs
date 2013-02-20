using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
namespace ChopComm7
{
    public enum CrossHairSizeState { Original, OneAndAHalfBigger, TwoTimes };
    public enum CrossHairPowerState { OneHitKill, TwoHitKill, ThreeHitKill, FourHitKill, FiveHitKill, SixHitKill, SevenHitKill };
   public class Crosshair
    {
       public int amountShot = 0;
       public int amountMissileShot = 0;
       public int totalKilled = 0;
        public Vector2 Position;
        public Vector2 Velocity;
        public Texture2D texture;
       // Accelerometer accelerometer;
        public bool fired=false;
      //  Vector3 accelReading = new Vector3();
        SpriteFont font;
        public Missile missile;
        SoundEffectInstance sound;
        public SoundEffectInstance bulletSound;
        SoundEffectInstance reload;
        SoundEffectInstance explode;
        
        public CrossHairSizeState size;
        public CrossHairPowerState power;
        public float strength;
       
        public Rectangle BoundingBox
         
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    texture.Width , texture.Height);
            }
        }
        public Rectangle BoundingBox1point5
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    (int)(texture.Width*1.5), (int)(texture.Height*1.5));
            }
        }

        public Rectangle BoundingBox2
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    (int)(texture.Width * 2), (int)(texture.Height * 2));
            }
        }

      
        public Crosshair(ContentManager Content)
        {
            
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
        }
        public void LoadContent(ContentManager Content)
        {

            sound = Content.Load<SoundEffect>("Sounds/chopper").CreateInstance();
            bulletSound = Content.Load<SoundEffect>("Sounds/gun").CreateInstance();
            reload = Content.Load<SoundEffect>("Sounds/reload").CreateInstance();
            explode = Content.Load<SoundEffect>("Sounds/explosion").CreateInstance();
            texture = Content.Load<Texture2D>("Sprites/cross");
            //accelerometer = new Accelerometer();
            font = Content.Load<SpriteFont>("Font");
            size = CrossHairSizeState.Original;
            power = CrossHairPowerState.SevenHitKill;
            strength = 1;
            TouchPanel.EnabledGestures = GestureType.FreeDrag|GestureType.Tap|GestureType.Pinch|GestureType.Hold;
           // accelerometer.Start();
            missile = new Missile(Content);
            
           
        }

     
       /*
        public void AccelerometerReadingChanged(object sender, AccelerometerReadingEventArgs e)
        {
            accelReading.X = (float)e.X;
            accelReading.Y = (float)e.Y;
            accelReading.Z = (float)e.Z;
        }*/

        public void Move(HUD h1)
        {
            Position += Velocity;
            Velocity.Y = 0;
            Velocity.X = 0;
        }
        public void Update(WaveManager wm,HUD h1,background b1, DropBoxManager dbm, VIP vip)
        {
            missile.update(this);
            Move( h1);
            sound.Play();
            missile.checkEnemys(wm);
            #region PowerAssignment
            if (power == CrossHairPowerState.SevenHitKill)
            {
                strength = 1;
            }
            if (power == CrossHairPowerState.SixHitKill)
            {
                strength = 1.5f;
            }
            if (power == CrossHairPowerState.FiveHitKill)
            {
                strength = 2.0f;
            }
            if (power == CrossHairPowerState.FourHitKill)
            {
                strength = 2.5f;
            }
            if (power == CrossHairPowerState.ThreeHitKill)
            {
                strength = 3.0f;
            }

            if (power == CrossHairPowerState.TwoHitKill)
            {
                strength = 3.5f;
            }

            if (power == CrossHairPowerState.OneHitKill)
            {
                strength = 7.0f;
            }



            #endregion


            // accelerometer.ReadingChanged += new EventHandler<AccelerometerReadingEventArgs>(AccelerometerReadingChanged);
            if (TouchPanel.IsGestureAvailable)
            {
                GestureSample touch = TouchPanel.ReadGesture();
                if (touch.Delta.Y < 0)
                {
                    Velocity.Y =-7f;
                }
                if (touch.Delta.Y < 0&&touch.Delta.X<0)
                {
                    Velocity.Y= -7f;
                    Velocity.X = -7f;
                }
                if (touch.Delta.Y > 0 && touch.Delta.X > 0)
                {
                    Velocity.Y =-7f;
                    Velocity.X = 7f;
                }
                if (touch.Delta.Y > 0 && touch.Delta.X < 0)
                {
                    Velocity.Y = 7f;
                    Velocity.X =-7f;
                }
                if (touch.Delta.Y < 0 && touch.Delta.X > 0)
                {
                    Velocity.Y = -7f;
                    Velocity.X = 7f;
                }
                if (touch.Delta.Y > 0)
                {
                    Velocity.Y = 7f;
                }
                if (touch.Delta.X < 0)
                {
                    Velocity.X = -7f;
                }
                if (touch.Delta.X > 0)
                {
                    Velocity.X = 7f;
                }


                if (touch.GestureType == GestureType.Tap)
                {
                    if (h1.bullet > 0)
                    {
                        amountShot += 1;
                        if (dbm.IAdb.active == false)
                        {
                            h1.bullet = h1.bullet - 1;
                        }
                        fired = true;
                        h1.firedTimer = 0;
                        bulletSound.Play();
                        //fire bullet;
                    }
                }
                if (wm.waveNumber >= 3)
                {
                    if (touch.GestureType == GestureType.Hold)
                    {
                        if (h1.Missile > 0)
                        {
                            amountMissileShot += 1;
                            if (dbm.IAdb.active == false)
                            {
                                h1.Missile = h1.Missile - 1;
                            }
                            fired = true;
                            explode.Play();
                            h1.firedTimer = 0;
                            missile.alive = true;

                        }
                        //fire bullet;
                    }
                }
            }
            /*if (accelReading.Z < -.7f)
            {
                Velocity.Y = -5f;
            }

            if (accelReading.Z > -.35f)
            {
                Velocity.Y = 5f;
            }


            if (accelReading.X < -.3f)
            {
                // Velocity.Y += 1f;
            }

            if (accelReading.X > .3f)
            {
                // Velocity.Y -= .2f;
            }

            if (accelReading.Y < -.2f)
            {
                Velocity.X = -5f;
            }

            if (accelReading.Y > .2f)
            {
                Velocity.X = 5f;

            }*/
            #region Clamping
            if (this.Position.X < 400)
            {
               this.Position.X = (400);

                Velocity.X = 0;
            }
            if (this.Position.Y < b1.b[0].position.Y+(h1.pit.Height/2))
            {
                this.Position.Y = b1.b[0].position.Y+(h1.pit.Height / 2);
                Velocity.Y = 0;

            }
            if (this.Position.X > 2200 - (h1.pit.Width))
            {
                this.Position.X = 2200 - h1.pit.Width;

                Velocity.X = -1;
            }
            if (this.Position.Y > 2000 - (h1.pit.Height / 2))
            {
                this.Position.Y = 2000 - (h1.pit.Height / 2);
                Velocity.Y = -1;

            }
            #endregion
            #region DropboxShootingBasedOnCrosshairSize
            if (size == CrossHairSizeState.Original)
            {

                if (dbm.db.alive == true && fired == true && dbm.db.BoundingBox.Intersects(this.BoundingBox))
                {

                    dbm.db.alive = false;
                    if (dbm.db.boom.transparency < -2f)
                    {
                        dbm.DropBoxesHit += 1;
                        dbm.db.Position = new Vector2(600, 0);
                        dbm.db.Velocity = new Vector2(0, 0);
                        dbm.timing = 0f;
                        reload.Play();
                        dbm.db.giveBullets(h1);
                        dbm.db.giveMissles(h1);
                        dbm.ok = 0;
                        vip.health += 33.3f;
                    }
                }
                if (dbm.IAdb.alive == true && fired == true && dbm.IAdb.BoundingBox.Intersects(this.BoundingBox))
                {
                    dbm.IAdb.active = true;
                    dbm.IAdb.countdown = -1.0f;

                    dbm.IAdb.alive = false;
                    if (dbm.IAdb.boom.transparency < -2f)
                    {
                        dbm.DropBoxesHit += 1;
                        dbm.IAdb.Position = new Vector2(600, 0);
                        dbm.IAdb.Velocity = new Vector2(0, 0);
                        dbm.IAdbTiming = 0f;

                        //dbm.IAdb.infinityTIME = InfinityState.Alive;
                        reload.Play();

                        dbm.ok = 0;

                    }
                }


                if (dbm.InvDb.alive == true && fired == true && dbm.InvDb.BoundingBox.Intersects(this.BoundingBox))
                {
                    dbm.InvDb.active = true;
                    dbm.InvDb.countdown = -1.0f;

                    dbm.InvDb.alive = false;
                    if (dbm.InvDb.boom.transparency < -2f)
                    {
                        dbm.DropBoxesHit += 1;
                        dbm.InvDb.Position = new Vector2(600, 0);
                        dbm.InvDb.Velocity = new Vector2(0, 0);
                        dbm.InvTiming = 0f;

                        //dbm.IAdb.infinityTIME = InfinityState.Alive;
                        reload.Play();

                        dbm.ok = 0;

                    }
                }
            }

            if (size == CrossHairSizeState.OneAndAHalfBigger)
            {

                if (dbm.db.alive == true && fired == true && dbm.db.BoundingBox.Intersects(this.BoundingBox1point5))
                {

                    dbm.db.alive = false;
                    if (dbm.db.boom.transparency < -2f)
                    {
                        dbm.DropBoxesHit += 1;
                        dbm.db.Position = new Vector2(600, 0);
                        dbm.db.Velocity = new Vector2(0, 0);
                        dbm.timing = 0f;
                        reload.Play();
                        dbm.db.giveBullets(h1);
                        dbm.db.giveMissles(h1);
                        dbm.ok = 0;
                        vip.health += 33.3f;
                    }
                }
                if (dbm.IAdb.alive == true && fired == true && dbm.IAdb.BoundingBox.Intersects(this.BoundingBox1point5))
                {
                    dbm.IAdb.active = true;
                    dbm.IAdb.alive = false;
                    if (dbm.IAdb.boom.transparency < -2f)
                    {
                        dbm.DropBoxesHit += 1;
                        dbm.IAdb.Position = new Vector2(600, 0);
                        dbm.IAdb.Velocity = new Vector2(0, 0);
                        dbm.IAdbTiming = 0f;
                        reload.Play();
                        //dbm.IAdb.infinityTIME = InfinityState.Alive;
                        dbm.ok = 0;

                    }
                }


                if (dbm.InvDb.alive == true && fired == true && dbm.InvDb.BoundingBox.Intersects(this.BoundingBox))
                {
                    dbm.InvDb.active = true;
                    dbm.InvDb.countdown = -1.0f;

                    dbm.InvDb.alive = false;
                    if (dbm.InvDb.boom.transparency < -2f)
                    {
                        dbm.DropBoxesHit += 1;
                        dbm.InvDb.Position = new Vector2(600, 0);
                        dbm.InvDb.Velocity = new Vector2(0, 0);
                        dbm.InvTiming = 0f;

                        //dbm.IAdb.infinityTIME = InfinityState.Alive;
                        reload.Play();

                        dbm.ok = 0;

                    }
                }
            }


            if (size == CrossHairSizeState.TwoTimes)
            {

                if (dbm.db.alive == true && fired == true && dbm.db.BoundingBox.Intersects(this.BoundingBox2))
                {

                    dbm.db.alive = false;
                    if (dbm.db.boom.transparency < -2f)
                    {
                        dbm.DropBoxesHit += 1;
                        dbm.db.Position = new Vector2(600, 0);
                        dbm.db.Velocity = new Vector2(0, 0);
                        dbm.timing = 0f;
                        reload.Play();
                        dbm.db.giveBullets(h1);
                        dbm.db.giveMissles(h1);
                        dbm.ok = 0;

                        vip.health += 33.3f;
                    }
                }

                if (dbm.IAdb.alive == true && fired == true && dbm.IAdb.BoundingBox.Intersects(this.BoundingBox2))
                {
                    dbm.IAdb.active = true;
                    dbm.IAdb.alive = false;
                    if (dbm.IAdb.boom.transparency < -2f)
                    {
                        dbm.DropBoxesHit += 1;
                        dbm.IAdb.Position = new Vector2(600, 0);
                        dbm.IAdb.Velocity = new Vector2(0, 0);
                        dbm.IAdbTiming = 0f;
                        reload.Play();
                        //dbm.IAdb.infinityTIME = InfinityState.Alive;
                        dbm.ok = 0;

                    }
                }

                if (dbm.InvDb.alive == true && fired == true && dbm.InvDb.BoundingBox.Intersects(this.BoundingBox))
                {
                    dbm.InvDb.active = true;
                    dbm.InvDb.countdown = -1.0f;

                    dbm.InvDb.alive = false;
                    if (dbm.InvDb.boom.transparency < -2f)
                    {
                        dbm.DropBoxesHit += 1;
                        dbm.InvDb.Position = new Vector2(600, 0);
                        dbm.InvDb.Velocity = new Vector2(0, 0);
                        dbm.InvTiming = 0f;

                        //dbm.IAdb.infinityTIME = InfinityState.Alive;
                        reload.Play();

                        dbm.ok = 0;

                    }
                }
            }

            #endregion



            #region ParatrooperDyingBasedOnCrossSize
            if (size == CrossHairSizeState.Original)
            {
                if (wm.para1.otherBox == false)
                {
                    if (wm.para1.alive == true && fired == true && wm.para1.BoundingBox.Intersects(this.BoundingBox))
                    {
                        //wm.para1.BoundingBox
                        wm.paratroopersKilled += 1;
                        totalKilled += 1;
                        wm.para1.alive = false;
                        wm.para1.Position = new Vector2(600, 0);
                        wm.para1.Velocity = new Vector2(0, 0);
                        wm.para1.timing = 0f;



                    }
                }
                if (wm.para1.otherBox == true)
                {
                    if (wm.para1.alive == true && fired == true && wm.para1.BoundingBoxNoPara.Intersects(this.BoundingBox))
                    {
                        //wm.para1.BoundingBox
                        wm.paratroopersKilled += 1;
                        totalKilled += 1;
                        wm.para1.alive = false;
                        wm.para1.Position = new Vector2(600, 0);
                        wm.para1.Velocity = new Vector2(0, 0);
                        wm.para1.timing = 0f;
                        wm.para1.otherBox = false;



                    }
                }
            }


            if (size == CrossHairSizeState.OneAndAHalfBigger)
            {
                if (wm.para1.otherBox == false)
                {
                    if (wm.para1.alive == true && fired == true && wm.para1.BoundingBox.Intersects(this.BoundingBox1point5))
                    {
                        //wm.para1.BoundingBox
                        wm.paratroopersKilled += 1;
                        totalKilled += 1;
                        wm.para1.alive = false;
                        wm.para1.Position = new Vector2(600, 0);
                        wm.para1.Velocity = new Vector2(0, 0);
                        wm.para1.timing = 0f;



                    }
                }
                if (wm.para1.otherBox == true)
                {
                    if (wm.para1.alive == true && fired == true && wm.para1.BoundingBoxNoPara.Intersects(this.BoundingBox1point5))
                    {
                        //wm.para1.BoundingBox
                        wm.paratroopersKilled += 1;
                        totalKilled += 1;
                        wm.para1.alive = false;
                        wm.para1.Position = new Vector2(600, 0);
                        wm.para1.Velocity = new Vector2(0, 0);
                        wm.para1.timing = 0f;
                        wm.para1.otherBox = false;


                    }
                }
            }


            if (size == CrossHairSizeState.TwoTimes)
            {
                if (wm.para1.otherBox == false)
                {
                    if (wm.para1.alive == true && fired == true && wm.para1.BoundingBox.Intersects(this.BoundingBox2))
                    {
                        //wm.para1.BoundingBox
                        wm.paratroopersKilled += 1;
                        totalKilled += 1;
                        wm.para1.alive = false;
                        wm.para1.Position = new Vector2(600, 0);
                        wm.para1.Velocity = new Vector2(0, 0);
                        wm.para1.timing = 0f;



                    }
                }
                if (wm.para1.otherBox == true)
                {
                    if (wm.para1.alive == true && fired == true && wm.para1.BoundingBoxNoPara.Intersects(this.BoundingBox2))
                    {
                        //wm.para1.BoundingBox
                        wm.paratroopersKilled += 1;
                        totalKilled += 1;
                        wm.para1.alive = false;
                        wm.para1.Position = new Vector2(600, 0);
                        wm.para1.Velocity = new Vector2(0, 0);
                        wm.para1.timing = 0f;
                        wm.para1.otherBox = false;


                    }
                }
            }

            #endregion
            
          
            

//*******************************************************************

//*******************************************************************


            // there may need to be a reset value for the movement when the phone is still
            /* else  {
                 Velocity= new Vector2(0,0);
             }*/
            #region ChopperShotsWithUpGradesTakenIntoAccount

            for (int i=0;i<wm.WaveEnemies.Count;i++){

                if (size == CrossHairSizeState.Original)
                {
                    if (fired == true & wm.WaveEnemies[i].BoundingBox.Intersects(this.BoundingBox))
                    {
                        wm.WaveEnemies[i].health -= strength;
                        wm.WaveEnemies[i].Velocity.X = -wm.WaveEnemies[i].Velocity.X;
                        wm.WaveEnemies[i].Velocity.Y = -wm.WaveEnemies[i].Velocity.Y;

                        if (wm.WaveEnemies[i].health <= 0)
                        {
                            wm.WaveEnemies[i].alive = false;
                           
                           
                        }
                    }
                }

                //**********************************************
                if (size == CrossHairSizeState.OneAndAHalfBigger)
                {
                    if (fired == true & wm.WaveEnemies[i].BoundingBox.Intersects(this.BoundingBox1point5))
                    {
                        wm.WaveEnemies[i].health -= strength;
                        wm.WaveEnemies[i].Velocity.X = -wm.WaveEnemies[i].Velocity.X;
                        wm.WaveEnemies[i].Velocity.Y = -wm.WaveEnemies[i].Velocity.Y;
                        if (wm.WaveEnemies[i].health <= 0)
                        {
                            wm.WaveEnemies[i].alive = false;
                           
                            
                        }
                    }
                }

                //**********************************************
                if (size == CrossHairSizeState.TwoTimes)
                {
                    if (fired == true & wm.WaveEnemies[i].BoundingBox.Intersects(this.BoundingBox2))
                    {
                        wm.WaveEnemies[i].health -= strength;
                        wm.WaveEnemies[i].Velocity.X = -wm.WaveEnemies[i].Velocity.X;
                        wm.WaveEnemies[i].Velocity.Y = -wm.WaveEnemies[i].Velocity.Y;
                        if (wm.WaveEnemies[i].health <= 0)
                        {
                            wm.WaveEnemies[i].alive = false;
                           
                           
                        }
                    }
                }
                    
                }



            


            #endregion


            #region JetsKilling
            if (size == CrossHairSizeState.Original)
            {
                if (fired = true && wm.j1.alive == true && wm.j1.boundingbox.Intersects(this.BoundingBox))
                {
                    totalKilled += 1;
                    wm.jetsKilled += 1;
                    wm.j1.alive = false;
                }
                if (fired = true && wm.j2.alive == true && wm.j2.boundingbox.Intersects(this.BoundingBox))
                {
                    totalKilled += 1;
                    wm.jetsKilled += 1;
                    wm.j2.alive = false;
                }

            }


            if (size == CrossHairSizeState.OneAndAHalfBigger)
            {
                if (fired = true && wm.j1.alive == true && wm.j1.boundingbox.Intersects(this.BoundingBox1point5))
                {
                    totalKilled += 1;
                    wm.jetsKilled += 1;
                    wm.j1.alive = false;
                }
                if (fired = true && wm.j2.alive == true && wm.j2.boundingbox.Intersects(this.BoundingBox1point5))
                {
                    totalKilled += 1;
                    wm.jetsKilled += 1;
                    wm.j2.alive = false;
                }

            }

            if (size == CrossHairSizeState.TwoTimes)
            {
                if (fired = true && wm.j1.alive == true && wm.j1.boundingbox.Intersects(this.BoundingBox2))
                {
                    totalKilled += 1;
                    wm.jetsKilled += 1;
                    wm.j1.alive = false;
                }
                if (fired = true && wm.j2.alive == true && wm.j2.boundingbox.Intersects(this.BoundingBox2))
                {
                    totalKilled += 1;
                    wm.jetsKilled += 1;
                    wm.j2.alive = false;
                }

            }


            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            #region DrawingOfCrosshairBasedOnSizeUpgrades
            if (size == CrossHairSizeState.Original)
            {
                spriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            if (size == CrossHairSizeState.OneAndAHalfBigger)
            {
                spriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            }
            if (size == CrossHairSizeState.TwoTimes)
            {
                spriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            }

            #endregion
            //spriteBatch.DrawString(font, "X of Crosshair:" + this.Position.X, new Vector2(0 + this.Velocity.X, 0 + this.Velocity.Y), Color.White);
            missile.draw(spriteBatch);

            // at this particular moment in time the cross hair, and by extension the HUD does not work when going up and down. That is all.

        }

    }
}
