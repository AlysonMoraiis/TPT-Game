using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OthersVolumeSlider : MonoBehaviour
{
    [SerializeField]
    private Slider OthersSlider;

    void Start()
    {
        OthersVolumeManager.Instance.ChangeMusicVolume(OthersSlider.value);
        OthersSlider.onValueChanged.AddListener(val => OthersVolumeManager.Instance.ChangeMusicVolume(val));
    }
}