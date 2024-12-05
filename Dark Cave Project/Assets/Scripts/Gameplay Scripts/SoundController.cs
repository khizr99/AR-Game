using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController instance;

    [SerializeField]
    private AudioClip playerJumpSound, gameOverSound, spiderJumperAttackSound, collectableSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Play_PlayerJumpSound()
    {
        AudioSource.PlayClipAtPoint(playerJumpSound, transform.position);
    }

    public void Play_GameOverSound()
    {
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
    }

    public void Play_SpiderAttackSound()
    {
        AudioSource.PlayClipAtPoint(spiderJumperAttackSound, transform.position);
    }

    public void Play_CollectableSound()
    {
        AudioSource.PlayClipAtPoint(collectableSound, transform.position);
    }

} // class





























