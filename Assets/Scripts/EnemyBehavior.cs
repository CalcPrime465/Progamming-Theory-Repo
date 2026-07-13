using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private MainManager mainManager;

    private Vector3 relative;
    private float speed = 5;
    private float yLimit = -5;
    private int damage = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        relative = transform.InverseTransformDirection(Vector3.down);
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
        DestroyOutofBounds();
    }

    void MoveDown()
    {
        transform.Translate(relative * Time.deltaTime * speed);
    }

    void DestroyOutofBounds()
    {
        if (transform.position.y < yLimit)
        {
            mainManager.UpdateHealth(damage);
            Destroy(gameObject);
        }
    }
}
