using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthersVolumeManager : MonoBehaviour
{
    public static OthersVolumeManager Instance;

    [SerializeField]
    private AudioSource _clipSource;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }



    public void ChangeMusicVolume(float value)
    {
        _clipSource.volume = value;
    }
}