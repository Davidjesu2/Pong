# Pong
Este es el primer juego que estoy desarrollando para aprender a crear videojuegos 2D utilizando C# en MonoGame
(Tengo experiencia de unas semanas en C#)

# Metas
- Menú, boton de reinicio, contador
- Modo 2 Jugadores 
- Modo 1 Jugador + 1 IA
- Sonidos (Pelota rebota, Pelota sale de la ventana, música de fondo)
- Pelota que rebota con los jugadores y las paredes
- Detectar cuando la pelota pasa de la ventana y entregar puntaje al contador del Jugador1 o Jugador2





# Que he aprendido
- Separar el juego en distintas clases, instanciando todo en una clase "GameWorld" que representa el mundo del juego
- Cada objeto dentro del juego tiene su propia clase con sus respectivos comportamientos
- Documentar código
- Cargar y dibujar gráficos (Texture2D, Content.Load<>, SpriteBatch (Begin(), Draw(), End()))
- Estado del Teclado y Mouse (MouseState, KeyboardState, Mouse.GetState(), Keyboard.GetState())
- Propiedades
- Miembros Variables
- Asignar un tamano especifico a la ventana del juego y aplicarla (GraphicsDeviceManager, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, _graphics.ApplyChanges())



