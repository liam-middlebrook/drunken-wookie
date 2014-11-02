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

namespace Drunken_Wookie
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SoundPlayer soundPlayer;
        private DrumPad drumPad;
        private List<SoundButton> soundButtons;
        private Texture2D backgroundTex;
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
            soundButtons = new List<SoundButton>();

            drumPad = new DrumPad(PlayerIndex.One);
            
            soundPlayer = new SoundPlayer();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            soundPlayer.LoadSounds(Content);


            Texture2D laserTex = Content.Load<Texture2D>("laser");
            Texture2D chewbaccaTex = Content.Load<Texture2D>("chewbacca");
            Texture2D characterTex = Content.Load<Texture2D>("characters");
            Texture2D r2d2Tex = Content.Load<Texture2D>("R2D2");

            soundButtons.Add(new SoundButton(PadNames.Blue, SoundPlayer.SoundType.Laser, laserTex, new Vector2(300, 100)));
            soundButtons.Add(new SoundButton(PadNames.Red, SoundPlayer.SoundType.Wookie, chewbaccaTex, new Vector2(000, 000)));
            soundButtons.Add(new SoundButton(PadNames.Yellow, SoundPlayer.SoundType.Starwars, characterTex, new Vector2(100, 100)));
            soundButtons.Add(new SoundButton(PadNames.Green, SoundPlayer.SoundType.R2D2, r2d2Tex, new Vector2(500, 200)));
            soundButtons.Add(new SoundButton(PadNames.Bass, SoundPlayer.SoundType.Music, r2d2Tex, new Vector2(5000, 2000)));

            backgroundTex = Content.Load<Texture2D>("bg");
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

            drumPad.Update();
            foreach(SoundButton sndBtn in soundButtons)
            {
                sndBtn.Update(drumPad, soundPlayer);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTex, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            
            foreach (SoundButton sndBtn in soundButtons)
            {
                sndBtn.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
