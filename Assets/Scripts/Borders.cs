using UnityEngine;

public class Borders : MonoBehaviour
{
    public static float Left { get; private set; }
    public static float Right { get; private set; }

    void Start()
    {
        Camera cam = Camera.main;
        Left = cam.ViewportToWorldPoint(Vector3.zero).x + 0.5f;
        Right = cam.ViewportToWorldPoint(Vector3.one).x - 0.5f;
    
    }
}