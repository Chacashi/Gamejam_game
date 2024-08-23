using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "UIData", menuName = "ScriptableObjects/UIData", order = 0)]
public class UIData : ScriptableObject
{
    
    public void Play()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ClosePanel(GameObject victim)
    {
        victim.SetActive(false);
    }
    public void OpenPanel(GameObject victim)
    {
        victim.SetActive(true);
    }
}