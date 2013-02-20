using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace ChopComm7.Scenes
{

    class StoryBoard : Scene
    {
        private Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService service;
        private Microsoft.Xna.Framework.Game game;
        private SpriteBatch spriteBatch;
        private SpriteFont spritefont;
        Texture2D[] str;
        int i = 0;
        TouchLocation prevTouch;
        float timer =.0f;
        public StoryBoard(Microsoft.Xna.Framework.Game game)
        {
            this.game = game;
            service = (Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService)game.Services.GetService(typeof(Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService));
            
            //Assign Spritebatch
            spriteBatch = new SpriteBatch(service.GraphicsDevice);
        }

        public override void Initialize()
        {
            //TODO: Implement intitialisation
            str = new Texture2D[3];
        }

        public override void LoadContent()
        {
            str[0] = game.Content.Load<Texture2D>("Sprites/comicpanel1");
            str[1] = game.Content.Load<Texture2D>("Sprites/comicpanel2");
            str[2] = game.Content.Load<Texture2D>("Sprites/comicpanel3");
            spritefont = game.Content.Load<SpriteFont>("Font");
        }

        public override void UnloadContent()
        {
            //TODO:Dispose of Content
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (i != 2)
            {
                if (timer > 6)
                {
                    i++;
                    timer = 0;
                }
            }
            if (i == 2)
            {
                if(timer > 6)
                    SceneManager.GetInstance(game).Current = SceneManager.State.PLAY;
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            service.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Red);
            spriteBatch.Begin();
            spriteBatch.Draw(str[i], new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.End();
        }
    }
}