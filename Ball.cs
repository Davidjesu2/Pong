
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework.Audio;

internal class Ball
{
    // Miembro Variables
    Texture2D ballSprite;

    SoundEffect boingSound;
    
    // Propiedades

    /// <summary>
    /// Esta propiedad representa la posición de la pelota
    /// </summary>
    public Vector2 Position { get; private set; }

    /// <summary>
    /// Esta propiedad representa la velocidad de la pelota en X e Y
    /// </summary>
    public Vector2 Velocity { get; private set; }

    /// <summary>
    /// Esta propiedad devuelve el rectangulo del sprite de la pelota
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


    /// <summary>
    /// Este método maneja los rebotes de la pelota con los jugadores
    /// </summary>
    public void Bounce()
    {
        Position = new Vector2(Position.X - Velocity.X, Position.Y);
        Velocity = new Vector2((Velocity.X)*-1, Velocity.Y);
        BoingSound();
    }

    /// <summary>
    /// Este método maneja los rebotes de la pelota con las paredes
    /// </summary>
    public void VerticalBounce()
    {
        Position = new Vector2(Position.X, Position.Y - Velocity.Y);
        Velocity = new Vector2(Velocity.X, Velocity.Y * -1);
        BoingSound();
    }



    /// <summary>
    /// Este método actualiza la posición de la pelota
    /// </summary>
    private void BallUpdatePosition()
    {
        Position += Velocity;
    }

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
    /// Reproduce el sonido de rebote de la pelota
    /// </summary>
    private void BoingSound()
    {
        boingSound.Play(0.8f, 2.5f, 0.0f);
    }




}

