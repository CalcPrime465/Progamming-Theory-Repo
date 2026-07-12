using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 50;
    private float yLimit = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
        DestroyOutOfBounds();
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.y > yLimit)
        {
            Destroy(gameObject);
        }
    }
}
