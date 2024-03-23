using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GranadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform grenadeSourceTransform;
    public Image SpellIcon;
    
    public float force = 10;

    public float Cooldown;

    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _timer = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        UpdateGranadelIcon();
        if (Input.GetMouseButtonDown(1) && _timer >= Cooldown)
        {
            _timer = 0;
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
        }
    }
    void UpdateGranadelIcon()
    {
        //находим текущий процент времени перезарядки (значение от 0 до 1)
        float fillAmount = _timer / Cooldown;
        //Параметр SpellIcon.fillAmount отвечает за заполнение иконки способности
        SpellIcon.fillAmount = fillAmount;
    }
}
