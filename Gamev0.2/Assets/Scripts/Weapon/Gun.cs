using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public Camera playerCamera;
    public ParticleSystem muzzleFlash;
    public float damage = 10f;
    public float range = 100f;
    public BulletTraycer bulletTracer;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public GameObject spawner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming "Fire1" is the left mouse button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        RaycastHit hit;
        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range);

        if (bulletPrefab != null)
            {
                GameObject bulletInstance = Instantiate(bulletPrefab, spawner.transform.position, spawner.transform.rotation);

                // Get the direction from the gun to the hit point (or forward if it's a miss)
                Vector3 bulletDirection = hit.point != Vector3.zero ? (hit.point - transform.position).normalized : transform.forward;

                // Set the velocity for the bullet
                bulletInstance.GetComponent<Bullet>().SetVelocity(bulletDirection, bulletSpeed);
            }

        
        
    }
}