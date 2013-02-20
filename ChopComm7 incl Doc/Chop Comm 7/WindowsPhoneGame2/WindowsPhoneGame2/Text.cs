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
    public class Text
    {
       

        public Vector2 position;
        public Vector2 velocity;
        public SpriteFont textual;
        public string text;
        public bool alive;
        public float scale = 1;
        float transparency = 1;
       
        public Text(ContentManager content, Vector2 position,string text)
        {
            textual = content.Load<SpriteFont>("textual");
            this.position = position;
            velocity = new Vector2(1, -1);
            this.text = text;
        
        }

        public Text(Vector2 position, string text)
        {
            
            this.position = position;
            velocity = new Vector2(1, -1);
            this.text = text;
            this.alive = false;

        }
        public void update(EvilChopper e)
        {
            position += e.Velocity;
            if(e.alive==false){
            position += velocity;
            transparency -= 0.02f;
            scale += 0.05f;
            }
        }
        public void update()
        {
            
            if (alive == true)
            {
                position += velocity;
                transparency -= 0.02f;
                scale += 0.05f;
            }
        }
        public void draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(textual, text, position, Color.Black * transparency, 0f, new Vector2(0, 0), scale, SpriteEffects.None, 0f);

        }

        public void draw(SpriteBatch spriteBatch, SpriteFont textual)
        {
            if (alive == true)
            {
                spriteBatch.DrawString(textual, text, position, Color.Black * transparency, 0f, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
            }
        }
    }
}
