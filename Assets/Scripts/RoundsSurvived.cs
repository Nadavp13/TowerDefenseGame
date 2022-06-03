using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        yield return new WaitForSeconds(0.5f);
        for (int round = 0; round <= PlayerStats.Rounds; round++)
        {
            roundsText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
