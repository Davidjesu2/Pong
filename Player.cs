using Microsoft.Xna.Framework;

internal class Player
{
    Vector2 Position
    {
        get { return Position; }
        set
        {
            if((value.Y < 800))
            {
                Position = value;
            }
        }
    }
    
    Vector2 Velocity
    {
        get { return Velocity; }
        set { Velocity = value; }
    }


    





}

