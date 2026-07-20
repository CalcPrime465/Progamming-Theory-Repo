using UnityEngine;

public class Player_SphereBullet : Bullet
{
    public override void Move()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            mainManager.UpdateScore(scoreIncrease);
            Destroy(other.gameObject);
        }
    }
}
