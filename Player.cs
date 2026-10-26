using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Mime;

internal class Player
{
    private Texture2D playerSprite;

    private InputHelper inputHelper;

    public int PlayerID { get; private set; }

    public Vector2 Position { get; private set; }

    public Vector2 Velocity { get; private set; }
    


    public Player(ContentManager content, int playerID)
    {
        PlayerID = playerID;


        if(playerID == 1)
        {
            Position = new Vector2(0, 400);
        }
        else if(playerID == 2)
        {
            Position = new Vector2(950, 400);
        }
        
        Velocity = new Vector2(0, 10);
        playerSprite = content.Load<Texture2D>("Player");
        inputHelper = new InputHelper();
    }


    public void Update(GameTime gameTime)
    {
        inputHelper.Update();

        if(PlayerID == 1)
        {
            if (inputHelper.KeyPressed(Keys.S) && (Position.Y < 600) && !inputHelper.KeyPressed(Keys.W))
            {
                Position += Velocity;
            }
            else if (inputHelper.KeyPressed(Keys.W) && (Position.Y > 0) && !inputHelper.KeyPressed(Keys.S))
            {
                Position -= Velocity;
            }
        }
        else
        {
            if (inputHelper.KeyPressed(Keys.Down) && (Position.Y < 600) && !inputHelper.KeyPressed(Keys.Up))
            {
                Position += Velocity;
            }
            else if (inputHelper.KeyPressed(Keys.Up) && (Position.Y > 0) && !inputHelper.KeyPressed(Keys.Down))
            {
                Position -= Velocity;
            }
        }

    }

    public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(playerSprite, Position, Color.White);
    }



}

