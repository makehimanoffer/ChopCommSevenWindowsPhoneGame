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
    class WIN : Scene
    {
        private Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService service;
        private Microsoft.Xna.Framework.Game game;
        private float elapsed = 0.0f;
        public Texture2D philWin;
        float timer = 0;
        //Splash background
        private Texture2D background;
        private SpriteBatch spriteBatch;
        private SpriteFont spritefont;
        Rectangle game_box;
        public static bool[] medalstrue;
        bool display_medals = false;
        


        public WIN(Microsoft.Xna.Framework.Game game)
        {

            this.game = game;
            service = (Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService)game.Services.GetService(typeof(Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService));

            //Assign Spritebatch
            spriteBatch = new SpriteBatch(service.GraphicsDevice);
            medalstrue = RankManager.medalstrue1;
        }

        public override void Initialize()
        {
            //TODO: Implement intitialisation
            game_box = new Rectangle(200, 300, 100, 50);
        }

        public override void LoadContent()
        {
            background = game.Content.Load<Texture2D>("Sprites\\winning");
            spritefont = game.Content.Load<SpriteFont>("Font");
            philWin = game.Content.Load<Texture2D>("Sprites/philWin");
        }

        public override void UnloadContent()
        {
            //TODO:Dispose of Content
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 5)
                display_medals = true;
            foreach (TouchLocation location in TouchPanel.GetState())
            {
                if (game_box.Contains((int)location.Position.X, (int)location.Position.Y))
                    SceneManager.GetInstance(game).Current = SceneManager.State.SPLASH;
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            service.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            if (display_medals)
            {
                spriteBatch.DrawString(spritefont, "MEDALS UNLOCKED", new Vector2(300, 60), Color.Black);
                for (int i = 0; i < 4; i++)
                {
                    if (medalstrue[i] == true)
                    {
                        spriteBatch.Draw(RankManager.medals1[i], new Rectangle(100, 000, 100, 100), Color.White);
                    }
                }
                
                for (int i = 4; i < 8; i++)
                {
                    if (medalstrue[i] == true)
                    {
                        spriteBatch.Draw(RankManager.medals1[i], new Rectangle((i * 100) / 4, 100, 100, 100), Color.White);
                    }
                }
                for (int i = 8; i < 12; i++)
                {
                    if (medalstrue[i] == true)
                    {
                        spriteBatch.Draw(RankManager.medals1[i], new Rectangle((i * 100) / 8, 200, 100, 100), Color.White);
                    }
                }
                for (int i = 12; i < 16; i++)
                {
                    if (medalstrue[i] == true)
                    {
                        spriteBatch.Draw(RankManager.medals1[i], new Rectangle((i * 100) / 12, 300, 100, 100), Color.White);
                    }
                }
                for (int i = 16; i < 20; i++)
                {
                    if (medalstrue[i] == true)
                    {
                        spriteBatch.Draw(RankManager.medals1[i], new Rectangle((i * 100) / 16, 350, 100, 100), Color.White);
                    }
                }
                spriteBatch.Draw(philWin, new Vector2(250, 300), Color.White);
            }
            spriteBatch.DrawString(spritefont, "Return to Main", new Vector2(200, 300), Color.White);
            spriteBatch.End();
        }
    }
}