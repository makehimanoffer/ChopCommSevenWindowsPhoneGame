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
using Microsoft.Devices.Sensors;
using ChopComm7.Scenes;

namespace ChopComm7
{
    public class VIP
    {
        public Vector2 Position;
        public Vector2 Velocity=new Vector2(0,-3);
        public Texture2D texture;
        public AnimatedSprite a1;
        public int type;
        public bool alive;
        public float health=100.0f;
        public Accelerometer acc = new Accelerometer();
        PlayerAnimation p1;
       
        public float timer;
        public Vector2 center;
        public int num = 0;
        public float rotationAngle;
        public Vector2 origin;
       
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width/3,texture.Height);
            }
        }

        public VIP( Vector2 position)
        {
            this.Position = position;
           
            this.alive = true; 
        }

        public void LoadContent(ContentManager Content)
        {
            texture= Content.Load<Texture2D>("Sprites/frontreel");
            if (Options.hel_op == Options.Heli_c.Relistic)
            {
                texture = Content.Load<Texture2D>("Sprites/frontreel");
            }
            else if (Options.hel_op == Options.Heli_c.Cartoon)
            {
                texture = Content.Load<Texture2D>("Sprites/bikeGuy");
            }
            else if (Options.hel_op == Options.Heli_c.Semi)
            {
                texture = Content.Load<Texture2D>("Sprites/RetroGuy");
            }
            p1 = new PlayerAnimation();
        }  
       
        public void Update(ContentManager Content, GameTime gametime)
        {
            Position.Y += Velocity.Y;
            Position.X += Velocity.X;
            UpAndDown();
            p1.AnimateVIP(gametime);

            
        }

        public void UpAndDown()
        {
            if (Position.Y < 400)
            {
                Velocity.Y = 2.5f;
            }
            if (Position.Y > 1800)
            {
                Velocity.Y =-2.5f;
            }
        }

        public void Draw(SpriteBatch spriteBatch, float RotationAngle, Vector2 origin)
        {
            p1.DrawVIP(spriteBatch, texture, this);
        }
        }
    }






