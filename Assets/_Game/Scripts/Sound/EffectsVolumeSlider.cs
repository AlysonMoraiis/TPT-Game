using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectsVolumeSlider : MonoBehaviour
{
    [SerializeField]
    private Slider effectsSlider;

    void Start()
    {
        EffectsManager.Instance.ChangeEffectsVolume(effectsSlider.value);
        effectsSlider.onValueChanged.AddListener(val => EffectsManager.Instance.ChangeEffectsVolume(val));
    }
}