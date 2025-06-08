using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var gameManager = GameManager.Instance; // Get the GameManager instance
        if (gameManager.IsGameOver())
        {
            return; // If the game is over, do not spawn obstacles
        }
        
        float x = GameManager.Instance.obstacleSpeed * Time.fixedDeltaTime; // Calculate the distance to move based on speed and time
        transform.position -= new Vector3(x, 0, 0);
        if (transform.position.x <= -GameManager.Instance.obstacleOffsetX) // Check if the obstacle has moved past a certain point
        {
            Destroy(gameObject); // Destroy the obstacle if it has moved too far
        }
    }
}
