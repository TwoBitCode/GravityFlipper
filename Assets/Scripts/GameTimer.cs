using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Drag your TimerText here in the Inspector
    private float elapsedTime = 0f; // Time tracker
    public TextMeshProUGUI objectiveText; // Drag the ObjectiveText here
    public int starsToWin = 10; // Number of stars needed to win
    private int starsCollected = 0; // Track collected stars

    void Update()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Update the TimerText with the elapsed time
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.FloorToInt(elapsedTime) + "s";
        }
    }
    public void AddStar()
    {
        starsCollected++;
        if (objectiveText != null)
        {
            objectiveText.text = "Stars: " + starsCollected + " / " + starsToWin;
        }

        // Check if the player has won
        if (starsCollected >= starsToWin)
        {
            Debug.Log("You Win!");
            VictoryManager victoryManager = Object.FindFirstObjectByType<VictoryManager>();
            if (victoryManager != null)
            {
                victoryManager.ShowVictoryScreen(); // Show the Victory Screen
            }
        }
    }


}
