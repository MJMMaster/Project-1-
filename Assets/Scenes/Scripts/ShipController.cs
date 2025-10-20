using UnityEngine;

[RequireComponent(typeof(ShipPawn))]
public class ShipController : MonoBehaviour
{
    private ShipPawn pawn;

    void Awake()
    {
        pawn = GetComponent<ShipPawn>();
    }

    void Update()
    {
        float dt = Time.deltaTime;

        // ---------------- WASD Movement ----------------
        float forwardInput = 0f;
        if (Input.GetKey(KeyCode.W)) forwardInput = 1f;
        if (Input.GetKey(KeyCode.S)) forwardInput = -1f;
        pawn.MoveForward(forwardInput, dt);

        float rotateInput = 0f;
        if (Input.GetKey(KeyCode.A)) rotateInput = -1f;
        if (Input.GetKey(KeyCode.D)) rotateInput = 1f;
        pawn.Rotate(rotateInput, dt);

        // ---------------- Turbo ----------------
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            pawn.EnableTurbo();
        else
            pawn.DisableTurbo();

        // ----------------Shoot-------------
        if (Input.GetKeyDown(KeyCode.Mouse0))
            pawn.Shoot();
        // ---------------- Teleports ----------------
        if (Input.GetKeyDown(KeyCode.UpArrow))
            pawn.TeleportWorld(Vector3.up);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            pawn.TeleportWorld(Vector3.down);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            pawn.TeleportWorld(Vector3.left);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            pawn.TeleportWorld(Vector3.right);

        // ---------------- Random Teleport ----------------
        if (Input.GetKeyDown(KeyCode.T))
            pawn.RandomTeleport();
    }
}