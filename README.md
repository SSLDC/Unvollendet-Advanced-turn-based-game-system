# Unvollendet – Advanced Turn-Based Game System

## 🇬🇧 English

**Unvollendet** is an ambitious project that merges deep narrative design, strategic turn-based combat, and a hybrid 2D/3D aesthetic in a 2.5D style.

The game is built on a modular architecture focused on scalability, robust state control, and complex decision-making systems at both narrative and artificial intelligence levels.

---

## Main Features

- Advanced turn-based combat system  
- Strategic final boss AI behavior  
- Multi-ending decision system  
- 2D/3D hybrid integration (2.5D style)  
- Dynamic music, video, and transition control  
- Robust and safe state management  

---

## Final Boss AI

The AI system does not rely on simple random decision-making.

It dynamically evaluates multiple variables including:

- Current combat state  
- Health and defense values  
- Tactical priorities  
- Simultaneous logical conditions  
- Resource availability  

Before executing any action, the AI analyzes the full context using:

- Complex conditional comparisons  
- Linked logical evaluation structures  
- Controlled probability variation to maintain behavioral coherence  

The result is an adaptive strategic behavior that responds to real combat situations.

---

## Turn System Architecture

The combat flow is implemented using a state-machine-based approach including:

- Safe transition validation  
- Continuous condition monitoring  
- Input blocking during action execution  
- Coroutine-based asynchronous processing  
- Animation-event synchronization  
- Invalid state prevention  
- Resource management (health, energy, items)  
- Automatic combat cycle control  

The system is designed to maintain logical consistency and prevent runtime state corruption.

---

## Project Structure

Each folder contains its own `README.md` with detailed internal documentation.

---

### Bosses

Final boss behavior and logic.

- `Boss.cs`

---

### CombatSystem

Core combat mechanics and entity logic.

- `Character.cs`
- `Items.cs`
- `Magias.cs`
- `Player.cs`

---

### Controllers

Audio-visual system management and scene transitions.

- `ControlMusica.cs`
- `ControladorVideo.cs`
- `Transicion.cs`

---

### GameManager

Global game state orchestration.

- `GameManager.cs`

---

### ScriptsEscena

Narrative flow and scene logic control.

- `BotonColor.cs`
- `Conversaciones.cs`
- `Conversaciones2.cs`
- `Conversaciones3.cs`
- `ConversacionFinal.cs`
- `ConversacionFinal2.cs`
- `GameManagerMain.cs`

---

## Design Philosophy

Unvollendet follows principles of:

- Clear separation of responsibilities  
- Structural modularity  
- Narrative scalability  
- Strict logical flow control  
- System-oriented software design  
- Robust runtime behavior management  

---

## 🇪🇸 Español

**Unvollendet** es un proyecto ambicioso que combina narrativa profunda, combate estratégico por turnos y una estética híbrida 2D/3D en estilo 2.5D.

El juego está desarrollado bajo una arquitectura modular enfocada en escalabilidad, control robusto de estados y sistemas complejos de toma de decisiones tanto narrativas como de inteligencia artificial.

---

## Características Principales

- Sistema de combate por turnos avanzado  
- IA estratégica para jefe final  
- Sistema de decisiones con múltiples finales  
- Integración 2D/3D en estilo 2.5D  
- Control dinámico de música, video y transiciones  
- Gestión de estados segura y robusta  

---

## IA del Jefe Final

El sistema de IA no se basa en decisiones aleatorias simples.

Evalúa dinámicamente múltiples variables como:

- Estado actual del combate  
- Vida y defensa  
- Prioridades tácticas  
- Condiciones lógicas simultáneas  
- Disponibilidad de recursos  

Antes de ejecutar una acción, la IA analiza el contexto completo mediante:

- Comparaciones condicionales complejas  
- Estructuras lógicas enlazadas  
- Variaciones probabilísticas controladas para mantener coherencia comportamental  

El resultado es un comportamiento estratégico adaptable que reacciona a la situación real del combate.

---

## Sistema de Turnos

Sistema de combate basado en máquina de estados que incluye:

- Validación segura de transiciones  
- Monitorización continua de condiciones  
- Bloqueo de entrada durante la ejecución de acciones  
- Procesamiento asincrónico mediante coroutines  
- Sincronización con animaciones y eventos  
- Prevención de estados inválidos  
- Gestión de recursos (vida, energía, objetos)  
- Control automático del ciclo de combate  

Diseñado para mantener coherencia lógica y prevenir corrupción de estados en tiempo de ejecución.

---

## Filosofía de Diseño

Unvollendet se desarrolla bajo principios de:

- Separación clara de responsabilidades  
- Modularidad estructural  
- Escalabilidad narrativa  
- Control estricto del flujo lógico  
- Diseño orientado a sistemas  
- Gestión robusta del runtime  
