using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public GameObject standardTurretPrefab;
    public GameObject rocketTurretPrefab;

    private GameObject turretToBuild;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More Than One BuildManager In Scene!");
        }
        Instance = this;
    }

    public GameObject GetTurretToBuild () 
    { 
        return turretToBuild;    
    }
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

}
