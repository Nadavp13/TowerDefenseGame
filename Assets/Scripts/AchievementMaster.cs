using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementMaster : MonoBehaviour
{

    public GameObject achNote;
    //Sound?
    //public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    //ach01
    // Kill 1 enemy
    public GameObject ach01Image;
    public int ach01Trigger = 1;
    private int ach01Code = 0;

    //ach02
    // Kill 100 enemies
    public GameObject ach02Image;
    public int ach02Trigger = 100;
    private int ach02Code = 0;


    //ach03
    // Kill 1000 enemies
    public GameObject ach03Image;
    public int ach03Trigger = 1000;
    private int ach03Code = 0;


    //ach04
    // Get 1000$
    public GameObject ach04Image;
    public int ach04Trigger = 1000;
    private int ach04Code = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ach01Code = PlayerPrefs.GetInt("Ach01");
        if (Enemy.GetEnemiesKilled() >= ach01Trigger && ach01Code != 1)
        {
            StartCoroutine(Trigger01Ach());
        }

        //ach02Code = PlayerPrefs.GetInt("Ach02");
        if (Enemy.GetEnemiesKilled() >= ach02Trigger && ach02Code != 2)
        {
            StartCoroutine(Trigger02Ach());
        }

        //ach03Code = PlayerPrefs.GetInt("Ach03");
        if (Enemy.GetEnemiesKilled() >= ach03Trigger && ach03Code != 3)
        {
            StartCoroutine(Trigger03Ach());
        }

        //ach04Code = PlayerPrefs.GetInt("Ach04");
        if (PlayerStats.Money >= ach04Trigger && ach04Code != 4)
        {
            StartCoroutine(Trigger04Ach());
        }
    }


    void UIReset()
    {
        achNote.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }


    IEnumerator Trigger01Ach()
    {
        achActive = true;
        ach01Code = 1;
        //PlayerPrefs.SetInt("Ach01", ach01Code);
        //achSound.Play();
        ach01Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "First Step";
        achDesc.GetComponent<Text>().text = "Killed your first enemy!";
        achNote.SetActive(true);
        yield return new WaitForSeconds(5);

        ach01Image.SetActive(false);
        UIReset();

    }

    IEnumerator Trigger02Ach()
    {
        achActive = true;
        ach02Code = 2;
        //PlayerPrefs.SetInt("Ach02", ach02Code);
        //achSound.Play();
        ach02Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "Born to kill";
        achDesc.GetComponent<Text>().text = "Killed 100 enemies";
        achNote.SetActive(true);
        yield return new WaitForSeconds(5);

        ach02Image.SetActive(false);
        UIReset();

    }

    IEnumerator Trigger03Ach()
    {
        achActive = true;
        ach03Code = 3;
        //PlayerPrefs.SetInt("Ach03", ach03Code);
        //achSound.Play();
        ach03Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "Mass Murderer";
        achDesc.GetComponent<Text>().text = "Killed 1000 enemies in one game";
        achNote.SetActive(true);
        yield return new WaitForSeconds(5);

        ach03Image.SetActive(false);
        UIReset();

    }

    IEnumerator Trigger04Ach()
    {
        achActive = true;
        ach04Code = 4;
        //PlayerPrefs.SetInt("Ach04", ach04Code);
        //achSound.Play();
        ach04Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "Getting rich";
        achDesc.GetComponent<Text>().text = "Obtain more than 1000$ in one game";
        achNote.SetActive(true);
        yield return new WaitForSeconds(5);

        ach04Image.SetActive(false);
        UIReset();

    }

}
