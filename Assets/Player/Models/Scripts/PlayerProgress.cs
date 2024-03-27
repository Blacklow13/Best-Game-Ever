using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public TextMeshProUGUI ScoreOfKillsUI;
    public TextMeshProUGUI ScoreOfKillsUIEndScreen;

    public AudioSource Sound;

    private int scoreOfKills;
  

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DrawUI();
    }

    public void AddKils()
    {
        Sound.Play();
        scoreOfKills++;
    }
    private void DrawUI()
    {
        ScoreOfKillsUI.text = scoreOfKills.ToString();
        ScoreOfKillsUIEndScreen.text = scoreOfKills.ToString();
    
        
    }

}
