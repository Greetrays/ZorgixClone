﻿using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]

public class MenuLoader : MonoBehaviour
{
    private CanvasGroup _mainMenu;

    public event UnityAction OpenedImproveMenu;

    private void OnEnable()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        _mainMenu = GetComponent<CanvasGroup>();
    }
    public void StartGame()
    {
        Game.Load();
    }

    private void Close()
    {
        _mainMenu.blocksRaycasts = false;
        _mainMenu.interactable = false;
    }

    private void OnClosedImproveMenu()
    {
        _mainMenu.blocksRaycasts = true;
        _mainMenu.interactable = true;
    }

    public void LoadImproveMenu()
    {
        Close();
        OpenedImproveMenu?.Invoke();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
