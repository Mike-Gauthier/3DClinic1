using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAnimScript : MonoBehaviour
{
    private Animator anim;
    private bool isRunning = true;
    private bool isJumping = false;
    private bool isSliding = false;
    private bool isShiftingR = false;
    private bool isShiftingL = false;
    private bool isDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //&& !isJumping)
        {
            anim.SetBool("isJumping", true);
            isJumping = true;
        }
        else if (isJumping)
        {
            anim.SetBool("isJumping", false);
            isJumping = false;
        }


        if (Input.GetKeyDown(KeyCode.S)) //&& !isJumping)
        {
            anim.SetBool("isSliding", true);
            isSliding = true;
        }
        else if (isSliding)
        {
            anim.SetBool("isSliding", false);
            isSliding = false;
        }

        if (Input.GetKeyDown(KeyCode.D)) //&& !isJumping)
        {
            anim.SetBool("isShiftingR", true);
            isShiftingR = true;
        }
        else if (isShiftingR)
        {
            anim.SetBool("isShiftingR", false);
            isShiftingR = false;
        }

        if (Input.GetKeyDown(KeyCode.A)) //&& !isJumping)
        {
            anim.SetBool("isShiftingL", true);
            isShiftingL = true;
        }
        else if (isShiftingL)
        {
            anim.SetBool("isShiftingL", false);
            isShiftingL = false;
        }


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            anim.SetBool("isDead", true);

        }
    }

}


