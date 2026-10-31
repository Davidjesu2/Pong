using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class GameWorld
{
    Player player1, player2;
    Ball ball;

    SpriteFont score;
    Rectangle left, right, top, bot;

    internal GameWorld(ContentManager content)
    {
        ball = new Ball(content);
        player1 = new Player(content, 1, ball);
        player2 = new Player(content, 2, ball);
        top = new Rectangle(0, 0, 1000, 0);
        bot = new Rectangle(0, 800, 1000, 0);
        left = new Rectangle(-100, 0, 0, 800);
        right = new Rectangle(1100, 0, 0, 800);
    }

    public void Update(GameTime gameTime)
    {
        player1.Update(gameTime);
        player2.Update(gameTime);
        ball.Update(gameTime);


        // Comprobar colisiones con jugadores
        if (ball.BoundingBox.Intersects(player1.BoundingBox))
        {
           
            ball.Bounce();
        }

        else if (ball.BoundingBox.Intersects(player2.BoundingBox))
        {
            ball.Bounce();
        }


        // Comprobar colisiones con paredes
        if (ball.BoundingBox.Intersects(top))
        {
            ball.VerticalBounce();
        }

        if (ball.BoundingBox.Intersects(bot))
        {
            ball.VerticalBounce();
        }

        if (ball.BoundingBox.Intersects(left))
        {
            ball.Reset();
        }

        if (ball.BoundingBox.Intersects(right))
        {
            ball.Reset();
        }


    }

    public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Begin();
        player1.Draw(gameTime, _spriteBatch);
        player2.Draw(gameTime, _spriteBatch);
        ball.Draw(gameTime, _spriteBatch);
        _spriteBatch.End();
    }



}

