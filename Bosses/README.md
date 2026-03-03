# Sistema de Inteligencia Artificial del Jefes

Este módulo implementa el comportamiento del jefe enemigo, incluyendo lógica de combate, selección de objetivos y procesamiento estratégico de daño.

El sistema está diseñado para generar decisiones de ataque no aleatorias simples, sino evaluando el estado de los personajes antes de ejecutar la acción.

---

## Sistema de IA del Jefe

La característica más importante de este sistema es la implementación de una lógica de decisión estructurada para el comportamiento del jefe.

### Cómo funciona la IA

El jefe no selecciona objetivos de forma puramente aleatoria.

El sistema evalúa:

- Vida de los personajes jugadores
- Estado de defensa de cada jugador
- Comparación entre estadísticas de los personajes
- Relación entre pares de jugadores en el combate

La IA analiza múltiples condiciones antes de decidir a quién atacar.

### Selección de comportamiento

El jefe puede:

- Atacar a un jugador específico basado en estado de vida
- Priorizar personajes con menor vida
- Considerar el estado de defensa activo
- Generar variabilidad mediante probabilidad controlada

Se utiliza un factor crítico aleatorio limitado entre rangos definidos para evitar comportamiento predecible.

---

## Sistema de Combate Estratégico

El combate se basa en procesamiento condicional del estado del juego.

La lógica incluye:

- Recorrido estructurado de la lista de jugadores usando `LinkedList`
- Evaluación de múltiples condiciones simultáneamente
- Selección dinámica de objetivos
- Control de daño crítico probabilístico

---

## Gestión de Animaciones y Feedback Visual

El sistema sincroniza la lógica de combate con la presentación visual:

- Animaciones de ataque del jefe
- Animación de daño al recibir impacto
- Panel visual de información de daño
- Transiciones suaves entre estados

Esto permite mantener coherencia entre mecánica y representación gráfica.

---

## Sistema de Muerte y Cambio de Escena

Cuando el jefe es derrotado:

- Se reproduce la animación de muerte
- Se ejecuta la transición visual
- Se gestionan objetos persistentes de audio
- Se actualiza la progresión del juego
- Se desbloquean recompensas de items según la batalla

---

## Enfoque Técnico

- Programación orientada a componentes
- Lógica de combate basada en estados
- Selección estratégica de objetivos
- Uso de coroutines para sincronización temporal
- Control de flujo narrativo del combate

