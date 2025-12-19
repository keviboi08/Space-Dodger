using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] int numberOfObstacles = 3;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetObstaclePrefab() { return obstaclePrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public int GetNumberOfObstacles() { return numberOfObstacles; }
    public float GetMoveSpeed() { return moveSpeed; }
}