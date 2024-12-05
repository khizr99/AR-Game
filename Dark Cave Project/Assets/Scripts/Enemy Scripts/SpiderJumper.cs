using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private float minJumpForce = 5f, maxJumpForce = 12f;

    [SerializeField]
    private float minWaitTime = 1.5f, maxWaitTime = 3.5f;

    private float jumpTimer;

    private bool canJump;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        jumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
    }

    private void Update()
    {
        HandleJumping();
        HandleAnimations();
    }

    void HandleJumping()
    {
        if (Time.time > jumpTimer)
        {
            jumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
            Jump();
        }

        if (myBody.velocity.magnitude == 0)
            canJump = true;

    }

    void Jump()
    {
        if (canJump)
        {
            // SoundController.instance.Play_SpiderAttackSound();
            canJump = false;
            myBody.velocity = new Vector2(0f, Random.Range(minJumpForce, maxJumpForce));
        }
    }

    void HandleAnimations()
    {
        if (myBody.velocity.magnitude == 0)
            anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, false);
        else
            anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, true);
    }

} // class






























