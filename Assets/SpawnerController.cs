using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [Range(0f, 1f)][SerializeField] private float TimeBetweenSpawns = 0.2f;
    [SerializeField] private List<GameObject> Balls = null;
    [SerializeField] private Transform Spawnpoints = null;

    [HideInInspector] public int BallCount = 0;
    private int count = 0;

    private void Start()
    {
        count = Spawnpoints.childCount;
        if (Input.GetMouseButtonDown(0))
        InvokeRepeating("Spawn", 0f, TimeBetweenSpawns);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            InvokeRepeating("Spawn", 0f, TimeBetweenSpawns);
        }

        if (Input.GetMouseButtonDown(0))
        {
            CancelInvoke();
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = Spawnpoints.GetChild(Random.Range(0, count)).position;
        Instantiate(Balls[BallCount % 2], spawnPosition, Quaternion.identity, this.transform);
        BallCount++;
    }
}
