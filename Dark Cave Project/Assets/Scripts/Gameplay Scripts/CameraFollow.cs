using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform target;

    [SerializeField]
    private float offsetX = -5f;

    private Vector3 tempPos;

    private void Awake()
    {
        target = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {

        if (!target)
            return;

        tempPos = transform.position;
        tempPos.x = target.position.x - offsetX;
        transform.position = tempPos;
    }


} // class
































