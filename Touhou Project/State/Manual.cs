using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.UI
{
    public class Manual : State
    {
        private List<Component> _components;
        private Texture2D buttonTexture;
        private SpriteFont button_font;
        private SpriteFont text_font;
        private Texture2D background_Texture;
        private Rectangle background_rec;
        private KeyboardState previousState;
        private bool remapping = false;
        private string newKeyToRebind;

        private Button upButton;
        private Button downButton;
        private Button leftButton;
        private Button rightButton;
        private Button changeSpeedButton;
        private Button cheatButton;
        private Button shootButton;
        private Button rebindButton;
        private Button clearAllBulletButton;

        public Manual()
        {
            buttonTexture = TextureFactory.Content.Load<Texture2D>("Source/Button");
            button_font = TextureFactory.Content.Load<SpriteFont>("Fonts/Font");
            text_font = TextureFactory.Content.Load<SpriteFont>("Fonts/Manual");
            background_Texture = TextureFactory.GetTexture("Source/background");
            background_rec = new Rectangle(0, 0, 500, 1000);

            
            var BackButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 750),
                Text = "Back",
            };
            BackButton.Click += BackButton_Click;


            this.upButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 300),
                Text = "Up | " + KeyboardInput.Up.ToString(),
            };
            this.upButton.Click += this.UpButton_Click;

            this.downButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 400),
                Text = "Down | " + KeyboardInput.Down.ToString(),
            };
            this.downButton.Click += this.DownButton_Click;

            this.leftButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(70, 350),
                Text = "Left | " + KeyboardInput.Left.ToString(),
            };
            this.leftButton.Click += this.LeftButton_Click;

            this.rightButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(270, 350),
                Text = "Right | " + KeyboardInput.Right.ToString(),
            };
            this.rightButton.Click += this.RightButton_Click;

            this.changeSpeedButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 500),
                Text = "Slow Down | " + KeyboardInput.SlowMode.ToString(),
            };
            this.changeSpeedButton.Click += this.ChangeSpeedButton_Click;

            this.cheatButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 550),
                Text = "Cheat Mode | " + KeyboardInput.CheatMode.ToString(),
            };
            this.cheatButton.Click += this.CheakButton_Click;

            this.shootButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 600),
                Text = "Shoot | " + KeyboardInput.Shoot.ToString(),
            };
            this.shootButton.Click += this.ShootButton_Click;

            this.clearAllBulletButton = new Button(buttonTexture, button_font)
            {
                Position = new Vector2(170, 650),
                Text = "Clear | " + KeyboardInput.ClearAllBullets.ToString(),
            };
            this.clearAllBulletButton.Click += this.ClearAllBulletButton_Click;

            _components = new List<Component>()
            {
                this.upButton,
                this.downButton,
                this.leftButton,
                this.rightButton,
                this.changeSpeedButton,
                this.cheatButton,
                this.shootButton,
                this.clearAllBulletButton,
                BackButton,
            };
        }

        private void ClearAllBulletButton_Click(object sender, EventArgs e)
        {
            if (!this.remapping)
            {
                this.remapping = true;
                this.newKeyToRebind = "Clear";
                this.rebindButton = sender as Button;
                this.rebindButton.Text = this.newKeyToRebind + " | KeyBinding";
            }
        }

        private void ShootButton_Click(object sender, EventArgs e)
        {
            if (!this.remapping)
            {
                this.remapping = true;
                this.newKeyToRebind = "Shoot";
                this.rebindButton = sender as Button;
                this.rebindButton.Text = this.newKeyToRebind + " | KeyBinding";
            }
        }

        private void CheakButton_Click(object sender, EventArgs e)
        {
            if (!this.remapping)
            {
                this.remapping = true;
                this.newKeyToRebind = "Cheat";
                this.rebindButton = sender as Button;
                this.rebindButton.Text = this.newKeyToRebind + " | KeyBinding";
            }
        }

        private void ChangeSpeedButton_Click(object sender, EventArgs e)
        {
            if (!this.remapping)
            {
                this.remapping = true;
                this.newKeyToRebind = "Slow";
                this.rebindButton = sender as Button;
                this.rebindButton.Text = this.newKeyToRebind + " | KeyBinding";
            }
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            if (!this.remapping)
            {
                this.remapping = true;
                this.newKeyToRebind = "Right";
                this.rebindButton = sender as Button;
                this.rebindButton.Text = this.newKeyToRebind + " | KeyBinding";
            }
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            if (!this.remapping)
            {
                this.remapping = true;
                this.newKeyToRebind = "Left";
                this.rebindButton = sender as Button;
                this.rebindButton.Text = this.newKeyToRebind + " | KeyBinding";
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (!this.remapping)
            {
                this.remapping = true;
                this.newKeyToRebind = "Down";
                this.rebindButton = sender as Button;
                this.rebindButton.Text = this.newKeyToRebind + " | KeyBinding";
            }
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            if (!this.remapping)
            {
                this.remapping = true;
                this.newKeyToRebind = "Up";
                this.rebindButton = sender as Button;
                this.rebindButton.Text = this.newKeyToRebind + " | KeyBinding";
            }
        }

        public override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicManagers.GraphicsDevice);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            StateManager.ChangeState(new MenuUI());
        }

        public override void Draw(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(background_Texture, background_rec, Color.White);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                if(this.remapping)
                {
                    this.GetNewKeyToMap();
                }
                component.Update(gameTime);
            }
        }

        private void GetNewKeyToMap()
        {
            KeyboardState currentState = Keyboard.GetState();
            if (this.previousState.GetPressedKeyCount() == 0 && currentState.GetPressedKeyCount() == 1)
            {
                //get the new key that is pressed
                Keys newKey = currentState.GetPressedKeys()[0];

                // check if the new key is already binded
                if (KeyboardInput.IsBinded(newKey) == false)
                {
                    KeyboardInput.SetKeyboardKey(this.newKeyToRebind, newKey);
                    this.rebindButton.Text = this.newKeyToRebind + " | " + newKey.ToString().ToUpper();

                    this.remapping = false;
                    this.newKeyToRebind = "";
                    this.rebindButton = null;
                } else
                {
                    this.rebindButton.Text = "Reset To Default";
                }
            }

            this.previousState = currentState;
        }

        public override void HandleInput(GameTime gameTime)
        {
        }

        protected override void SetInputManager()
        {
        }
    }
}
