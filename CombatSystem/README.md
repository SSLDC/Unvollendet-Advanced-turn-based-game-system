# Sistema Completo de Combate por Turnos

Este módulo implementa el sistema central de combate del juego, incluyendo gestión de turnos, inteligencia básica del jefe, uso de magias, control de animaciones y manejo de recursos del jugador.

El sistema está diseñado siguiendo un enfoque por componentes, donde cada clase se encarga de una responsabilidad específica dentro del flujo de combate.

---

## Sistema de Combate y Flujo de Turnos

El combate se basa en un sistema estructurado de turnos que controla:

- Acción del jugador
- Acción del jefe enemigo
- Sincronización con animaciones
- Control de entrada del usuario

El flujo del combate se gestiona mediante contadores y banderas de estado para asegurar transiciones coherentes entre acciones.

---

## Sistema de IA Básica del Jefe

Uno de los elementos más relevantes del proyecto es la implementación de una lógica de decisión para el jefe enemigo.

La IA del jefe:

- Evalúa el estado de los jugadores antes de atacar
- Selecciona objetivos de forma probabilística y contextual
- Puede priorizar jugadores con menor vida o estados específicos
- Introduce variabilidad mediante factores aleatorios controlados

No se trata de un sistema aleatorio simple, sino de una selección de comportamiento basada en condiciones del combate.

---

## Sincronización de Animaciones

El sistema coordina la lógica de combate con la presentación visual mediante `Animator` y coroutines.

Características:

- Espera la finalización de animaciones antes de continuar el turno
- Control de transiciones narrativas del combate
- Ejecución de acciones después de los efectos visuales

Esto permite mantener coherencia entre mecánica y representación gráfica.

---

## Sistema de Magias

Se implementa un sistema de habilidades especiales con:

- Diferentes hechizos con potencias independientes
- Costes de PM asociados
- Daño estratégico al jefe enemigo
- Recuperación de vida y recursos

Las magias funcionan como acciones de combate estructuradas dentro del turno del jugador.

---

## Gestión de Recursos del Jugador

El sistema controla:

- Vida
- Maná 
- Límite de ataque especial
- Estados de defensa
- Estado de muerte

Incluye:

- Barras de interfaz actualizadas en tiempo real
- Feedback visual al recibir daño
- Control de estados críticos del personaje

---

## Enfoque Arquitectónico

El proyecto está desarrollado siguiendo un modelo de:

- Programación orientada a componentes  
- Separación de lógica de combate, animación e interfaz  
- Control de flujo mediante estados  
- Uso de coroutines para sincronización temporal  

---

## Qué demuestra este sistema

Este módulo refleja capacidad para:

- Diseñar sistemas de combate interactivos  
- Coordinar múltiples subsistemas del juego  
- Implementar lógica de decisión básica para enemigos  
- Manejar estados de juego complejos  
- Controlar flujo narrativo mediante código  
