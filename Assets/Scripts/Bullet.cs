using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 70f;
    [SerializeField] GameObject impactEffect;

    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    private void Update()
    {
        //if target dies before the bullet hits the bullet deletes itself
        if (target == null)
        {
            Destroy(gameObject); 
            return;
        }

        //Sends bullet towards target and tells us if we hit it.
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
