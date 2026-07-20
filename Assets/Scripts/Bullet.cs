using UnityEngine;

public class Bullet : MonoBehaviour
{
    public MainManager mainManager;
    private float speed = 50;
    private float yLimit = 10;
    public int scoreIncrease = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyOutOfBounds();
    }

    public virtual void Move()
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

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            mainManager.UpdateScore(scoreIncrease);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
