using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;


namespace ChopComm7
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    /// 
    public enum HudUpgradeState { stoneAge, modernAge, nanoAge };
    public class HUD 
    {
        public HudUpgradeState HudUpg;
        public Texture2D pit;
        public Texture2D pit2;
        public Texture2D pit3;
        public Texture2D arrowUP;
        public Texture2D arrowDown;
        public Color colour=Color.White;
       
        public Texture2D missileText;
       
        SpriteFont health;
        SpriteFont gameover;
        public int firedTimer=0;
        public int score;
        public Vector2 Position;
        public int bullet=100;
        public int Missile=10;
        public List<HRocket> rocketPower = new List<HRocket>();
        
        Vector2 touchPosition;
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                pit.Width,
                pit.Height);
            }
        }
        public HUD()
        {
           
            Position = new Vector2(0, 0);
            
            
            
        }

        public void LoadContent(ContentManager Content)
        {
            pit = Content.Load<Texture2D>("Sprites/cockpitredesign");
            pit2 = Content.Load<Texture2D>("Huds/upgrade1");
            pit3 = Content.Load<Texture2D>("Huds/upgrade2");
            HudUpg = HudUpgradeState.stoneAge;
            health = Content.Load<SpriteFont>("Sprites/font");
            gameover = Content.Load<SpriteFont>("Sprites/font");
           
            arrowUP = Content.Load<Texture2D>("Sprites/uparrow");
            arrowDown = Content.Load<Texture2D>("Sprites/downarrow");
            TouchPanel.EnabledGestures = GestureType.VerticalDrag | GestureType.HorizontalDrag | GestureType.Tap;


        }
        public void Update( Crosshair crosshair)
        {
            Position = crosshair.Position -new Vector2(pit.Width/2,pit.Height/2);
           /* if (Position.X < 0+(pit.Width/2))
            {
                Position.X = 0 + (pit.Width / 2);
            }
            if (Position.Y < 0 + (pit.Height/ 2))
            {
                Position.Y = 0 + (pit.Height / 2);
            }
            if (Position.X >3000-(pit.Width ));
            {
                Position.X =3000-(pit.Width );;
            }
            if (Position.Y > 3000 - (pit.Height ))
            {
                Position.Y = 3000 - (pit.Height );
            }*/
           /*if (Position.X < -5)
            {
                Position.X = -5;
            }
           if (Position.X > (2000-pit.Width))
           {
               Position.X = 2000 - pit.Width;
           }
            if (Position.Y < -5)
            {
                Position.Y = -5;
            }
            if (Position.Y >2000-pit.Height)
            {
                Position.Y = 2000- pit.Height;
            }*/
           
            
                this.score = score;
                this.bullet = bullet;
                
          
              
                
                if (firedTimer >1)
                {
                    crosshair.fired = false;
                }
                firedTimer++;
        }


     
        public void Draw(SpriteBatch spriteBatch, VIP vip,WaveManager wm,Crosshair cross)
        {
            if (HudUpg == HudUpgradeState.stoneAge)
            {
                spriteBatch.Draw(pit, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
            }
            else if (HudUpg == HudUpgradeState.modernAge)
            {
                spriteBatch.Draw(pit3, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
            }
            else if (HudUpg == HudUpgradeState.nanoAge)
            {
                spriteBatch.Draw(pit2, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
            }
            spriteBatch.DrawString(health, "Wave:" + wm.waveNumber , new Vector2(this.Position.X+30, this.Position.Y+ 60), Color.Green,0f,Vector2.Zero,2f,SpriteEffects.None,0f);
            if(wm.waveNumber>=3){
            spriteBatch.DrawString(health, "Missile : " + Missile , new Vector2(this.Position.X + 400, this.Position.Y + 450), Color.Green, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            spriteBatch.DrawString(health, "Bullets : " + bullet  , new Vector2(this.Position.X + 210, this.Position.Y + 450), Color.Green, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(health, "HEALTH  :" + vip.health, new Vector2(this.Position.X + 40, this.Position.Y + 20), Color.Green, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(health, "Score  :" + score, new Vector2(this.Position.X + 30, this.Position.Y + 120), Color.Green, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            
           
            if(this.BoundingBox.Intersects(vip.BoundingBox)){
            }

            else if (vip.Position.Y < cross.Position.Y)
            {
                spriteBatch.Draw(arrowUP, new Vector2(this.Position.X + 70, this.Position.Y + 200), null, Color.White, 0f, Vector2.Zero, .33f, SpriteEffects.None, 0f);
            }
            else if(vip.Position.Y>cross.Position.Y)
            {
                spriteBatch.Draw(arrowDown, new Vector2(this.Position.X + 70, this.Position.Y + 200), null, Color.White, 0f, Vector2.Zero, .33f, SpriteEffects.None, 0f);
            }
            
            if (vip.health <= 0.0f)
            {
                spriteBatch.DrawString(gameover, "GAME OVER ", new Vector2(this.Position.X + 220, this.Position.Y + 440), Color.Gold);
            }
        }
    }
}
