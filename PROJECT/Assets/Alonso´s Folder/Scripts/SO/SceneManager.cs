using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneManager", menuName = "ScriptableObjects/SceneManager", order = 3)]
public class SceneManager1 : ScriptableObject
{
    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
