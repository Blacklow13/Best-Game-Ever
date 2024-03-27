using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject ControlScreen;
    public GameObject GameplayUI;

    private int _ScreenStage;

    private void InitDisComponents()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<GranadeCaster>().enabled = false;
        ControlScreen.SetActive(false);
        GameplayUI.SetActive(false);
    }
    void Start()
    {
        InitDisComponents();
        _ScreenStage = 0;
        Time.timeScale = 0f;
    }
    private void SetScreen()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_ScreenStage == 0)
            {
                ControlScreen.SetActive(true);
                StartScreen.SetActive(false);
                _ScreenStage = 1;
            }
            else if (_ScreenStage == 1)
            {
                GameplayUI.SetActive(true);
                ControlScreen.SetActive(false);
                GetComponent<PlayerController>().enabled = true;
                GetComponent<FireballCaster>().enabled = true;
                GetComponent<CameraRotation>().enabled = true;
                GetComponent<GranadeCaster>().enabled = true;
                ControlScreen.SetActive(false);
                _ScreenStage = 2;
                Time.timeScale = 1f;

            }
        }
    }

    void Update()
    {
        SetScreen();
    }
}
