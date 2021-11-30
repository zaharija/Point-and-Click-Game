using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public PlayerController player;
    public AudioClip dirt;
    public AudioClip wood;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = dirt;
    }

    private void Update()
    {
        if ((player.player.transform.position.x < 25 && player.player.transform.position.z < -13) || (player.player.transform.position.x < 46 && player.player.transform.position.z < -16)) {
            audioSource.clip = wood;
        } else audioSource.clip = dirt;
    }

    private void LateUpdate()
    {
        if(player.isWalking && !audioSource.isPlaying) {
            audioSource.Play();
        }

        if(!player.isWalking && audioSource.isPlaying) {
            audioSource.Stop();
        }
    }
}
