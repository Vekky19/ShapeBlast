using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject MenuButton;
    public Image PauseOverlay;
    public GameObject VolumeSlider;

    public SloMotion sloMo;

    bool temp;

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        MenuButton.SetActive(false);
        PauseOverlay.enabled = false;
        VolumeSlider.SetActive(false);
    }

    void TogglePause(bool temp)
    {
        MenuButton.SetActive(temp);
        PauseOverlay.enabled = !PauseOverlay.enabled;
        VolumeSlider.SetActive(temp);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuButton.activeSelf == true)
            {
                temp = false;
                sloMo.timescaleValue = 1;
            }
            else
            {
                temp = true;
                sloMo.timescaleValue = 0;
            }
            TogglePause(temp);
        }
        else
        {

        }
    }
}
