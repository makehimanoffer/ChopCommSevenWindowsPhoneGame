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
    public class Jet 
    {
        public Texture2D texture;
        public Vector2 velocity;
        public Vector2 position;
        public bool alive;
        SoundEffectInstance jet;
        public Rectangle boundingbox{
            get{
             
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width,
                    texture.Height);
               }
            }
        public Rectangle Near
        {
            get
            {

                return new Rectangle(
                    0,
                    0,
                    700,
                    600);
            }
        }
    public Jet(ContentManager content,Vector2 position){
        this.texture = content.Load<Texture2D>("Sprites/jet");
        this.position = position;
        this.velocity = new Vector2(-12,0);
        jet = content.Load<SoundEffect>("Sounds/Jet fly by").CreateInstance();
    }
    public void update(VIP vip)
    {
        position += velocity;
        if(vip.BoundingBox.Intersects(boundingbox)){
             position.X = 2000;
             position.Y = Random(50, 1800);
             vip.health -= 10;
        }
        if(boundingbox.Intersects(Near)){
            jet.Volume = .7f;
            jet.Play();
        }
        if (position.X < -200)
        {
            position.X = 2000;
            position.Y = Random(50, 1800);
        }
        if (this.alive == false)
        {
            for (float i = 0; i < 20; i += .25f)
            {
                if (i == 19)
                {
                    this.alive = true;
                    position.X = 2000;
                    position.Y = Random(50, 1800);
                }
            }
        }
    }
    public int Random(int min, int max)
    {
        Random r = new Random();
        int nextValue = r.Next(min, max); 
        return nextValue;
    }
    public void draw(SpriteBatch spriteBatch,HUD h1)
    {
        if(h1.BoundingBox.Intersects(this.boundingbox)){

        if (this.alive == true)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
        }
        }
    }
    }
}  
    
