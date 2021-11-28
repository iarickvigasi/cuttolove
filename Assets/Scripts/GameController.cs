using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    Animator cameraAnimator;

    private int level;
    private bool isLevelCompleted;
    private bool isGameOver;
    UIAnimationsController uiAnimationsController;

    public GameObject heartBox;
    GameObject currentHeartBox;
    public GameObject[] levels;
    public Transform[] heartBoxStartPositions;

    GameObject previousLevel;
    GameObject currentActiveLevel;

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int value) {
        level = value;
    }

    private void Start()
    {
        cameraAnimator = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Animator>();
        uiAnimationsController = SceneManager.Instance.uiAnimationsController;

        SceneManager.Instance.uiAnimationsController.RunIntroduction();
        currentHeartBox = Instantiate(heartBox, heartBoxStartPositions[0]);
        currentHeartBox.SetActive(false);
        StartLevel(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (level != 8)
            {
                RestartLevel();
            }
        }
    }

    public void StartLevel(int level)
    {
        SetLevel(level);
        CheckUIAnimation();
        isLevelCompleted = false;
        if (level == 0) return;
        if (currentActiveLevel)
        {
            previousLevel = currentActiveLevel;
            Invoke("DestroyPreviousLevel", 1);
        }
        currentActiveLevel = Instantiate(levels[level - 1]);
        cameraAnimator.SetInteger("Level", level);
        currentActiveLevel.SetActive(true);
        currentHeartBox.SetActive(true);
    }

    private void RestartLevel()
    {
        isGameOver = false;
        uiAnimationsController.OnHideBoxSliced();
        Destroy(currentActiveLevel);
        currentActiveLevel = null;
        ResetHeartBox();
        StartLevel(level);
    }

    private void CheckUIAnimation()
    {
        switch (level)
        {
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
                Debug.Log("Show Current Level Tutorial: " + level);
                uiAnimationsController.DoOnShowCurrentLevelTutorial();
                return;
        }
    }

    public void StartFirstLevel()
    {
        StartLevel(1);
        uiAnimationsController.RunFirstLevelTutorial();
    }

    public void OnLevelComplete()
    {
        if (isLevelCompleted) return;
        if (isGameOver) return;

        isLevelCompleted = true;
        if (level == 1)
        {
            uiAnimationsController.OnFirstLevelTutorialEnd();
        }
        StartLevel(level + 1);
        if (level == 8)
        {
            Destroy(currentHeartBox);
        }
    }

    public void OnBoxMissed()
    {
        isGameOver = true;
        Destroy(currentHeartBox);
        uiAnimationsController.OnShowBoxSliced();
    }

    public void OnBoxSliced()
    {
        isGameOver = true;
        uiAnimationsController.OnShowBoxSliced();
    }

    private void DestroyPreviousLevel()
    {
        Destroy(previousLevel);
    }

    private void ResetHeartBox()
    {
        Destroy(currentHeartBox);
        currentHeartBox = Instantiate(heartBox, heartBoxStartPositions[level - 1]);
        currentHeartBox.SetActive(false);
    }

    private void FixedUpdate()
    {
        cameraAnimator.SetInteger("Level", level);
    }
}
