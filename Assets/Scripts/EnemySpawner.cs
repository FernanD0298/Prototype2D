using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private float SpawnCounter;

    public Transform MinSpawn, MaxSpawn;
    private Transform Target;
    private GameObject Player;

    private List<GameObject> SpawnedEnemies = new List<GameObject>();
    public List<GameObject> KilledEnemies = new List<GameObject>();

    public List<WaveInfo> Waves;
    private int CurrentWave = 0;
    private float WaveCounter;

    void Start()
    {
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
            if (CurrentWave < Waves.Count && CurrentWave >= 0)
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
            else
            {
                if (KilledEnemies.Count == SpawnedEnemies.Count)
                    StartCoroutine(ReturnLobby());
            }
        }

        transform.position = Target.position;
    }

    IEnumerator ReturnLobby()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }

    private void GoToNextWave()
    {
        CurrentWave++;

        if (CurrentWave >= Waves.Count)
        {
            CurrentWave = -1;
        }

        if (CurrentWave >= 0)
        {
            WaveCounter = Waves[CurrentWave].WaveLenght;
            SpawnCounter = Waves[CurrentWave].TimeBetweenSpawn;
        }
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
