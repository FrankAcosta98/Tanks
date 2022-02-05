using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNucleo : MonoBehaviour
{
    // Start is called before the first frame update
    float timeSinceLastSpawn;

    public float timeBetweenSpawns;

    public float spawnDistance;

    public Nucleo[] nucleonPrefabs;
    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnNucleon();
        }
    }
    void SpawnNucleon()
    {
        Nucleo prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        Nucleo spawn = Instantiate<Nucleo>(prefab);
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }
}
