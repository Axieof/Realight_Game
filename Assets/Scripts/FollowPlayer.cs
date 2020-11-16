using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 CameraPos;
    public Vector3 offset;
    public Vector3 counter;
    public GameObject firstPersonCam;
    public GameObject thirdPersonCam;
    public GameObject CinemachineCam;

    AudioListener firstPersonAudio;
    AudioListener thirdPersonAudio;

    private void Start()
    {
        // Sets camera positions
        //CameraPos = player.position;
        offset = new Vector3(0, 1, -5);
        transform.position = player.position;
        firstPersonAudio = firstPersonCam.GetComponent<AudioListener>();
        thirdPersonAudio = CinemachineCam.GetComponent<AudioListener>();

        firstPersonCam.SetActive(true);
        firstPersonAudio.enabled = true;

        thirdPersonCam.SetActive(false);
        thirdPersonAudio.enabled = false;

        CinemachineCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        counter = new Vector3(0, 2, 0);
        firstPersonCam.transform.position = player.position + counter;
        thirdPersonCam.transform.position = player.position + offset;

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            // Scroll Wheel goes up
            //transform.position = player.position;
            //CameraPos = player.position;
            firstPersonCam.SetActive(true);
            firstPersonAudio.enabled = true;

            thirdPersonCam.SetActive(false);
            thirdPersonAudio.enabled = false;

            CinemachineCam.SetActive(false);
            Debug.Log("Mouse Up");

        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            // Scroll Wheel goes down
            //transform.position = player.position + offset;
            //CameraPos = player.position + offset;
            firstPersonCam.SetActive(false);
            firstPersonAudio.enabled = false;

            thirdPersonCam.SetActive(true);
            thirdPersonAudio.enabled = true;

            Debug.Log("Cam Turned on");
            CinemachineCam.SetActive(true);
            Debug.Log("Mouse Down");
        }
    }
}
