using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SettingMenuControllers : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
