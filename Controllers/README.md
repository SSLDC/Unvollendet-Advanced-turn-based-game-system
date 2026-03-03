# Game Infrastructure System

## English

This module is responsible for global management of scenes, audio, and narrative sequences within the game.

It includes visual transition control, ambient music playback, and cinematic event handling such as game endings.

---

## Scene Transition System

A visual transition system is implemented for scene loading using animations and coroutines.

Main features:

- Fade effect activation before scene switching  
- Execution time control to synchronize animations  
- Gameplay flow management during loading  

This system improves user experience by preventing abrupt scene changes.

---

## Intelligent Music Control

The audio system maintains or stops music playback depending on the current scene.

Scene lists are used to define:

- Scenes where music should continue playing  
- Scenes where music should stop  

Behavior is updated dynamically when the player changes scenes.

The Singleton pattern is used to ensure music persistence when required.

---

## Video Sequence Control

Cinematic sequence playback is managed using `VideoPlayer`.

When a video finishes:

- End-of-playback events are detected  
- Narrative state flags are updated  
- Transition to the next scene is executed  

Narrative completion states are also tracked for:

- Ending A  
- Ending B  

This enables support for multiple narrative endings within the game.

---

## Contribution of This System to the Project

This module demonstrates the ability to:

- Design global game controllers  
- Synchronize audio, video, and narrative flow  
- Implement basic object persistence patterns  
- Manage interactive story states  

---

## Español

# Sistema de Infraestructura del Juego

Este módulo se encarga de la gestión global de escenas, audio y secuencias narrativas del juego.

Incluye el control de transiciones visuales, reproducción de música ambiental y manejo de eventos cinematográficos como los finales del juego.

---

## Sistema de Transición entre Escenas

Se implementa un sistema de transición visual para la carga de escenas mediante animaciones y coroutines.

Características principales:

- Activación del efecto Fade antes del cambio de escena  
- Control del tiempo de ejecución para sincronizar animaciones  
- Gestión del flujo de juego durante la carga  

Este sistema mejora la experiencia del usuario evitando cambios bruscos entre escenas.

---

## Control Inteligente de Música

El sistema de audio mantiene o detiene la música dependiendo de la escena actual.

Se utilizan listas de escenas para definir:

- Escenas donde la música debe continuar reproduciéndose  
- Escenas donde la música debe detenerse  

El comportamiento se actualiza dinámicamente cuando el jugador cambia de escena.

Se implementa el patrón Singleton para garantizar la persistencia del audio cuando sea necesario.

---

## Control de Secuencias de Video

La reproducción de secuencias cinematográficas se gestiona mediante `VideoPlayer`.

Cuando un video finaliza:

- Se detecta el evento de finalización  
- Se actualizan banderas de estado narrativo  
- Se ejecuta la transición a la siguiente escena  

También se registran estados de finalización para:

- Final A  
- Final B  

Esto permite soportar múltiples finales narrativos dentro del juego.

---

## Aporte de este Sistema al Proyecto

Este módulo demuestra la capacidad para:

- Diseñar controladores globales del juego  
- Sincronizar audio, video y flujo narrativo  
- Implementar patrones básicos de persistencia de objetos  
- Gestionar estados de historia interactiva  
