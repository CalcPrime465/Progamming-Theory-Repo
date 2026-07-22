using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction fireAction;
    public InputAction changePlayerAction;
    public GameObject bulletPrefab;
    public GameObject playerTypePrefab;

    public float speed = 20;
    private float xRange = 12;
    private float changePlayerDelay = 0.5f;
    private Vector2 moveInput;

    private void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();
        StartCoroutine(EnablePlayerChange(changePlayerDelay));
    }

    // Update is called once per frame
    void Update()
    {
        ChangePlayerType();
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

    void ChangePlayerType()
    {
        if (changePlayerAction.triggered)
        {
            Instantiate(playerTypePrefab, transform.position, playerTypePrefab.transform.rotation);
            Destroy(gameObject);
        }
    }

    IEnumerator EnablePlayerChange(float delay)
    {
        yield return new WaitForSeconds(delay);
        changePlayerAction.Enable();
    }
}
