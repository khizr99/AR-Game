using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    private SpriteRenderer spriteRen;

    private Transform groundCheckPos;

    [SerializeField]
    private LayerMask groundLayer;

    private RaycastHit2D groundHit;

    [SerializeField]
    private float moveSpeed = 5f;

    private bool moveLeft;

    private Vector3 tempPos;
    private Vector3 tempScale;

    private float scaleXValue;

    [SerializeField]
    private float maxWalkDistanceValue = 10f;

    private float minWalkX, maxWalkX;

    [SerializeField]
    private bool walkWithGroundCheck;

    private void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        groundCheckPos = transform.GetChild(0);

        moveLeft = Random.Range(0, 2) > 0 ? true : false;

        scaleXValue = transform.localScale.x;

        minWalkX = transform.position.x - maxWalkDistanceValue;
        maxWalkX = transform.position.x + maxWalkDistanceValue;

    }

    private void Update()
    {
        HandleWalkignWithGroundCheck();
        CheckForGround();

        HandleWalkingWithWalkDistance();

    }

    void CheckForGround()
    {

        groundHit = Physics2D.Raycast(groundCheckPos.position,
            Vector2.down, 0.1f, groundLayer);

        if (!groundHit)
            moveLeft = !moveLeft;

    }

    void HandleWalkignWithGroundCheck()
    {
        if (!walkWithGroundCheck)
            return;

        tempPos = transform.position;
        tempScale = transform.localScale;

        //spriteRen.flipX = moveLeft;

        if (moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
            tempScale.x = -scaleXValue;
        }
        else
        {
            tempPos.x += moveSpeed * Time.deltaTime;
            tempScale.x = scaleXValue;
        }

        transform.position = tempPos;
        transform.localScale = tempScale;

    }

    void HandleWalkingWithWalkDistance()
    {

        if (walkWithGroundCheck)
            return;

        tempPos = transform.position;

        if (moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
        }
        else
        {
            tempPos.x += moveSpeed * Time.deltaTime;
        }

        transform.position = tempPos;

        spriteRen.flipX = moveLeft;

        if (tempPos.x < minWalkX)
            moveLeft = false;

        if (tempPos.x > maxWalkX)
            moveLeft = true;

    }

} // class

































