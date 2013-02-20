using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChopComm7
{
   
    public abstract class Enemy
    {
        public Vector2  Position;
        public Vector2 Velocity;
        public bool alive;
        public Texture2D texture;

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

        public Enemy() { }
        public Enemy(ContentManager Content) {
            this.Position = Vector2.Zero;
            this.Velocity = Vector2.Zero;
            this.alive = true;
            this.texture = Content.Load<Texture2D>("Sprites/shadow");
        }
        public  Enemy(Vector2 Position, Vector2 Velocity, bool alive)
        {
            this.Position = Position;
            this.Velocity = Velocity;
            this.alive = alive;
        }

        public abstract void LoadContent(ContentManager Content, Viewport viewport);
        public abstract void Update(HUD hud, VIP vip);
        public abstract void Draw(SpriteBatch spriteBatch);
       

    }
}
