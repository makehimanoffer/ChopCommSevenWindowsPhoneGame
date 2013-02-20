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
    public class ParticleSystem
    {
        public float transparency;
        Vector2 Position;
        particle[] particles ;
        public ParticleSystem(Texture2D image,Vector2 position)
        {
            this.Position = position;
             particles = new particle[16];
             int i = 0;
             while (i < 16)
            {
                particles[i] = new particle(image, Position);
               
                i++;
            }
           
           
           
         
        }

        public void draw(SpriteBatch spriteBatch, EvilChopper e)
        {
            foreach (particle value in particles)
            {
                value.draw(spriteBatch,e,transparency);

            }
        }

        public void draw(SpriteBatch spriteBatch, DropBox e)
        {
            foreach (particle value in particles)
            {
                if (e.alive == false)
                {
                    value.draw(spriteBatch, e, transparency);
                }

            }
        }

        public void draw(SpriteBatch spriteBatch, InfiniteAmmoDropBox e)
        {
            foreach (particle value in particles)
            {
                if (e.alive == false)
                {
                    value.draw(spriteBatch, e, transparency);
                }

            }
        }

        public void draw(SpriteBatch spriteBatch, InvincibleDropBox e)
        {
            foreach (particle value in particles)
            {
                if (e.alive == false)
                {
                    value.draw(spriteBatch, e, transparency);
                }

            }
        }
        public int random(int min, int max)
        {
            Random random = new Random();
            int i = 0;
               
            return random.Next(min, max);
        }

        public void init()
        {
            foreach (particle value in particles)
            {
                value.scale = 3;
            }
            //transparency = particles[0].transparency;
            particles[0].velocity = new Vector2(0, 1);
            particles[1].velocity = new Vector2(1, 2);
            particles[2].velocity = new Vector2(1, 1);
            particles[3].velocity = new Vector2(2, 1);
            particles[4].velocity = new Vector2(1, 0);
            particles[5].velocity = new Vector2(2, -1);
            particles[6].velocity = new Vector2(1, -1);
            particles[7].velocity = new Vector2(-2, 1);
            particles[8].velocity = new Vector2(0, -1);
            particles[9].velocity = new Vector2(-1, -2);
            particles[10].velocity = new Vector2(-1, -1);
            particles[11].velocity = new Vector2(-2, -1);
            particles[12].velocity = new Vector2(-2, 1);
            particles[13].velocity = new Vector2(-1, 1);
            particles[14].velocity = new Vector2(-1, 2);
            particles[15].velocity = new Vector2(-1, -1);
            
        }
        public void update(EvilChopper e){
            this.Position += e.Velocity;
           
            if(e.alive==false){
                foreach (particle value in particles)
                {
                    value.update();
                    transparency = value.transparency;
                }
            
            }
        }

        public void update(DropBox e)
        {
            this.Position += e.Velocity;

            if (e.alive == false)
            {
                foreach (particle value in particles)
                {
                    value.update();
                    transparency = value.transparency;
                }

            }
        }
        public void update(InvincibleDropBox e)
        {
            this.Position += e.Velocity;

            if (e.alive == false)
            {
                foreach (particle value in particles)
                {
                    value.update();
                    transparency = value.transparency;
                }

            }
        }
        public void update(InfiniteAmmoDropBox e)
        {
            this.Position += e.Velocity;

            if (e.alive == false)
            {
                foreach (particle value in particles)
                {
                    value.update();
                    transparency = value.transparency;
                }

            }
        }
    }
}