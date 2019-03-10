using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    // we are creating a static aray of waypoint transform
    public static Transform[] _waypoints;
    

    private void Awake()
    {
        

        GetAllWayPoints();

         
        
    }

    private void Update()
    {
        if (this.transform.childCount > _waypoints.Length)
        {
            GetAllWayPoints();
        }
    }

    //this method gets all child waypoints and puts
    //them in the array.
    void GetAllWayPoints()
    {

        // set the array to the size of the number of children of this transform
        // (waypoints will be created as child to the game object that this 
        // script is attachted to.
        _waypoints = new Transform[this.transform.childCount];

        //iterate through the array and assign
        for (int i = 0; i < _waypoints.Length; i++)
        {
            _waypoints[i] = this.transform.GetChild(i);
        }

        print(_waypoints.Length);
    }
}
