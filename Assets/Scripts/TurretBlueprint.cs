using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    
    public GameObject prefab;
    public int cost;
    public int upgradeCost;
    public GameObject upgradedPrefab;
    /*private int[] upgradesAvailable = new int[3];
    private string playerPref;*/

    // Start is called before the first frame update
    void Start()
    {
        /*for(int i = 0; i < 3; i++)
        {
            playerPref = string.Format(prefab.ToString());
            Debug.log(playerPref);
            upgradesAvailable = PlayerPrefs.GetInt(playerPref, new int[3]);
        }*/
        
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetSellAmount()
    {
        return (int) Mathf.Round(cost * 0.5f);
    }

    /*public void SetUpgrades(int upgradeType)
    {
        upgradesAvailable[upgradeType]++;
        PlayerPrefs.SetInt(this.playerPref, upgradesAvailable[upgradeType]);
    }*/
}
