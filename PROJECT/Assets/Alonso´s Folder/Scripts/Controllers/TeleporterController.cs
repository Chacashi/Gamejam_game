using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    [SerializeField] SceneManager1 SceneManager1;
    [SerializeField] private string Scene;
    void OnTriggerEnter(Collider other)
    {
        SceneManager1.GoToScene(Scene);
    }
}