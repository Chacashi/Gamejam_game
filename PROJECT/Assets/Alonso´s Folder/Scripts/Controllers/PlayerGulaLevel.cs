using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGulaLevel : MonoBehaviour
{
    int R = 8;
    int A = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Item")
        {
            A++;
            if(A == R)
            {
                GetComponent<SphereCollider>().enabled = false;
                StartCoroutine(Teleport());
            }
        }
    }
    public IEnumerator Teleport()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Avarice");
    }
}
