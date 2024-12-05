using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Play_WalkAnimation(int walk)
    {
        anim.SetInteger(TagManager.WALK_ANIMATION_PARAMETER, walk);
    }

    public void Play_JumpAnimation(bool jump)
    {
        anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, jump);
    }

    public void SetFacingDirection(int facingDir)
    {

        if (facingDir > 0)
            spriteRenderer.flipX = false;
        else if (facingDir < 0)
            spriteRenderer.flipX = true;

    }

} // class





























