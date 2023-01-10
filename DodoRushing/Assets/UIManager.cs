using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject menu, menuText, levelFinishedText;

    private bool _menuEnable;

    public bool menuEnable
    {
        get => _menuEnable;
        set
        {
            _menuEnable = value;
            EnableDisableMenu(value);
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        instance = this;
    }

    void EnableDisableMenu(bool b)
    {
        menu.SetActive(b);
        if (b)
        {
            Time.timeScale = 0;
            return;
        }

        Time.timeScale = 1;
    }

    public void LevelFinished()
    {
        menuText.SetActive(false);
        levelFinishedText.SetActive(true);
        menuEnable = true;
    }
}
