using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

internal class InputHelper
{
    MouseState currentMouseState, previousMouseState;
    KeyboardState currentKeyboardState, previousKeyboardState;


    public Vector2 MousePosition
    {
        get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
    }

    public void Update()
    {
        previousMouseState = currentMouseState;
        currentMouseState = Mouse.GetState();


        previousKeyboardState = currentKeyboardState;
        currentKeyboardState = Keyboard.GetState();
    }

    public bool KeyPressed(Keys k)
    {
        return currentKeyboardState.IsKeyDown(k);
    }

    public bool MouseLeftButtonPressed()
    {
        return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
    }
}
