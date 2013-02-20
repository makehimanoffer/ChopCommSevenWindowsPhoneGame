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

namespace ChopComm7
{
    public class Kamakaze
    {
        /*
        Texture2D texture;
       
        public Vector2 Position;
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
        public Kamakaze(Texture2D texture, Vector2 position, int type)//some constructurs
        {
            this.texture = texture;
            this.Position = position;
            this.alive = true;
            this.type = type;
        }
        public Kamakaze(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.Position = position;
            this.alive = true;


        }
        public void Draw(SpriteBatch spriteBatch, float RotationAngle, Vector2 origin)
        {
           
                spriteBatch.Draw(texture, Position, null, Color.White, RotationAngle, origin, 1.0f, SpriteEffects.None, 1f);
            
           
        }

        public void Move(Enemy enemy)
        {
            Position.X += Velocity.X ;
            Position.Y += Velocity.Y;
        }

        public void Veloc(Enemy enemy, Kamakaze k1)
        {

            if (enemy.Position.X > k1.Position.X)
            {

                k1.Velocity.X += 0.1f;

                if (k1.Velocity.X > 5)
                {
                    k1.Velocity.X = 5;
                }

            }
            if (enemy.Position.X < k1.Position.X)
            {
                k1.Velocity.X -= 0.1f;

                if (k1.Velocity.X < -5)
                {
                    k1.Velocity.X = -5;
                }
            }
            if (enemy.Position.X == k1.Position.X)
            {
                k1.Velocity.X = 0;
            }
            if (enemy.Position.Y > k1.Position.Y)
            {

                k1.Velocity.Y += 0.1f;

                if (k1.Velocity.Y > 5)
                {
                    k1.Velocity.Y = 5;
                }
            }
            if (enemy.Position.Y < k1.Position.Y)
            {

                k1.Velocity.Y -= 0.1f;

                if (k1.Velocity.Y < -5)
                {
                    k1.Velocity.Y = -5;
                }
            }
            if (enemy.Position.Y == k1.Position.Y)
            {
                k1.Velocity.Y = 0;
            }

        }
         */
    }


}