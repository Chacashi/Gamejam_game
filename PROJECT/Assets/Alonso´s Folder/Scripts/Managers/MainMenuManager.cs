using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private VolumeData volumeData;

    [SerializeField] private Slider Master;
    [SerializeField] private Slider Music;
    [SerializeField] private Slider SFX;

    void FixedUpdate()
    {
        volumeData.SetProcessedValues(Master, Music, SFX);
    }
}