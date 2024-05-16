using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealthBar : MonoBehaviour
{
    public Slider slider;
    private enemyState enemy;

    private void Start()
    {
        enemy = GetComponent<enemyState>();
        slider.maxValue = enemy.health;
    }

    void Update()
    {
        slider.value = enemy.health;
    }
}
