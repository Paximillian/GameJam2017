using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject destination { get; set; }
    public float stepDistance { get; set; }
    private int maxHP = 1000;
    private int currentHP;
    private int minHP;

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
        currentHP = maxHP;
        minHP = 0;
        destination = GameObject.FindGameObjectWithTag("pkak") as GameObject;
    }

    private void moveTowardsDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 0.1f);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("shrmota");
        if (other.gameObject.transform.tag == "tower")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
