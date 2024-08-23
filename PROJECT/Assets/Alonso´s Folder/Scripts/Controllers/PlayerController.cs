using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;

    private Vector3 MovementDirection;

    [SerializeField] private float MovementSpeed;
    [SerializeField] private float MovementMultiplier;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject MovementRef;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        //MOVEMENT REF
        MovementRef.transform.position = _camera.transform.position;
        MovementRef.transform.rotation = new Quaternion(0f, _camera.transform.rotation.y, 0f, _camera.transform.rotation.w);
        
        //MOVEMENT
        rigidBody.velocity = new Vector3(MovementRef.transform.TransformDirection(MovementDirection).x * MovementSpeed, rigidBody.velocity.y, MovementRef.transform.TransformDirection(MovementDirection).z * MovementSpeed);

        //ROTATION
        transform.rotation = MovementRef.transform.rotation;
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementDirection = context.ReadValue<Vector3>();
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MovementSpeed = MovementSpeed * MovementMultiplier;
        }
        else if (context.canceled)
        {
            MovementSpeed = MovementSpeed / MovementMultiplier;
        }
    }
}