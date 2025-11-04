using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

    public abstract void Shoot(); // Each subclass defines how to shoot
}