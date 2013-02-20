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
    class Credits : Scene
 {
        private Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService service;
        private Microsoft.Xna.Framework.Game game;
        private SpriteBatch spriteBatch;
        private SpriteFont spritefont;
        Rectangle game_box;
        Texture2D cred_txt;

        public Credits(Microsoft.Xna.Framework.Game game)
        {
            this.game = game;
            service = (Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService)game.Services.GetService(typeof(Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService));
            
            //Assign Spritebatch
            spriteBatch = new SpriteBatch(service.GraphicsDevice);
        }

        public override void Initialize()
        {
            //TODO: Implement intitialisation
            game_box = new Rectangle(200, 300, 100, 50);
        }

        public override void LoadContent()
        {
            cred_txt = game.Content.Load<Texture2D>("Sprites\\Credits");
            spritefont = game.Content.Load<SpriteFont>("Font");
        }

        public override void UnloadContent()
        {
            //TODO:Dispose of Content
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
           
            foreach (TouchLocation location in TouchPanel.GetState())
            {
                if (game_box.Contains((int)location.Position.X, (int)location.Position.Y))
                    SceneManager.GetInstance(game).Current = SceneManager.State.SPLASH;
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            service.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Red);
            spriteBatch.Begin();
            spriteBatch.Draw(cred_txt, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.DrawString(spritefont, "Return to Main", new Vector2(200, 300), Color.White);
            spriteBatch.End();
        }
    }
}