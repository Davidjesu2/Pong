
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

internal class Ball
{
    Texture2D ballSprite;
    
    public Vector2 Position { get; private set; }

    public Vector2 Velocity { get; private set; }

    public Rectangle BoundingBox
    {
        get
        {
            Rectangle spriteBounds = ballSprite.Bounds;
            spriteBounds.Offset(Position);
            return spriteBounds;
        }
    }


    public void Bounce()
    {
        Position = new Vector2(Position.X - Velocity.X, Position.Y);
        Velocity = new Vector2((Velocity.X)*-1, Velocity.Y);
    }

    public void VerticalBounce()
    {
        Position = new Vector2(Position.X, Position.Y - Velocity.Y);
        Velocity = new Vector2(Velocity.X, Velocity.Y * -1);
    }


    private void BallUpdatePosition()
    {
        Position += Velocity;
    }

    public Ball(ContentManager content)
    {
        ballSprite = content.Load<Texture2D>("Ball");
        Position = new Vector2(500, 400);
        Velocity = new Vector2(20, 5);
    }

    public void Update(GameTime gameTime)
    {
        BallUpdatePosition();
    }

    public void Draw(GameTime gametime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(ballSprite, Position, Color.White);
    }

    public void Reset()
    {
        Position = new Vector2(500, 400);

        int x = Random.Shared.Next(0, 2) == 0 ? 1 : -1;
        int y = Random.Shared.Next(0, 2) == 0 ? 1 : -1;
        Velocity = new Vector2(20 * x, 5 * y);
    }




}

