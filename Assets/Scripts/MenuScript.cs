using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject[] levelButtons;

    private void Start()
    {
        if (levelButtons.Length > 0)
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                levelButtons[i].SetActive(false);
            }
        }
    }

    public void ShowLevels()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].SetActive(true);
        }
    }

    public void StartGame()
    {
        ShowLevels();
    }

    public void StartEasy()
    {
        SceneManager.LoadScene("Level_Easy");
    }

    public void StartMedium()
    {
        SceneManager.LoadScene("Level_Medium");
    }

    public void StartHard()
    {
        SceneManager.LoadScene("Level_Hard");
    }

    public void ShowAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
