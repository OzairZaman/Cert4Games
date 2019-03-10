using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    private Transform target; // will hold the current waypoint
    private int currIndex = 0;
    
    // Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {

        //call Patrol method
        Patrol();
    }


    void Patrol()
    {
        //target = Waypoints._waypoints[currIndex];
        //Vector3 dir = target.position - this.transform.position;
        //this.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        this.transform.position = Vector3.MoveTowards(transform.position, Waypoints._waypoints[currIndex].position, speed * Time.deltaTime);
    }
}
