using UnityEngine;

public class ShipPawn : MonoBehaviour
{
    [Header("Components")]
    public Health health;
    public Death death;

    [Header("Movement Speeds")]
    public float moveSpeed = 5f;       // units per second
    public float turboSpeed = 10f;     // turbo units per second
    public float rotationSpeed = 90f;  // degrees per second

    [Header("Teleport Settings")]
    public float teleportStep = 2f;           // step size for arrow key teleports

   

    [Header("Camera Bounds")]
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    private float currentSpeed;

    void Start()
    {
        currentSpeed = moveSpeed;
        health = GetComponent<Health>();
        death = GetComponent<Death>();
    }

    // Called by controller each frame
    public void MoveForward(float input, float deltaTime)
    {
        Vector3 moveDir = Vector3.up * input * currentSpeed * deltaTime;
        transform.Translate(moveDir, Space.Self);
    }

    public void Rotate(float input, float deltaTime)
    {
        float rotation = input * rotationSpeed * deltaTime;
        transform.Rotate(-Vector3.forward * rotation, Space.Self);
    }

    public void TeleportWorld(Vector3 direction)
    {
        transform.position += direction * teleportStep;
    }
    public SoundManager soundManager; // drag your SoundManager here in the Inspector


    public void RandomTeleport()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Keep Z unchanged
        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }

    public void EnableTurbo()
    {
        currentSpeed = turboSpeed;
    }

    public void DisableTurbo()
    {
        currentSpeed = moveSpeed;
    }
    public ShooterBullet shooter;

    void LateUpdate()
    {
        transform.position = GameManager.Instance.WarpPosition(transform.position);
    }
    public void Shoot()
        {
            shooter.Shoot(); 
        if (soundManager != null)
        {
            soundManager.PlayShootSound();
        }
        else
        {
            Debug.LogWarning("SoundManager not found on this object!");
        }
        ;
    }  



   
}
    



