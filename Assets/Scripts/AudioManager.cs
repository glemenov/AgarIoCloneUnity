using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        // Send a reference to gamemanager
        GameHandler.GH.audioMan = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = GameHandler.GH.overall_volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string _name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == _name); // => [Where]
        s.source.Play();
    }

    public void Stop(string _name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == _name); // => [Where]
        s.loop = false;
        s.source.Stop();
    }

    public void ChangeVolume(string _name, float _volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == _name);
        s.source.volume = _volume;
    }

    //StopALL
}