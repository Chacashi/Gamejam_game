using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLustLevel : MonoBehaviour
{
    private bool IsBeingAttacked;
    private RaycastHit hit;
    [SerializeField] private float RayLenght;
    [SerializeField] private LayerMask layerMask;

    public event Action EnemyIsComing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (!IsBeingAttacked)
        {
            if (Physics.Raycast(transform.position, Vector3.back, out hit, RayLenght, layerMask))
            {
                Debug.DrawRay(transform.position, Vector3.back * hit.distance, Color.yellow);

                StartCoroutine(ResetState(5f));
                EnemyIsComing?.Invoke();
            }
            else
            {
                Debug.DrawRay(transform.position, Vector3.back * RayLenght, Color.white);
            }
        }
    }
    public IEnumerator ResetState(float time)
    {
        IsBeingAttacked = true;
        yield return new WaitForSeconds(time);
        IsBeingAttacked = false;
        EnemyIsComing?.Invoke();
    }
}