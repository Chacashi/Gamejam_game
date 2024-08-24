using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCinematichManager : MonoBehaviour
{
    [SerializeField] CameraController cameraController;

    private float TargetY;
    private float TruckMultiplier;
    [SerializeField] private GameObject Truck;

    private float PersonTarget;
    [SerializeField] private GameObject Person;
    [SerializeField] private GameObject Person1;

    [SerializeField] GameObject blackScreen;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Crash;
    [SerializeField] AudioClip Brakes;
    [SerializeField] AudioClip HospitalMach;

    [SerializeField] GameObject victim;

    // Start is called before the first frame update
    void Start()
    {
        TargetY = Truck.transform.position.y - 60;
        PersonTarget = Person.transform.position.x - 15;
        StartCoroutine(TimeRecover());
        StartCoroutine(ChangeSprite());
    }

    // Update is called once per frame
    void Update()
    {
        Truck.transform.position = Vector3.Lerp(Truck.transform.position, new Vector3(Truck.transform.position.x, TargetY, Truck.transform.position.z), TruckMultiplier * Time.deltaTime);
        Truck.transform.localScale = Vector3.Slerp(Truck.transform.localScale, Vector3.one * 5, 0.2f * Time.deltaTime);

        Person.transform.position = Vector3.Lerp(Person.transform.position, new Vector3(PersonTarget, Person.transform.position.y, Person.transform.position.z), 0.5f * Time.deltaTime);
    }
    public IEnumerator TimeRecover()
    {
        TruckMultiplier = 0.01f;
        yield return new WaitForSeconds(2);
        TruckMultiplier = 0.1f;
        yield return null;
    }
    public IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(1.7f);
        cameraController.SwitchCamera();
        yield return new WaitForSeconds(1.5f);
        Person.GetComponent<SpriteRenderer>().sprite = Person1.GetComponent<SpriteRenderer>().sprite;
        yield return new WaitForSeconds(0.2f);
        blackScreen.SetActive(true);
        audioSource.clip = Crash;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        audioSource.clip = HospitalMach;
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        victim.SetActive(true);
    }
}