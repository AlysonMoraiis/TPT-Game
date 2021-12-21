using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;

    void Start()
    {
        SoundManager.Instance.ChangeMusicVolume(musicSlider.value);
        musicSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
    }
}