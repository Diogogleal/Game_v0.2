using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void SetVelocity(Vector3 direction, float speed)
    {
        // Apply the provided velocity to the bullet
        GetComponent<Rigidbody>().velocity = direction * speed;

        // Destroy the bullet after a certain time to prevent it from filling up the scene
        Destroy(gameObject, 2f);
    }
}
