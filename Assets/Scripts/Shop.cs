using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncer;
    public TurretBlueprint laserBeamer;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStandardTurret()
    {   
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncer);
    }
    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
