# Boss Artificial Intelligence System

## English

This module implements the boss enemy behavior, including combat logic, target selection, and strategic damage processing.

The system is designed to generate decision-making behavior that is not based on simple random selection, but on evaluating character states before executing actions.

---

## Boss AI System

The most important feature of this system is the implementation of structured decision logic for boss behavior.

### How the AI Works

The boss does not select targets using pure randomness.

The system evaluates:

- Player characters' health values  
- Defense state of each player  
- Statistical comparison between characters  
- Relationship between combat participants  

The AI analyzes multiple conditions before deciding which target to attack.

---

## Behavior Selection

The boss can:

- Attack a specific player based on health state  
- Prioritize characters with lower health  
- Consider active defense states  
- Generate variability using controlled probability  

A restricted critical randomness factor is used within defined ranges to avoid predictable behavior.

---

## Strategic Combat System

Combat is based on conditional state processing.

Logic includes:

- Structured traversal of player lists using `LinkedList`  
- Evaluation of multiple simultaneous conditions  
- Dynamic target selection  
- Probabilistic critical damage calculation  

---

## Animation and Visual Feedback Management

The system synchronizes combat logic with visual presentation:

- Boss attack animations  
- Damage reaction animations  
- Damage information UI panel  
- Smooth transitions between combat states  

This maintains coherence between gameplay mechanics and graphical representation.

---

## Death and Scene Transition System

When the boss is defeated:

- Death animation is played  
- Visual transition is executed  
- Persistent audio objects are managed  
- Game progression state is updated  
- Item rewards are unlocked based on battle outcome  

---

## Technical Approach

- Component-oriented programming  
- State-based combat logic  
- Strategic target selection  
- Coroutine-based temporal synchronization  
- Narrative combat flow control  

---

## Español

# Sistema de Inteligencia Artificial del Jefe

Este módulo implementa el comportamiento del jefe enemigo, incluyendo lógica de combate, selección de objetivos y procesamiento estratégico del daño.

El sistema está diseñado para generar decisiones de ataque que no sean puramente aleatorias, sino evaluando el estado de los personajes antes de ejecutar la acción.

---

## Sistema de IA del Jefe

La característica más importante de este sistema es la implementación de lógica estructurada de decisión para el comportamiento del jefe.

### Funcionamiento de la IA

El jefe no selecciona objetivos mediante aleatoriedad simple.

El sistema evalúa:

- Vida de los personajes jugadores  
- Estado de defensa de cada jugador  
- Comparación estadística entre personajes  
- Relaciones entre participantes del combate  

La IA analiza múltiples condiciones antes de decidir el ataque.

---

## Selección de Comportamiento

El jefe puede:

- Atacar a un jugador específico según su estado de vida  
- Priorizar personajes con menor salud  
- Considerar defensas activas  
- Generar variabilidad mediante probabilidades controladas  

Se utiliza un factor aleatorio restringido dentro de rangos definidos para evitar patrones predecibles.

---

## Sistema de Combate Estratégico

El combate se basa en procesamiento condicional del estado del juego.

Incluye:

- Recorrido estructurado de listas de jugadores mediante `LinkedList`  
- Evaluación de múltiples condiciones simultáneamente  
- Selección dinámica de objetivos  
- Cálculo probabilístico de daño crítico  

---

## Gestión de Animaciones y Retroalimentación Visual

El sistema sincroniza la lógica de combate con la presentación visual:

- Animaciones de ataque del jefe  
- Animaciones de reacción al daño  
- Panel UI de información de daño  
- Transiciones suaves entre estados de combate  

Se mantiene coherencia entre mecánicas y representación gráfica.

---

## Sistema de Muerte y Transición de Escena

Cuando el jefe es derrotado:

- Se reproduce la animación de muerte  
- Se ejecuta la transición visual  
- Se gestionan objetos de audio persistentes  
- Se actualiza el estado de progresión del juego  
- Se desbloquean recompensas de objetos según el resultado de la batalla  

---

## Enfoque Técnico

- Programación orientada a componentes  
- Lógica de combate basada en estados  
- Selección estratégica de objetivos  
- Sincronización temporal mediante coroutines  
- Control narrativo del flujo de combate  
