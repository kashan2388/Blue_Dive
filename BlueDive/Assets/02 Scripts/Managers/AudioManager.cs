using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable 
public class AudioManager : MonoBehaviour
{

    public AudioSource _bgmSource;

    public AudioClip _titleMusic;
    public AudioClip _fadeOut;


    public static AudioManager Instance { get; protected set; }

    protected void Awake()
    {
        if((Object) AudioManager.Instance != (Object) null)
        {
            Object.Destroy((Object)this.gameObject);
        }
        else
        {
            AudioManager.Instance = this;
          
        }
        
    }
}
