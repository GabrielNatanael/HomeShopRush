using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("TurretMovement")]
    [SerializeField] float range = 15f;
    [SerializeField] string enemyTag = "Enemy";
    [SerializeField] Transform partToRotate;
    [SerializeField] float turnSpeed = 10f;

    [Header("FireTurret")]
    [SerializeField] float fireRate = 1f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    private Transform target;
    private float fireCountdown = 0f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void Update()
    {
        if (target == null)
        {
            return;
        }
        //SuperAdvanced Quaternion-code-which-makes-turret-turn-to-nearest-target.
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //Fire the bullets
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        //Goes into the bullet script and starts the seek function.
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        //Super simple code that finds the nearest enemy :).
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
