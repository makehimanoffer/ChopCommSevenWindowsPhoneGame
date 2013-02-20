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
    public class background 
        {
        public SoundEffectInstance sound;
        public int wave = 1;
       public bImage[] b=new bImage[13];
       
        int i = -1;
        int amount=0;

        public void initImage(ContentManager Content)
        {
            sound = Content.Load<SoundEffect>("Sounds/NewArea").CreateInstance();
                b[0] = new bImage(Content.Load<Texture2D>("Sprites/one"), new Vector2(0, 0));
                b[1] = new bImage(Content.Load<Texture2D>("Sprites/two"), new Vector2(0, 0));
                b[2] = new bImage(Content.Load<Texture2D>("Sprites/three"), new Vector2(0, 0));
                b[3] = new bImage(Content.Load<Texture2D>("Sprites/four"), new Vector2(0, 0));
                b[4] = new bImage(Content.Load<Texture2D>("Sprites/five"), new Vector2(0, 0));
                b[5] = new bImage(Content.Load<Texture2D>("Sprites/six"), new Vector2(0, 0));
                b[6] = new bImage(Content.Load<Texture2D>("Sprites/seven"), new Vector2(0, 0));
                b[7] = new bImage(Content.Load<Texture2D>("Sprites/eight"), new Vector2(0, 0));
                b[8] = new bImage(Content.Load<Texture2D>("Sprites/nine"), new Vector2(0, 0));
                b[9] = new bImage(Content.Load<Texture2D>("Sprites/ten"), new Vector2(0, 0));
                b[10] = new bImage(Content.Load<Texture2D>("Sprites/eleven"), new Vector2(0, 0));
                b[11] = new bImage(Content.Load<Texture2D>("Sprites/twelve"), new Vector2(0, 0));
                b[12] = new bImage(Content.Load<Texture2D>("Sprites/thirteen"), new Vector2(0, 0));
                b[0].position.X=0;
                b[1].position.X=b[0].position.X+b[0].image.Width;
                b[2].position.X = b[1].position.X + b[1].image.Width;
                b[3].position.X = b[2].position.X + b[2].image.Width;
                b[4].position.X = b[3].position.X + b[3].image.Width;
                b[5].position.X = b[4].position.X + b[4].image.Width;
                b[6].position.X = b[5].position.X + b[5].image.Width;
                b[7].position.X = b[6].position.X + b[6].image.Width;
                b[8].position.X = b[7].position.X + b[7].image.Width;
                b[9].position.X = b[8].position.X + b[8].image.Width;
                b[10].position.X = b[9].position.X + b[9].image.Width;
                b[11].position.X = b[10].position.X + b[10].image.Width;
                b[12].position.X = b[11].position.X + b[11].image.Width;

        }
        public void update(HUD h1)
        {
            if(h1.score<333333 && h1.score>=0){
                if (i == -1)
                {
                    //sound.Play();
                    i = 0;
                }
                    b[0].draw = true;
                    b[1].draw = true;
                    b[2].draw = true;
                    b[3].draw = true;
                    loop(b[1],b[2],b[3]);
                    b[0].update();
                    b[1].update();
                    b[2].update();
                    b[3].update();
            }
            if(h1.score<666666 &&h1.score>=333333){
                    b[4].draw = true;
                    b[5].draw = true;
                    b[6].draw = true;
                    b[7].draw = true;
                    if (i == 0)
                    {
                        sound.Play();
                        b[4].position.X = checkWhosLast(b[1], b[2], b[3]).position.X + b[4].image.Width;
                        b[5].position.X = b[4].position.X + b[5].image.Width;
                        b[6].position.X = b[5].position.X + b[6].image.Width;
                        b[7].position.X = b[6].position.X + b[7].image.Width;
                        i++;
                    }
                    loop(b[5],b[6],b[7]);
                    kill(b[1], b[2], b[3]);
                    b[4].update();
                    b[0].update();
                    b[5].update();
                    b[6].update();
                    b[7].update();
            }
               if(h1.score<999999&&h1.score>=666666){
                    b[8].draw = true;
                    b[9].draw = true;
                    b[10].draw = true;
                    b[11].draw = true;
                    if (i == 1)
                    {
                        sound.Play();
                        b[8].position.X = checkWhosLast(b[5], b[6], b[7]).position.X + b[8].image.Width;
                        b[9].position.X = b[8].position.X + b[9].image.Width;
                        b[10].position.X = b[9].position.X + b[10].image.Width;
                        b[11].position.X = b[10].position.X + b[11].image.Width;
                        i++;
                    }
                    kill(b[5],b[6],b[7]);
                    kill(b[1], b[2], b[3]);
                    loop(b[9],b[10],b[11]);
                    b[4].update();
                    b[0].update();
                    b[08].update();
                    b[9].update();
                    b[10].update();
                    b[11].update();
               }
                if(h1.score>=999999){
                     
                    b[12].draw = true;
                    if (i == 2)
                    {
                        b[12].position.X = checkWhosLast(b[9], b[10], b[11]).position.X + b[12].image.Width;
                        i++;
                    }
                    kill(b[9],b[10],b[11]);
                    kill(b[5], b[6], b[7]);
                    kill(b[1], b[2], b[3]);
                    if(b[12].position.X<0){
                        b[12].position.X = 0;
                    }
                    b[4].update();
                    b[0].update();
                    b[08].update();
                    b[12].update();
                    
        }

          

            
        }
        public bImage checkWhosLast(bImage one,bImage two,bImage three)
        {
            if (one.position.X > two.position.X)
            {
                if (three.position.X > one.position.X)
                {
                    return three;
                }
                else
                {
                    return one;
                }
            }
            else
            {
                if (three.position.X > two.position.X)
                {
                    return three;
                }
                else
                {
                    return two;
                }
            }
            
        }
        public void loop(bImage one, bImage two, bImage three)
        {
            
            if (one.position.X < (-one.image.Width) )
            {
                one.position.X = checkWhosLast(one, two, three).position.X + one.image.Width;
            }
            if (two.position.X < (-two.image.Width))
            {
                two.position.X = checkWhosLast(one, two, three).position.X + two.image.Width;
            }
            if (three.position.X < (-three.image.Width))
            {
                three.position.X = checkWhosLast(one, two, three).position.X +three.image.Width;
            }
            
        }
        public void kill(bImage one, bImage two, bImage three)
        {
            if (one.position.X < -one.image.Width && one.draw==true) {
                one.position.X = -one.image.Width;
                one.draw = false;
               // one.image.Dispose();
        }
            if (two.position.X < -one.image.Width&& two.draw == true)
            {
                two.position.X = -one.image.Width;
                two.draw = false;
               // two.image.Dispose();
            }
            if (three.position.X < -one.image.Width&& three.draw == true)
            {
                three.position.X = -one.image.Width;
                three.draw = false;
                //three.image.Dispose();
            }
            one.update();
            two.update();
            three.update();
        }
        public void draw(SpriteBatch spriteBatch)
        {
            foreach (bImage value in b)
            {
                if (value.draw== true)
                {

                    spriteBatch.Draw(value.image, value.position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None,1f);
                }
                
            }
        }
    }
}