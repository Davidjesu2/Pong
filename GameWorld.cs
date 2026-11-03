using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

internal class GameWorld
{
    Player player1, player2;
    Ball ball;
    SpriteFont scoreFont;
    Texture2D line;

    SoundEffect goalSound;

    Song backgroundSong; 

    Rectangle left, right, top, bot;

    /// <summary>
    /// Comprueba si ocurrio una colision de la pelota en el juego y actua dependiendo de la colision que ocurrio
    /// </summary>
    /// <param name="ball"></param>
    /// <param name="player1"></param>
    /// <param name="player2"></param>
    private void BallCollision(Ball ball, Player player1, Player player2)
    {
        // Comprobar colisiones con jugadores y reproducir sonido
        if (ball.BoundingBox.Intersects(player1.BoundingBox))
        {
            ball.Bounce();
            ball.PlayBoingSound();
        }

        else if (ball.BoundingBox.Intersects(player2.BoundingBox))
        {
            ball.Bounce();
            ball.PlayBoingSound();
        }


        // Comprobar colisiones con paredes y reproducir sonido
        if (ball.BoundingBox.Intersects(top))
        {
            ball.VerticalBounce();
            ball.PlayBoingSound();
        }

        if (ball.BoundingBox.Intersects(bot))
        {
            ball.VerticalBounce();
            ball.PlayBoingSound();
        }

        if (ball.BoundingBox.Intersects(left))
        {
            GoalSound();
            ball.Reset();
            player2.Score += 1;
        }

        if (ball.BoundingBox.Intersects(right))
        {
            GoalSound();
            ball.Reset();
            player1.Score += 1;
        }
    }

    /// <summary>
    /// Reproduce sonido de Gol
    /// </summary>
    private void GoalSound()
    {
        goalSound.Play(0.2f, 0f, 0f);
    }

    /// <summary>
    /// Inicializa la instancia GameWorld
    /// </summary>
    /// <param name="content"></param>
    internal GameWorld(ContentManager content)
    {
        // Inicializar objetos del juego

        ball = new Ball(content);
        player1 = new Player(content, 1);
        player2 = new Player(content, 2);

        // Rectangulos para las colisiones

        top = new Rectangle(0, 0, 1000, 0);
        bot = new Rectangle(0, 800, 1000, 0);
        left = new Rectangle(-100, 0, 0, 800);
        right = new Rectangle(1100, 0, 0, 800);

        // Cargar Texturas y Sonidos
        scoreFont = content.Load<SpriteFont>("File");
        line = content.Load<Texture2D>("Line");
        goalSound = content.Load<SoundEffect>("Goal");
        backgroundSong = content.Load<Song>("Sound");

        // Configurar la música
        MediaPlayer.Volume = 0.1f;
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Play(backgroundSong);
    }

    public void Update(GameTime gameTime)
    {
        // Actualizar el estado de cada objeto
        player1.Update(gameTime);
        player2.Update(gameTime);
        ball.Update(gameTime);

        // Comprobar si ocurrio una colision entre la pelota y reproducir sonido
        BallCollision(ball, player1, player2);



    }

    public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Begin();

        // Dibujo linea divisoria
        _spriteBatch.Draw(
            texture: line,
            position: new Vector2(500, 0),
            sourceRectangle: null,
            color: Color.White,
            rotation: 0,
            origin: new Vector2(line.Width / 2, 0),
            scale: 1.0f,
            effects: SpriteEffects.None,
            layerDepth: 0f
        );

        // Dibujo Score
        Vector2 FontOriginOne = scoreFont.MeasureString(player1.Score.ToString()) / 2;
        Vector2 FontOriginTwo = scoreFont.MeasureString(player2.Score.ToString()) / 2;
        
        _spriteBatch.DrawString(scoreFont, player1.Score.ToString(), new Vector2(250, 200), Color.White, 0, FontOriginOne, 1.0f, SpriteEffects.None, 0.5f);
        _spriteBatch.DrawString(scoreFont, player2.Score.ToString(), new Vector2(750, 200), Color.White, 0, FontOriginTwo, 1.0f, SpriteEffects.None, 0.5f);

        // Llamada a los Draw de cada objeto
        player1.Draw(gameTime, _spriteBatch);
        player2.Draw(gameTime, _spriteBatch);
        ball.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();
    }

}

