using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;

    /*
    [SerializeField] private GameObject firstPersonCamera = null;
    bool firstPerson = true;
    bool thirdPerson = false;
    GameObject player;
    Vector3 offset = new Vector3(0, -5f, -5f);
    AudioListener firstPersonAudio;
    AudioListener thirdPersonAudio;
    */

    private void Start()
    {
        var player = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        /*
        firstPersonCamera.SetActive(false);
        playerCamera.enabled = true;

        firstPersonAudio = firstPersonCamera.GetComponent<AudioListener>();
        thirdPersonAudio = playerCamera.GetComponent<AudioListener>();

        firstPersonAudio.enabled = false;
        */
    }

    /*
    public void Update()
    {
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
            firstPersonCamera.SetActive(true);
            playerCamera.enabled = false;
            firstPersonAudio.enabled = true;
            thirdPersonAudio.enabled = false;
        }
        else if (thirdPerson)
        {
            firstPersonCamera.SetActive(false);
            playerCamera.enabled = true;
            playerCamera.Follow = player.transform;
            playerCamera.LookAt = player.transform;
            firstPersonAudio.enabled = false;
            thirdPersonAudio.enabled = true;
        }
        
    }
    */

    
}