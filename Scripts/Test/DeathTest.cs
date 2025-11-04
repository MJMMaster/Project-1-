using UnityEngine;

public class DeathTest : MonoBehaviour
{
    [Header("Reference to the Ship Pawn")]
    public ShipPawn pawnToTest;

    void Update()
    {
        // Make sure pawnToTest exists before checking its components
        if (pawnToTest == null)
        {
            Debug.LogWarning("No pawn assigned to DeathTest!");
            return;
        }

        // --- Test Death ---
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pawnToTest.death != null)
            {
                pawnToTest.death.Die();
            }
            else
            {
                Debug.Log("YOU KILLED MEEEE!!!!");
            }
        }

        // --- Test Damage ---
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (pawnToTest.health != null)
            {
                pawnToTest.health.TakeDamage(1);
            }
            else
            {
                Debug.Log("Ow that hurts man");
            }
        }

        // --- Test Healing ---
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (pawnToTest.health != null)
            {
                pawnToTest.health.Heal(1);
            }
            else
            {
                Debug.Log("Thanks for the heals broski");
            }
        }
    }
}