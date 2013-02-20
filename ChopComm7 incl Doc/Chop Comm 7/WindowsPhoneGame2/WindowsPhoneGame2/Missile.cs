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
    /// 
    public enum MissileUpgradeState { Upgraded, Normal, HalfSize };
    public class Missile
    {
        public Texture2D texture;
        public Vector2 position;
        Vector2 hidden;
        Vector2 onscreen;
        public MissileUpgradeState state;
        
        float transparency = 1f; 
        public bool alive=false;
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width,
                    texture.Height);
            }
        }
        public Rectangle BoundingBoxHalf
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width/2,
                    texture.Height/2);
            }
        }
        public Rectangle BoundingBoxTwice
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width *2,
                    texture.Height * 2);
            }
        }
    public Missile(ContentManager Content) 
    {
        this.texture = Content.Load<Texture2D>("Sprites/explode");
        
        this.hidden =new Vector2(position.X, -1000) ;
        state = MissileUpgradeState.HalfSize;
        
       // this.onscreen = position;
    }
        public void checkEnemys(WaveManager wm){
            if (state == MissileUpgradeState.HalfSize)
            {
                if (wm.para1.otherBox == false)
                {
                    if (this.alive == true && this.BoundingBoxHalf.Intersects(wm.para1.BoundingBox))
                    {
                        wm.para1.alive = false;
                    }
                }
                if (wm.para1.otherBox == false)
                {
                    if (this.alive == true && this.BoundingBoxHalf.Intersects(wm.para1.BoundingBoxNoPara))
                    {
                        wm.para1.alive = false;
                    }
                }
                if (this.alive == true && this.BoundingBoxHalf.Intersects(wm.j1.boundingbox))
                {
                    wm.j1.alive = false;
                }
                if (this.alive == true && this.BoundingBoxHalf.Intersects(wm.j2.boundingbox))
                {
                    wm.j2.alive = false;
                }
                foreach (EvilChopper e in wm.WaveEnemies)
                {
                    if (this.alive == true)
                    {
                        if (e.BoundingBox.Intersects(this.BoundingBoxHalf))
                        {
                            e.alive = false;
                        }
                    }
                }
            }

            if (state == MissileUpgradeState.Upgraded)
            {
                if (wm.para1.otherBox == false)
                {
                    if (this.alive == true && this.BoundingBoxTwice.Intersects(wm.para1.BoundingBox))
                    {
                        wm.para1.alive = false;
                    }
                }
                if (wm.para1.otherBox == false)
                {
                    if (this.alive == true && this.BoundingBoxTwice.Intersects(wm.para1.BoundingBoxNoPara))
                    {
                        wm.para1.alive = false;
                    }
                }
                if (this.alive == true && this.BoundingBoxTwice.Intersects(wm.j1.boundingbox))
                {
                    wm.j1.alive = false;
                }
                if (this.alive == true && this.BoundingBoxTwice.Intersects(wm.j2.boundingbox))
                {
                    wm.j2.alive = false;
                }
                foreach (EvilChopper e in wm.WaveEnemies)
                {
                    if (this.alive == true)
                    {
                        if (e.BoundingBox.Intersects(this.BoundingBoxTwice))
                        {
                            e.alive = false;
                        }
                    }
                }
            }

            if (state == MissileUpgradeState.Normal)
            {
                if (wm.para1.otherBox == false)
                {
                    if (this.alive == true && this.BoundingBox.Intersects(wm.para1.BoundingBox))
                    {
                        wm.para1.alive = false;
                    }
                }
                if (wm.para1.otherBox == false)
                {
                    if (this.alive == true && this.BoundingBox.Intersects(wm.para1.BoundingBoxNoPara))
                    {
                        wm.para1.alive = false;
                    }
                }
                    
                if (this.alive == true && this.BoundingBox.Intersects(wm.j1.boundingbox))
                {
                    wm.j1.alive = false;
                }
                if (this.alive == true && this.BoundingBox.Intersects(wm.j2.boundingbox))
                {
                    wm.j2.alive = false;
                }
                foreach (EvilChopper e in wm.WaveEnemies)
                {
                    if (this.alive == true)
                    {
                        if (e.BoundingBox.Intersects(this.BoundingBox))
                        {
                            e.alive = false;
                        }
                    }
                }
            }
        }


            
    public void update(Crosshair crosshair)
    {
        if (state == MissileUpgradeState.HalfSize)
        {
            position = crosshair.Position - new Vector2(texture.Width / 4, texture.Height / 4);
        }
        if (state == MissileUpgradeState.Normal)
        {
            position = crosshair.Position - new Vector2(texture.Width /2, texture.Height/2);
        }
        if (state == MissileUpgradeState.Upgraded)
        {
            position = crosshair.Position - new Vector2(texture.Width , texture.Height);
        }
        if (this.alive == true)
        {
            transparency-=.3f;
            if(transparency<=-2f){
                    this.alive = false;
                    transparency = 1f;
                }
            }
        
        
        
    }
    public void draw(SpriteBatch spriteBatch)
    {
        if (state == MissileUpgradeState.Normal)
        {
            if (alive == true)
            {
                spriteBatch.Draw(texture, position, null, Color.White * transparency, 0f, Vector2.Zero, 1f, SpriteEffects.None, .1f);
            }
        }


        if (state == MissileUpgradeState.Upgraded)
        {
            if (alive == true)
            {
                spriteBatch.Draw(texture, position, null, Color.White * transparency, 0f, Vector2.Zero, 2f, SpriteEffects.None, .1f);
            }
        }


        if (state == MissileUpgradeState.HalfSize)
        {
            if (alive == true)
            {
                spriteBatch.Draw(texture, position, null, Color.White * transparency, 0f, Vector2.Zero, .5f, SpriteEffects.None, .1f);
            }
        }
    }
    }
}