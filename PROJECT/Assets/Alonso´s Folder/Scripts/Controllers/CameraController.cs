using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerLustLevel Player;

    [SerializeField] private CinemachineVirtualCamera ExtraTarget;
    [SerializeField] private CinemachineVirtualCamera PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        try
        {
            Player.EnemyIsComing += SwitchCamera;
        }
        catch
        {

        }
    }
    private void OnDisable()
    {
        try
        {
            Player.EnemyIsComing -= SwitchCamera;

        }
        catch
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwitchCamera()
    {
        int tmp = ExtraTarget.Priority;
        ExtraTarget.Priority = PlayerCamera.Priority;
        PlayerCamera.Priority = tmp;
    }
}