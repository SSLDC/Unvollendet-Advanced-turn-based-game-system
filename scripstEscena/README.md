# Sistema Narrativo y de Conversaciones Interactivas

Este módulo implementa el sistema de diálogos interactivos del juego, incluyendo escenas cinematográficas, control de narrativa y reproducción de videos dentro de la historia.

---

## Sistema de Conversaciones

Se desarrolló un sistema de diálogos basado en texto secuencial, donde el jugador puede avanzar la historia mediante:

- Pulsación de teclas
- Control del flujo narrativo
- Cambios dinámicos de interfaz

El sistema permite estructurar la historia en bloques narrativos.

---

## Integración de Video Narrativo

Se implementó un sistema de reproducción de secuencias cinematográficas usando `VideoPlayer`.

Características principales:

- Reproducción de videos dentro de la narrativa
- Detección del evento de finalización del video
- Bloqueo temporal del input del jugador durante la reproducción
- Continuación automática de la conversación después del video

Los videos se utilizan para reforzar momentos importantes de la historia.

---

## Gestión de Personajes y Narrativa Visual

El sistema controla:

- Cambio de nombres de personajes en pantalla
- Modificación de colores de interfaz según el hablante
- Animaciones del jefe durante la conversación

Se implementa un patrón de control de estado para sincronizar:

- Diálogo  
- Animación  
- Video  
- Flujo de escena  

---

## Qué aporta este sistema al proyecto

Este módulo demuestra habilidades en:

- Desarrollo de sistemas narrativos interactivos  
- Sincronización entre UI, animación y reproducción de video  
- Control de flujo de juego mediante eventos  
- Diseño de experiencias cinemáticas interactivas  
