using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;

    public Animator animator;

    public GameObject GameplayUI;
    public GameObject GameOverScreen; 
    
    public TextMeshProUGUI SurvavialTimeUI;

    private float _startTime;
    private float _maxValue;
    private bool _isTimeNotActive;

    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _maxValue = value;
        DrawHealthBar();
        GameOverScreen.SetActive(false);
        _isTimeNotActive = true;
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            GameOver();
            PlayerIsDead();
        }
        DrawHealthBar();
    }
    private void PlayerIsDead()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<GranadeCaster>().enabled = false;
        if (_isTimeNotActive)
        {
            _isTimeNotActive = false;
            SurvavialTimeUI.text = ((int)(Time.time - _startTime) / 60).ToString() + ":" + ((int)(Time.time - _startTime) % 60).ToString();
        }
        animator.SetTrigger("death");
    }
    private void GameOver()
    {
        GameOverScreen.SetActive(true);
        GameplayUI.SetActive(false);

    }
    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
}
