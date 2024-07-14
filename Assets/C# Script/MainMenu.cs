using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject menu;
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitLevel()
    {
        Application.Quit();
    }
    public void ChoosePlayer()
    {
        mainMenu.SetActive(false);
        menu.SetActive(true);
    }
}
