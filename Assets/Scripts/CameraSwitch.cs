using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject firstPerson;
    public GameObject thirdPerson;

    AudioListener firstPersonAudio;
    AudioListener thirdPersonAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonAudio = firstPerson.GetComponent<AudioListener>();
        thirdPersonAudio = thirdPerson.GetComponent<AudioListener>();

        // Set Camera Position
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));

    }

    // Update is called once per frame
    void Update()
    {
        switchCamera();
    }

    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    public void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Scroll Wheel goes down
            cameraChangeCounter();
        }
        
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
            firstPerson.SetActive(true);
            firstPersonAudio.enabled = true;

            thirdPersonAudio.enabled = false;
            thirdPerson.SetActive(false);
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            thirdPerson.SetActive(true);
            thirdPersonAudio.enabled = true;

            firstPersonAudio.enabled = false;
            firstPerson.SetActive(false);
        }

    }
}
