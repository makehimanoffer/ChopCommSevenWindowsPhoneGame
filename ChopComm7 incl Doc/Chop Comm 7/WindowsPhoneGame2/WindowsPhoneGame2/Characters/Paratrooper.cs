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


namespace ChopComm7
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Paratrooper
    {

        //public AnimatedSprite DropBoxAnimation;
        public Vector2 Position;
        public bool what = false;
        public Vector2 Velocity;
        public Texture2D texture;
        public Texture2D texturepara;
        public Texture2D textureNoPara;
        public float timing = 0f;
        public bool alive;
        public int ok = 0;
        public bool otherBox = false;
        //private PlayerAnimation sprite;
        public float rotationAngle = 0.1f;


        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                texture.Width, texture.Height);
            }
           
        }
        public Rectangle BoundingBoxNoPara
        {
            get
            {
                return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                textureNoPara.Width, textureNoPara.Height);
            }
        }


        public Paratrooper(Vector2 position, ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Sprites/paratrooper");
            texturepara = Content.Load<Texture2D>("Sprites/paratrooper");
            textureNoPara = Content.Load<Texture2D>("Sprites/paratrooperNoPara");

            this.Velocity = new Vector2(0, 1);
            this.Position = position;
            this.alive = false;
            rotationAngle = 0;
        }
        public void update(VIP vip)
        {
           
            timing += .025f;
            if (timing > 15.0f & ok == 0)
            {
                alive = true;
                otherBox = false;
                Velocity = new Vector2(0, 2);
                ok = 1;
            }
           /* else
            {
                otherBox = true;
            }              why david?
            * */

            if (timing > 30.0f)
            {
                timing = 0.0f;
                ok = 0;
            }

           
            if (vip.Position.X < Position.X)
            {
                Velocity.X = -2;
            }

            if (vip.Position.X > Position.X)
            {
                Velocity.X = 2;
            }
         
            if (Position.Y > 2000)
            {
                Position.Y = -500;
            }

            Position += Velocity;
            if (rotationAngle > .1f)
            {
                what = true;
            }
            if (rotationAngle < -.1)
            {
                what = false;
            }
            if (what == false)
            {
                rotationAngle += 0.01f;
            }
            if (what == true)
            {
                rotationAngle -= 0.01f;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (otherBox == false)
            {
                spriteBatch.Draw(texture, Position, null, Color.White, rotationAngle,
        new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, .5f);
            }
            else
            {
                spriteBatch.Draw(textureNoPara, Position, null, Color.White, rotationAngle,
        new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, .1f);
            }
            //spriteBatch.Draw(texture, Position, Color.White);
        }
       
         


    }
}