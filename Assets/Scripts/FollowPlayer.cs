﻿using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 CameraPos;
    public Vector3 offset;
    public GameObject firstPersonCam;
    public GameObject thirdPersonCam;

    private void Start()
    {
        // Sets camera positions
        //CameraPos = player.position;
        offset = new Vector3(0, 1, -5);
        transform.position = player.position;

        firstPersonCam.SetActive(true);
        thirdPersonCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        firstPersonCam.transform.position = player.position;
        thirdPersonCam.transform.position = player.position + offset;

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            // Scroll Wheel goes up
            //transform.position = player.position;
            //CameraPos = player.position;
            firstPersonCam.SetActive(true);
            thirdPersonCam.SetActive(false);
            Debug.Log("Mouse Up");

        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            // Scroll Wheel goes down
            //transform.position = player.position + offset;
            //CameraPos = player.position + offset;
            firstPersonCam.SetActive(false);
            thirdPersonCam.SetActive(true);
            Debug.Log("Mouse Down");
        }
    }
}
