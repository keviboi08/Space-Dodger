using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 2;
    [SerializeField] AudioClip hitSound;

    public int GetDamage() { return damage; }

    public AudioClip GetHitSound() { return hitSound; }

    public void Hit()
    {
        Destroy(gameObject);
    }
}