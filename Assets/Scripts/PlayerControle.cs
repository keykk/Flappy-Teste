using UnityEngine;

public class PlayerControle:MonoBehaviour
{
    private Rigidbody thisRigidbody;
    public float jumpPower = 5f; // Jump power variable
    public float jumpInterval = 0.5f; // Jump interval variable
    private float jumpCooldown = 0f; // Cooldown timer
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Update the cooldown timer
        jumpCooldown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.isGameActive(); // Check if the game is active
        bool canJump = jumpCooldown <= 0f && isGameActive; // Check if the player can jump based on cooldown and game state

        //Jump
        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0);
            if (jumpInput)
            {
                Jump(); // Call the Jump method 
            }
        }
        thisRigidbody.useGravity = isGameActive; // Enable or disable gravity based on game state
       
    }

    void OnTriggerEnter(Collider other)
    {
         OnCustomCollisionEnter(other.gameObject); // Call the custom collision method
    }
    void OnCollisionEnter(Collision other)
    {
        OnCustomCollisionEnter(other.gameObject); // Call the custom collision method
    }

    private void OnCustomCollisionEnter(GameObject other)
    {
        bool isSensor = other.CompareTag("Sensor");
        if (isSensor)
        {
            GameManager.Instance.score++; // Increment the score in GameManager
            Debug.Log("Score: " + GameManager.Instance.score); // Placeholder for sensor logic
        }
        else
        {
            //game over
            if (GameManager.Instance.isGameActive())
            {
                GameManager.Instance.EndGame(); // Call the EndGame method in GameManager
            }
        }
    }
    private void Jump()
    {
        jumpCooldown = jumpInterval; // Reset the cooldown timer

        thisRigidbody.linearVelocity = Vector3.zero; // Reset the velocity to zero before jumping
        thisRigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }
}
