using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    [SerializeField] float jumpZoneForce = 2f;

    bool isJumpZone;
    Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "JumpZone")
        {
            isJumpZone = true;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        AutoJump();
    }

    private void AutoJump()
    {
        if (isJumpZone)
        {
            rb.AddForce(new Vector2(0, jumpZoneForce) * CharacterManager.Instance.Player.controller.jumpPower, ForceMode.Impulse);
            isJumpZone = false;
        }
    }
}
