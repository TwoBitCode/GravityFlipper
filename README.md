
# 🌌 **Gravity Flipper** 🚀  
![image](https://github.com/user-attachments/assets/79e87a12-0783-4d7f-a35d-dfc93261df7a)

🎮 **Play now on Itch.io**: [Gravity Flipper on Itch.io](https://twobitcode.itch.io/gravityflipper)  

---

### 🌟 **Description**
**Gravity Flipper** is a 2D arcade game where players defy gravity to navigate hazards and collect stars. The goal is to survive, collect 10 stars, and earn a medal based on your performance time. Flip gravity, dodge obstacles, and prove your skills to claim the **Gold Medal**! 🥇

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

### 📜 **Key Features in Code**

#### **Gravity Flip**  
The `GravityFlip.cs` script allows the player to reverse gravity with the **Spacebar**, creating a dynamic gameplay mechanic.  
**Key code snippet**:  
```csharp
void FlipGravity()
{
    isGravityFlipped = !isGravityFlipped;
    rb.gravityScale = isGravityFlipped ? -1 : 1;
    transform.rotation = Quaternion.Euler(0, 0, isGravityFlipped ? 180 : 0);
}
```
---

#### **Hazard Management**  
`HazardManager.cs` disables all hazards temporarily when a power-up is collected and re-enables them after a set duration.  
**Key code snippet**:  
```csharp
public void DisableHazards(float duration)
{
    hazards = Object.FindObjectsByType<Hazard>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
    foreach (Hazard hazard in hazards) hazard.gameObject.SetActive(false);
    StartCoroutine(ReenableHazards(duration));
}
```
---

#### **Dynamic Hazard Spawning**  
`HazardSpawner.cs` spawns hazards at random positions within defined boundaries at regular intervals.  
**Key code snippet**:  
```csharp
void SpawnHazard()
{
    GameObject hazardPrefab = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];
    float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
    float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
    Instantiate(hazardPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
}
```
---

#### **Player Movement**  
The `PlayerMovement.cs` script ensures smooth horizontal movement using keyboard input.  
**Key code snippet**:  
```csharp
float move = Input.GetAxis("Horizontal");
transform.Translate(new Vector3(move, 0, 0) * speed * Time.deltaTime);
```
---
#### **Dynamic Stars**  
The `MovingStar.cs` script creates stars that move dynamically in random directions and ensures they are destroyed if they go out of bounds or are collected by the player.  
**Key code snippet**:  
```csharp
Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
GetComponent<Rigidbody2D>().linearVelocity = randomDirection * moveSpeed;

// Destroy the star after 3 seconds if not collected
Destroy(gameObject, 3f);
```
- When the player collects a star, it triggers a particle effect and notifies the game timer.  

---

#### **Power-Up Spawning**  
The `PowerUpSpawner.cs` script manages the spawning of power-ups at regular intervals in random positions, giving the player opportunities to disable hazards temporarily.  
**Key code snippet**:  
```csharp
void SpawnPowerUp()
{
    float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
    float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);

    Instantiate(powerUpPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
}
```
- Power-ups spawn every 10 seconds (adjustable) in random positions within specified boundaries.  

---

Let me know if you'd like me to expand or refine this further! 😊
#### **Victory System**  
The `VictoryManager.cs` script displays a victory screen with a medal based on the player's performance.  
**Key code snippet**:  
```csharp
victoryText.text = "You Win!\nMedal: " + medal;
switch (medal.ToLower())
{
    case "gold": medalImage.sprite = goldMedal; break;
    case "silver": medalImage.sprite = silverMedal; break;
    case "bronze": medalImage.sprite = bronzeMedal; break;
}
```

---

### 🕹️ **How to Play**
1. **Move**: Use **A/D** or **Arrow Keys** to move left and right.
2. **Flip Gravity**: Press **Spacebar** to invert gravity.
3. **Goal**: Collect 10 stars while avoiding hazards.  

---

### ⚙️ **How to Run**
1. Clone this repository:  
   ```bash
   git clone https://github.com/TwoBitCode/GravityFlipper.git
   ```
2. Open the project in Unity **6000.0.24f1 LTS**.
3. Press **Play** in the Unity editor and enjoy flipping gravity! 🎮

---

### 🏗️ **Tech Stack**
- 🎮 **Engine**: Unity **6000.0.24f1 LTS**
- 💻 **Language**: C#
- 🎨 **Assets**: Custom particle effects and UI elements

---
