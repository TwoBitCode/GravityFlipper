# 🌌 **GravityFlipper** 🚀

### 🌟 **Description**
**GravityFlipper** is a 2D arcade game where players defy gravity to navigate hazards and collect stars. The goal is to survive, collect 10 stars, and earn a medal based on your performance time. Flip gravity, dodge obstacles, and prove your skills to claim the **Gold Medal**! 🥇

---

### 🎮 **Gameplay Features**
- 🌀 **Gravity Flipping**: Control gravity with a single button to avoid hazards and collect stars.
- 🌟 **Dynamic Stars**: Stars spawn in random locations, forcing players to strategize their movements.
- 💥 **Hazards**: Moving obstacles and vertical hazards challenge your timing and reflexes.
- ⚡ **Power-Ups**: Temporarily disable hazards to gain an edge.
- 🎖️ **Medal System**: Earn **Gold, Silver, or Bronze medals** based on your time:
  - 🥇 **Gold**: For the fastest players.
  - 🥈 **Silver**: Solid performance.
  - 🥉 **Bronze**: A great start—keep flipping!

---

### 📜 **Code Overview**
The game is built with Unity, featuring modular scripts to handle various game mechanics. Here’s a breakdown of the key scripts:

1. **Game Manager**:
   - Manages game-wide settings and behaviors.
   - Handles gravity flipping via the `GravityFlip.cs` script.

2. **Star Spawning**:
   - `StarSpawner.cs` handles the random spawning of stars within defined boundaries.

3. **Hazard Mechanics**:
   - `Hazard.cs`: Manages basic hazard behavior.
   - `MovingHazard.cs`: Adds movement for hazards.
   - `VerticalHazard.cs`: Implements vertical movement logic for hazards.
   - `HazardSpawner.cs`: Dynamically spawns hazards during gameplay.

4. **Power-Ups**:
   - `PowerUp.cs`: Defines power-up behavior and effects.
   - `PowerUpSpawner.cs`: Controls power-up spawning intervals and locations.

5. **Game Timer**:
   - `GameTimer.cs`: Tracks elapsed time, collected stars, and triggers the victory screen.

6. **Victory Screen**:
   - `VictoryManager.cs`: Displays the victory panel, medal type, and handles game restarts.

---

### 🕹️ **How to Play**
1. Use the **Spacebar** to flip gravity and navigate the environment.
2. **Collect 10 stars** to win! 🌟
3. Avoid hazards and earn a medal based on your time:
   - 🥇 Gold: < 60 seconds.
   - 🥈 Silver: 60–90 seconds.
   - 🥉 Bronze: > 90 seconds.

---

### ⚙️ **How to Run**
1. Clone this repository:
   ```bash
   git clone https://github.com/TwoBitCode/GravityFlipper.git
   ```
2. Open the project in Unity **6000.0.24f1 LTS**.
3. Press **Play** in the Unity editor and enjoy flipping gravity! 🎮

---

### 📜 **Key Features in Code**
#### **Gravity Flip**:
`GravityFlip.cs` controls player movement by flipping gravity when the **Spacebar** is pressed:
```csharp
void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Physics2D.gravity *= -1;
    }
}
```

#### **Victory System**:
`VictoryManager.cs` displays a victory screen based on performance time and awards medals:
```csharp
victoryText.text = "You Win!\nMedal: " + medal;
switch (medal.ToLower())
{
    case "gold": medalImage.sprite = goldMedal; break;
    case "silver": medalImage.sprite = silverMedal; break;
    case "bronze": medalImage.sprite = bronzeMedal; break;
}
```

#### **Star Spawning**:
`StarSpawner.cs` generates stars in random positions to challenge players to chase moving targets:
```csharp
float randomX = Random.Range(minX, maxX);
float randomY = Random.Range(minY, maxY);
Instantiate(starPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
```

---

### 🏗️ **Tech Stack**
- 🎮 **Engine**: Unity **6000.0.24f1 LTS**
- 💻 **Language**: C# for all scripting.
- 🎨 **Design**: Unity's Particle Effects for visuals and dynamic UI.

---
