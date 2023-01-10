using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private PlayerController plc;
    private PlayerInputs _inputs; 
    private bool gameFinished;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (instance != null)
        {
            Destroy(instance);
        }
        
        instance = this;
        _inputs = new PlayerInputs();
        _inputs.Enable();
        plc._inputs = _inputs;
    }

    private void Update()
    {
        if (_inputs.Menu.OpenMenu.WasPressedThisFrame() && !gameFinished)
        {
            UIManager.instance.menuEnable = !UIManager.instance.menuEnable;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void FinisGame()
    {
        gameFinished = true;
        UIManager.instance.LevelFinished();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
