using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "VolumeData", menuName = "ScriptableObjects/VolumeData", order = 1)]
public class VolumeData : ScriptableObject
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetProcessedValues(Slider master, Slider music, Slider sfx)
    {
        audioMixer.SetFloat("_Master", Mathf.Log10(master.value) * 20f);
        audioMixer.SetFloat("_Music", Mathf.Log10(music.value) * 20f);
        audioMixer.SetFloat("_SFX", Mathf.Log10(sfx.value) * 20f);
    }
}