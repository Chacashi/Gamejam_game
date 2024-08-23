using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private PlayerLustLevel Player;
    [SerializeField] private Volume Volume;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void OnEnable()
    {
        Player.EnemyIsComing += reachVignette;
    }
    private void OnDisable()
    {
        Player.EnemyIsComing -= reachVignette;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void reachVignette()
    {
        StartCoroutine(ReachVignetteValue());
    }
    public IEnumerator ReachVignetteValue()
    {
        while (true)
        {
            Volume.profile.TryGet(out Vignette vignette);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.65f, 5 * Time.deltaTime);
            yield return null;
        }
    }
}