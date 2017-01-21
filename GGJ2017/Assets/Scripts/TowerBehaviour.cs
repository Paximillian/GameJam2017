using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float damping = 1;
    [SerializeField]
    public string enemyTag;
    [SerializeField]
    public float radius;
    [SerializeField]
    public int towerHP;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    public float timeBetweenShots;
    [SerializeField]
    public float LifeTime;
    private bool canFire;
    private GameObject currentEnemy;


    // Use this for initialization
    void Start()
    {
        this.currentEnemy = null;
        this.canFire = true;
        startLifeCondown();

    }

    public void startLifeCondown()
    {
        StartCoroutine(this.Life());
    }

    private IEnumerator Life()
    {
        Debug.Log(LifeTime);
        yield return new WaitForSeconds(LifeTime);
        
        this.drown();

    }

    private void drown()
    {
        // add animations and sound for drowining//
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.currentEnemy == null)
        {
           // Debug.Log("lost enemy");
            this.currentEnemy = this.getNearestEnemy();

        }
        else
        {
            this.lookAtEnemy(currentEnemy);
            float curentEnemyDistance = Vector3.Distance(this.transform.position, currentEnemy.transform.position);
            if (curentEnemyDistance >= radius)
            {
                currentEnemy = null;
            }
        }

        if (canFire == true)
        {
            this.fire(currentEnemy);
            canFire = false;
            StartCoroutine( canFireWaitTime());

        }

    }
    private IEnumerator canFireWaitTime()
    {
        //while (true)
        {
            yield return new WaitForSeconds(this.timeBetweenShots);
            canFire = true;
        }

    }
    private void fire(GameObject enemy)
    {
        if (enemy == null)
        {
            return;
        }
        else
        {
            var go = Instantiate(Bullet, this.transform.position, new Quaternion());
            go.GetComponent<PlayersProjectile1Behaviour>().Enemy = enemy;

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
    private void lookAtEnemy(GameObject enemy)
    {
        if (enemy == null)
        {

        }
        else
        {
            Vector3 relativeVecotor = this.transform.position - enemy.transform.position;
            relativeVecotor.y = 0;
            var rotationFactor = Quaternion.LookRotation(relativeVecotor);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotationFactor, Time.deltaTime * damping);
        }


    }
} 
