using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Touhou_Project;
using Touhou_Project.Enemys.Abstract_Factory;
using Touhou_Project.Sprites;
using System.Threading.Tasks;
using Touhou_Project.Collision;
using System.IO;
using System.Text.Json;

namespace Touhou_Project
{
    static public class JSONModel
    {
        public class Rootobject
        {
            public string difficulty { get; set; }
            public List<Wave> Waves { get; set; }
        }
        public class Wave
        {
            public string id { get; set; }
            public double start { get; set; }
            public double end { get; set; }

            public List<enemy> enemies { get; set; }

        }

        public class enemy
        {
            public string enemyType { get; set; }
            public string movementType { get; set; }
            public string bulletType { get; set; }
            public string bulletTexture { get; set; }
            public int enemyAmount { get; set; }
            public double start { get; set; }
            public double end { get; set; }

        }
    }
    public class GameUI : State
    {
        private BulletMovementFactory bullerFactory = new BulletMovementFactory();
        private Texture2D ship_texture;
        static public Texture2D playerBullet_texture;
        static public Texture2D secretFeatureBullet_texture;
        private Texture2D moveDown;
        private Texture2D moveUp;
        private Texture2D moveRight;
        private Texture2D moveLeft;
        private Texture2D enemyA_texture;
        private Texture2D enemyB_texture;
        private Texture2D Midboss_texture;
        private Texture2D Finalboss_texture;
        private SpriteFont timerFont;
        private BulletMovementFactory bulletFactory = new BulletMovementFactory();

        //Enemy facotry
        private EnemyAFactory eAfactory = new EnemyAFactory();
        private EnemyBFactory eBfactory = new EnemyBFactory();
        private MidbossFactory mbossfactory = new MidbossFactory();
        private FinalbossFactory fbossfactory = new FinalbossFactory();

        static public Player _player;
        private Bullet enemyA_bullet;
        private Bullet enemyB_bullet;
        private Bullet midboss_bullet;
        private Bullet finalboss_bullet;
        private Bullet _playerBullet;
        //public static int Heath; 
        //private int a = 500;
        private ScrollingBackground background;
        private EnemyBuild ememy_genertor;
        public static List<Sprite> sprites;
        public static List<Bullet> enemyBullet;
        public static List<Bullet> playerBullet;
        private int mid_boss;
        private int final_boss;
        static Random rand = new Random();
        public static bool _playerDead;
        public static bool _finalBossDead;
        public static int playerLives = 3;
        private CollisionInvoker invoker;
        private double startTime;
        private double endTime;
        private int wave;
        private List<JSONModel.enemy> enemyStatus;
        static JSONModel.Rootobject records;
        private int score;
        private int bomb;

        private int bombs = 20;
        private bool bombtriger = false;

        // 接口变量
        public static string enemyAmovement;
        public static string enemyBmovement;
        public static string midBossMovement;
        public static string finalBossMovement;

        public static string enemyAbulletMovement;
        public static string enemyBbulletMovement;
        public static string midBossBulletMovement;
        public static string finalBossBulletmovement;

        public static string enemyAbulletTexture;
        public static string enemyBbulletTexture;
        public static string midBossBulletTexture;
        public static string finalBossBulletTexture;

        // 声音控制
        public static SoundControl soundControl;

        private Texture2D playerBullet_texture1;
        private Texture2D playerBullet_texture2;
        private Texture2D playerBullet_texture3;
        private Texture2D playerBullet_texture4;
        private Texture2D playerBullet_texture5;
        private bool cheeatMode = false;
        private string difficulty; 
        public GameUI()
        {
            _playerDead = false;
            _finalBossDead = false;
            mid_boss = 0;
            final_boss = 0;
            ememy_genertor = new EnemyBuild();
            sprites = new List<Sprite>();
            enemyBullet = new List<Bullet>();
            invoker = new CollisionInvoker();
            playerBullet = new List<Bullet>();
            score = 0;
            bomb = 1;

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            //C: \Users\wenzh\Desktop\Cpt_S 487\teambadapple\Touhou Project\State\stagel.json
            string fullPathToFile1 = Path.Combine(projectDirectory, "Jsons");
            fullPathToFile1 = Path.Combine(fullPathToFile1, "stagel.json");
            
            using (StreamReader r = new StreamReader(fullPathToFile1))
            {
                string json = r.ReadToEnd();
                records = JsonSerializer.Deserialize<JSONModel.Rootobject>(json);
            }
            wave = 0;
            startTime = records.Waves[wave].start;
            endTime = records.Waves[wave].end;
            enemyStatus = records.Waves[wave].enemies;


            // Json file 接口 -- 全局定义接口
            enemyAmovement = enemyStatus[0].movementType;
            enemyBmovement = enemyStatus[1].movementType;
            midBossMovement = enemyStatus[2].movementType;
            finalBossMovement = enemyStatus[3].movementType;

            enemyAbulletMovement = enemyStatus[0].bulletType;
            enemyBbulletMovement = enemyStatus[1].bulletType;
            midBossBulletMovement = enemyStatus[2].bulletType;
            finalBossBulletmovement = enemyStatus[3].bulletType;

            enemyAbulletTexture = enemyStatus[0].bulletTexture;
            enemyBbulletTexture = enemyStatus[1].bulletTexture;
            midBossBulletTexture = enemyStatus[2].bulletTexture;
            finalBossBulletTexture = enemyStatus[3].bulletTexture;

            difficulty = records.difficulty; 
        }

