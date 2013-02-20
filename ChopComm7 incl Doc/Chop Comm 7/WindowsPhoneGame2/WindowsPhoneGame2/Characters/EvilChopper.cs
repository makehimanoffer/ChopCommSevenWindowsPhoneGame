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
    public class EvilChopper
    {
        public float health = 7;
        public float rotation;
        public Vector2 origin;
        Vector2 screenpos;
        public ParticleSystem splosions;
        public Texture2D texture;
        public Vector2 Position;
        public Vector2 Velocity;
        public bool alive;
        public Text text;
        public float rotationAngle;
        PlayerAnimation p1;
        public Rectangle  BoundingBox
        {
            get
            {
                return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                texture.Width/3,
                texture.Height);
            }
        }

        public EvilChopper(Vector2 Position, ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Sprites/shadow");
            this.Position = Position;
            this.alive = true;
        }

        public  void LoadContent(ContentManager Content, Viewport viewport)
        {
            splosions = new ParticleSystem(Content.Load<Texture2D>("Sprites/particle"), this.Position);
            splosions.init();
            text = new Text(Content, this.Position, "200");
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;
            screenpos = new Vector2(viewport.Width / 2, viewport.Height / 2);
            p1 = new PlayerAnimation();
        }
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);

        }
        public void Update(HUD hud, VIP vip, GameTime gametime)
        {



            
            if (vip.Position.X < Position.X)
            {
                Velocity.X -= 0.05f;
            }

            if (Velocity.X > 3)
            {
                Velocity.X = 3;
            }

            if (Velocity.X < -3)
            {

                Velocity.X = -3;
            }

            if (Velocity.Y > 3)
            {
                Velocity.Y = 3;
            }

            if (Velocity.Y < -3)
            {

                Velocity.Y = -3;
            }

            if (vip.Position.X > Position.X)
            {
                Velocity.X += 0.05f;
            }
            if (vip.Position.Y < Position.Y)
            {
                Velocity.Y -= 0.05f;
            }
            if (vip.Position.Y > Position.Y)
            {
                Velocity.Y += 0.05f;
            }
            Position += Velocity;
            rotation = Velocity.X / 10;
            splosions.update(this);
            p1.AnimateEvilChopper(gametime);
            
        }

     
        public   void Draw(SpriteBatch spriteBatch,HUD h1)
        {
             if(this.BoundingBox.Intersects(h1.BoundingBox)){

            if (Velocity.X > 0)
            {
                p1.DrawEvilChopper(spriteBatch, texture, this, SpriteEffects.None);
            }
            if (Velocity.X < 0)
            {
                p1.DrawEvilChopper(spriteBatch, texture, this, SpriteEffects.FlipHorizontally);
            }

            if (alive == false)
            {
                splosions.draw(spriteBatch,this);
            }
             }
           
           
        }

    }

}