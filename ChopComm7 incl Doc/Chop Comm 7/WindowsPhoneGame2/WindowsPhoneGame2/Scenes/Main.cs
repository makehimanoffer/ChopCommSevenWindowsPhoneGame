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
    class Main : Scene
    {
        private Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService service;
        private Microsoft.Xna.Framework.Game game;
        public background b1;
        public Crosshair crosshair;
        SpriteFont font;
        public Texture2D texture;
        public PlayerAnimation sprite;
        SoundEffectInstance chopperSound;
        public CameraMan cam;
        public HUD h1;
        public DropBoxManager d1;
        public RankManager ranks;
        public WaveManager wm;
        public VIP vip;
      
        public AnimatedSprite chopperAnimation;
        
        SpriteBatch spriteBatch;
        private float timer = .0f;

        public Main(Microsoft.Xna.Framework.Game game)
        {
            this.game = game;
            service = (Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService)game.Services.GetService(typeof(Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService));
        }


        public override void Initialize()
        {
            // TODO: Add your initialization logic here
            ranks = new RankManager();
            crosshair = new Crosshair(game.Content);
            h1 = new HUD();
            d1 = new DropBoxManager(game.Content);
            b1 = new background();
           
            cam = new CameraMan(new Vector2(0, 0));
            cam._pos.Y += service.GraphicsDevice.PresentationParameters.BackBufferHeight / 2;
            cam._pos.X += service.GraphicsDevice.PresentationParameters.BackBufferWidth / 2;
           
       }

        public override void LoadContent()
        {
            ranks.LoadContent(game.Content);
            spriteBatch = new SpriteBatch(service.GraphicsDevice); 
            // Create a new SpriteBatch, which can be used to draw textures.
            h1.LoadContent(game.Content);
            crosshair.LoadContent(game.Content);
            d1.LoadContent(game.Content);
           
            b1.initImage(game.Content);
            font = game.Content.Load<SpriteFont>("Font");
            crosshair.Position = new Vector2((service.GraphicsDevice.PresentationParameters.BackBufferWidth / 2)+ 400, service.GraphicsDevice.PresentationParameters.BackBufferHeight / 2);
            vip = new VIP(crosshair.Position);
            vip.LoadContent(game.Content);
            sprite = new PlayerAnimation();
            chopperAnimation = new AnimatedSprite(game.Content.Load<Texture2D>("Sprites/frontreel"), .15f, true);
            chopperAnimation.FrameDivisions = 3;
            chopperSound = game.Content.Load<SoundEffect>("Sounds\\Chopper").CreateInstance();
           
            wm = new WaveManager();
            wm.LoadContent(game.Content, crosshair, vip, service.GraphicsDevice.Viewport);
            // TODO: use this.Content to load your game content here
        }

        public override void UnloadContent()
        {
          //  throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Console.WriteLine("Hello");
            vip.Update(game.Content, gameTime); ;
            b1.update(h1);
            
            //sprite.PlayAnimation(chopperAnimation);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                game.Exit();
            crosshair.Update(wm,h1,b1,d1,vip);
            cam.Pos = crosshair.Position;
            d1.Update();
            h1.Update(crosshair);
            cam.Move(crosshair.Velocity);
           
            // TODO: Add your update logic here
            wm.Update(h1, vip, crosshair, game.Content, service.GraphicsDevice.Viewport, gameTime);
            if (vip .health<=0)
            {
                
                    SceneManager.GetInstance(game).Current = SceneManager.State.Lose;
            }
            if (h1.score>=999999)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(timer >= 10)
                    SceneManager.GetInstance(game).Current = SceneManager.State.WIN;
            }

            ranks.Update(crosshair, h1, wm, d1);
        }
        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {



            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, cam.get_transformation(service.GraphicsDevice));
            service.GraphicsDevice.Clear(Color.CornflowerBlue);



            crosshair.Draw(spriteBatch);

            h1.Draw(spriteBatch,vip,wm,crosshair);
            vip.Draw(spriteBatch, vip.rotationAngle, vip.origin);

            ranks.Draw(spriteBatch,h1);
            
          
            service.GraphicsDevice.BlendState = BlendState.AlphaBlend;
            b1.draw(spriteBatch);
            wm.Draw(spriteBatch, service.GraphicsDevice.Viewport,h1);
            d1.Draw(spriteBatch,h1);
            spriteBatch.End();
        }
    }
}
