using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For UI elements like Image
using TMPro; // For TextMeshPro

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryPanel; // Drag the VictoryPanel here
    public TextMeshProUGUI victoryText; // Drag the Victory Text (e.g., "You Win!") here
    public Image medalImage; // Drag the Medal Image UI element here

    // Medal sprites to assign in the Inspector
    public Sprite goldMedal;
    public Sprite silverMedal;
    public Sprite bronzeMedal;

    public void ShowVictoryScreen(string medal)
    {
        if (victoryPanel == null || victoryText == null || medalImage == null)
        {
            Debug.LogError("VictoryManager: Missing required UI components in the Inspector!");
            return;
        }

        victoryPanel.SetActive(true); // Show the Victory Panel
        Time.timeScale = 0; // Pause the game

        // Update the victory text
        victoryText.text = "You Win!\nMedal: " + medal;

        // Update the medal image
        switch (medal.ToLower())
        {
            case "gold":
                medalImage.sprite = goldMedal;
                break;
            case "silver":
                medalImage.sprite = silverMedal;
                break;
            case "bronze":
                medalImage.sprite = bronzeMedal;
                break;
            default:
                Debug.LogError("VictoryManager: Invalid medal type passed (" + medal + ").");
                return;
        }

        medalImage.gameObject.SetActive(true); // Show the medal image
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }
}
