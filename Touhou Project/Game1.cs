using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Touhou_Project;

namespace Touhou_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private State _currentState;
        private State _nextState;
        private SpriteBatch spriteBatch;
        public Game1()
        {

            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            _graphics = new GraphicsDeviceManager(this);
            UtlilityManager.Initialize(this.Content, _graphics);
            StateManager.ExitEvent += this.ExitMainGame;
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.PreferredBackBufferHeight = 1000;
        }

        public void ExitMainGame(object sender, EventArgs e)
        {
            this.Exit();
        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public void ChangeGameSize()
        {
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();
        }

        public void ChangeMenuUISize()
        {
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 675;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //_spriteBatch = new SpriteBatch(GraphicsDevice);

            //_currentState = new MenuUI();
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            StateManager.CurrentState = new MenuUI();
            StateManager.CurrentState.LoadContent();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //if (_nextState != null)
            //{
            //    _currentState = _nextState;

            //    _nextState = null;
            //}

            //_currentState.Update(gameTime);

            //_currentState.PostUpdate(gameTime);
            StateManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //_currentState.Draw(gameTime, _spriteBatch);
            StateManager.CurrentState.Draw(gameTime, this.spriteBatch);
            StateManager.CurrentState.HandleInput(gameTime);

            base.Draw(gameTime);
        }

    }
}
