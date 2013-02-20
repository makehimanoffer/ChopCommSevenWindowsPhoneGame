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
    class Options : Scene
 {
        private Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService service;
        private Microsoft.Xna.Framework.Game game;
        private float elapsed = 0.0f;
        public enum Heli_c { Relistic, Semi, Cartoon };
        public static Heli_c hel_op;

        //Splash background
        private Texture2D background;
        private Texture2D rectangle;
        private SpriteBatch spriteBatch;
        private SpriteFont spritefont;
        Rectangle game_box;
        Rectangle hel_c1;
        Rectangle hel_c2;
        Rectangle hel_c3;

        public Options(Microsoft.Xna.Framework.Game game)
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
            hel_c1 = new Rectangle(130, 150, 150, 150);
            hel_c2 = new Rectangle(360, 150, 150, 150);
            hel_c3 = new Rectangle(520, 150, 150, 150);
        }

        public override void LoadContent()
        {
            rectangle = game.Content.Load<Texture2D>("Sprites\\red border");
            background = game.Content.Load<Texture2D>("Sprites\\options");
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
                else if (hel_c1.Contains((int)location.Position.X, (int)location.Position.Y))
                    hel_op = Heli_c.Relistic;
                else if (hel_c2.Contains((int)location.Position.X, (int)location.Position.Y))
                    hel_op = Heli_c.Semi;
                else if (hel_c3.Contains((int)location.Position.X, (int)location.Position.Y))
                    hel_op = Heli_c.Cartoon;
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            service.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 400), Color.White);

            if (hel_op == Heli_c.Relistic)
            {
                spriteBatch.Draw(rectangle, new Rectangle(130, 150, 150, 150), Color.White);
            }
            else
            {
            }
            if (hel_op == Heli_c.Semi)
            {
                spriteBatch.Draw(rectangle, new Rectangle(340, 150, 150, 150), Color.White);
            }
            else
            {
            }
            if (hel_op == Heli_c.Cartoon)
            {
                spriteBatch.Draw(rectangle, new Rectangle(520, 150, 150, 150), Color.White);
            }
            else
            {
            }


            spriteBatch.DrawString(spritefont, "Return to Main", new Vector2(200, 300), Color.White);
            spriteBatch.End();
        }
    }
}