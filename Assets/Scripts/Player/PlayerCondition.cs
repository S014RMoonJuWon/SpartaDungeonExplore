using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    public GameObject endPanel;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action OnTakeDamage;

    private void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if(health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    private void Die()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);
    }
}