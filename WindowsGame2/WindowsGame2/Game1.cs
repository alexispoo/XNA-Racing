using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D rb;
        Texture2D p1;
        Texture2D p2;
        Texture2D p3;
        Texture2D p4;
        Texture2D rock;
        Vector2 position;
        Vector2 position2;
        Vector2 SpritePosition=Vector2.Zero;
        protected float scale = .5f;
        protected float scalerock = 2f;
        Rectangle rectangle1;
        Rectangle rectangle2;
        Rectangle rectangle3;
        Rectangle rectangle4;
        Song bgMusic;
        protected SpriteFont font;
        protected SpriteFont font2;
        protected SpriteFont font3;

        Vector2 pos2;
        public static Rectangle Hitbox;
        public static Rectangle Carbox;
        int nexth;
        int nextw;
        int rockh;
        int rockw;
        TimeSpan timer = new TimeSpan(0, 0, 0);
        TimeSpan starts = new TimeSpan(0, 0,0);
        TimeSpan fastspawn = new TimeSpan(0, 0, 1);
        TimeSpan fast = new TimeSpan(0, 0, 0);
        TimeSpan timercollision = new TimeSpan(0, 0, 0);
        Color backgroundColor = Color.Red;
        bool colision;
        String score;
        String lifestring;
        int lifeint=100;

        SoundEffect bgMusic2;
        SoundEffectInstance instance;
      public  bool life3=true;

        Color color;
        public Game1()
        {
        
         
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

         
            position = Vector2.Zero;
            position2 = new Vector2(0f,0f);

            pos2 = Vector2.Zero;
            SpritePosition = new Vector2(400,300);
            base.Initialize();
            rectangle1 = new Rectangle(0, 0, 800, 600);
            rectangle2 = new Rectangle(0, 600, 800, 600);
            rectangle3 = new Rectangle(0, 1200, 800, 600);
            rectangle4 = new Rectangle(0, 1800, 800, 600);
          
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            rock = Content.Load<Texture2D>(@"images/rock");

            spriteBatch = new SpriteBatch(GraphicsDevice);
            rb = Content.Load<Texture2D>(@"images/Black_viper");
            p1 = Content.Load<Texture2D>(@"images/part1");
            p2 = Content.Load<Texture2D>(@"images/part2");
            p3 = Content.Load<Texture2D>(@"images/part3");
            p4 = Content.Load<Texture2D>(@"images/part4");
            font = Content.Load<SpriteFont>(@"SpriteFont1");
            font2 = Content.Load<SpriteFont>(@"SpriteFont2");
            font3 = Content.Load<SpriteFont>(@"SpriteFont3");
            bgMusic = Content.Load<Song>("Musica/algodon");
            MediaPlayer.Play(bgMusic);
            MediaPlayer.IsRepeating = true;

            bgMusic2 = Content.Load<SoundEffect>("Musica/pat");
            instance = bgMusic2.CreateInstance();
           
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
     
        
        protected override void Update(GameTime gameTime)
        {
           
           
            // Allows the game to exit
            // TODO: Add your update logic here

           
              


                //position
                if (SpritePosition.Y < 0)
                {
                    SpritePosition.Y *= -1;
                }
                if (SpritePosition.Y > 550)
                {
                    SpritePosition.Y = 300;
                }
                if ((SpritePosition.X < -80) || (SpritePosition.X > 480 + rb.Width))
                {
                    SpritePosition.X = 300;
                }

                //scroll

                if (rectangle1.Y + p1.Height <= 0)
                {
                    rectangle1.Y = 1800;
                }

                if (rectangle2.Y + p2.Height <= 0)
                {

                    rectangle2.Y = 1800;
                }

                if (rectangle3.Y + p3.Height <= 0)
                {

                    rectangle3.Y = 1800;
                }
                if (rectangle4.Y + p4.Height <= 0)
                {

                    rectangle4.Y = 1800;
                }
               
                
                score = fast.ToString();
                lifestring = lifeint.ToString();
                if (lifeint > 0)
                {
                    fast += gameTime.ElapsedGameTime;

                }
               

                timer += gameTime.ElapsedGameTime;

                if ((int)fast.Seconds > 33)
                {
                    KeyboardState keyboard = Keyboard.GetState();
                    if ((keyboard.IsKeyDown(Keys.Up)) || (keyboard.IsKeyDown(Keys.W)))
                    {
                        SpritePosition.Y -= 10;
                    }
                    if ((keyboard.IsKeyDown(Keys.Down)) || (keyboard.IsKeyDown(Keys.S)))
                    {
                        SpritePosition.Y += 20;
                    }
                    if ((keyboard.IsKeyDown(Keys.Left)) || (keyboard.IsKeyDown(Keys.A)))
                    {
                        SpritePosition.X -= 10;
                    }
                    if ((keyboard.IsKeyDown(Keys.Right)) || (keyboard.IsKeyDown(Keys.D)))
                    {
                        SpritePosition.X += 10;
                    }
                    //scroll speed
                    rectangle1.Y -= 25;
                    rectangle2.Y -= 25;
                    rectangle3.Y -= 25;
                    rectangle4.Y -= 25;
                    SpritePosition.X -= 0.7f;
                    if ((int)timer.Seconds > 1)
                    {
                        Random r = new Random();
                        nexth = r.Next(0, 600);
                        nextw = r.Next(100, 700);
                        rockw = r.Next(35, 200);
                        rockh = r.Next(35, 200);
                        Hitbox = new Rectangle(r.Next(0, 600), r.Next(100, 700), rockw, rockh);
                        timer = fastspawn;

                    }
                }
                else
                {
                    //movility increased
                    KeyboardState keyboard = Keyboard.GetState();
                    if ((keyboard.IsKeyDown(Keys.Up)) || (keyboard.IsKeyDown(Keys.W)))
                    {
                        SpritePosition.Y -= 5;
                    }
                    if ((keyboard.IsKeyDown(Keys.Down)) || (keyboard.IsKeyDown(Keys.S)))
                    {
                        SpritePosition.Y += 10;
                    }
                    if ((keyboard.IsKeyDown(Keys.Left)) || (keyboard.IsKeyDown(Keys.A)))
                    {
                        SpritePosition.X -= 5;
                    }
                    if ((keyboard.IsKeyDown(Keys.Right)) || (keyboard.IsKeyDown(Keys.D)))
                    {
                        SpritePosition.X += 5;
                    }
                    //scroll speed increased
                    rectangle1.Y -= 15;
                    rectangle2.Y -= 15;
                    rectangle3.Y -= 15;
                    rectangle4.Y -= 15;
                    SpritePosition.X -= 0.5f;
                    if ((int)timer.Seconds > 5)
                    {
                        Random r = new Random();
                        nexth = r.Next(0, 600);
                        nextw = r.Next(100, 700);
                        rockw = r.Next(35, 260);
                        rockh = r.Next(35, 260);
                        Hitbox = new Rectangle(r.Next(0, 600), r.Next(0, 800), rockw, rockh);
                        timer = starts;
                    }
                }
                //collision
                Carbox = new Rectangle((int)SpritePosition.X, (int)SpritePosition.Y, rb.Width / 2 - 50, rb.Height / 2 - 20);


                if (Carbox.Intersects(Hitbox))
                {

                    colision = true;
                    
                }

                else
                    colision = false;

                if (colision)
                {
                    //decrease hp

                    instance.Play();
                    if (lifeint > 0)
                    {
                        color = Color.Red;
                        life3 = false;
                        lifeint -= 1;
                       
                    }
                    SpritePosition.Y -= 10;
                }
                else
                {
                    color = Color.White;
                }
                base.Update(gameTime);
            
 

         
            
        }
              

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            if (lifeint > 1)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.Draw(p4, rectangle4, Color.White);

                spriteBatch.Draw(p3, rectangle3, Color.White);

                spriteBatch.Draw(p2, rectangle2, Color.White);

                spriteBatch.Draw(p1, rectangle1, Color.White);
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.DrawString(font2, "HP:" + lifeint.ToString(), new Vector2(600, 0), Color.Red);
                spriteBatch.DrawString(font, score, new Vector2(0, 0), Color.White);





                spriteBatch.Draw(rb, SpritePosition, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                spriteBatch.Draw(rock, Hitbox, color);

               
                spriteBatch.End();
            }
            else 
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.DrawString(font3, "GAME OVER \n \nYour Time Was:\n" + score+"\nIs that all you got?", new Vector2(100, 100), Color.White);
                spriteBatch.End();
            }

             
          
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

       
          
    }
}
