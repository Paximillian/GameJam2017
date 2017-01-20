using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

    public float sponTime;
    public GameObject[] sponbolObjects;
    public GameObject[] sponPoints;
    

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnObjects());
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            GameObject objectToSpon = sponbolObjects[Random.Range(0, sponbolObjects.Length)];
            Vector3 sponPoint = sponPoints[Random.Range(0, sponPoints.Length)].transform.position;
             Instantiate(objectToSpon, sponPoint, objectToSpon.transform.rotation);

            yield return new WaitForSeconds(sponTime);
        }
    }
}