        public override void LoadContent()
        {
            // Load BGM.
            soundControl = new SoundControl("Audio/BadApple");
            // Load player shooting sound effect.
            soundControl.AddSound("Shoot", "Audio/ShootSound", 1f);

            //load character material from the source file
            ship_texture = TextureFactory.Content.Load<Texture2D>("Source/lingmeng");
            enemyA_texture = TextureFactory.Content.Load<Texture2D>("Source/enemyA");
            enemyB_texture = TextureFactory.Content.Load<Texture2D>("Source/enemyB");
            moveDown = TextureFactory.Content.Load<Texture2D>("Source/moveDown");
            moveUp = TextureFactory.Content.Load<Texture2D>("Source/moveUp");
            moveRight = TextureFactory.Content.Load<Texture2D>("Source/moveRight");
            moveLeft = TextureFactory.Content.Load<Texture2D>("Source/moveLeft");
            Midboss_texture = TextureFactory.Content.Load<Texture2D>("Source/midBoss");
            Finalboss_texture = TextureFactory.Content.Load<Texture2D>("Source/finalBoss");
            timerFont = TextureFactory.Content.Load<SpriteFont>("Fonts/timerFont");
            playerBullet_texture = TextureFactory.Content.Load<Texture2D>("Source/player_bullet");
            secretFeatureBullet_texture = TextureFactory.Content.Load<Texture2D>("Source/secretFeatureBullet");
            
            playerBullet_texture1 = TextureFactory.Content.Load<Texture2D>("Source/black_bullet");
            playerBullet_texture2 = TextureFactory.Content.Load<Texture2D>("Source/knife_bullet");
            playerBullet_texture3 = TextureFactory.Content.Load<Texture2D>("Source/snow_bullet");
            playerBullet_texture4 = TextureFactory.Content.Load<Texture2D>("Source/red_bullet");
            playerBullet_texture5 = TextureFactory.Content.Load<Texture2D>("Source/ultimate_bullet");

            // create scrolling background
            background = new ScrollingBackground(TextureFactory.Content.Load<Texture2D>("Source/background-far"), new Rectangle(0, -2000, 500, 3000));

            //genrate player and bullet
            enemyA_bullet = new Bullet(TextureFactory.Content.Load<Texture2D>(enemyAbulletTexture));
            enemyB_bullet = new Bullet(TextureFactory.Content.Load<Texture2D>(enemyBbulletTexture));
            midboss_bullet = new Bullet(TextureFactory.Content.Load<Texture2D>(midBossBulletTexture));
            finalboss_bullet = new Bullet(TextureFactory.Content.Load<Texture2D>(finalBossBulletTexture));

            _playerBullet = new Bullet(playerBullet_texture);
            _player = new Player(ship_texture, _playerBullet, 50);
            _player.animations[0] = new SpriteAnimation(moveUp, 4, 8);
            _player.animations[1] = new SpriteAnimation(moveDown, 4, 8);
            _player.animations[2] = new SpriteAnimation(moveLeft, 4, 8);
            _player.animations[3] = new SpriteAnimation(moveRight, 4, 8);

            _player.anim = _player.animations[0];
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {

                if (cmd is GameplayInputCommand.PlayerMoveLeft)
                {
                    _player.MoveLeft();
                }

                if (cmd is GameplayInputCommand.PlayerMoveRight)
                {
                    _player.MoveRight();
                }

                if (cmd is GameplayInputCommand.PlayerMoveUp)
                {
                    _player.MoveUp();
                }

                if (cmd is GameplayInputCommand.PlayerMoveDown)
                {
                    _player.MoveDown();
                }

                if (cmd is GameplayInputCommand.PlayerShoots)
                {
                    _player.Shoot(gameTime);
                }

                if (cmd is GameplayInputCommand.PlayerSlowMode)
                {
                    _player.SlowDown();
                }

                if (cmd is GameplayInputCommand.PlayerCheatMode)
                {
                    _player.CheatMode();
                }

                if (cmd is GameplayInputCommand.PlayerRefillHealth)
                {
                    _player.refillHealth();
                    
                }
                
                if(cmd is GameplayInputCommand.ClearAllBullets)
                {
                    //call子弹清屏function
                    bombtriger = true;
                }
            });
        }

