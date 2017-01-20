using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayersProjectile1Behaviour : MonoBehaviour
{

    private NavMeshAgent movementAgent;
    private GameObject enemyDuck { get; set; }
    public int projectileDamage { get; set; }

    // Use this for initialization
    void Start ()
    {
        enemyDuck = GameObject.FindGameObjectWithTag("EnemyDuck1") as GameObject;
        projectileDamage = 25;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.transform.position == enemyDuck.transform.position)
        {
            enemyDuck.GetComponent<EnemyBehaviour>().TakeHit(projectileDamage);
            Destroy(gameObject);
        }
    }
}
