# Pong
Este es el primer juego que desarrollo para aprender a crear videojuegos 2D utilizando C# en MonoGame

# Visualización del juego creado


https://github.com/user-attachments/assets/c2d411f4-6ee5-4a35-b0d0-1c617195ca27




# Metas
- [X] Boton de reinicio, contador
- [X] Modo 2 Jugadores 
- [X] Sonidos (Pelota rebota, Pelota sale de la ventana, música de fondo)
- [X] Pelota que rebota con los jugadores y las paredes
- [X] Detectar cuando la pelota pasa de la ventana y entregar puntaje al contador del Jugador1 o Jugador2

# Que he aprendido
- Separar el juego en distintas clases, instanciando todo en una clase "GameWorld" que representa el mundo del juego
- Cada objeto dentro del juego tiene su propia clase con sus respectivos comportamientos
- Documentar código
- Cargar y dibujar (Texture2D, Content.Load<>, SpriteBatch (Begin(), Draw(), End()))
- Estado del Teclado y Mouse (MouseState, KeyboardState, Mouse.GetState(), Keyboard.GetState())
- Propiedades
- Miembros Variables
- Asignar un tamaño especifico a la ventana del juego y aplicarla (GraphicsDeviceManager, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, _graphics.ApplyChanges())
- Dibujar texto de una fuente y calcular el origen del texto para centrarlo (SpriteFont, _spriteBatch.DrawString(), MeasureString(string) / 2)
- Crear Rectangulos y crear rectangulos con el tamaño de un Sprite (struct Rectangle, new Rectangle(int (pos_x), int (pos_y), int (width) , int (height), Sprite.Bounds-> devuelve el rectangulo con las dimensiones del sprite,  )
- Colisiones entre Rectangulos, es decir se superponen (Rectangle.Intersects(Rectangle))
- Reproducir Sonidos (SoundEffect, SoundEffect.Play(float volumen, float pitch, float pan)
- Reproducir Canciones (MediaPlayer, Song, MediaPlayer.Volume = float, MediaPlayer.IsRepeating = bool, MediaPlayer.Play(Song))
- Uso de gameTime.ElapsedGameTime.TotalSeconds para manejar el juego mediante DeltaTime y volverlo independiente de las veces que se actualiza el bucle del Juego (pasar de pixeles por frame a pixeles por segundo)
- Normalizar Vectores, posiciones relativas entre objetos para asignar donde ocurrio el golpe.

# Assets Usados
- Musica de fondo de https://pixabay.com/es/music/optimista-game-8-bit-399898/
- Sonido de rebote de la pelota https://pixabay.com/es/sound-effects/pel%C3%ADculas-y-efectos-especiales-toonboing-mcu-electronic-nicholas-judy-tdc-488797/
- Sonido de gol https://pixabay.com/es/sound-effects/pel%C3%ADculas-y-efectos-especiales-8-bit-level-win-584217/
- Dibujos por mi en Aseprite
