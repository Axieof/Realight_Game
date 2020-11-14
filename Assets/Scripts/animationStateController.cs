using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isSeatedHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isSeatedHash = Animator.StringToHash("IsSeated");
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
    }
}
