using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    public UICondition uiCondition;

    private float lastHeight;

    bool isGround;
    Condition health { get { return uiCondition.health; } }

    void Start()
    {
        lastHeight = transform.position.y;
    }

    void Update()
    {
        if (!CharacterManager.Instance.Player.controller.IsGrounded())
        {
            lastHeight = Mathf.Max(lastHeight, transform.position.y);
        }
    }

    private void OnCollisionEnter(Collision collision) // 떨어지는 높이에 따른 데미지 계산
    {
        float fallDistance = lastHeight - transform.position.y;

        if (fallDistance > 5 && fallDistance <= 10)
        {
            health.Subtract(10);
        }

        else if( fallDistance > 10)
        {
            health.Subtract(20);
        }
            
        lastHeight = transform.position.y;
    }
}
