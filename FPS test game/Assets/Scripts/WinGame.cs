using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField]
    GameObject targets;
    [SerializeField]
    float waitBeforeRestart;
    [SerializeField]
    GameObject summaryText;
    [SerializeField]
    float waitForChildDestruction=0.1f;
    bool win = false;
    public void CheckWinConditions()=>StartCoroutine(WaitForSecond());

    IEnumerator WaitForSecond()
    {
        if (win)
        {
            summaryText.SetActive(true);
            yield return new WaitForSeconds(waitBeforeRestart);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            yield return new WaitForSeconds(waitForChildDestruction);
            if (targets.transform.childCount == 0)
            {
                win = true;
                StartCoroutine(WaitForSecond());
            }
            //Debug.Log("targets.transform.childCount " + targets.transform.childCount);
        }

    }
}

