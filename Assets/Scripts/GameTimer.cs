using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Drag your TimerText here in the Inspector
    public TextMeshProUGUI objectiveText; // Drag the ObjectiveText here
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
            Debug.Log("You Win!");

            // Determine the medal and pass it to the VictoryManager
            string medal = DetermineMedal();

            VictoryManager victoryManager = Object.FindFirstObjectByType<VictoryManager>();
            if (victoryManager != null)
            {
                victoryManager.ShowVictoryScreen(medal); // Pass the medal to the Victory Screen
            }
        }
    }

    private string DetermineMedal()
    {
        // Determine the medal based on elapsed time
        if (elapsedTime <= goldThreshold)
        {
            return "Gold";
        }
        else if (elapsedTime <= silverThreshold)
        {
            return "Silver";
        }
        else if (elapsedTime <= bronzeThreshold)
        {
            return "Bronze";
        }

        return ""; // No medal if it doesn't meet any threshold
    }
}
