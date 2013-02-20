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
    public class BulletDrop
    {


       
        public Vector2 Position;
        public Vector2 Velocity;
        public Texture2D texture;
        public bool alive;
        
        public float rotationAngle;


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






        public BulletDrop(Vector2 position, ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Sprites/one");

            this.Velocity = new Vector2(0, 1);
            this.Position = position;

            this.alive = true;
        }


        public void Move()
        {

            Position.Y += Velocity.Y;
            Position.X += Velocity.X;
            if (rotationAngle <= 0)
            {
                rotationAngle += .1f;
            }
            if (rotationAngle > 0)
            {
                rotationAngle -= .1f;
            }

        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           // sprite.DrawBulletDrop(gameTime, spriteBatch, RotationAngle);
            spriteBatch.Draw(texture, Position, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotationAngle, new Vector2(0, 0), 1.0f, SpriteEffects.None,0f);
        }








        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update()
        {
            // TODO: Add your update code here
            Move();
            //sprite.PlayAnimation(DropBoxAnimation);

        }
    }
}