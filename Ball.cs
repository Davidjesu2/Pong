using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System;


internal class Ball
{
    Texture2D ballSprite;
    SoundEffect boingSound;

    public Vector2 Position { get; private set; }
    public Vector2 Velocity { get; private set; }

    /// <summary>
    /// Esta propiedad devuelve un rectangulo con el tamaño del sprite
    /// </summary>
    public Rectangle BoundingBox
    {
        get
        {
            Rectangle spriteBounds = ballSprite.Bounds;
            spriteBounds.Offset(Position);
            return spriteBounds;
        }
    }


    // Métodos para el comportamiento de la pelota
    // ----------------------------------------------------------------------------------

    // REBOTES
    /// <summary>
    /// Este método maneja los rebotes de la pelota con los jugadores
    /// </summary>
    public void Bounce(Rectangle paddleBounds)
    {
        bool esPaletaIzquierda = paddleBounds.X < Position.X;

        if (esPaletaIzquierda && Velocity.X > 0) return;
        if (!esPaletaIzquierda && Velocity.X < 0) return;

        float newX = -Velocity.X;
        float ballCenter = Position.Y + (ballSprite.Height / 2f);
        float relativeHitY = ballCenter - paddleBounds.Y;
        float hitFactor = (relativeHitY / paddleBounds.Height) * 2f - 1f;
        hitFactor = MathHelper.Clamp(hitFactor, -1f, 1f);

        float maxVerticalForce = 700f;
        float newY = hitFactor * maxVerticalForce;

        float currentSpeed = Velocity.Length();
        float newSpeed = MathF.Min(currentSpeed * 1.05f, 1500f);

        Vector2 newDirection = new Vector2(newX, newY);
        Velocity = Vector2.Normalize(newDirection) * newSpeed;

        if (esPaletaIzquierda)
        {
            Position = new Vector2(paddleBounds.Right + 1, Position.Y);
        }
        else
        {
            Position = new Vector2(paddleBounds.Left - ballSprite.Width - 1, Position.Y);
        }
    }

    /// <summary>
    /// Este método maneja los rebotes de la pelota con las paredes
    /// </summary>
    public void VerticalBounce()
    {
        Velocity = new Vector2(Velocity.X, -Velocity.Y);
    }

    // POSICION

    /// <summary>
    /// Este método reinicia la pelota en el centro y con una direccion en diagonal aleatoria
    /// </summary>
    public void Reset()
    {
        Position = new Vector2(500, 400);

        int x = Random.Shared.Next(0, 2) == 0 ? 1 : -1;
        int y = Random.Shared.Next(0, 2) == 0 ? 1 : -1;
        Velocity = new Vector2(600 * x, 100 * y);
    }

    /// <summary>
    /// Este método actualiza la posición de la pelota
    /// </summary>
    private void BallUpdatePosition(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Position += Velocity * deltaTime;
    }

    // SONIDO
    /// <summary>
    /// Reproduce el sonido de rebote de la pelota
    /// </summary>
    public void PlayBoingSound()
    {
        boingSound.Play(0.8f, 2.5f, 0.0f);
    }
    // ----------------------------------------------------------------------------------


    // Constructor 
    /// <summary>
    /// Inicializa una pelota
    /// </summary>
    /// <param name="content"></param>
    public Ball(ContentManager content)
    {
        ballSprite = content.Load<Texture2D>("Ball");
        Position = new Vector2(500, 400);
        Velocity = new Vector2(600, 100);
        boingSound = content.Load<SoundEffect>("Boing");
    }
    

    /// <summary>
    /// Este método maneja el estado actual de la pelota
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime)
    {
        BallUpdatePosition(gameTime);
    }



    /// <summary>
    /// Este método dibuja la pelota
    /// </summary>
    /// <param name="gametime"></param>
    /// <param name="_spriteBatch"></param>
    public void Draw(GameTime gametime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(ballSprite, Position, Color.White);
    }
}

