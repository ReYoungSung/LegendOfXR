using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioData
{
    public string title;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f; // Volume for each audio clip
    [HideInInspector] public AudioSource audioSource; // Reference to AudioSource
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public List<AudioData> bgmList;
    public List<AudioData> sfxList;
    [HideInInspector] public List<AudioSource> audioSources; // List of AudioSources for concurrent playback

    private Dictionary<string, AudioClip> bgmClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (AudioData bgmData in bgmList)
            {
                bgmClips[bgmData.title] = bgmData.clip;
                bgmData.audioSource = gameObject.AddComponent<AudioSource>();
            }

            foreach (AudioData sfxData in sfxList)
            {
                sfxClips[sfxData.title] = sfxData.clip;
                sfxData.audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(string bgmTitle)
    {
        if (!bgmClips.ContainsKey(bgmTitle))
        {
            Debug.LogError("Invalid BGM title");
            return;
        }

        AudioData bgmData = bgmList.Find(data => data.title == bgmTitle);
        AudioSource availableSource = GetAvailableAudioSource();
        if (availableSource != null)
        {
            availableSource.clip = bgmClips[bgmTitle];
            availableSource.volume = bgmData.volume;
            availableSource.loop = true;
            availableSource.Play();
        }
        else
        {
            Debug.LogError("No available AudioSource for BGM playback");
        }
    }

    public void PlaySFX(string sfxTitle)
    {
        if (!sfxClips.ContainsKey(sfxTitle))
        {
            Debug.LogError("Invalid SFX title");
            return;
        }

        AudioData sfxData = sfxList.Find(data => data.title == sfxTitle);
        AudioSource availableSource = GetAvailableAudioSource();
        if (availableSource != null)
        {
            availableSource.PlayOneShot(sfxClips[sfxTitle], sfxData.volume);
        }
        else
        {
            Debug.LogError("No available AudioSource for SFX playback");
        }
    }

    public void StopAudio(string audioTitle)
    {
        if (bgmClips.ContainsKey(audioTitle))
        {
            bgmList.Find(data => data.title == audioTitle).audioSource.Stop();
        }
        else if (sfxClips.ContainsKey(audioTitle))
        {
            sfxList.Find(data => data.title == audioTitle).audioSource.Stop();
        }
        else
        {
            Debug.LogError("Invalid audio title");
        }
    }

    private AudioSource GetAvailableAudioSource()
    {
        foreach (var source in audioSources)
        {
            if (!source.isPlaying)
                return source;
        }
        return null;
    }
}

