using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ChopComm7
{

    
    public class DropBoxManager
    {
        public int DropBoxesHit = 0;
        
        public DropBox db;
        public float timing;
        public int ok = 0;

        public WipeoutDropBox wdb;
        public float wdbTiming = 0.0f;
        public int wdbOK=0;

        public InfiniteAmmoDropBox IAdb;
        public float IAdbTiming = 0.0f;
        public int IAdbOK=0;

        public InvincibleDropBox InvDb;
        public float InvTiming=0.0f;
        public int InvOK=0;

        public DropBoxManager(ContentManager Content)
        {
            //Content.RootDirectory = "Content";

            db = new DropBox(new Vector2(600,0), Content);
            wdb = new WipeoutDropBox(new Vector2(650, 0), Content);
            IAdb = new InfiniteAmmoDropBox(new Vector2(700, 0), Content);
            InvDb=new InvincibleDropBox(new Vector2(750,0),Content);
            db.alive = false;
            db.Velocity = new Vector2(0, 0);
            wdb.alive = false;
            wdb.Velocity = new Vector2(0, 0);
            IAdb.alive = false;
            IAdb.active = false;
            IAdb.countdown = -1.0f;
            IAdb.Velocity=new Vector2(0,0);
            InvDb.alive = false;
            InvDb.Velocity = new Vector2(0, 0);
            //InvDb.active = false;
            //InvDb.countdown = -1.0f;



        }


        public void LoadContent(ContentManager Content)
        {
            timing = 0;
            db.LoadContent(Content);
            IAdb.LoadContent(Content);
            wdb.LoadContent(Content);
            InvDb.LoadContent(Content);

        }


        public void Update()
        {
            //IAdb.infinityTIME = InfinityState.NotAlive;
            timing = timing + .025f;
            InvTiming += .025f;
            IAdbTiming += .025f;
            wdbTiming += .025f;

            if (timing > 15.0f & ok == 0)
            {
                db.alive = true;
                db.Velocity = new Vector2(0, 2);
                db.boom.init();
                ok = 1;
            }


            if (InvTiming > 70.0f & InvOK == 0)
            {
                InvDb.alive = true;
                InvDb.Velocity = new Vector2(0, 2);
                
                InvDb.boom.init();
                InvOK = 1;
            }


            if (IAdbTiming > 10.0f & IAdbOK == 0)
            {
                IAdb.alive = true;
               // IAdb.infinityTIME = InfinityState.GoingAlive;

                IAdb.Velocity = new Vector2(0, 2);
                IAdb.boom.init();
                IAdbOK = 1;
            }


            if (wdbTiming > 95.0f & wdbOK == 0)
            {
                wdb.alive = true;
                wdb.Velocity = new Vector2(0, 2);
                wdb.boom.init();
                wdbOK = 1;
            }





            if (timing > 30.0f)
            {
                timing = 0.0f;
                ok = 0;
            }


            if (InvTiming > 60.0f)
            {
                InvTiming = 0.0f;
                InvOK = 0;
            }

            if (IAdbTiming > 40.0f)
            {
                IAdbTiming = 0.0f;
                IAdbOK = 0;
            }

            if (wdbTiming > 140.0f)
            {
                wdbTiming = 0.0f;
                wdbOK = 0;
            }


           
                db.update();
                InvDb.update();
                wdb.update();
                IAdb.update();
            

        }





        public void Draw(SpriteBatch spriteBatch,HUD h1)
        {
            if(this.db.BoundingBox.Intersects(h1.BoundingBox)){
               db.Draw(spriteBatch);
                }
            if (this.IAdb.BoundingBox.Intersects(h1.BoundingBox))
            {
                IAdb.Draw(spriteBatch);
            }
            if (this.InvDb.BoundingBox.Intersects(h1.BoundingBox))
            {
                InvDb.Draw(spriteBatch);
            }
            
        }
    }
}
