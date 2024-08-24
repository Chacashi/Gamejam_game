using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GulaItemEffect : MonoBehaviour
{
    [SerializeField] Transform target;
    void FixedUpdate()
    {
        transform.LookAt(target);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            RiseScale(other.transform);
            Destroy(gameObject);
        }
    }
    
    public void RiseScale(Transform transform)
    {
        transform.localScale = transform.localScale * 1.125f;
    }
}