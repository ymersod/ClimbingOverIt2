using System.Collections;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource backgroundAudio;
    public AudioClip nightAudio;
    public AudioClip sunriseAudio;
    public AudioClip dayAudio;
    public AudioClip sunsetAudio;

    // Fade out the current audio, switch the clip, and fade it back in
    public void ChangeBackgroundMusic(AudioClip newClip, float fadeDuration = 2f)
    {
        if (backgroundAudio.clip == newClip)
            return; // Skip if the new clip is already playing

        StartCoroutine(FadeOutAndChangeClip(newClip, fadeDuration));
    }

    private IEnumerator FadeOutAndChangeClip(AudioClip newClip, float fadeDuration)
    {
        // Fade out
        float startVolume = backgroundAudio.volume;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            backgroundAudio.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }
        backgroundAudio.Stop();

        // Change the clip and play
        backgroundAudio.clip = newClip;
        backgroundAudio.Play();

        // Fade in
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            backgroundAudio.volume = Mathf.Lerp(0, startVolume, t / fadeDuration);
            yield return null;
        }
        backgroundAudio.volume = startVolume;
    }
}
