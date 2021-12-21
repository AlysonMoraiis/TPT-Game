using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickSoundCaller : MonoBehaviour
{
    [SerializeField]
    private AudioClip menuClick;

    void Start()
    {
        SoundManager.Instance.PlaySound(menuClick);
    }

    void Update()
    {

    }
}