using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] wayPointsPath;

    private void Awake()
    {
        //Counts amount of waypoints inside of waypoint object.
        wayPointsPath = new Transform[transform.childCount];

        for(int i = 0; i < wayPointsPath.Length; i++)
        {
            wayPointsPath[i] = transform.GetChild(i);
        }
    }
}
