# Sistema de Infraestructura del Juego

Este módulo se encarga de la gestión global de escenas, audio y secuencias narrativas del juego.

Incluye control de transiciones visuales, reproducción de música ambiental y manejo de eventos cinematográficos como los finales del juego.

---

## Sistema de Transición entre Escenas

Se implementa un sistema de transición visual para la carga de escenas utilizando animaciones y corrutinas.

Características principales:

- Activación de efectos Fade antes de cambiar de escena
- Control del tiempo de ejecución para sincronizar animaciones
- Gestión del flujo de juego durante la carga

Este sistema mejora la experiencia del usuario al evitar cambios bruscos entre escenas.

---

## Control Inteligente de Música

El sistema de audio mantiene o detiene la música dependiendo de la escena actual.

Se utilizan listas de escenas para definir:

- Escenas donde la música debe continuar reproduciéndose
- Escenas donde la música debe detenerse

El comportamiento se actualiza dinámicamente cuando el jugador cambia de escena.

Se implementa el patrón Singleton para asegurar que la música persista cuando sea necesario.

---

## Control de Secuencias de Video

Se gestiona la reproducción de escenas cinematográficas mediante `VideoPlayer`.

Cuando un video termina:

- Se detecta el evento de finalización
- Se actualizan banderas de estado narrativo
- Se ejecuta la transición hacia la siguiente escena

También se registran estados de finalización para:

- Final A  
- Final B  

Esto permite soportar múltiples finales narrativos dentro del juego.

---

## Qué aporta este sistema al proyecto

Este módulo demuestra la capacidad para:

- Diseñar controladores globales del juego  
- Sincronizar audio, vídeo y flujo narrativo  
- Implementar patrones básicos de persistencia de objetos  
- Gestionar estados de historia interactiva  
