using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Vector3 positionOffset;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.Instance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        { return; }

        if (buildManager.GetTurretToBuild()==null)
        { return; }

        if (turret != null)
        {
            Debug.Log("Can't Build Here!-todo place on screen");
            return;
        }
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    //When mouse enters the color changes and when it exites the color goes back to its original color.
    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject()) 
        { return; }

        if (buildManager.GetTurretToBuild() == null)
        { return; }

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
