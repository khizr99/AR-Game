using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private bool timeCollectable;

    [SerializeField]
    private float collectableValue = 15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {

            SoundController.instance.Play_CollectableSound();

            if (timeCollectable)
            {
                GameplayController.instance.IncreaseTime(collectableValue);
            }
            else
            {
                GameplayController.instance.IncreaseAir(collectableValue);
            }

            gameObject.SetActive(false);
        }

    }



} // class



































