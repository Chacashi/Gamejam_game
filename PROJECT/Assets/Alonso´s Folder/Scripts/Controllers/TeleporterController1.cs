using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController1 : MonoBehaviour
{
    [SerializeField] Transform Target;
    void OnCollisionEnter(Collision other)
    {
        other.gameObject.transform.position = Target.position;
    }
}
