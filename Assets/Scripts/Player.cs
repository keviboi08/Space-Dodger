
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int health = 100;
    [SerializeField] AudioClip deathSound;
    [SerializeField][Range(0, 1)] float deathVolume = 0.75f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) return;

        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        AudioSource.PlayClipAtPoint(damageDealer.GetHitSound(), Camera.main.transform.position, 0.5f);

        if (health <= 0)
        {
            Die();
        }


    }

    
      
    

    private void Die()
    {
        FindObjectOfType<LevelManager>().LoadGameOver();
        GameObject exp = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(exp, explosionDuration);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathVolume);
        Destroy(gameObject);
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, Borders.Left, Borders.Right);
        transform.position = new Vector2(newXPos, transform.position.y);
    }
}

