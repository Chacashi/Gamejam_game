using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersController : MonoBehaviour
{
    [SerializeField] GameObject[] Spawners;
    [SerializeField] 
    public IEnumerator Spawn()
    {
        while (true)
        {
            int A = Random.Range(0, Spawners.Length);
            
        }
    }
}
