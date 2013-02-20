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
    public class bImage
    {
        public Texture2D image;
        public Vector2 position;
        public Vector2 velocity=new Vector2(-4,0);
        public bool draw = false;

        public bImage(Texture2D image, Vector2 position)
        {
            this.image = image;
            this.position = position;
        }

        public bool drawable()
        {
            return draw;
        }
        public void update()
        {
            position += velocity;
        }
    }
}