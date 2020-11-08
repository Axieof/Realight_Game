using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 CameraPos;

    private void Start()
    {
        // Sets camera positions
        CameraPos = player.position;
        transform.position = CameraPos;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            // Scroll Wheel goes up
            //transform.position = player.position;
            CameraPos = player.position;
            Debug.Log("Mouse Up");

        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            // Scroll Wheel goes down
            Vector3 offset = new Vector3(0, 1, -5);
            //transform.position = player.position + offset;
            CameraPos = player.position + offset;
            Debug.Log("Mouse Down");
        }
    }
}
