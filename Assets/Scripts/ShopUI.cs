using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject UI;
    public Text moneyAmount;
    // Start is called before the first frame update
    void Start()
    {
        moneyAmount.text = "Money: " + PlayerPrefs.GetInt("Cash", 0).ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
