# 🎮 Modular Mini-Game Framework (Unity)

This project is a **Senior Unity Developer case study** that demonstrates a **modular, extensible mini-game framework** built in **Unity 2022.3.52f1**.  
It is designed with clean architecture principles (SOLID) to make adding new mini-games straightforward, while keeping systems decoupled and reusable.

---

## ✨ Features

- **Framework Core**
  - Modular `IMiniGame` interface for all mini-games.
  - Centralized `GameFrameworkManager` to access core managers and register, start, and stop games.
  - Event-driven communication via a lightweight `EventManager` implementing `IEventBus`.

- **Mini-Games**
  - **Tic-Tac-Toe**: Classic 3x3 board game with turn management and win detection.(not implemented)
  - **Memory Match (Find the Pair)**: Flip and match pairs of cards with randomized layouts. (Not implemented)

- **Core Systems**
  - `SaveManager`: JSON + basic encryption, saves player progress to `persistentDataPath`.
  - `EventManager`: Type-safe event bus with Register/Unregister/Send methods.
  - `SpriteManager`: Handles sprite references for boards and player marks (via ScriptableObject).
  - `UIManager`: Manages modular panels and transitions.
  - `AsyncSceneManager`: Smoothly loads/unloads scenes asynchronously.

- **Editor Tools**
  - **Demo Scene Creator** (via Odin Inspector): One-click tool to generate a Unity scene preconfigured with a `DemoGame` object.

---

## 🏗 Architecture

### Game Lifecycle

GameFrameworkManager
↓
Registers mini-games implementing IGame
↓
StartGame(string gameId)
↓
Game.Initialize(GameContext)
↓
Game.Update() called each frame
↓
Game.Cleanup() on stop or scene change

csharp
Copy code

### Key Interfaces

```csharp
public interface IGame
{
    void Initialize(GameContext context);
    void Update();
    void Cleanup();
}
csharp
Copy code
public interface IEventBus
{
    void Register<T>(Action<T> handler) where T : CustomEvent;
    void Unregister<T>(Action<T> handler) where T : CustomEvent;
    void Send<T>(T evt) where T : CustomEvent;
}
🧩 Mini-Games
Tic-Tac-Toe
3x3 grid board.

Players alternate turns (managed by TurnManager).

Win detection checks rows, columns, and diagonals in O(N²) time with early exits.

Visuals are handled via SpriteManager.

Memory Match
Grid of face-down cards.

Flip two at a time; if they match, they stay revealed.

Uses shuffled card pool with sprite references managed by SpriteManager.

💾 Save System
Data stored as SaveData (currently includes userId, extendable for progress, scores, unlocks).

JSON-serialized and encrypted before saving to persistentDataPath/save_data.txt.

Accessible through SaveManager.Instance.

Example:

csharp
Copy code
var save = SaveManager.Instance.GetSaveData();
save.userID = "Player123";
SaveManager.Instance.SetSaveData(save);
🔔 Event System
Decouples game logic, UI, and systems.

Example: A game can send a GameOverEvent → UI listens and shows the Game Over panel.

csharp
Copy code
EventManager.Instance.Send(new GameOverEvent(winnerId));
🛠 Development Principles
SOLID Principles

Single Responsibility: Each manager/system handles one concern.

Open/Closed: Add new games without modifying existing framework.

Liskov Substitution: All games implement IGame, interchangeable in framework.

Interface Segregation: Systems (e.g., Save, EventBus) expose minimal, specific contracts.

Dependency Inversion: Games depend on abstractions (IEventBus, ISaveSystem), not concrete managers.

🚀 How to Run
Clone this repo.

Open in Unity 2022.3.52f1 (or Unity 6.0.47).

Open the demo scene (created via the Odin tool or found in Assets/Scenes/DemoScene.unity).

Enter Play Mode.

Switch between games via GameFrameworkManager.Instance.StartGame("TicTacToe") or "Memory".

📦 Project Structure
bash
Copy code
Assets/
 ├── Framework/          # Core framework code (IGame, GameFrameworkManager, GameContext)
 ├── Managers/           # Core systems (SaveManager, EventManager, UIManager, SceneManager, SpriteManager)
 ├── Games/              # Game implementations (TicTacToe, Memory)
 ├── UI/                 # Panels and UI prefabs
 ├── Editor/             # Odin editor tools
 └── Scenes/             # Unity scenes (DemoScene)
🧪 Tests
Unit tests written for SaveManager and WinChecker (TicTacToe).

Example: Verify TicTacToe win detection for rows, columns, and diagonals.

📈 Known Issues & Future Improvements
Known Issues

Current SaveManager only saves basic data (userId).

UIManager is minimal, doesn’t yet handle animated transitions.

MemoryGame card flip animations are placeholder.

Future Improvements

Add support for multiple themes in SpriteManager (switchable at runtime).

Extend SaveData for high scores, unlocks, player settings.

Add new mini-games (Endless Runner, Match-3).

Implement addressable scene loading in AsyncSceneManager.

Add dependency injection container for more scalable system registration.

🛠 Requirements
Unity 2022.3.52f1 or 6.0.47

Odin Inspector (for Editor tooling)
