using UnityEngine;

public class OrbSpawnerMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float amplitude = 4f;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(
            Mathf.Clamp(startPos.x + x, Borders.Left + 1f, Borders.Right - 1f),
            startPos.y, 0);
    }
}