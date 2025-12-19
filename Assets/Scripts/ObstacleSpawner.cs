using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = true;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    IEnumerator SpawnAllWaves()
    {
        foreach (var wave in waveConfigs)
        {
            yield return StartCoroutine(SpawnAllInWave(wave));
        }
    }

    IEnumerator SpawnAllInWave(WaveConfig wave)
    {
        for (int i = 0; i < wave.GetNumberOfObstacles(); i++)
        {
            var obs = Instantiate(wave.GetObstaclePrefab(), wave.GetWaypoints()[0].position, Quaternion.identity);
            obs.GetComponent<ObstaclePathing>().SetWaveConfig(wave);
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }
}