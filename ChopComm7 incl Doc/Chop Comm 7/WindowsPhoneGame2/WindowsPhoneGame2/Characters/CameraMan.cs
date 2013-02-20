using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChopComm7
{
    public class CameraMan
    {
        public Matrix _transform; // Matrix Transform
        public Vector2 _pos; // Camera Position

        public CameraMan()
        {
            _pos = Vector2.Zero;
        }
        public CameraMan(Vector2 bounds)
        {
            _pos = bounds;
        }

        // Auxiliary function to move the camera
        public void Move(Vector2 amount)
        {
            _pos += amount;
        }
        // Get set position
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }
        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            _transform =
                Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                                         Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));
            return _transform;
        }
    }
}
