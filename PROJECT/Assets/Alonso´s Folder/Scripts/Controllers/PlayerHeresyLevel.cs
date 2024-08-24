using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerHeresyLevel : MonoBehaviour
{
    [SerializeField] RectTransform go;

    bool badEnding;
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    [SerializeField] CinemachineVirtualCamera _virtualCamera1;

    private void FixedUpdate()
    {
        if (badEnding)
        {
            go.position = Vector3.Lerp(go.position, new Vector3(go.position.x, go.position.y + 60, go.position.z), 0.5f * Time.deltaTime);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Elevator")
        {
            StartCoroutine(ElevatorFall(other));
        }
    }
    public IEnumerator ElevatorFall(Collision Other)
    {
        yield return new WaitForSeconds(3f);
        Rigidbody rb = Other.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        yield return new WaitForSeconds(4f);
        GetComponent<PlayerController>().enabled = false;

        int tmp = _virtualCamera1.Priority;
        _virtualCamera1.Priority = _virtualCamera.Priority;
        _virtualCamera.Priority = _virtualCamera1.Priority;

        badEnding = true;
    }
}