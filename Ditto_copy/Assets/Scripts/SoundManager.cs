using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AudioSourceInfo
{
    public string name;
    public AudioSource source;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] List<AudioSourceInfo> BGMList = new List<AudioSourceInfo>();
    [SerializeField] List<AudioSourceInfo> SFXList = new List<AudioSourceInfo>();

    private Dictionary<string, AudioSource> bgmAudioSources = new Dictionary<string, AudioSource>();
    private Dictionary<string, AudioSource> sfxAudioSources = new Dictionary<string, AudioSource>();

    float volume = 0.3f;

    [SerializeField] private GameObject Handle;
    

    private void Awake()
    {
        instance = this;
        InitializeAudioSources();
    } 

    void Update() 
    {
        ChangeVolumeAllBGM(volume*Handle.GetComponent<Scrollbar>().value);
    
    }

    private void InitializeAudioSources()
    {
        InitializeAudioSourceList(BGMList, bgmAudioSources); 
        InitializeAudioSourceList(SFXList, sfxAudioSources); 
    }

    private void InitializeAudioSourceList(List<AudioSourceInfo> sourceList, Dictionary<string, AudioSource> targetDictionary)
    {
        foreach (var audioSourceInfo in sourceList)
        {
            if (!audioSourceInfo.source)
            {
                Debug.LogError("AudioSource in SoundManager is not assigned for: " + audioSourceInfo.name);
                continue;
            }

            if (!string.IsNullOrEmpty(audioSourceInfo.name))
            {
                if (!targetDictionary.ContainsKey(audioSourceInfo.name))
                {
                    targetDictionary[audioSourceInfo.name] = audioSourceInfo.source; 
                }
                else
                {
                    Debug.LogError("Duplicate AudioSource name found: " + audioSourceInfo.name); 
                }
            }
        } 
    }

    public void PlayBGM(string bgmTitle)
    {
        if (bgmAudioSources.ContainsKey(bgmTitle))
        {
            AudioSource bgmSource = bgmAudioSources[bgmTitle];
            bgmSource.volume = volume;
            bgmSource.loop = true;
            bgmSource.Play();
        }
        else
        {
            Debug.LogError("Invalid BGM title: " + bgmTitle);
        }
    }

    public void PlaySFX(string sfxTitle, float volume = 1.2f)
    {
        if (sfxAudioSources.ContainsKey(sfxTitle))
        {
            AudioSource sfxSource = sfxAudioSources[sfxTitle];
            sfxSource.volume = volume;
            sfxSource.Play();
        }
        else
        {
            Debug.LogError("Invalid SFX title: " + sfxTitle);
        }
    }

    public void StopBGM(string bgmTitle)
    {
        if (bgmAudioSources.ContainsKey(bgmTitle))
        {
            AudioSource bgmSource = bgmAudioSources[bgmTitle];
            bgmSource.Stop();
        }
        else
        {
            Debug.LogError("Invalid BGM title: " + bgmTitle);
        }
    }

    public void StopSFX(string sfxTitle)
    {
        if (sfxAudioSources.ContainsKey(sfxTitle))
        {
            AudioSource sfxSource = sfxAudioSources[sfxTitle];
            sfxSource.Stop();
        }
        else
        {
            Debug.LogError("Invalid SFX title: " + sfxTitle);
        }
    }

    public void StopAllBGM()
    {
        foreach (var bgmSource in bgmAudioSources.Values)
        {
            bgmSource.Stop();
        }
    }

    public void ChangeVolumeAllBGM(float Power)
    {
        foreach (var bgmSource in bgmAudioSources.Values)
        {
            bgmSource.volume = Power;
        }
    }

    public void StopAllSFX()
    {
        foreach (var sfxSource in sfxAudioSources.Values)
        {
            sfxSource.Stop();
        }
    }

    public void StopAllAudio()
    {
        StopAllBGM();
        StopAllSFX();
    }

    public void PlayTapSFX()
    {
        PlaySFX("ButtonSFX"); 
    }

    public void PlayShutter()
    {
        PlaySFX("CameraShutterSFX"); 
    }
}