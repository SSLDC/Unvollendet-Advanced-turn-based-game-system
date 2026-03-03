# Unvollendet – Advanced Turn-Based Game System

**Unvollendet** es un proyecto ambicioso que fusiona narrativa profunda, combate estratégico por turnos y una estética híbrida 2D/3D en estilo 2.5D.  

El juego está diseñado con una arquitectura modular enfocada en escalabilidad, control de estados robusto y toma de decisiones compleja tanto a nivel narrativo como en inteligencia artificial.

---

##  Características Principales

- Sistema de combate por turnos avanzado
- IA estratégica para jefe final
- Sistema de decisiones con múltiples finales
- Integración 2D/3D (estilo 2.5D)
- Control dinámico de música, video y transiciones
- Gestión de estados robusta y segura

---

# IA del Jefe Final

El sistema de IA no funciona mediante decisiones aleatorias simples.  

Evalúa dinámicamente múltiples variables:

- Estado actual del combate
- Vida y defensa
- Prioridades tácticas
- Condiciones simultáneas
- Recursos disponibles

La IA analiza el contexto completo antes de actuar, utilizando:

- Comparaciones condicionales complejas
- Estructuras enlazadas
- Probabilidades controladas para generar variabilidad coherente

El resultado es un comportamiento estratégico adaptable que reacciona a la situación real del jugador.

---

# Sistema de Turnos

Sistema completo basado en máquina de estados:

- Control de transiciones seguras
- Validación constante de condiciones
- Bloqueo de entrada durante ejecución
- Uso de coroutines para ejecución asincrónica
- Sincronización con animaciones y eventos
- Prevención de estados inválidos
- Gestión de recursos (vida, energía, objetos)
- Control automático del ciclo principal del combate

Diseñado para mantener coherencia interna y evitar errores lógicos durante el flujo del combate.

---

# Estructura del Proyecto

Cada carpeta contiene su propio `README.md` con explicación detallada de su funcionamiento interno.

---

## Bosses

Lógica y comportamiento del jefe final.

- `Boss.cs`

---

## CombatSystem

Núcleo del sistema de combate y entidades jugables.

- `Character.cs`
- `Items.cs`
- `Magias.cs`
- `Player.cs`

---

## Controllers

Control de elementos audiovisuales y transiciones.

- `ControlMusica.cs`
- `ControladorVideo.cs`
- `Transicion.cs`

---

## GameManager

Gestión global del estado del juego y control central del sistema.

- `GameManager.cs`

---

## ScriptsEscena

Control narrativo y lógica de escenas.

- `BotonColor.cs`
- `Conversaciones.cs`
- `Conversaciones2.cs`
- `Conversaciones3.cs`
- `ConversacionFinal.cs`
- `ConversacionFinal2.cs`
- `GameManagerMain.cs`

---

# Filosofía de Diseño

Unvollendet está construido bajo principios de:

- Separación clara de responsabilidades
- Modularidad estructural
- Escalabilidad narrativa
- Control riguroso del flujo lógico
- Diseño orientado a sistemas complejos