        public override void Draw(GameTime gameTime)
        {
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            // Draw scrolling background and the player
            background.Draw(spriteBatch);
            if (!_playerDead)
            {
                _player.anim.Draw(spriteBatch);
            }

            // Draw player bullet
            foreach (var bullet in playerBullet)
            {
                bullet.Draw(gameTime, spriteBatch);
            }

            // Enemy A, B 改为 Midterm 和 Final_boss 的格式，位置跟新和子弹发射应全部在Update()中实现
            if (gameTime.TotalGameTime.TotalSeconds > 10)
                Console.WriteLine(" "); 
            foreach (var e in sprites)
            {
                e.anim.Draw(spriteBatch);
                //draw heath on the top of mid boss and final boss
                if (e.GetType() == typeof(Mid_boss))
                {
                    spriteBatch.DrawString(timerFont, ((Mid_boss)e).Heath.ToString(), ((Mid_boss)e).Position + new Vector2(10, -30), Color.White);
                }
                if (e.GetType() == typeof(Final_boss))
                {
                    spriteBatch.DrawString(timerFont, ((Final_boss)e).Heath.ToString(), ((Final_boss)e).Position + new Vector2(10,-30), Color.White);
                }

            }


            foreach (var bullet in enemyBullet)
            {
                bullet.Draw(gameTime, spriteBatch);
                Console.WriteLine(bullet);
            }

            if (gameTime.TotalGameTime.TotalSeconds > enemyStatus[2].start && gameTime.TotalGameTime.TotalSeconds < enemyStatus[2].end)
            {
                if(mid_boss < enemyStatus[2].enemyAmount)
                {
                    sprites.Add(mbossfactory.createEmemy(Midboss_texture, new Vector2(rand.Next(100,500), rand.Next(10, 300)), midboss_bullet, 100));
                }
                mid_boss++;
            }
            if (gameTime.TotalGameTime.TotalSeconds > enemyStatus[3].start && gameTime.TotalGameTime.TotalSeconds < enemyStatus[3].end)
            {
                if(final_boss < enemyStatus[3].enemyAmount)
                {
                    sprites.Add(fbossfactory.createEmemy(Finalboss_texture, new Vector2(rand.Next(100, 300), rand.Next(10, 100)), finalboss_bullet, 200));
                }
                final_boss++;
            }

            // draw string on screen
            spriteBatch.DrawString(timerFont, "Time: " + Math.Floor(gameTime.TotalGameTime.TotalSeconds).ToString(), new Vector2(3, 3), Color.White);
            spriteBatch.DrawString(timerFont, "Health: " + Player.health.ToString(), new Vector2(160, 3), Color.White);
            spriteBatch.DrawString(timerFont, "Health: " + Player.health.ToString(), new Vector2(160, 3), Color.White);
            spriteBatch.DrawString(timerFont, "Lives: " + playerLives.ToString(), new Vector2(360, 3), Color.White);
            spriteBatch.DrawString(timerFont, "Score: " + score.ToString(), new Vector2(160, 30), Color.White);

            if (_playerDead && playerLives > 0)
            {
                spriteBatch.DrawString(timerFont, "Player Respawning....", new Vector2(120, 500), Color.White);
            }

            // draw slow mode
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.V))
            {
                spriteBatch.DrawString(timerFont, "Slow Mode", new Vector2(180, 950), Color.White);
            }
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            if (_playerDead)
            {
                this.RemoveAllSprites(gameTime);
            }
        }

        private void RemoveAllSprites(GameTime gameTime)
        {
            gameTime.TotalGameTime = gameTime.TotalGameTime.Subtract(gameTime.TotalGameTime);
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites.RemoveAt(i);
            }
            for (int i = 0; i < enemyBullet.Count; i++)
            {
                enemyBullet.RemoveAt(i);
            }
           
        }

        // Enemy A, B 改为 Midterm 和 Final_boss 的格式，位置跟新和子弹发射应全部在Update()中实现
        public override void Update(GameTime gameTime)
        {
            if (difficulty != "easy")
            {
                int time = (int)gameTime.TotalGameTime.TotalSeconds;
                if (difficulty == "medium")
                {
                    if(time % 5 == 0 && gameTime.TotalGameTime.TotalSeconds - (float)time < 0.001 && time - startTime > 20)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            Random r = new Random();
                            float X = (float)r.Next(0, 1000);
                            float Y = (float)r.Next(0, 500);
                            Vector2 pos = new Vector2(X, Y);
                            bullerFactory.addSercetFeatureBulletFactory(gameTime, pos, playerBullet_texture4);
                        }
                    }
                }
                else // hard 
                {
                    if (time % 5 == 0 && gameTime.TotalGameTime.TotalSeconds - (float)time < 0.05 && time - startTime > 20)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Random r = new Random();
                            float X = (float)r.Next(0, 1000);
                            float Y = (float)r.Next(0, 500);
                            Vector2 pos = new Vector2(X, Y);
                            bullerFactory.addSercetFeatureBulletFactory(gameTime, pos, playerBullet_texture3);
                        }
                    }
                }
            }


            if (bombtriger == true && bomb > 0)
            {
                bullerFactory.addBombsFactory(gameTime, _player.Position, playerBullet_texture5);
                bombs--;
            }
            if (bombs <= 0)
            {
                bombtriger = false;
                bombs = 20;
                bomb--;
            }
            if (endTime < gameTime.TotalGameTime.TotalSeconds)
            {
                wave += 1;
                if (wave < records.Waves.Count)
                {
                    startTime = records.Waves[wave].start;
                    endTime = records.Waves[wave].end;
                    enemyStatus = records.Waves[wave].enemies;
                    mid_boss = 0;
                    final_boss = 0;
                    EnemyBuild.enemyA = 0;
                    EnemyBuild.enemyB = 0;
                }
            }

            foreach (var e in enemyBullet)
            {
                e.Update(gameTime);

            }

            if (Player.health <= 0)
                Player.health = 0;

            // Update background movement
            if (background.rectangle.Y >= 0)
            {
                background.rectangle.Y = -2000;
            }
            background.Update();

            // Update player and player's bullet movement
            _player.Update(gameTime);
            foreach (Bullet b in playerBullet)
            {
                b.Update(gameTime);
            }

            /// Step 1: Create bullet and enemy object
            /// Step 2: Update enemy AI
            /// Step 3: Check the death of enemy
            /// Step 4: Remove the dead enemy

            /// Step 1
            /// random add ememyA or enemyB
            int who = rand.Next(2);
            switch (who)
            {
                case 0:
                    // Enemy A
                    ememy_genertor.Update(gameTime, enemyA_texture, sprites, eAfactory, eBfactory, enemyA_bullet, enemyStatus);
                    break;
                case 1:
                    // Enemy B
                    ememy_genertor.Update(gameTime, enemyB_texture, sprites, eAfactory, eBfactory, enemyB_bullet, enemyStatus);
                    break;
            }
            // Enemy A, B 改为 Midterm 和 Final_boss 的格式，位置跟新和子弹发射应全部在Update()中实现

            foreach (var b in sprites)
            {
                b.Update(gameTime, _player.Position);
            }

            if(Player.health <= 20 && bomb == 1)
            {
                if(Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    sprites.Clear();
                    enemyBullet.Clear();
                    bomb--;
                }
            }

            // 玩家子弹与敌人碰撞
            invoker.setCommand(new PlayerBulletCollisionWithEnemy(sprites, playerBullet));
            invoker.CollisionDetect();


            // 敌人与玩家碰撞
            invoker.setCommand(new PlayerCollisionWithEnemy(_player, sprites));
            invoker.CollisionDetect();

            // 敌人子弹与玩家碰撞
            invoker.setCommand(new EnemyBulletCollisionWithPlayer(_player, enemyBullet));
            invoker.CollisionDetect();

            // get score
            foreach (var e in sprites)
            {
                if(((Enemy) e).Dead)
                {
                    if(e.GetType() == typeof(EnemyA) || e.GetType() == typeof(EnemyB))
                    {
                        score += 500;

                    }
                    else
                    {
                        score += 1000;
                    }
                }

            }

            playerBullet.RemoveAll(b => b.Collided);
            sprites.RemoveAll(e => ((Enemy)e).Dead);
            sprites.RemoveAll(e => ((Enemy)e).Heath <= 0);
            enemyBullet.RemoveAll(b => b.Collided);

            PostUpdate(gameTime);
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new GameplayInputMapper());
        }
      
    }
}
