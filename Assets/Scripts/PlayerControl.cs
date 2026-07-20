using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction fireAction;
    public GameObject bulletPrefab;

    public float speed = 15;
    private float xRange = 12;
    private Vector2 moveInput;

    void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        KeepInBounds();
        FireBullet();
    }

    void MovePlayer()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.right * moveInput.x * Time.deltaTime * speed);
    }

    void KeepInBounds()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    public virtual void FireBullet()
    {
        if (fireAction.triggered)
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        }
    }
}
