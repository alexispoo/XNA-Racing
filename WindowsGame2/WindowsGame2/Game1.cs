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
        Vector2 position;
        Vector2 position2;
        Vector2 SpritePosition=Vector2.Zero;
        protected float scale = .5f;
        Rectangle rectangle1;
        Rectangle rectangle2;
        Rectangle rectangle3;
        Rectangle rectangle4;

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
           
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rb = Content.Load<Texture2D>(@"images/Black_viper");
            p1 = Content.Load<Texture2D>(@"images/part1");
            p2 = Content.Load<Texture2D>(@"images/part2");
            p3 = Content.Load<Texture2D>(@"images/part3");
            p4 = Content.Load<Texture2D>(@"images/part4");
            

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            KeyboardState keyboard = Keyboard.GetState();
            if ((keyboard.IsKeyDown(Keys.Up))||(keyboard.IsKeyDown(Keys.W)))
            { SpritePosition.Y -= 5;
            }
            if ((keyboard.IsKeyDown(Keys.Down))||(keyboard.IsKeyDown(Keys.S)))
            { SpritePosition.Y+=10;
            }
            if ((keyboard.IsKeyDown(Keys.Left)) ||(keyboard.IsKeyDown(Keys.A))){ 
                SpritePosition.X -= 5; }
            if ((keyboard.IsKeyDown(Keys.Right))||(keyboard.IsKeyDown(Keys.D)))
            {  SpritePosition.X += 5; 
            }
            if (SpritePosition.Y < 0)
            {SpritePosition.Y *= -1;
            }
            
            //position
            if (SpritePosition.Y <0)
            {
                SpritePosition.Y *= -1;
            }
            if (SpritePosition.Y > graphics.PreferredBackBufferHeight - 128)
            {
                SpritePosition.Y = 250;
            }
            if ((SpritePosition.X < -80)||(SpritePosition.X > 480+rb.Width))
            {
                SpritePosition.X = 300;
            }

            //scroll

           if (rectangle1.Y + p1.Height<=0)
            {           
				rectangle1.Y = 1800;}
		
			if (rectangle2.Y + p2.Height<= 0){

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
            //scroll speed
            rectangle1.Y -= 15;
            rectangle2.Y -= 15;
            rectangle3.Y -= 15;
            rectangle4.Y -= 15;
            SpritePosition.X -= 0.5f;
            base.Update(gameTime);

         
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
           
            spriteBatch.Draw(p1, rectangle1, Color.White);
            spriteBatch.Draw(rb, SpritePosition, null, Color.White, 0f,
Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(p2, rectangle2, Color.White);

            spriteBatch.Draw(p3, rectangle3, Color.White);
            spriteBatch.Draw(p4, rectangle4, Color.White);
        
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
