using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChopComm7
{
    /// <summary>
    /// Controls playback of an Animation.
    /// </summary>
    public class PlayerAnimation
    {
        Rectangle sourceBounds;
        int frameCount = 0;
        int delay = 3;
        #region not needed i think
        ///// <summary>
        ///// Gets the animation which is currently playing.
        ///// </summary>
        //public AnimatedSprite Animation
        //{
        //    get { return animation; }
        //}
        //AnimatedSprite animation;

        ///// <summary>
        ///// Gets the index of the current frame in the animation.
        ///// </summary>
        //public int FrameIndex
        //{
        //    get { return frameIndex; }
        //}
        //int frameIndex;

        ///// <summary>
        ///// The amount of time in seconds that the current frame has been shown for.
        ///// </summary>
        //private float time;

        ///// <summary>
        ///// Gets a texture origin at the bottom center of each frame.
        ///// </summary>
        public Vector2 Origin
       {
           get { return new Vector2(0, 0); }
        }

        /// <summary>
        /// Begins or continues playback of an animation.
        /// </summary>
        public void PlayAnimation(AnimatedSprite animation)
        {
            // If this animation is already running, do not restart it.
            //if (Animation == animation)
            //    return;

            //// Start the new animation.
            //this.animation = animation;
            //this.frameIndex = 0;
            //this.time = 0.0f;
        }
        #endregion
        public void AnimateVIP(GameTime gametime)
        {
            if (frameCount % delay == 0)
            {
                if (frameCount / delay >= 3)
                    frameCount = 0;

                sourceBounds = new Rectangle(frameCount / delay * 158, 0, 158, 60);
            }
            frameCount++;
        }
        public void DrawVIP(SpriteBatch spriteBatch, Texture2D texture, VIP c)
        {
            
            spriteBatch.Draw(texture, c.Position, sourceBounds,Color.White,c.rotationAngle, Origin,1.0f, SpriteEffects.None ,0.2f);
        }
        public void DrawHUD(SpriteBatch spriteBatch, Texture2D texture, HUD h1)
        {

            spriteBatch.Draw(texture, h1.Position, sourceBounds, Color.White, 0f, Origin, 1.0f, SpriteEffects.None, 0f);
        }
        public void AnimateEvilChopper(GameTime gametime)
        {
            if (frameCount % delay == 0)
            {
                if (frameCount / delay >= 3)
                    frameCount = 0;

                sourceBounds = new Rectangle(frameCount / delay * 100, 0, 100, 100);
            }
            frameCount++;
        }
        public void DrawEvilChopper(SpriteBatch spriteBatch, Texture2D texture, EvilChopper c, SpriteEffects flip)
        {
            
                spriteBatch.Draw(texture, c.Position, sourceBounds, Color.White, 0f,

                Origin, 1.0f, flip, .2f);
           
        }
        /// <summary>
        /// Advances the time position and draws the current frame of the animation.
        /// </summary>
        //public void DrawChopper(SpriteBatch spriteBatch, SpriteEffects spriteEffects,VIP c)
        //{
        //    #region ol code
        //    //if (Animation == null)
        //    //    throw new NotSupportedException("No animation is currently playing.");

        //    //// Process passing time.
        //    //time += .025f;
        //    //while (time > Animation.FrameTime)
        //    //{
        //    //    time -= Animation.FrameTime;

        //    //    // Advance the frame index; looping or clamping as appropriate.
        //    //    if (Animation.IsLooping)
        //    //    {
        //    //        frameIndex = (frameIndex + 1) % Animation.FrameCount;
        //    //    }
        //    //    else
        //    //    {
        //    //        frameIndex = Math.Min(frameIndex + 1, Animation.FrameCount - 1);
        //    //    }
        //    //}

        //    //// Calculate the source rectangle of the current frame.
        //    //Rectangle source = new Rectangle(FrameIndex * Animation.FrameWidth, 0, Animation.FrameWidth, Animation.Texture.Height);
        //    #endregion
        //    ////// Draw the current frame.
        //    //spriteBatch.Draw(Animation.Texture, c.Position, source, Color.White, c.rotationAngle, Origin, 1.0f, spriteEffects, 0.0f);

        //}
        
        
        
        //public void DrawEvilChopper(GameTime gameTime, SpriteBatch spriteBatch, SpriteEffects spriteEffects, EvilChopper c)
        //{
        //    if (Animation == null)
        //        throw new NotSupportedException("No animation is currently playing.");

        //    // Process passing time.
        //    time += (float)gameTime.ElapsedGameTime.TotalSeconds;
        //    while (time > Animation.FrameTime)
        //    {
        //        time -= Animation.FrameTime;

        //        // Advance the frame index; looping or clamping as appropriate.
        //        if (Animation.IsLooping)
        //        {
        //            frameIndex = (frameIndex + 1) % Animation.FrameCount;
        //        }
        //        else
        //        {
        //            frameIndex = Math.Min(frameIndex + 1, Animation.FrameCount - 1);
        //        }
        //    }

        //    // Calculate the source rectangle of the current frame.
        //    Rectangle source = new Rectangle(FrameIndex * Animation.FrameWidth, 0, Animation.FrameWidth, Animation.Texture.Height);

        //    // Draw the current frame.
        //    spriteBatch.Draw(Animation.Texture, c.Position, source, Color.White, c.rotationAngle, Origin, 1.0f, spriteEffects, 0.0f);
        
        
    }
}
