using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    public string enemyTag ;
    public float radius;
    public int towerHP; 
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // scans objects
        var objectsInRadius = Physics.SphereCastAll(transform.position, radius, Vector3.down, radius);

        // find nearest enemy
        GameObject closestEnemy = null;
        float minDistance = 1000;
        foreach (var hit in objectsInRadius)
        {
            var objectHit = hit.transform.gameObject;
            if (objectHit.transform.tag == enemyTag)
            {
                float enemyDistance = Vector3.Distance(this.transform.position, hit.transform.position);
                if (enemyDistance < minDistance)
                {
                    closestEnemy = hit.transform.gameObject;
                }
            }
         this.fire(closestEnemy);
        }
    }
}   
