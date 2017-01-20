using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float damping = 1;
    public string enemyTag ;
    public float radius;
    public int towerHP;
    private GameObject currentEnemy;

    // Use this for initialization
    void Start()
    {
        this.currentEnemy = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.currentEnemy == null)
        {
            this.currentEnemy = this.getNearestEnemy();
            Debug.Log(currentEnemy.transform.position.ToString());
        }
        else
        {
            float curentEnemyDistance = Vector3.Distance(this.transform.position, currentEnemy.transform.position); 
            if (curentEnemyDistance >= radius)
            {
                currentEnemy = null;
            }
        }
        this.changeHeading(currentEnemy);
        this.fire(currentEnemy);

    }
    private void fire(GameObject enemy)
    {
        if (enemy == null)
        {
            return;
        }
        else
        {
            // add bullet with enemy object as destenation

        }
    }
    private GameObject getNearestEnemy()
    {
        // scans objects
        var objectsInRadius = Physics.SphereCastAll(transform.position, radius, Vector3.down, radius);

        // find nearest enemy
        GameObject closestEnemy = null;
        float minDistance = 1000;
        foreach (var hit in objectsInRadius)
        {
            GameObject objectHit = hit.transform.gameObject;
            if (objectHit.transform.tag == enemyTag)
            {
                float enemyDistance = Vector3.Distance(this.transform.position, hit.transform.position);
                if (enemyDistance < minDistance)
                {
                    closestEnemy = hit.transform.gameObject;
                    minDistance = enemyDistance;
                }
            }
        }
        return closestEnemy;
    }
    private void changeHeading(GameObject enemy)
    {
        Vector3 relativeVecotor = this.transform.position - enemy.transform.position;
        relativeVecotor.y = 0;
        var rotationFactor = Quaternion.LookRotation(relativeVecotor);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotationFactor, Time.deltaTime * damping);

    }
}   
