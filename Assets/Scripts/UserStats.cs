using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStats : MonoBehaviour
{
    private int Cash;

    // Start is called before the first frame update
    void Start()
    {
        Cash = PlayerPrefs.GetInt("Cash", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCash()
    {
        return Cash;
    }
}
