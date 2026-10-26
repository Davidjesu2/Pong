using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

internal class GameWorld
{
    Player player1, player2;

    public GameWorld(ContentManager content)
    {
        player1 = new Player(content, 1);
        player2 = new Player(content, 2);

    }

    public void Update(GameTime gameTime)
    {
        player1.Update(gameTime);
        player2.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
    {
        _spriteBatch.Begin();
        player1.Draw(gameTime, _spriteBatch);
        player2.Draw(gameTime, _spriteBatch);
        _spriteBatch.End();
    }



}

