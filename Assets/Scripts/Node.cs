using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color cantPlaceOnNodeColor;
    private Renderer rend;
    private Color startColor;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    public Vector3 positionOffset;
    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret == null && buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = cantPlaceOnNodeColor;
        }

    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }


        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        GameObject newTurret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = newTurret;
        turretBlueprint = blueprint;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret been built!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;
        Destroy(turret);
        GameObject upgradedTurret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = upgradedTurret;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("Turret upgraded!");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(turret);
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        turretBlueprint = null;

    }

}
