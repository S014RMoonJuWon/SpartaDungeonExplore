using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    public GameObject endPanel;

    private Coroutine speedCoroutine;

    bool isSpeedCoroutineActive = false;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

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

    public void Die()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void AddSpeed(float amount, float duration)  // 속도 증가 메소드
    {
        if(isSpeedCoroutineActive == true)
        {
            return;
        }
        speedCoroutine = StartCoroutine(IAddSpeed(amount, duration));
    }

    private IEnumerator IAddSpeed(float amount, float duration) // 속도 증가 코루틴
    {
        isSpeedCoroutineActive = true;
        CharacterManager.Instance.Player.controller.moveSpeed += amount;

        yield return new WaitForSeconds(duration);

        isSpeedCoroutineActive = false;
        CharacterManager.Instance.Player.controller.moveSpeed -= amount;
    }
}