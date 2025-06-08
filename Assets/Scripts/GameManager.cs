using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance

    [FormerlySerializedAs("prefab")]
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval = 1f; // Interval for spawning obstacles
    public float obstacleSpeed = 10f; // Speed of obstacles
    public float obstacleOffsetX = 0f; // X offset for obstacles
    public Vector2 obstacleOffsetY = new Vector2(0f, 0f); // Y offset for obstacles

    [HideInInspector]
    public int score = 0; // Player's score

    private bool isGameOver = false; // Flag to check if the game is over
    void Awake()
    {
        // Ensure that there is only one instance of GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this; // Set the singleton instance to this GameManager
        }
    }

    public bool IsGameOver()
    {
        return isGameOver; // Return the game over status
    }
    public bool isGameActive()
    {
        return !isGameOver; // Return true if the game is not over
    }
    public void EndGame()
    {
        isGameOver = true; // Set the game over flag to true
        // Placeholder for game over logic
        Debug.Log("Game Over! Final Score: " + score);
        // You can add more game over logic here, such as showing a UI or restarting the game
        Debug.Log("Reloading scene in 2 seconds..."); // Log message for debugging
        StartCoroutine(ReloadScene(2f)); // Reload the scene after a delay of 2 seconds
    }
    
    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        Debug.Log("Reloading scene now..."); // Log message for debugging
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
