using UnityEngine;

public class AlienShooter : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float minTime = 1f;
    [SerializeField] float maxTime = 3f;
    float shotCounter;



    void Start()
    {
        shotCounter = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            var laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * projectileSpeed;
            shotCounter = Random.Range(minTime, maxTime);
        }
    }
}