using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationsController : MonoBehaviour
{
    public GameObject introductionGameObject;
    public GameObject firstLevelTutorial;

    public GameObject[] levelTutorials;
    public int currentLevel;

    public GameObject boxSliced;
    private IEnumerator coroutine;

    public void RunIntroduction()
    {
        introductionGameObject.SetActive(true);
    }
    public void OnIntroductionEnd()
    {
        introductionGameObject.SetActive(false);
        introductionGameObject.GetComponent<Animator>().StopPlayback();
        SceneManager.Instance.gameController.StartFirstLevel();
    }

    public void RunFirstLevelTutorial()
    {
        firstLevelTutorial.SetActive(true);
    }
    public void OnFirstLevelTutorialEnd()
    {
        firstLevelTutorial.GetComponent<Animator>().SetBool("Dissapear", true);
    }

    public void OnShowBoxSliced()
    {
        boxSliced.SetActive(true);
        boxSliced.GetComponent<Animator>().SetBool("Hide", false);
    }
    public void OnHideBoxSliced()
    {
        boxSliced.GetComponent<Animator>().SetBool("Hide", true);

        Invoke("OnHideBoxSlicedEnd", 1);
    }
    void OnHideBoxSlicedEnd()
    {
        boxSliced.SetActive(false);
    }

    public void DoOnShowCurrentLevelTutorial()
    {
        Debug.Log("Courotine Before ");
        StartCoroutine("onShowCurrentLevelTutorial");
        StartCoroutine("onShowCurrentLevelTutorial");
        StartCoroutine("onShowCurrentLevelTutorial");
        Debug.Log("Courotine AFter ");
    }

    IEnumerator onShowCurrentLevelTutorial()
    {
        Debug.Log("Courotine: ");
        int curLevel = SceneManager.Instance.gameController.GetLevel();
        if (curLevel >= 2 && curLevel != 8)
        {
            Debug.Log("Show Current Level Tutorial > 2 Courotine: " + curLevel.ToString());
            GameObject currentLevelTutorial = SceneManager.Instance.uiAnimationsController.levelTutorials[curLevel - 1];

            if (!currentLevelTutorial) yield return new WaitForEndOfFrame();
            currentLevelTutorial.SetActive(true);
            yield return new WaitForSeconds(15);
            currentLevelTutorial.GetComponent<Animator>().SetBool("Hide", true);
            yield return new WaitForSeconds(1);
            currentLevelTutorial.transform.GetChild(0).gameObject.SetActive(false);
            yield return null;
        }
        else if (curLevel == 8)
        {
            GameObject currentLevelTutorial = SceneManager.Instance.uiAnimationsController.levelTutorials[curLevel - 1];
            currentLevelTutorial.SetActive(true);
        }
    }

}
