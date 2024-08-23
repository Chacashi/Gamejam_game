using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerLustLevel : MonoBehaviour
{
    [SerializeField] private UIData UIData;

    [SerializeField] private bool IsBeingAttacked;
    private RaycastHit hit;
    [SerializeField] private float RayLenght;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject button;

    [SerializeField] private Slider Danger;
    private float danger;

    public event Action EnemyIsComing;
    void Start()
    {
        danger = Danger.maxValue / 7f;
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
                UIData.OpenPanel(button);
            }
            else
            {
                Debug.DrawRay(transform.position, Vector3.back * RayLenght, Color.white);
                IsBeingAttacked = false;
            }
        }

        if (IsBeingAttacked)
        {
            UIData.OpenPanel(Danger.gameObject);
            Danger.value = Mathf.Lerp(Danger.value, 0f, 0.5f * Time.deltaTime);
            if (Danger.value > 0.75f)
            {
                UIData.ClosePanel(button.gameObject);
                IsBeingAttacked = false;
            }
        }
    }
    public IEnumerator ResetState(float time)
    {
        IsBeingAttacked = true;
        yield return new WaitForSeconds(time);
        EnemyIsComing?.Invoke();
    }
    public void AddToSlider()
    {
        Danger.value = Danger.value + danger;
        if(Danger.value + danger >= 0.75f)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            rb.AddForce(Vector3.forward * 50f, ForceMode.Impulse);
            Danger.value = 0;
        }
    }
}