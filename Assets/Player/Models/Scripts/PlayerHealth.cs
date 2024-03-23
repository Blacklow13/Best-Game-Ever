using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;

    public Animator animator;

    public GameObject GameplayUI;
    public GameObject GameOverScreen;

    private float _maxValue;

    // Start is called before the first frame update
    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
        GameOverScreen.SetActive(false);
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
