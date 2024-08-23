using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour
{
    bool CanChange;
    [SerializeField] Material M1;
    [SerializeField] Material M2;
    Color TargetColor;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(randomColor());
    }

    // Update is called once per frame
    void Update()
    {
        if (CanChange)
        {
            M1.SetColor("_Color", Color.Lerp(M1.GetColor("_Color"), TargetColor, 2.5f * Time.deltaTime));
        }
    }
    public IEnumerator randomColor()
    {
        while (true)
        {
            CanChange = true;
            yield return new WaitForSeconds(1f);
            CanChange = false;
            yield return new WaitForSeconds(1f);
            TargetColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }
    }
}