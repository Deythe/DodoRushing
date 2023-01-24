using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private UIDocument mainUI;
    [SerializeField] private GameObject gameUI;
    private VisualElement startMenu, pauseMenu;
    private Button playButton, quitButton, restartButton, chooseLevelButton, unPauseButton;
    
    
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


        restartButton.clicked += StartGame;
        playButton.clicked += StartGame;
        quitButton.clicked += GameManager.instance.QuitGame;
        unPauseButton.clicked += UnPause;
    }

    public void Pause()
    {
        pauseMenu.style.display = DisplayStyle.Flex;
    }

    public void UnPause()
    {
        pauseMenu.style.display = DisplayStyle.None;
        GameManager.instance.UnPause();
    }
    
    private void StartGame()
    {
        startMenu.style.display = DisplayStyle.None;
        pauseMenu.style.display = DisplayStyle.None;
        GameManager.instance.RestartGame();
    }
    
}
