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
        MusicManager.Instance.ChangeMusicVolume(musicSlider.value);
        musicSlider.onValueChanged.AddListener(val => MusicManager.Instance.ChangeMusicVolume(val));
    }
}