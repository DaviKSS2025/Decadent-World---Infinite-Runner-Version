# Gameplay Architecture Overview

This project was structured with modular gameplay systems and clear separation of responsibilities.

The core gameplay loop revolves around a state-driven architecture:

Both the Player and Fireball use a State Pattern implementation (IPlayerState / IFireballState) to isolate behavior logic per state.

Each controller acts as a coordinator, wiring dependencies and managing the lifecycle of the state machine.

Movement and animation logic are implemented in plain C# classes instead of MonoBehaviours to reduce coupling to Unity's lifecycle.

# Fireball System

Fireballs are spawned using a simple fixed-size object pool to avoid runtime instantiation.

Each fireball:

Manages its behavior through a state machine (Traveling, Reverse, Explosion).

Handles collision rules in a dedicated collision component.

Returns to the pool automatically when leaving the camera view.

Special interaction rules:

Player attacks can reverse fireballs.

Reversed fireballs cause explosions on contact with other fireballs.

Player collision triggers damage and explosion state.

# Player System

The PlayerController coordinates:

Input reading

Movement logic

Ground detection

Animation control

Damage handling

State transitions

Gameplay states (Grounded, Jumping, Attacking, etc.) are isolated into separate classes to avoid large conditional blocks and simplify extensibility.

# Communication & Events

The project uses event channels to decouple systems:

Score updates

Damage notifications

Audio triggers

This prevents direct dependencies between gameplay systems and UI or persistence layers.

# Persistence

A centralized SaveController updates and persists the maximum score using a SaveManager system.
Score changes trigger events so UI updates remain reactive and decoupled.
