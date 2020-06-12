using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume_Script : MonoBehaviour
{
    public AudioSource _audio;
    private float _vol = 1f;
    public List<AudioClip> _audioClip;


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }


    // Update volume based on slider
    private void Update()
    {
        _audio.volume = _vol;
    }


    // Get slider percentage
    public void SetVolume(float volume)
    {
        _vol = volume;
    }
}
