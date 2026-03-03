# Sistema de Combate por Turnos

Este módulo implementa el sistema principal de combate del juego, combinando mecánicas de turnos, control de animaciones, gestión de interfaz y lógica de estado de partida.

El sistema está diseñado para coordinar múltiples subsistemas durante el combate, incluyendo personajes, jefe enemigo, UI y flujo narrativo.

---

## Sistema de Turnos

El combate se basa en un sistema de turnos controlado mediante un array booleano:

- Control de turno del jugador
- Control de turno del jefe
- Rotación automática de turnos

El sistema utiliza contadores y modularidad para avanzar entre estados de combate.

---

## Sistema de Animaciones

Se gestionan animaciones tanto del jugador como del jefe mediante `Animator`.

Características principales:

- Activación de animaciones mediante triggers
- Espera a la finalización de animaciones usando coroutines
- Sincronización entre animaciones y lógica de combate
- Control de transición narrativa durante el combate

Este enfoque permite que el flujo del combate dependa de las animaciones en ejecución.

---

## Control de IA del Jefe

El comportamiento del jefe se basa en selección aleatoria controlada:

- Selección de ataque entre dos posibles animaciones
- Ejecución sincronizada con el sistema de turnos
- Uso de coroutines para esperar el final de la animación

Esto permite generar variabilidad en el comportamiento del enemigo.

---

## Gestión de Interfaz de Usuario

El sistema controla dinámicamente los paneles de combate:

- Paneles de comandos
- Panel de magia y objetos
- Tutoriales
- Panel de derrota
- Información de estado

Los elementos UI se activan o desactivan según el estado del combate.

---

## Sistema de Muerte y Fin de Partida

El sistema verifica continuamente el estado de los personajes.

Si todos los jugadores están muertos:

- Se detiene el tiempo del juego
- Se muestra el panel de derrota
- Se ajustan recompensas de items según la batalla actual

---

## Flujo General del Combate

1. Inicialización de personajes, jefes y UI  
2. Control del tutorial inicial  
3. Ejecución del turno del jugador  
4. Espera de finalización de animación  
5. Turno del jefe con ataque aleatorio  
6. Verificación de estado de vida  
7. Finalización de partida si es necesario  

---

## Enfoque de Diseño

- Arquitectura basada en componentes  
- Separación entre lógica de combate, animaciones y UI  
- Uso de coroutines para sincronización temporal  
- Control de flujo mediante estados de juego  
