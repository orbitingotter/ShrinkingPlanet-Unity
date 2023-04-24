using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    [Range(0.0f, 1.0f)]
    public float volume;
    [Range(0.1f, 3.0f)]
    public float pitch;
    public bool loop;
    public AudioMixerGroup mixer;

}
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // singleton
    public static AudioManager instance;
    private float themeStartDelay = 20.0f;
    private float themeDelay = 6 * 50.0f;


    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixer;
        }

        StartCoroutine(PlayTheme());
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + " not found");
            return;
        }
        s.source.Play();
    }

    IEnumerator PlayTheme()
    {
        yield return new WaitForSeconds(themeStartDelay);
        themeStartDelay = themeDelay;
        Play("Theme");
        StartCoroutine(PlayTheme());
    }
}
