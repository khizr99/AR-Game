using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    
    void Start()
    {
        Door.instance.RegisterDiamond();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            SoundController.instance.Play_CollectableSound();
            Door.instance.DiamondCollected();
            gameObject.SetActive(false);
        }

    }


} // class
