using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LimboManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(hammerhit());
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator hammerhit()
    {
        yield return new WaitForSeconds(3);
        audioSource.Play();
        yield return new WaitForSeconds(2);
        audioSource.Play();
        yield return new WaitForSeconds(1);
        rigidBody.useGravity = true;
    }
}
