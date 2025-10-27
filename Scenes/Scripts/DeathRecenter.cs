using UnityEngine;

public class DeathRecenter : Death
{
    public override void Die()
    {
        transform.position = Vector3.zero;

    }
}
