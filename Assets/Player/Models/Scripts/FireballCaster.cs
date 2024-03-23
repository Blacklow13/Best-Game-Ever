using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;

    public Transform fireballSourceTransform;

    public Image SpellIcon;

    public float Cooldown;

    private float _timer ;

    // Start is called before the first frame update
    void Start()
    {
        _timer = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        UpdateFireballIcon();

        if (Input.GetMouseButtonDown(0) && _timer >= Cooldown)
        {
            _timer = 0;
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
        }
    }
    void UpdateFireballIcon()
    {
        //находим текущий процент времени перезарядки (значение от 0 до 1)
        float fillAmount = _timer / Cooldown;
        //Параметр SpellIcon.fillAmount отвечает за заполнение иконки способности
        SpellIcon.fillAmount = fillAmount;
    }
}
