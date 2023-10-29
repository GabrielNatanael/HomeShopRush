using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    [SerializeField] GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More Than One BuildManager In Scene!");
        }
        Instance = this;
    }
    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild () 
    { 
        return turretToBuild;    
    }
}
