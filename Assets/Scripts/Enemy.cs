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

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.wayPointsPath.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.wayPointsPath[wavepointIndex];

    }
}
