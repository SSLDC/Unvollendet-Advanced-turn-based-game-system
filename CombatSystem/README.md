# Complete Turn-Based Combat System

## English

This module implements the core combat system of the game, including turn management, basic boss AI behavior, magic usage, animation synchronization, and player resource handling.

The system follows a component-based approach where each class is responsible for a specific aspect of the combat flow.

---

## Turn-Based Combat Flow

The combat is structured around a turn-based system that controls:

- Player actions  
- Enemy boss actions  
- Animation synchronization  
- User input handling  

Combat flow is managed using state flags and counters to ensure coherent transitions between actions.

---

## Basic Boss AI System

One of the most relevant elements of the project is the implementation of decision logic for the enemy boss.

The boss AI:

- Evaluates player states before attacking  
- Selects targets probabilistically and contextually  
- May prioritize players with lower health or specific states  
- Introduces variability through controlled randomness  

This is not a simple random system, but a condition-based behavioral selection mechanism.

---

## Animation Synchronization

The system coordinates combat logic with visual presentation using `Animator` components and coroutines.

Features include:

- Waiting for animation completion before continuing turns  
- Combat narrative transition control  
- Execution of actions after visual effects  

This maintains consistency between gameplay mechanics and graphical representation.

---

## Magic System

A skill system is implemented with:

- Multiple spells with independent power values  
- Associated mana costs  
- Strategic damage output against the enemy boss  
- Health and resource recovery mechanics  

Spells function as structured combat actions within the player's turn.

---

## Player Resource Management

The system tracks and controls:

- Health  
- Mana  
- Special attack limits  
- Defense state  
- Death state  

Includes:

- Real-time UI bar updates  
- Visual feedback when receiving damage  
- Critical state monitoring  

---

## Architectural Approach

The project is developed following:

- Component-oriented programming  
- Separation of combat, animation, and UI logic  
- State-based flow control  
- Coroutine-based temporal synchronization  

---

## What This System Demonstrates

This module reflects the ability to:

- Design interactive combat systems  
- Coordinate multiple gameplay subsystems  
- Implement basic enemy decision logic  
- Manage complex game states  
- Control narrative flow through code  

---

## Español

# Sistema Completo de Combate por Turnos

Este módulo implementa el sistema principal de combate del juego, incluyendo gestión de turnos, comportamiento básico de IA del jefe, uso de magias, sincronización de animaciones y manejo de recursos del jugador.

El sistema sigue un enfoque basado en componentes, donde cada clase se encarga de una responsabilidad específica dentro del flujo de combate.

---

## Flujo de Combate por Turnos

El combate se estructura mediante un sistema de turnos que controla:

- Acciones del jugador  
- Acciones del jefe enemigo  
- Sincronización de animaciones  
- Manejo de entrada del usuario  

El flujo se gestiona mediante banderas de estado y contadores para asegurar transiciones coherentes.

---

## Sistema Básico de IA del Jefe

Uno de los elementos más relevantes del proyecto es la implementación de lógica de decisión para el jefe enemigo.

La IA del jefe:

- Evalúa el estado de los jugadores antes de atacar  
- Selecciona objetivos de forma probabilística y contextual  
- Puede priorizar jugadores con menor vida o estados específicos  
- Introduce variabilidad mediante aleatoriedad controlada  

No se trata de un sistema aleatorio simple, sino de un mecanismo de selección basado en condiciones del combate.

---

## Sincronización de Animaciones

El sistema coordina la lógica de combate con la presentación visual mediante componentes `Animator` y coroutines.

Incluye:

- Espera de finalización de animaciones antes de continuar los turnos  
- Control de transiciones narrativas del combate  
- Ejecución de acciones después de efectos visuales  

Esto mantiene coherencia entre mecánicas de juego y representación gráfica.

---

## Sistema de Magias

Se implementa un sistema de habilidades con:

- Diferentes hechizos con potencias independientes  
- Costes de maná asociados  
- Daño estratégico contra el jefe enemigo  
- Mecánicas de recuperación de recursos  

Las magias funcionan como acciones estructuradas dentro del turno del jugador.

---

## Gestión de Recursos del Jugador

El sistema controla:

- Vida  
- Maná  
- Límites de ataque especial  
- Estados de defensa  
- Estado de muerte  

Incluye:

- Actualización en tiempo real de barras UI  
- Retroalimentación visual al recibir daño  
- Monitorización de estados críticos  

---

## Enfoque Arquitectónico

El proyecto se desarrolla siguiendo:

- Programación orientada a componentes  
- Separación de lógica de combate, animación e interfaz  
- Control de flujo basado en estados  
- Sincronización temporal mediante coroutines  

---

## Qué demuestra este sistema

Este módulo refleja la capacidad de:

- Diseñar sistemas de combate interactivos  
- Coordinar múltiples subsistemas de juego  
- Implementar lógica básica de decisión enemiga  
- Gestionar estados complejos del juego  
- Controlar flujo narrativo mediante código  
