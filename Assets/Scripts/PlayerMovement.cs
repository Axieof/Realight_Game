using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    [SerializeField] private float movementSpeed = 12f;

    public CharacterController controller;
    public Vector3 offset;
    public Transform player;
    public GameObject FirstPersonCamera;
    public GameObject ThirdPersonCamera;
    public GameObject CinemachineCam;
    private Transform mainCameraTransform = null;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    //public Transform groundCheck;
    public Transform cinemachineCam;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 0.5f;

    Vector3 velocity;
    bool isGrounded;
    Animator playeranimator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCameraTransform = Camera.main.transform;
        // Sets camera positions
        //CameraPos = player.position;
        offset = new Vector3(0, 1, -5);
        transform.position = player.position;

        FirstPersonCamera.SetActive(true);
        ThirdPersonCamera.SetActive(false);
        CinemachineCam.SetActive(false);

        cinemachineCam = CinemachineCam.transform;

        playeranimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            isGrounded = true;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -20f;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                //playeranimator.SetTrigger("isJumping");
                Invoke("JumpAction", 0.359f);
                //Vector3 jumpHeight = new Vector3(0f, 3f, 0f);
                //controller.Move(jumpHeight);
                //controller.transform.up * 3f * Time.deltaTime;
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (FirstPersonCamera.activeSelf)
            {
                FirstPerson();
            }
            else if (CinemachineCam.activeSelf)
            {
                ThirdPerson();
            }
        }
    }

    void FirstPerson()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

    }

    void ThirdPerson()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cinemachineCam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    public void JumpAction()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
    }
}


