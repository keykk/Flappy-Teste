using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float cooldown = 0f; // Cooldown timer for spawning obstacles
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance; // Get the GameManager instance
        if (gameManager.IsGameOver())
        {
            return; // If the game is over, do not spawn obstacles
        }

        cooldown -= Time.deltaTime; // Decrease the cooldown timer by the time since the last frame
        if (cooldown <= 0f) // Check if the cooldown has reached zero
        {
            cooldown = gameManager.obstacleInterval; // Reset the cooldown timer to the obstacle interval defined in GameManager

            //spawn obstacle
            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex]; // Get a random obstacle prefab
            float x = gameManager.obstacleOffsetX; // Get the X offset for the obstacle
            float y = Random.Range(gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y); // Get a random Y offset within the specified range
            float z = -1.241f; // Set a fixed Z position for the obstacle
            Vector3 position = new Vector3(x, y, z); // Set the position for the obstacle
            Quaternion rotation = prefab.transform.rotation; // Get the rotation of the prefab
            Instantiate(prefab, position, rotation); // Instantiate the obstacle at the specified position and rotation
        }
    }
}
