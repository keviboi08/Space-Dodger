using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    public void SetWaveConfig(WaveConfig wc)
    {
        waveConfig = wc;
    }

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[0].position;
    }

    void Update()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var target = waypoints[waypointIndex].position;
            var movement = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, movement);
            if (transform.position == target)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}