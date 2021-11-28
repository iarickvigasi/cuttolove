using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameController gameController;
    public UIAnimationsController uiAnimationsController;
    public MainPlatform mainPlatform;

    public static SceneManager Instance { get; private set; } // static singleton

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        // Cache references to all desired variables
        gameController = FindObjectOfType<GameController>();
        uiAnimationsController = FindObjectOfType<UIAnimationsController>();
        mainPlatform = FindObjectOfType<MainPlatform>();
    }
}
