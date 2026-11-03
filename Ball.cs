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
    public void Bounce()
    {
        Position = new Vector2(Position.X - Velocity.X, Position.Y);
        Velocity = new Vector2((Velocity.X)*-1, Velocity.Y);
    }

    /// <summary>
    /// Este método maneja los rebotes de la pelota con las paredes
    /// </summary>
    public void VerticalBounce()
    {
        Position = new Vector2(Position.X, Position.Y - Velocity.Y);
        Velocity = new Vector2(Velocity.X, Velocity.Y * -1);
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
        Velocity = new Vector2(10 * x, 4 * y);
    }

    /// <summary>
    /// Este método actualiza la posición de la pelota
    /// </summary>
    private void BallUpdatePosition()
    {
        Position += Velocity;
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
        Velocity = new Vector2(10, 4);
        boingSound = content.Load<SoundEffect>("Boing");
    }
    

    /// <summary>
    /// Este método maneja el estado actual de la pelota
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime)
    {
        BallUpdatePosition();
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

