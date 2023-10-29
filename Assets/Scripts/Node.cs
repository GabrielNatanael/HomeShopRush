using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Vector3 positionOffset;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't Build Here!-todo place on screen");
            return;
        }
        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    //When mouse enters the color changes and when it exites the color goes back to its original color.
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
