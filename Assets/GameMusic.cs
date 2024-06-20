using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioClip[] songs; // Array of AudioClip objects for your songs
    private AudioSource audioSource;
    private int currentSongIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Start playing the first song
        PlayNextSong();
    }

    void Update()
    {

        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        // Play the next song in the array
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();

        // Move to the next index in the array
        currentSongIndex++;

        // If we've reached the end of the array, loop back to the beginning
        if (currentSongIndex >= songs.Length)
        {
            currentSongIndex = 0;
        }
    }
}