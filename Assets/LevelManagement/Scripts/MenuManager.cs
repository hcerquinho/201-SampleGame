using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    [RequireComponent(typeof(Canvas))]
    public class MenuManager : MonoBehaviour
    {
        public MainMenu mainMenuPrefab;
        public SettingsMenu settingsMenuPrefab;
        public CreditsScreen creditsMenuPrefab;
        public GameMenu gameMenuPrefab;
        public PauseMenu pauseMenuPrefab;

        [SerializeField]
        private Transform _menuParent;

        private Stack<Menu> _menuStack = new Stack<Menu>();

        private static MenuManager _instance;

        // instance to be used as a singleton
        public static MenuManager Instance { get { return _instance; } }

        private void Awake()
        {
            // allow only one instance of the singleton
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                InitializeMenus();
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
        
        private void InitializeMenus()
        {
            if (_menuParent == null)
            {
                GameObject menuParentObject = new GameObject("Menus");
                _menuParent = menuParentObject.transform;
            }

            Menu[] menuPrefabs = { mainMenuPrefab, settingsMenuPrefab, creditsMenuPrefab,
            gameMenuPrefab, pauseMenuPrefab };

            foreach (Menu prefab in menuPrefabs)
            {
                if (prefab != null)
                {
                    Menu menuInstance = Instantiate(prefab, _menuParent);
                    if (prefab != mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }

        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
            {
                Debug.LogWarning("INVALID MENU BRO");
                return;
            }
            
            if (_menuStack.Count > 0)
            {
                foreach (Menu menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }

            menuInstance.gameObject.SetActive(true);
            _menuStack.Push(menuInstance);
        }

        public void CloseMenu()
        {
            if (_menuStack.Count == 0)
            {
                Debug.LogWarning("you bitch");
                return;
            }

            Menu topMenu = _menuStack.Pop();
            topMenu.gameObject.SetActive(false);
            
            if (_menuStack.Count > 0)
            {
                Menu nextMenu = _menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }
}
