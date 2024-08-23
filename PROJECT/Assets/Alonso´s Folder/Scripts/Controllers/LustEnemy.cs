using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LustEnemy : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private float MovementSpeed;
    [SerializeField] private Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = (Target.position - transform.position).normalized * MovementSpeed;
    }
}