using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LazinessBoat : MonoBehaviour
{
    private Vector3 MovementDirection;
    Rigidbody rigidBody;
    [SerializeField] Transform MovRef;
    [SerializeField] Camera _camera;

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
        MovRef.transform.rotation = new Quaternion(0,_camera.transform.rotation.y,0,_camera.transform.rotation.w);

        rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, new Vector3((MovRef.transform.TransformDirection(MovementDirection) * 3).x, 0f, (MovRef.transform.TransformDirection(MovementDirection) * 3).z), 3.5f * Time.deltaTime);
        if (MovementDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, MovRef.rotation, 0.5f * Time.deltaTime);
        }
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementDirection = context.ReadValue<Vector3>();
    }
}
