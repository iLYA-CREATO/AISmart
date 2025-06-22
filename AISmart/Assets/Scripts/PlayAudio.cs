using UnityEngine;

public static class PlayAudio
{
    public static void _PlayAudio(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
