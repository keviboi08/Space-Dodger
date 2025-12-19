using System.Collections;
using System.Collections.Generic; // <-- Added this line (missing!)
using UnityEngine;

public class PointGiverSpawner : MonoBehaviour
{
    [SerializeField] GameObject energyOrbPrefab;
    [SerializeField] float minTime = 1.5f;
    [SerializeField] float maxTime = 4f;
    int spawned = 0;

    void Start()
    {
        StartCoroutine(SpawnOrbs());
    }

    IEnumerator SpawnOrbs()
    {
        while (spawned < 10)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            Instantiate(energyOrbPrefab, transform.position, Quaternion.identity);
            spawned++;
            if (spawned >= 10)
            {
                 FindObjectOfType<LevelManager>().AllOrbsSpawned();
            }
        }
    }
}