using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public PlayerController player;
    public AudioClip dirt;
    public AudioClip wood;
    public AudioClip door;
    private AudioSource audioSource;
    private AudioSource effectSource;

    private void Awake()
    {
        audioSource = GetComponents<AudioSource>()[0];
        effectSource = GetComponents<AudioSource>()[1];
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

    public void DoorOpenSound() {
        effectSource.Play();
    }
}
