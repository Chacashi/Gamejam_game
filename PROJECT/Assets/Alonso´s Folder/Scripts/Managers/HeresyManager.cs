using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeresyManager : MonoBehaviour
{
    [SerializeField] Light _light;

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            StartCoroutine(Twinkle());
        }
    }
    public IEnumerator Twinkle()
    {
        while (true)
        {
            _light.intensity = 0;
            yield return new WaitForSeconds(0.25f);
            _light.intensity = 1;
            yield return new WaitForSeconds(0.25f);
            _light.intensity = 0;
            yield return new WaitForSeconds(0.25f);
            _light.intensity = 1;
            int rnd = Random.Range(0, 2);
            if(rnd == 1)
            {
                yield return new WaitForSeconds(2f);
            }
        }
    }
}
