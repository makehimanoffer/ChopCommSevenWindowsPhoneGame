using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ChopComm7.Graphics
{
   public class Graphic
    {
        public enum Mode { Sprite, AnimatedSpriteLoop, AnimatedSprite }
        private SpriteBatch batch;
        private SpriteEffects effect;
        private Texture2D texture;
        private Mode mode;
        private Vector2 position, origin;
        private float rotation, scale, depth, duration, totalElapsed;
        private int frame, frameCount, frameLoop, framePlays;
        private bool paused;

        public Graphic(Texture2D texture)
        {
            this.texture = texture;
            this.mode = Mode.Sprite;
            this.rotation = 0.0f;
            this.effect = SpriteEffects.None;
        }

        public Graphic(Mode mode, Texture2D texture, int frameCount, int framesPerSec, float scale, float depth)
        {
            this.mode = mode;
            this.texture = texture;
            this.frameCount = frameCount;
            this.duration = (float)1 / framesPerSec;
            this.scale = scale;
            this.depth = depth;
            this.frame = 0;
            this.totalElapsed = 0;
            this.paused = false;
            this.origin = Vector2.Zero;
            this.effect = SpriteEffects.None;
            this.rotation = 0.0f;
            this.frameLoop = 0;
        }

        public Graphic(Mode mode, Texture2D texture, int frameCount, int framesPerSec, float scale, float depth, int frameLoop)
        {
            this.mode = mode;
            this.texture = texture;
            this.frameCount = frameCount;
            this.duration = (float)1 / framesPerSec;
            this.scale = scale;
            this.depth = depth;
            this.frame = 0;
            this.totalElapsed = 0;
            this.paused = false;
            this.origin = Vector2.Zero;
            this.rotation = 0.0f;
            this.effect = SpriteEffects.None;
            this.frameLoop = frameLoop;
        }

        public Texture2D Texture2D
        {
            get { return texture; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return batch; }
            set { batch = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Boolean Pause
        {
            get { return paused; }
            set { paused = value; }
        }


        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public SpriteEffects Effect
        {
            get { return effect; }
            set { effect = value; }
        }

        public int FrameWidth
        {
            get { return texture.Width / frameCount; }
        }

        public int FrameHeight
        {
            get { return texture.Height; }
        }

        public void ResetFramePlays()
        {
            paused = false;
            totalElapsed = 0.0f;
            framePlays = 0;
        }

        public Vector2 Origin()
        {
            if (mode == Mode.AnimatedSprite || mode == Mode.AnimatedSpriteLoop)
            {
                origin.X = FrameWidth / 2;
                origin.Y = FrameHeight / 2;
            }
            else
            {
                origin.X = texture.Width;
                origin.Y = texture.Height;
            }
            return origin;
        }

        public void Update(GameTime gameTime)
        {
            if (mode == Mode.AnimatedSprite || mode == Mode.AnimatedSpriteLoop)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (paused)
                    return;
                totalElapsed += elapsed;
                if (totalElapsed > duration)
                {
                    frame++;

                    // Update Playcount
                    if (frame == frameCount)
                        framePlays++;

                    // Keep the Frame between 0 and the total frames, minus one.
                    frame = frame % frameCount;

                    if (frameLoop > 0)
                    {
                        if (framePlays >= frameLoop)
                        {
                            frame = 0;
                        }
                    }
                    totalElapsed -= duration;
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (mode == Mode.AnimatedSprite || mode == Mode.AnimatedSpriteLoop)
            {
                int frameWidth = texture.Width / frameCount;
                Rectangle sourcerect = new Rectangle(frameWidth * frame, 0, frameWidth, texture.Height);

                batch.Draw(texture, this.Position, sourcerect, Color.White, rotation, Origin(), scale, effect, depth);
            }
            else
            {
                batch.Draw(texture, position, Color.White);
            }
        }
    }
}
