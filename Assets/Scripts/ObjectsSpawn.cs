using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawn : MonoBehaviour
{
    public int numberOfObjects;
    public int numberOfGameObjects;
    public GameObject[] Ball;
    public GameObject[] GameObjects;
    public Transform[] Cannons;
    private bool formation = false;
    private bool formationCannon_1 = false;
    private bool formationCannon_2 = false;
    private float DelayBetweenSpawnStart = 2f;
    private float DelayBetweenSpawnEnd = 4f;

    void Start()
    {
        StartCoroutine(RaisingDifficalty());
        StartCoroutine(RaisingDifficaltyAgain());
    }

    void FixedUpdate()
    {
        if (!formation)
        {
            StartCoroutine(SpawnBalls());
        }
        if (!formationCannon_1)
        {
            StartCoroutine(SpawnObjects_1());
        }
        if (!formationCannon_2)
        {
            StartCoroutine(SpawnObjects_2());
        }
    }

    private IEnumerator SpawnBalls()
    {
        formation = true;
        yield return new WaitForSeconds(Random.Range(DelayBetweenSpawnStart, DelayBetweenSpawnEnd));
        int index = Random.Range(0, numberOfObjects);
        Instantiate(Ball[index], new Vector3(0, -0.5f, 14), Quaternion.identity);
        formation = false;
    }

    private IEnumerator SpawnObjects_1()
    {
        formationCannon_1 = true;
        yield return new WaitForSeconds(Random.Range(4, 8));
        int index = Random.Range(0, numberOfGameObjects);
        Instantiate(GameObjects[index], Cannons[0].position, Quaternion.identity);
        formationCannon_1 = false;
    }

    private IEnumerator SpawnObjects_2()
    {
        formationCannon_2 = true;
        yield return new WaitForSeconds(Random.Range(4, 8));
        int index = Random.Range(0, numberOfGameObjects);
        Instantiate(GameObjects[index], Cannons[1].position, Quaternion.identity);
        formationCannon_2 = false;
    }

    IEnumerator RaisingDifficalty()
    {
        yield return new WaitForSeconds(10f);
        DelayBetweenSpawnStart = 1f;
        DelayBetweenSpawnEnd = 2f;
    }

    IEnumerator RaisingDifficaltyAgain()
    {
        yield return new WaitForSeconds(20f);
        DelayBetweenSpawnStart = 0.3f;
        DelayBetweenSpawnEnd = 1f;
    }
}
