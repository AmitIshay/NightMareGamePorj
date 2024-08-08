using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this to use the Text component


public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Text gameOverText; // Add a Text component to display the score

    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
                // Display the score
        int finalScore = ScoreManager.GetScore();
        gameOverText.text = "Game Over Score: " + finalScore;
    }
}
