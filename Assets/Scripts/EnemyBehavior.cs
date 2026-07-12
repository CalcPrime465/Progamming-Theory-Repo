using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 relative;
    private float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        relative = transform.InverseTransformDirection(Vector3.down);

    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }

    void MoveDown()
    {
        transform.Translate(relative * Time.deltaTime * speed);
    }
}
