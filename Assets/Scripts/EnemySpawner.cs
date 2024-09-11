using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyToSpawn;

    public float TimeToSpawn;
    private float SpawnCounter;

    public Transform MinSpawn, MaxSpawn;
    private Transform Target;
    private GameObject Player;
    
    void Start()
    {
        SpawnCounter = TimeToSpawn;

        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            Target = Player.GetComponent<Transform>();
        }
    }

    void Update()
    {
        SpawnCounter -= Time.deltaTime;
        if (SpawnCounter <= 0)
        {
            SpawnCounter = TimeToSpawn;
            var TransformSpawn = transform;
            Instantiate(EnemyToSpawn, SelectSpawnPoint(), TransformSpawn.rotation);
        }

        transform.position = Target.position;
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
