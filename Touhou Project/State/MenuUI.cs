using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.UI;
using Touhou_Project.Aesthetics;

namespace Touhou_Project
{
    public class MenuUI : State
    {
        private List<Component> _components;
        private Texture2D background_Texture;
        private Rectangle background_rec;
        private Texture2D buttonTexture;
        private SpriteFont button_font;
        private SpriteFont text_font;
        private SnowEmitter snowEmitter;

        public MenuUI()
            : base()
        {
            buttonTexture = TextureFactory.GetTexture("Source/Button");
            button_font = TextureFactory.GetSpriteFont("Fonts/Font");
            text_font = TextureFactory.GetSpriteFont("Fonts/Menutext");
            background_Texture = TextureFactory.GetTexture("Source/background");
            background_rec = new Rectangle(0, 0, 500, 1000);

            var newGameButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 500),
                Text = "New Game",
            };

            newGameButton.Click += this.NewGameButton_Click;

            var userManualButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 600),
                Text = "Key Settings",
            };

            userManualButton.Click += this.UserManualButton_Click;

            var quitGameButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 700),
                Text = "Quit Game",
            };

            quitGameButton.Click += this.QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                userManualButton,
                quitGameButton,
            };
        }

        public static ContentManager Content { get; set; }
        public object GraphicsDevice { get; private set; }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(background_Texture, background_rec, Color.White);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
            this.snowEmitter.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(text_font, "Touhou", new Vector2(125, 100), Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
            this.snowEmitter.Update(gameTime);
        }

        public override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicManagers.GraphicsDevice);
            this.snowEmitter = new SnowEmitter(new Particle(TextureFactory.Content.Load<Texture2D>("Source/Snow")));
        }

        private void UserManualButton_Click(object sender, EventArgs e)
        {
            StateManager.ChangeState(new Manual());

        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            StateManager.ChangeState(new GameUI());
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            StateManager.ExitEvent(null, e);
        }


        public override void Draw(GameTime gameTime)
        {
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void HandleInput(GameTime gameTime)
        {
        }

        protected override void SetInputManager()
        {
        }
    }
}
