using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    private VisualElement mainMenu, optionMenu, createCharMenu;
    private Button buttonQuit, buttonGoToOptionMenu, buttonGoToCreateCharMenu;
    private void Awake()
    {
        mainMenu = document.rootVisualElement.Q<VisualElement>("mainMenu");
        optionMenu = document.rootVisualElement.Q<VisualElement>("option");
        createCharMenu = document.rootVisualElement.Q<VisualElement>("createChar");

        buttonGoToOptionMenu.clicked += GoToOptionMenu;
        buttonGoToCreateCharMenu.clicked += GoToCreateCharMenu;

    }

    void GoToOptionMenu()
    {
        mainMenu.SetEnabled(false);
        optionMenu.SetEnabled(true);
        createCharMenu.SetEnabled(false);
    }

    void GoToCreateCharMenu()
    {
        mainMenu.SetEnabled(false);
        optionMenu.SetEnabled(false);
        createCharMenu.SetEnabled(true);
    }
    
    void GoToCreateMainMenu()
    {
        mainMenu.SetEnabled(true);
        optionMenu.SetEnabled(false);
        createCharMenu.SetEnabled(false);
    }
}
