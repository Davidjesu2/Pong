using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Pong : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D player1;

    private Vector2 position;

    private InputHelper inputHelper;

    public Pong()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        position = Vector2.Zero;
        inputHelper = new InputHelper();

        
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        player1 = Content.Load<Texture2D>("player");
        _graphics.PreferredBackBufferHeight = 800;
        _graphics.PreferredBackBufferWidth = 1000;
        _graphics.ApplyChanges();
    
    }

    protected override void Update(GameTime gameTime)
    {
        inputHelper.Update();

        if (inputHelper.KeyPressed(Keys.S) && (position.Y < 600) && !inputHelper.KeyPressed(Keys.W))
        {
            position.Y += 10;
        }
        else if (inputHelper.KeyPressed(Keys.W) && (position.Y > 0) && !inputHelper.KeyPressed(Keys.S))
        {
            position.Y -= 10;
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        _spriteBatch.Draw(player1, position, Color.White);
        _spriteBatch.End();




        base.Draw(gameTime);
    }
}

