using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{

    public float SpawnTime;
    public GameObject[] SpawnableObjects;
    public GameObject[] SpawnPoints;
    private bool isGameOver;

    // Use this for initialization
    void Start()
    {
        isGameOver = false;
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObjects()
    {
        while (isGameOver == false)
        {
            GameObject objectToSpawn = SpawnableObjects[Random.Range(0, SpawnableObjects.Length)];
            Vector3 spawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position;
            Instantiate(objectToSpawn, spawnPoint, objectToSpawn.transform.rotation);

            yield return new WaitForSeconds(SpawnTime);
        }
    }

    public void gameOver()
    {
        isGameOver = true;
    }
}
