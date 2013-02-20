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
    public class Trail
    {
        TrailElement[] particles ;
        public Trail(Texture2D image,Vector2 position)
        {
             particles = new TrailElement[16];
             int i = 0;
             while (i < 16)
            {
                particles[i] = new TrailElement(image, position);
                
                i++;
            }
              i = 0;
             while (i < 15)
             {
                

                 i++; particles[i].scale=1;
             }
           
           
           
         
        }

        public void draw(SpriteBatch spriteBatch)
        {
            foreach (TrailElement value in particles)
            {
                value.draw(spriteBatch);

            }
        }
        public int random(int min, int max)
        {
            Random random = new Random();
            
               
            return random.Next(min, max);
        }

        public void init()
        {
           /* foreach (particle value in particles)
            {
                value.scale = 3;
            }
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
            */
        }
        public void update(HRocket h1){

            int i = 1;
            particles[0].update(h1);
            Console.WriteLine("Blah:" + particles[0].prevPosition);
            while (i < 15)
            {
                particles[i].update(particles[i-1]);
                i++;
            }
        }
    }
}