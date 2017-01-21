using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayersProjectile1Behaviour : MonoBehaviour
{
    public GameObject Enemy { get; set; }
    public int projectileDamage { get; set; }

    // Use this for initialization
    void Start ()
    {
        projectileDamage = 25;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Enemy == null)
        {
            return;
        }

        if (gameObject.transform.position == Enemy.transform.position)
        {
            Enemy.GetComponent<EnemyBehaviour>().TakeHit(projectileDamage);
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Enemy.transform.position, 0.5f);
        }
    }
}
