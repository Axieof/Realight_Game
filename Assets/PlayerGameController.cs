using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook playerCamera = null;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera.Follow = this.transform;
        playerCamera.LookAt = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
