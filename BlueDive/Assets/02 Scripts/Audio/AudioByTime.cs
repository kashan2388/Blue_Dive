using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioByTime : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private void Update()
    {
        if ((Object)this.m_AudioSource == (Object)null)
            this.m_AudioSource = this.GetComponent<AudioSource>();
        if ((double)Time.timeScale <= 0.1)
            this.m_AudioSource.Stop();
        else
            this.m_AudioSource.Play();
    }
}
