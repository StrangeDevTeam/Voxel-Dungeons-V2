﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public static GameObject InteractionPanel;
    public static GameObject DialoguePanel;
    public static GameObject DialogueChoices;
    public static GameObject QuestHelperPanel;
    public static GameObject MenuPanel;


    public static bool isCursorVisible = true; //when true, the user can use mouse to navigate menus without rotating the camera or player in game
    public static bool areMenusOpen = false;
    
    void Start()
    {

        InteractionPanel = GameObject.Find("InteractionPanel");
        InteractionPanel.SetActive(false);

        DialogueChoices = GameObject.Find("DialogueChoices");
        DialogueChoices.SetActive(false);

        DialoguePanel = GameObject.Find("DialoguePanel");
        DialoguePanel.SetActive(false);

        QuestHelperPanel = GameObject.Find("QuestHelperPanel");
        QuestHelperPanel.SetActive(false);

        MenuPanel = GameObject.Find("MenuPanel");
        MenuPanel.SetActive(false);

        ShowQuestHelper();


        ToggleMenus(); //default to cursor invisible on start
    }
    

    void Update()
    {
        //when escape is pressed, toggle whether mouse moved charcter or cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenus();
        }

        // quick inventory open
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isCursorVisible)
            {
                ToggleMenus();
            }
            MenuUIController.singleton.InventoryQuickOpen();
        }
    }

    /// <summary>
    /// toggle between Locking cursor for player rotation, and unlocking cursor for navigating menus
    /// </summary>
    public static void ToggleMenus()
    {
        isCursorVisible = !isCursorVisible;          
        if (isCursorVisible)                          
            UnityEngine.Cursor.lockState = CursorLockMode.None;  
        else                                         
            UnityEngine.Cursor.lockState = CursorLockMode.Locked; 
        UnityEngine.Cursor.visible = isCursorVisible;
        areMenusOpen = isCursorVisible;

        MenuPanel.SetActive(areMenusOpen);


        if (!areMenusOpen)
        {
            MenuUIController.singleton.CloseAllMenus();
        }
        else
        {
            MenuUIController.currentMenuCentered = MenuUIController.MenuCentered.Main;
        }

    }

    /// <summary>
    /// Show "press f to interact"
    /// </summary>
    public static void ShowInteractionTooltip()
    {
        InteractionPanel.SetActive(true);
        InteractionPanel.GetComponentInChildren<Text>().text = "Press F to Interact";
    }
    public static void ShowInteractionTooltip(string message)
    {
        InteractionPanel.SetActive(true);
        InteractionPanel.GetComponentInChildren<Text>().text = message;
    }
    /// <summary>
    /// hide "press f to interact"
    /// </summary>
    public static void HideInteractionTooltip()
    {
        InteractionPanel.SetActive(false);
    }


    public static void ShowDialogueBox(string text)
    {
        Text dialogueText = DialoguePanel.GetComponentInChildren<Text>();
        dialogueText.text = text;
        DialoguePanel.SetActive(true);
    }
    public static void HideDialogueBox()
    {
        DialoguePanel.SetActive(false);
    }

    public static void ShowDialogueChoices(string text)
    {
        Text dialogueChoiceText = DialogueChoices.GetComponentInChildren<Text>();
        dialogueChoiceText.text = text;
        DialogueChoices.SetActive(true);
    }
    public static void HideDialogueChoices()
    {
        DialogueChoices.SetActive(false);
    }

    public static void ShowQuestHelper()
    {
        QuestHelperPanel.SetActive(true);
    }
    public static void HideQuestHelper()
    {
        QuestHelperPanel.SetActive(false);
    }
}
