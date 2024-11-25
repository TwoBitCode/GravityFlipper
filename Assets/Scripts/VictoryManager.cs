using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryPanel; // Drag the VictoryPanel here

    // Call this method when the player wins
    public void ShowVictoryScreen()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true); // Show the Victory Panel
            Time.timeScale = 0; // Pause the game
        }
    }

    // Restart the game when the Restart button is pressed
    public void RestartGame()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }
}
