using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ChopComm7
{
   public  class WaveManager
    {
       public Paratrooper para1;
       public  Jet j1;
       public Jet j2;
       float timer = 0;
       EvilChopper genericDude;
       public List<EvilChopper> WaveEnemies = new List<EvilChopper>();
       public int choppersKilled = 0;
       public int jetsKilled = 0;
       
       public int paratroopersKilled = 0;
       public int waveNumber=1;
       public float distance=0;
       TimeSpan enemySpawnTime;
       TimeSpan previousSpawnTime;
      
       public WaveManager() {
       
       
       }

       public void LoadContent(ContentManager Content, Crosshair crosshair, VIP vip, Viewport viewport){
           previousSpawnTime = TimeSpan.Zero;
           enemySpawnTime= TimeSpan.FromSeconds(10);
           genWave(2, crosshair, vip, Content, viewport, 50);
           j1=new Jet(Content,new Vector2(2000,400));
           j2 = new Jet(Content, new Vector2(2000, 600));
           para1 = new Paratrooper(new Vector2(1000, -400), Content);
            
       
       }


       public void genWave(int amount, Crosshair crosshair,  VIP vip, ContentManager Content, Viewport viewport, int incDistance){
          
               for (int i = 0; i < amount; i++)
               {
                   if (waveNumber == 1)
                   {

                       
                               genericDude = new EvilChopper(new Vector2((float)(vip.Position.X + 400 + ((double)distance * Math.PI)), RandomNumber(200, 700)), Content);
                               genericDude.LoadContent(Content, viewport);
                               WaveEnemies.Add(genericDude);
                       
                   }
                  

                   if (waveNumber >= 2)
                   {

                       for (float time = 0; time <= 8; time += .15f)
                       {
                           if (time >= 7)
                           {
                               genericDude = new EvilChopper(new Vector2((float)(vip.Position.X + 400 + ((double)distance * Math.PI)), RandomNumber(200, 700)), Content);
                               genericDude.LoadContent(Content, viewport);
                               WaveEnemies.Add(genericDude);
                           }
                       }
                   }
                               
                               
                               

                          
                   distance+=incDistance;

                            
                           
                       
                   }

                   
                   //  heli.position.y=Random(0,200);//randomise its y value
                   
               
          
          
       }

       #region Collisions
       public void CollDetect()
       {
           foreach (EvilChopper e in WaveEnemies)
           {
               foreach (EvilChopper e2 in WaveEnemies)
               {
                   if (e.BoundingBox.Intersects(e2.BoundingBox) && e != e2)
                   {
                       if (e.Position.X > e2.Position.X)
                       {
                           e.Velocity.X += .1f;
                           e2.Velocity.X -= .1f;

                       }
                       if (e.Position.X < e2.Position.X)
                       {

                           e.Velocity.X -= .1f;
                           e2.Velocity.X += .1f;
                       }
                       if (e.Position.Y > e2.Position.Y)
                       {

                           e.Velocity.Y += .1f;
                           e2.Velocity.Y -= .1f;
                       }
                       if (e.Position.Y < e2.Position.Y)
                       {
                           e.Velocity.Y -= .1f;
                           e2.Velocity.Y += .1f;
                       }
                   }
               }
           }


       }

       public void VipCollDetect(VIP vip,Paratrooper p1){

           for(int i=0;i<WaveEnemies.Count;i++){

               if (vip.BoundingBox.Intersects(p1.BoundingBox))
               {
                   p1.Position = vip.Position;
                   p1.texture = p1.textureNoPara;
                   vip.health -= 0.0000000001f;
                   p1.otherBox = true;
                   // p1.BoundingBox = new Rectangle(p1.BoundingBoxNoPara.X,p1.BoundingBoxNoPara.Y,p1.BoundingBoxNoPara.Width,p1.BoundingBoxNoPara.Height);
               }
               else
               {
                   p1.texture = p1.texturepara;
               }
               if(WaveEnemies[i].BoundingBox.Intersects(vip.BoundingBox)){
                   vip.health -= .02f;
                       if (vip.Position.X > WaveEnemies[i].Position.X)
                       {
                           //vip.Velocity.X += .1f;
                           WaveEnemies[i].Velocity.X -= .1f;

                       }
                       if (vip.Position.X <WaveEnemies[i].Position.X)
                       {

                           //vip.Velocity.X -= .1f;
                           WaveEnemies[i].Velocity.X += .1f;
                       }
                       if (vip.Position.Y > WaveEnemies[i].Position.Y)
                       {

                           //vip.Velocity.Y += .1f;
                           WaveEnemies[i].Velocity.Y -= .1f;
                       }
                       if (vip.Position.Y < WaveEnemies[i].Position.Y)
                       {
                          // vip.Velocity.Y -= .1f;
                           WaveEnemies[i].Velocity.Y += .1f;
                       }
               }
           }
       }


        private int RandomNumber(int min, int max){
            Random random= new Random();
            return random.Next(min,max);

        }

#endregion 
       public void UnloadContent(){}

       public void Update(HUD hud, VIP vip,Crosshair crosshair, ContentManager Content, Viewport viewport,GameTime gameTime) {
           CollDetect();
           VipCollDetect(vip,para1);
           j1.update(vip);
           para1.update(vip);
           j2.update(vip);
           for (int i = 0; i < WaveEnemies.Count; i++){
               if (WaveEnemies.Count > 0)
               {
                   WaveEnemies[i].Update(hud, vip,gameTime);
                   WaveEnemies[i].text.update(WaveEnemies[i]);
               }
           }


           checkWave(crosshair,vip,Content,viewport);

          
            getAlive(crosshair, vip, Content, viewport,hud);
       
       
       }
       
      


       public void getAlive(Crosshair crosshair, VIP vip, ContentManager Content, Viewport viewport,HUD h1) {
           
           for(int i=0; i< WaveEnemies.Count;i++)
           {
               if (WaveEnemies[i].alive==false)
               {


                   if (WaveEnemies[i].splosions.transparency < -2f)
                   {
                       WaveEnemies.RemoveAt(i);
                       crosshair.totalKilled += 1;
                       choppersKilled += 1;
                       h1.score += 200;
                       
                   }
                           
                         
                   
                
                   
                  /* while (timer <= 2)
                   {
                       timer += 0.025f;
                   }
                   if (timer >= 2)
                   {
                       WaveEnemies.RemoveAt(i);
                       h1.score += 200;
                       timer = 0;
                   }*/
               }

           }

           if (WaveEnemies.Count == 0 )
           {
              
              // genWave(5, crosshair, vip, Content, viewport);
               //full = false;
               waveNumber += 1;
           }
       }
       public void checkWave(Crosshair crosshair, VIP vip, ContentManager Content, Viewport viewport)
       {
          
              
                  
              
               if (waveNumber == 2 && WaveEnemies.Count== 0)
               {
                   distance = 50;
                   genWave(2, crosshair, vip, Content, viewport, 73);
                  // full = true;
               }

               if (waveNumber == 3 && WaveEnemies.Count==0)
               {
                   distance = 100;
                   genWave(5, crosshair, vip, Content, viewport, 73);
                   //full = true;
               }
               if (waveNumber >= 4 && WaveEnemies.Count == 0)
               {
                   distance = 100;
                   genWave(10, crosshair, vip, Content, viewport, 73);
                   //full = true;
               }

           

       }
        //check if all the enemies are alive, if not, add new EM to list, remove previous.

       public void Draw(SpriteBatch spriteBatch, Viewport viewport,HUD h1)
       {
           para1.Draw(spriteBatch);
           j1.draw(spriteBatch,h1);
           j2.draw(spriteBatch,h1);
           for(int i=0; i<WaveEnemies.Count;i++)
           {
               if (WaveEnemies.Count > 0)
               {
                   if (WaveEnemies[i].alive == true)
                   {
                       WaveEnemies[i].Draw(spriteBatch,h1);
                   }
                   if (WaveEnemies[i].alive == false)
                   {
                       WaveEnemies[i].text.draw(spriteBatch);
                       WaveEnemies[i].splosions.draw(spriteBatch,WaveEnemies[i]);
                      
                   }
               }
           }
       }

       

      
    }
}
