using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ChopComm7
{
    public class HRocket
    {
        Texture2D texture;
       
        public Vector2 Position;
        public Vector2 prePosition;
        public Vector2 Velocity;
        public int type;
        public bool alive;
        public float rotationAngle;
        public Vector2 origin;
        public Trail trail;
        public Texture2D trailTexture;
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    texture.Width,
                    texture.Height);
            }
        }
        public HRocket(Texture2D texture, Vector2 position, int type)//some constructurs
        {
            this.texture = texture;
            this.Position = position;
            this.alive = true;
            this.type = type;
        }
        public HRocket(Texture2D texture, Texture2D trailTexture, Vector2 position)
        {
            this.texture = texture;
            this.Position = position;
            this.trailTexture = trailTexture;
            this.alive = true;
            trail = new Trail(trailTexture, new Vector2(Position.X, Position.Y + texture.Height));


        }

        public void LoadContent(ContentManager Content)
        {
           
        }
        public void checkkillBullet(WaveManager wm)
        {
            for (int i = 0; i < wm.WaveEnemies.Count;)
            {
                
                if (wm.WaveEnemies[i].alive == true)
                {
                    this.Move(wm.WaveEnemies[i]);
                    if (Position.X > wm.WaveEnemies[i].Position.X + 600)
                    {
                        this.alive = false;
                    }
                    if (Position.X < wm.WaveEnemies[i].Position.X - 600)
                    {
                        this.alive = false;
                    }
                    if (this.BoundingBox.Intersects(wm.WaveEnemies[i].BoundingBox))
                    {
                        wm.WaveEnemies[i].alive = false;
                        this.alive = false;
                    }
                }
                else{
                    i++;
                }
            }
                
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
           
                spriteBatch.Draw(texture, Position,Color.White);
                spriteBatch.Draw(trailTexture, trail.Position, Color.White);
           
        }

        public void Move(EvilChopper command)
        {
            prePosition = Position;
            Position.X += Velocity.X ;
            Position.Y += Velocity.Y;
            Veloc(command);
            trail.update(this);
        }

        public void Veloc(EvilChopper chopper)
        {

            if (chopper.Position.X > Position.X)
            {

                Velocity.X += 0.1f;

                if (Velocity.X > 5)
                {
                    Velocity.X = 5;
                }

            }
            if (chopper.Position.X <Position.X)
            {
                Velocity.X -= 0.1f;

                if (Velocity.X < -5)
                {
                    Velocity.X = -5;
                }
            }
            if (chopper.Position.X == Position.X)
            {
                Velocity.X = 0;
            }
            if (chopper.Position.Y > Position.Y)
            {

                Velocity.Y += 0.1f;

                if (Velocity.Y > 5)
                {
                    Velocity.Y = 5;
                }
            }
            if (chopper.Position.Y < Position.Y)
            {

                Velocity.Y -= 0.1f;

                if (Velocity.Y < -5)
                {
                    Velocity.Y = -5;
                }
            }
            if (chopper.Position.Y == Position.Y)
            {
               Velocity.Y = 0;
            }

        }
    }


}