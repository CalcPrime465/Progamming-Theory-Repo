using UnityEngine;
using UnityEngine.InputSystem;

public class Player_SphereControl : PlayerControl
{
    private float slowSpeed = 5;
    private float fastSpeed = 15;

    public override void FireBullet()
    {
        if (fireAction.WasPressedThisFrame())
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            speed = slowSpeed;
        }

        if (fireAction.WasReleasedThisFrame())
        {
            Destroy(GameObject.FindWithTag("Bullet"));
            speed = fastSpeed;
        }
    }
}
