using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;

namespace LevelManagement
{
    public class GameMenu : Menu<GameMenu>
    {
        public void OnPausePressed()
        {
            if (PauseMenu.Instance != null)
            {
                Time.timeScale = 0;

                if (MenuManager.Instance != null && PauseMenu.Instance != null)
                {
                    MenuManager.Instance.OpenMenu(PauseMenu.Instance);
                }
            }
        }
    }
}
