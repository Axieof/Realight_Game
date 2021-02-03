using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook playerCamera = null;
    /*
    [SerializeField] private Camera firstPersonCamera = null;
    [SerializeField] private GameObject mainCamera = null;
    bool firstPerson = true;
    bool thirdPerson = false;
    GameObject player;
    Vector3 offset = new Vector3(0, -5f, -5f);
    AudioListener firstPersonAudio;
    AudioListener thirdPersonAudio;
    */

    // Start is called before the first frame update
    void Start()
    {
        
        playerCamera.Follow = this.transform;
        playerCamera.LookAt = this.transform;
        /*
        firstPersonCamera.enabled = false;
        playerCamera.enabled = true;

        firstPersonAudio = firstPersonCamera.GetComponent<AudioListener>();
        thirdPersonAudio = mainCamera.GetComponent<AudioListener>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            //Scroll Wheel Goes Up
            thirdPerson = true;
            firstPerson = false;
            Debug.Log("Scroll Wheel Down");
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            //Scroll Wheel Goes Down
            thirdPerson = false;
            firstPerson = true;
            Debug.Log("Scroll Wheel Up");
        }

        if (firstPerson)
        {
            firstPersonCamera.enabled = true;
            playerCamera.enabled = false;
            firstPersonAudio.enabled = true;
            thirdPersonAudio.enabled = false;
        }
        else if (thirdPerson)
        {
            firstPersonCamera.enabled = false;
            playerCamera.enabled = true;
            playerCamera.Follow = this.transform;
            playerCamera.LookAt = this.transform;
            firstPersonAudio.enabled = false;
            thirdPersonAudio.enabled = true;
        }
        */
    }
}
