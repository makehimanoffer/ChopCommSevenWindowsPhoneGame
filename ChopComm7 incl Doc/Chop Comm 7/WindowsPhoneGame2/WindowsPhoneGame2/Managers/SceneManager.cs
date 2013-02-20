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
using ChopComm7.Scenes;

namespace ChopComm7
{
    class SceneManager
    {
        public enum State { SPLASH, PLAY, WIN, TRY_AGAIN, LOADING, OPTIONS, HELP, CREDITS, STORYBOARD,Lose }

        private static SceneManager manager;

        private Microsoft.Xna.Framework.Game game;

        private State last;
        private State current;

        private Scene previous;
        private Scene active;

        private SceneManager(Microsoft.Xna.Framework.Game game)
        {
            this.game = game;
            last = State.LOADING;
            current = State.SPLASH;            
        }

        public static SceneManager GetInstance(Microsoft.Xna.Framework.Game game)
        {
            if (manager == null)
                manager = new SceneManager(game);
            return manager;
        }

        public State Current
        {
            get { return current; }
            set { current = value; }
        }

        public Scene NextScene()
        {
            switch (Current)
            {
                case State.SPLASH:
                    if (last != State.SPLASH)
                    {
                        active = new MainMenu(game);
                        active.Initialize();
                        active.LoadContent();
                        
                        last = State.SPLASH;

                        if (previous != null)
                            previous.UnloadContent();
                        previous = active;
                    }
                    break;
                case State.OPTIONS:
                    if (last != State.OPTIONS)
                    {
                        active = new Options(game);
                        active.Initialize();
                        active.LoadContent();

                        last = State.OPTIONS;
                        if (previous != null)
                            previous.UnloadContent();
                        previous = active;
                    }
                    break;
                case State.HELP:
                    if (last != State.HELP)
                    {
                        active = new Help(game);
                        active.Initialize();
                        active.LoadContent();

                        last = State.HELP;
                        if (previous != null)
                            previous.UnloadContent();
                        previous = active;
                    }
                    break;
                case State.Lose:
                    if (last != State.Lose)
                    {
                        active = new Lose(game);
                        active.Initialize();
                        active.LoadContent();

                        last = State.Lose;
                        if (previous != null)
                            previous.UnloadContent();
                        previous = active;
                    }
                    break;
                case State.CREDITS:
                    if (last != State.CREDITS)
                    {
                        active = new Credits(game);
                        active.Initialize();
                        active.LoadContent();

                        last = State.CREDITS;
                        if (previous != null)
                            previous.UnloadContent();
                        previous = active;
                    }
                    break;
                case State.PLAY:
                    if (last != State.PLAY)
                    {
                        active = new Main(game);
                        active.Initialize();
                        active.LoadContent();

                        last = State.PLAY;
                        if (previous != null)
                            previous.UnloadContent();
                        previous = active;
                    }
                    break;
                case State.WIN:
                    if (last != State.WIN)
                    {
                        active = new WIN(game);
                        active.Initialize();
                        active.LoadContent();

                        last = State.WIN;
                        if (previous != null)
                            previous.UnloadContent();
                        previous = active;
                    }
                    break;
                case State.STORYBOARD:
                    if (last != State.STORYBOARD)
                    {
                        active = new StoryBoard(game);
                        active.Initialize();
                        active.LoadContent();

                        last = State.STORYBOARD;
                        if (previous != null)
                            previous.UnloadContent();
                        previous = active;
                    }
                    break; 
                default:
                    last = State.LOADING; //Return player to Splash Screen
                    break;
            }
            return active;
        }
    }
}
