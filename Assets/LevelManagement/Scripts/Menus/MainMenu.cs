﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;

namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        public void OnPlayPressed()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadNextLevel();
            }

            if (MenuManager.Instance != null && GameMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(GameMenu.Instance);
            }
        }

        public void OnSettingsPressed()
        {
            if (SettingsMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(SettingsMenu.Instance);
            }
        }

        public void OnCreditsPressed()
        {
            if (CreditsScreen.Instance != null)
            {
                MenuManager.Instance.OpenMenu(CreditsScreen.Instance);
            }
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }
    }
}
