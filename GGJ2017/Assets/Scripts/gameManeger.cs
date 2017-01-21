using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManeger : MonoBehaviour {
    private GameObject m_IsDragging;
    private float distance;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver() == true)
        {
            gameOver();
        }
        if (m_IsDragging != null)
        {
            doDrag();
        }
        getInput();
	}

    private void doDrag()
    {
        //Vector3 camera = Camera.main.transform.position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit objectHitted;
       // Vector3 offset = Input.mousePosition - Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        if (Physics.Raycast(ray, out objectHitted, 1 << LayerMask.NameToLayer("plane")))
        {

          //  m_IsDragging.transform.position = objectHitted.point ;
           // m_IsDragging.transform.up = objectHitted.normal;
            distance = Vector3.Distance(objectHitted.transform.position, Camera.main.transform.position);
           Ray rayy = Camera.main.ScreenPointToRay(Input.mousePosition);
           Vector3 rayPoint = rayy.GetPoint(distance);
           objectHitted.transform.position = rayPoint;
        }

        if(Input.GetMouseButton(0) == false)
        {
            m_IsDragging.GetComponent<TowerBehaviour>().startLifeCondown();
            m_IsDragging = null;
        }

    }

    private void getInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            dragTower();

        }
    }

    private void dragTower()
    {
        //Vector3 camera = Camera.main.transform.position;
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition);
        RaycastHit objectHitted;
        if  (Physics.Raycast(ray, out objectHitted))
        {
            if (objectHitted.transform.tag == "tower")
            {
                objectHitted.transform.GetComponent<TowerBehaviour>().StopAllCoroutines();
                m_IsDragging = objectHitted.collider.gameObject;
            }

        }
       
    }

    private void gameOver()
    {
        //add cool gameover stuff
        GetComponent<ObjectGenerator>().gameOver();
    }

    private bool isGameOver()
    {
        if (GameObject.FindGameObjectWithTag("tower") == null)
        {
            return true;
        }
        else
        {
            return false;
        }

                

    }
}
