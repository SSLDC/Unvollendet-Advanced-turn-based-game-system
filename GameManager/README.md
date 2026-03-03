# Turn-Based Combat System

## English

This module implements the main combat system of the game, combining turn mechanics, animation control, UI management, and game state logic.

The system is designed to coordinate multiple subsystems during combat, including characters, boss enemy behavior, UI components, and narrative flow.

---

## Turn System

Combat is based on a turn system controlled using a boolean array structure:

- Player turn control  
- Boss turn control  
- Automatic turn rotation  

The system uses counters and modular state progression to move between combat phases.

---

## Animation System

Animations for both player and boss are managed using `Animator` components.

Main features:

- Animation triggering using animation parameters  
- Waiting for animation completion using coroutines  
- Synchronization between animation and combat logic  
- Narrative transition control during combat  

This approach allows combat flow to depend on ongoing animations.

---

## Boss AI Control

Boss behavior is based on controlled randomness selection:

- Attack selection between two possible attack animations  
- Execution synchronized with turn system  
- Coroutine-based waiting for animation completion  

This introduces variability in enemy behavior while maintaining structured logic.

---

## User Interface Management

The system dynamically controls combat UI panels including:

- Command panels  
- Magic and item panels  
- Tutorial overlays  
- Defeat panel  
- Status information panels  

UI elements are activated or deactivated based on combat state.

---

## Game Over and Death System

The system continuously monitors character survival state.

If all player characters are defeated:

- Game time is stopped  
- Defeat panel is displayed  
- Item reward logic is adjusted based on battle outcome  

---

## General Combat Flow

1. Character, boss, and UI initialization  
2. Tutorial phase activation  
3. Player turn execution  
4. Animation completion waiting  
5. Boss turn with randomized attack selection  
6. Health state verification  
7. Game termination if necessary  

---

## Design Approach

- Component-based architecture  
- Separation of combat logic, animation, and UI  
- Coroutine-based temporal synchronization  
- State-driven game flow control  

---

## Español

# Sistema de Combate por Turnos

Este módulo implementa el sistema principal de combate del juego, combinando mecánicas de turnos, control de animaciones, gestión de interfaz y lógica de estado de la partida.

El sistema está diseñado para coordinar múltiples subsistemas durante el combate, incluyendo personajes, comportamiento del jefe enemigo, interfaz de usuario y flujo narrativo.

---

## Sistema de Turnos

El combate se basa en un sistema de turnos controlado mediante un arreglo booleano:

- Control del turno del jugador  
- Control del turno del jefe  
- Rotación automática de turnos  

El sistema utiliza contadores y progresión modular de estados para avanzar entre fases del combate.

---

## Sistema de Animaciones

Las animaciones del jugador y del jefe se gestionan mediante componentes `Animator`.

Características principales:

- Activación de animaciones mediante parámetros  
- Espera de finalización de animaciones usando coroutines  
- Sincronización entre animación y lógica de combate  
- Control de transición narrativa durante el combate  

Este enfoque permite que el flujo del combate dependa del estado de las animaciones.

---

## Control de IA del Jefe

El comportamiento del jefe se basa en selección aleatoria controlada:

- Selección de ataque entre dos posibles animaciones  
- Ejecución sincronizada con el sistema de turnos  
- Espera del final de la animación mediante coroutines  

Esto introduce variabilidad en el enemigo manteniendo un comportamiento estructurado.

---

## Gestión de Interfaz de Usuario

El sistema controla dinámicamente los paneles de combate:

- Paneles de comandos  
- Panel de magia y objetos  
- Tutoriales  
- Panel de derrota  
- Información de estado  

Los elementos de interfaz se activan o desactivan según el estado del combate.

---

## Sistema de Fin de Partida y Muerte

El sistema monitorea continuamente el estado de los personajes.

Si todos los jugadores son derrotados:

- Se detiene el tiempo del juego  
- Se muestra el panel de derrota  
- Se ajusta la lógica de recompensas según el resultado de la batalla  

---

## Flujo General del Combate

1. Inicialización de personajes, jefe y UI  
2. Activación de fase tutorial  
3. Ejecución del turno del jugador  
4. Espera de finalización de animaciones  
5. Turno del jefe con selección aleatoria de ataque  
6. Verificación del estado de vida  
7. Finalización de la partida si es necesario  

---

## Enfoque de Diseño

- Arquitectura basada en componentes  
- Separación de lógica de combate, animación e interfaz  
- Sincronización temporal mediante coroutines  
- Control de flujo mediante estados de juego  
