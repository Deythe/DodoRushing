using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private UIDocument mainUI, gameUI;
    private VisualElement startMenu, pauseMenu;
    private Button playButton, quitButton, restartButton, chooseLevelButton, unPauseButton;
    private ProgressBar timer;
    private Label counterFruits;

    public Action<float> UpdateProgress;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        instance = this;
        startMenu = mainUI.rootVisualElement.Q<VisualElement>("startMenu");
        pauseMenu = mainUI.rootVisualElement.Q<VisualElement>("pauseMenu");
        
        
        playButton = mainUI.rootVisualElement.Q<Button>("playButton");
        quitButton = mainUI.rootVisualElement.Q<Button>("quitButton");
        restartButton = mainUI.rootVisualElement.Q<Button>("restartButton");
        chooseLevelButton = mainUI.rootVisualElement.Q<Button>("chooseLevelButton");
        unPauseButton = mainUI.rootVisualElement.Q<Button>("unPauseButton");
        counterFruits = gameUI.rootVisualElement.Q<Label>("counter");
        timer = gameUI.rootVisualElement.Q<ProgressBar>("timer");
        
        
        restartButton.clicked += StartGame;
        playButton.clicked += StartGame;
        quitButton.clicked += GameManager.instance.QuitGame;
        unPauseButton.clicked += UnPause;

        UpdateProgress += UpdateProgressBar;
    }

    private void Start()
    {
        gameUI.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void UpdateValue(int value)
    {
        counterFruits.text = $"{value}";
    }

    void UpdateProgressBar(float f)
    {
        Debug.Log(f);
        timer.value = f;
    }

    public void Pause()
    {
        pauseMenu.style.display = DisplayStyle.Flex;
        gameUI.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void UnPause()
    {
        gameUI.rootVisualElement.style.display = DisplayStyle.Flex;
        pauseMenu.style.display = DisplayStyle.None;
        GameManager.instance.UnPause();
    }
    
    private void StartGame()
    {
        startMenu.style.display = DisplayStyle.None;
        pauseMenu.style.display = DisplayStyle.None;
        gameUI.rootVisualElement.style.display = DisplayStyle.Flex;
        GameManager.instance.RestartGame();
    }
    
}
