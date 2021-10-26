﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SampleGame;

namespace LevelManagement
{
    public class PauseMenu : Menu<PauseMenu>
    {
        [SerializeField] int mainMenuIndex = 0;
        public void OnResumePressed()
        {
            Time.timeScale = 1;
            base.OnBackPressed();
        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            GameManager.Instance.ReloadLevel();
            base.OnBackPressed();
        }

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1;
            GameManager.Instance.LoadMainMenu();

            if (MenuManager.Instance != null && MainMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(MainMenu.Instance);
            }
        }

        public void OnQuitPressed()
        {
            Application.Quit();
        }
    }
}
