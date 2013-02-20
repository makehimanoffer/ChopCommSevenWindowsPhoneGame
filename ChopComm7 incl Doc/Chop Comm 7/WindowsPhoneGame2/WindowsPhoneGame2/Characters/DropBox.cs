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
    public class DropBox 
    {
       
        //public AnimatedSprite DropBoxAnimation;
        public Vector2 Position;
        public bool what = false;
        public Vector2 Velocity;
        public Texture2D texture;
        public ParticleSystem boom;
        public bool alive;
        //private PlayerAnimation sprite;
        public float rotationAngle=0.1f;


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
        public DropBox() { }
        
        public DropBox(Vector2 position, ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Sprites/DropBox");
           // boom = new ParticleSystem(Content.Load<Texture2D>("Sprites/dropboxplosion"), this.Position);
            this.Velocity = new Vector2(0, 1);
            this.Position = position;
            this.alive = true;
            rotationAngle = 0;
        }
        public void LoadContent(ContentManager Content)
        {
            boom = new ParticleSystem(Content.Load<Texture2D>("Sprites/dropboxplosion"), this.Position);
            boom.init();
           // boom.transparency = 1f;


        }
        public void update()
        {
            if(this.alive==true){
            if (Position.Y > 2000)
            {
                Position.Y = -100;
            }
            Position+= Velocity;
           
            if (rotationAngle > .1f)
            {
                what = true;
            }
            if (rotationAngle < -.1)
            {
                what = false;
            }
            if (what==false)
            {
                rotationAngle += 0.01f;
            }
            if (what==true)
            {
                rotationAngle -= 0.01f;
            }
        }
         boom.update(this);
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.alive == true)
            {
                spriteBatch.Draw(texture, Position, null, Color.White, rotationAngle,
        new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, .2f);
            }
            if (this.alive == false)
            {
                boom.draw(spriteBatch, this);
            }
            //spriteBatch.Draw(texture, Position, Color.White);
        }
        public void giveMissles(HUD h1)
        {

            h1.Missile += 5;
        }
        public void giveBullets(HUD h1)
        {
            if (h1.bullet <= 80)
            {
                h1.bullet += 20;
            }
        }

        
}
}