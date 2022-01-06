using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance;

    [SerializeField] AudioClip menuClickClip;

    [SerializeField]
    private AudioSource _effectsSource;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }



    public void PlaySound(AudioClip sound)
    {
        _effectsSource.PlayOneShot(sound);
    }


    public void MenuClick()
    {
        _effectsSource.PlayOneShot(menuClickClip);
    }



    public void ChangeEffectsVolume(float value)
    {
        _effectsSource.volume = value;
    }
}