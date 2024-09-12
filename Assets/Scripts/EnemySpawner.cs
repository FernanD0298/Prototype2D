using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyToSpawn;

    public float TimeToSpawn;
    private float SpawnCounter;

    public Transform MinSpawn, MaxSpawn;
    private Transform Target;
    private GameObject Player;

    private List<GameObject> SpawnedEnemies = new List<GameObject>();

    public List<WaveInfo> Waves;
    private int CurrentWave;
    private float WaveCounter;

    void Start()
    {
        SpawnCounter = TimeToSpawn;

        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            Target = Player.GetComponent<Transform>();
        }

        CurrentWave--;
        GoToNextWave();
    }

    void Update()
    {
        /*SpawnCounter -= Time.deltaTime;
        if (SpawnCounter <= 0)
        {
            SpawnCounter = TimeToSpawn;
            var TransformSpawn = transform;
            Instantiate(EnemyToSpawn, SelectSpawnPoint(), TransformSpawn.rotation);
        }*/

        if (Player.activeSelf)
        {
            if (CurrentWave < Waves.Count && CurrentWave > 0)
            {
                WaveCounter -= Time.deltaTime;
                if (WaveCounter <= 0)
                {
                    GoToNextWave();
                }

                SpawnCounter -= Time.deltaTime;
                if (SpawnCounter <= 0)
                {
                    SpawnCounter = Waves[CurrentWave].TimeBetweenSpawn;

                    GameObject NewEnemy = Instantiate(Waves[CurrentWave].EnemyToSpawn, SelectSpawnPoint(),
                        quaternion.identity);
                    
                    SpawnedEnemies.Add(NewEnemy);
                }
            }
        }

        transform.position = Target.position;
    }

    private void GoToNextWave()
    {
        CurrentWave++;

        if (CurrentWave >= Waves.Count)
        {
            CurrentWave = -1;
        }

        WaveCounter = Waves[CurrentWave].WaveLenght;
        SpawnCounter = Waves[CurrentWave].TimeBetweenSpawn;
    }

    private Vector3 SelectSpawnPoint()
    {
        Vector3 SpawnPoint = Vector3.zero;

        bool SpawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;

        if (SpawnVerticalEdge)
        {
            return MinSpawn.position;
        }
        else
        {
            return MaxSpawn.position;
        }
    }
}

[System.Serializable]
public class WaveInfo
{
    public GameObject EnemyToSpawn;
    public float WaveLenght = 10f;
    public float TimeBetweenSpawn = 1f;
}
