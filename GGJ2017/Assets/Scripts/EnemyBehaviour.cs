using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject destination { get; set; }
    public float stepDistance { get; set; }
    private int maxHP = 100;
    private int currentHP;
    private int minHP;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
        initializeEnemyDuck();
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsDestination();

        if (currentHP <= minHP)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHit(int damage)
    {
        currentHP -= damage;
        Debug.logger.Log("took " + damage + " damage!");
    }
    

    private void initializeEnemyDuck()
    {
        stepDistance = 0.1f;
        agent = GetComponent<NavMeshAgent>();
        currentHP = maxHP;
        minHP = 0;
        destination = GameObject.FindGameObjectWithTag("Pkak") as GameObject;
    }

    private void moveTowardsDestination()
    {
        agent.SetDestination(destination.transform.position);
    }
}
