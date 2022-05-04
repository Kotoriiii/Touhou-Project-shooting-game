using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Touhou_Project.Aesthetics;

namespace Touhou_Project
{
    public class GameOver : State
    {
        private List<Component> components;
        private SpriteFont gameOverTexture;
        private SpriteFont gameOverTexture2;
        private SnowEmitter snowEmitter;

        public GameOver()
          : base()
        {
            var buttonTexture = TextureFactory.GetTexture("Source/Button");
            var buttonFont = TextureFactory.GetSpriteFont("Fonts/Font");
            this.gameOverTexture = TextureFactory.GetSpriteFont("Fonts/Menutext");
            this.gameOverTexture2 = TextureFactory.GetSpriteFont("Fonts/Menutext");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(170, 500),
                Text = "Play Again",
            };

            newGameButton.Click += this.NewGameButton_Click;

            var returnButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(170, 600),
                Text = "Main Menu",
            };

            returnButton.Click += this.ReturnButton_Click;

            var exitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(170, 700),
                Text = "Exit Game",
            };

            exitGameButton.Click += this.ExitGameButton_Click;

            this.components = new List<Component>()
                {
                    newGameButton,
                    returnButton,
                    exitGameButton,
                };
        }

        public object GraphicsDevice { get; private set; }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GraphicManagers.GraphicsDevice.Clear(Color.Crimson);

            spriteBatch.Begin();

            foreach (var component in this.components)
            {
                component.Draw(gameTime, spriteBatch);
                spriteBatch.DrawString(gameOverTexture, "GAME", new Vector2(160, 100), Color.White);
                spriteBatch.DrawString(gameOverTexture2, "OVER", new Vector2(160, 200), Color.White);
            }

            this.snowEmitter.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)

        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in this.components)
            {
                component.Update(gameTime);
            }
            this.snowEmitter.Update(gameTime);

        }

        public override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicManagers.GraphicsDevice);
            this.snowEmitter = new SnowEmitter(new Particle(TextureFactory.Content.Load<Texture2D>("Source/Snow")));
        }

        public override void Draw(GameTime gameTime)
        {
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            StateManager.ChangeState(new GameUI());
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            StateManager.ChangeState(new MenuUI());
        }

        private void ExitGameButton_Click(object sender, EventArgs e)
        {
            StateManager.ExitEvent(null, e);
        }

        public override void HandleInput(GameTime gameTime)
        {
        }

        protected override void SetInputManager()
        {
        }
    }
}
