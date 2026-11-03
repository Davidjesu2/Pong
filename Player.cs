using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

internal class Player
{
    private Texture2D playerSprite;
    private InputHelper inputHelper;
    public int PlayerID { get; private set; }
    public int Score { get;  set; }
    public Vector2 Position { get; private set; }
    public Vector2 Velocity { get; private set; }

    /// <summary>
    /// Esta propiedad devuelve un rectangulo con el tamaño del sprite
    /// </summary>
    public Rectangle BoundingBox
    {
        get
        {
            Rectangle spriteBounds = playerSprite.Bounds;
            spriteBounds.Offset(Position);
            return spriteBounds;
        }
    }


    public void Reset()
    {
        if (PlayerID == 1)
        {
            Position = new Vector2(0, 400);
        }
        else if (PlayerID == 2)
        {
            Position = new Vector2(950, 400);
        }
        Velocity = new Vector2(0, 600);

        Score = 0;
    }

    /// <summary>
    /// Maneja el Input del jugador
    /// </summary>
    private void HandleInput(GameTime gameTime)
    {
        inputHelper.Update();
        float deltatime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (PlayerID == 1)
        {
            if (inputHelper.KeyPressed(Keys.S) && (Position.Y < 600) && !inputHelper.KeyPressed(Keys.W))
            {
                Position += Velocity * deltatime;
            }
            else if (inputHelper.KeyPressed(Keys.W) && (Position.Y > 0) && !inputHelper.KeyPressed(Keys.S))
            {
                Position -= Velocity * deltatime;
            }
        }
        else
        {
            if (inputHelper.KeyPressed(Keys.Down) && (Position.Y < 600) && !inputHelper.KeyPressed(Keys.Up))
            {
                Position += Velocity * deltatime;
            }
            else if (inputHelper.KeyPressed(Keys.Up) && (Position.Y > 0) && !inputHelper.KeyPressed(Keys.Down))
            {
                Position -= Velocity * deltatime;
            }
        }
    }

    /// <summary>
    /// Inicializa un Player
    /// </summary>
    /// <param name="content"></param>
    /// <param name="playerID">Identificador del jugador 1 o 2</param>
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
        
        Velocity = new Vector2(0, 600);
        playerSprite = content.Load<Texture2D>("Player");
        inputHelper = new InputHelper();
    }

    /// <summary>
    /// Actualiza el estado del jugador
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime)
    {
        HandleInput(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(playerSprite, Position, Color.White);
    }
}

