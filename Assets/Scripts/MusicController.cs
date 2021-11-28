using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    // Audio players components.
    public AudioSource MusicSource;

	public AudioClip[] audioClips;

    int currentTrack = 0;

    private void Start()
    {
        PlayMusic(audioClips[currentTrack]);
    }

    private void Update()
    {
        if (MusicSource.isPlaying != true)
        {
            NextSong();
        }
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

    void NextSong()
    {
        currentTrack++;
        if (currentTrack == audioClips.Length)
        {
            currentTrack = 0;
        }
        PlayMusic(audioClips[currentTrack]);
    }
}
