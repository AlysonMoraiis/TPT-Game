using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField]
    private AudioSource _musicSource;
    

    private void Awake()
    {
        ChangeMusicVolume(0.5f);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void ChangeMusicVolume(float value)
    {
        _musicSource.volume = value;
    }
}