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



namespace WindowsGame5
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class TrailElement
    {
        public Texture2D image;

        public Vector2 position;
        public Vector2 prevPosition;

        public float scale=1;
        float amount = .1f;
        float transparency = 1;
        public Vector2 velocity = new Vector2(-8, 0);
        public bool drawable = false;
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    image.Width,
                    image.Height);
            }
        }
        public TrailElement(Texture2D image, Vector2 position)
        {
            this.image = image;
            this.position = position;
           
            amount -= .1f;
            
        }
        public void update(TrailElement p1)
        {
            prevPosition = position;
            position = p1.prevPosition;
           
            transparency -= 0.03f;
        }
        public void update(HRocket h1)
        {
            prevPosition = position;
            position = h1.prePosition;
            
        }

        public void draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(image, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 1f);

        }
    }
}