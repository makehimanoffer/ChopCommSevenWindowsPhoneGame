using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsPhoneGame2
{
    public class HRocket
    {
        Texture2D texture;
       
        public Vector2 Position;
        public Vector2 prePosition;
        public Vector2 Velocity;
        public int type;
        public bool alive;
        public float rotationAngle;
        public Vector2 origin;
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    texture.Width,
                    texture.Height);
            }
        }
        public HRocket(Texture2D texture, Vector2 position, int type)//some constructurs
        {
            this.texture = texture;
            this.Position = position;
            this.alive = true;
            this.type = type;
        }
        public HRocket(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.Position = position;
            this.alive = true;


        }
        public void checkKillBullet(EvilChopper c)
        {
            if (Position.X > c.Position.X + 600)
            {
                this.alive = false;
            }
            if (Position.X < c.Position.X - 600)
            {
                this.alive = false;
            }
            if(this.BoundingBox.Intersects(c.BoundingBox)){
                this.alive=false;
                c.alive=false;

            }
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
           
                spriteBatch.Draw(texture, Position,Color.White);
            
           
        }

        public void Move(EvilChopper command)
        {
            prePosition = Position;
            Position.X += Velocity.X ;
            Position.Y += Velocity.Y;
        }

        public void Veloc(EvilChopper chopper)
        {

            if (chopper.Position.X > Position.X)
            {

                Velocity.X += 0.1f;

                if (Velocity.X > 5)
                {
                    Velocity.X = 5;
                }

            }
            if (chopper.Position.X <Position.X)
            {
                Velocity.X -= 0.1f;

                if (Velocity.X < -5)
                {
                    Velocity.X = -5;
                }
            }
            if (chopper.Position.X == Position.X)
            {
                Velocity.X = 0;
            }
            if (chopper.Position.Y > Position.Y)
            {

                Velocity.Y += 0.1f;

                if (Velocity.Y > 5)
                {
                    Velocity.Y = 5;
                }
            }
            if (chopper.Position.Y < Position.Y)
            {

                Velocity.Y -= 0.1f;

                if (Velocity.Y < -5)
                {
                    Velocity.Y = -5;
                }
            }
            if (chopper.Position.Y == Position.Y)
            {
               Velocity.Y = 0;
            }

        }
    }


}