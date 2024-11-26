using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Drag your TimerText here in the Inspector
    public TextMeshProUGUI objectiveText; // Drag the ObjectiveText here
    public TextMeshProUGUI victoryText; // Drag your VictoryText from the VictoryPanel
    public int starsToWin = 10; // Number of stars needed to win

    private float elapsedTime = 0f; // Time tracker
    private int starsCollected = 0; // Track collected stars
    private bool gameWon = false; // Track if the game is already won

    // Medal thresholds (in seconds)
    public float goldThreshold = 60f;
    public float silverThreshold = 90f;
    public float bronzeThreshold = 120f;

    void Update()
    {
        if (gameWon) return; // Stop updating if the game is won

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
        if (starsCollected >= starsToWin && !gameWon)
        {
            gameWon = true; // Prevent further updates after winning
            AssignMedal(); // Assign the appropriate medal
            Debug.Log("You Win!");

            VictoryManager victoryManager = Object.FindFirstObjectByType<VictoryManager>();
            if (victoryManager != null)
            {
                victoryManager.ShowVictoryScreen(); // Show the Victory Screen
            }
        }
    }

    private void AssignMedal()
    {
        string medal = "";

        // Determine the medal based on elapsed time
        if (elapsedTime <= goldThreshold)
        {
            medal = "Gold";
        }
        else if (elapsedTime <= silverThreshold)
        {
            medal = "Silver";
        }
        else if (elapsedTime <= bronzeThreshold)
        {
            medal = "Bronze";
        }
        else
        {
            medal = "No Medal"; // If the time exceeds all thresholds
        }

        // Update the VictoryText with the medal information
        if (victoryText != null)
        {
            victoryText.text = "You Win!\nMedal: " + medal;
        }

        Debug.Log("Player earned: " + medal);
    }
}
