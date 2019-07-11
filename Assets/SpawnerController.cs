using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [Range(0f, 1f)][SerializeField] private float TimeBetweenSpawns = 0.2f;
    [SerializeField] private List<GameObject> Balls = null;
    [SerializeField] private Transform Spawnpoints = null;

    [Header("Explosion")]
    [SerializeField] private float ExplosionForce = 30f;
    [SerializeField] private float ExplosionRadius = 5f;

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
        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("Spawn", 0f, TimeBetweenSpawns);
        }

        if (Input.GetMouseButtonDown(1))
        {
            CancelInvoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Boom();
        }
    }

    private void Boom()
    {
        foreach (Transform go in this.transform)
        {
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.AddExplosionForce(ExplosionForce, Vector3.zero, ExplosionRadius);
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = Spawnpoints.GetChild(Random.Range(0, count)).position;
        Instantiate(Balls[BallCount % 7], spawnPosition, Quaternion.identity, this.transform);
        Debug.Log(Balls.Count);
        BallCount++;
    }
}
