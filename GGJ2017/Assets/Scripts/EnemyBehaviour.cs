using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject Destination { get; set; }
    public float StepDistance { get; set; }
    private int maxHP = 100;
    private int currentHP;
    private int minHP;

    // Use this for initialization
    void Start ()
    {
        InitializeEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsDestination();

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
    

    private void InitializeEnemy()
    {
        StepDistance = 0.1f;
        currentHP = maxHP;
        minHP = 0;
        Destination = GameObject.FindGameObjectWithTag("pkak") as GameObject;
    }

    private void MoveTowardsDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, Destination.transform.position, StepDistance);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.tag == "tower")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
