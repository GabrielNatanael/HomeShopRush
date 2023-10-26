using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.wayPointsPath[0];
    }
    private void Update()
    {
        //moves the enemy towards waypoints
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Changes waypoint if enemy slows down to 0.4.
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        //Destroys enemy if reach last waypoint
        if(wavepointIndex >= Waypoints.wayPointsPath.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        //Counts amount of waypoints enemy has crossed, Changes target to next waypoint.
        wavepointIndex++;
        target = Waypoints.wayPointsPath[wavepointIndex];

    }
}
