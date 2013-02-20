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
    public class particle
    {
        public Texture2D image;
      
        public Vector2 position;
        public float scale;
        public float transparency = 1;
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
        public particle(Texture2D image, Vector2 position)
        {
            this.image = image;
            this.position = position;
            this.scale = 1;
        }
        public void update()
        {
            position += velocity;
            transparency-=.3f;
            
        }
        public void draw(SpriteBatch spriteBatch, EvilChopper e,float transparency)
        {
            transparency = this.transparency;
            spriteBatch.Draw(image, e.Position, null, Color.White * transparency, 0f, Vector2.Zero, scale, SpriteEffects.None, 1f);

        }
        public void draw(SpriteBatch spriteBatch,DropBox e, float transparency)
        {
            transparency = this.transparency;
            spriteBatch.Draw(image, e.Position, null, Color.White * transparency, 0f, Vector2.Zero, scale, SpriteEffects.None, 1f);

        }


        public void draw(SpriteBatch spriteBatch, InfiniteAmmoDropBox e, float transparency)
        {
            transparency = this.transparency;
            spriteBatch.Draw(image, e.Position, null, Color.White * transparency, 0f, Vector2.Zero, scale, SpriteEffects.None, 1f);

        }


        public void draw(SpriteBatch spriteBatch, InvincibleDropBox e, float transparency)
        {
            transparency = this.transparency;
            spriteBatch.Draw(image, e.Position, null, Color.White * transparency, 0f, Vector2.Zero, scale, SpriteEffects.None, 1f);

        }
    }
}
