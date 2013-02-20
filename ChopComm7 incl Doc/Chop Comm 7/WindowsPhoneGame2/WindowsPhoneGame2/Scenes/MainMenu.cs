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
    class MainMenu : Scene
    {
        private Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService service;
        private Microsoft.Xna.Framework.Game game;

        //Splash background
        private SpriteBatch spriteBatch;
        private SpriteFont spritefont;
        Rectangle game_box;
        Rectangle op_box;
        Rectangle help_box;
        Rectangle cred_box;
        Texture2D main_txt;

        public MainMenu(Microsoft.Xna.Framework.Game game)
        {
            this.game = game;
            service = (Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService)game.Services.GetService(typeof(Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService));
            
            //Assign Spritebatch
            spriteBatch = new SpriteBatch(service.GraphicsDevice);
        }

        public override void Initialize()
        {
            //TODO: Implement intitialisation
            game_box = new Rectangle(290, 220, 250, 30);
            op_box = new Rectangle(290, 410, 100, 50);
            help_box = new Rectangle(290, 290, 250, 30);
            cred_box = new Rectangle(290, 350, 250, 30);
        }

        public override void LoadContent()
        {
            main_txt = game.Content.Load<Texture2D>("Sprites\\test");
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
                    SceneManager.GetInstance(game).Current = SceneManager.State.STORYBOARD;
                else if (op_box.Contains((int)location.Position.X, (int)location.Position.Y))
                    SceneManager.GetInstance(game).Current = SceneManager.State.OPTIONS;
                else if (help_box.Contains((int)location.Position.X, (int)location.Position.Y))
                    SceneManager.GetInstance(game).Current = SceneManager.State.HELP;
                else if (cred_box.Contains((int)location.Position.X, (int)location.Position.Y))
                    SceneManager.GetInstance(game).Current = SceneManager.State.CREDITS;
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            service.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(main_txt, new Rectangle(0,0,800,480), Color.White);
            spriteBatch.End();
        }
    }
}
