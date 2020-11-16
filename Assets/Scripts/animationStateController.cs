using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isSeatedHash;
    int walkingLeftHash;
    int walkingRightHash;

    bool allowInput = true;

    // Start is called before the first frame update
    void Start()
    {
        //retrieve boolean conditions from animation controller
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isSeatedHash = Animator.StringToHash("IsSeated");
        walkingLeftHash = Animator.StringToHash("walkingLeft");
        walkingRightHash = Animator.StringToHash("walkingRight");
    }

    // Update is called once per frame
    void Update()
    {
        //Code for forward movement
        bool isWalking = animator.GetBool(isWalkingHash);

        bool forwardMove = Input.GetKey("w");
        if (!isWalking && forwardMove)
        {
            //Set IsWalking Parameter in animator to true so movement begins
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardMove)
        {
            //Set IsWalking Parameter in animator to false so movement stops
            animator.SetBool(isWalkingHash, false);
        }

        //Code for left strafe
        bool walkingLeft = animator.GetBool(walkingLeftHash);

        bool leftMove = Input.GetKey("a");
        if (!walkingLeft && leftMove)
        {
            //Set IsWalking Parameter in animator to true so movement begins
            animator.SetBool(walkingLeftHash, true);
        }
        if (walkingLeft && !leftMove)
        {
            //Set IsWalking Parameter in animator to false so movement stops
            animator.SetBool(walkingLeftHash, false);
        }

        //Code for left strafe
        bool walkingRight = animator.GetBool(walkingRightHash);

        bool rightMove = Input.GetKey("d");
        if (!walkingRight && rightMove)
        {
            //Set IsWalking Parameter in animator to true so movement begins
            animator.SetBool(walkingRightHash, true);
        }
        if (walkingRight && !rightMove)
        {
            //Set IsWalking Parameter in animator to false so movement stops
            animator.SetBool(walkingRightHash, false);
        }

        //Code for sitting down
        bool isSeated = animator.GetBool(isSeatedHash);

        bool sit = Input.GetKeyDown("c");
        if (!isSeated && sit)
        {
            //Set IsSeated parameter in animator to true so model sits
            animator.SetBool(isSeatedHash, true);
        }
        
        //Code for standing up
        if (isSeated && sit)
        {
            //Set IsWalking Parameter in animator to false so model stands
            animator.SetBool(isSeatedHash, false);
        }

        //Code for jumping
        bool jump = Input.GetButtonDown("Jump");
        if (jump && allowInput)
        {
            animator.SetTrigger("isJumping");
        }
    }

    public void disableInput()
    {
        allowInput = false;
    }

    public void enableInput()
    {
        allowInput = true;
    }
}
