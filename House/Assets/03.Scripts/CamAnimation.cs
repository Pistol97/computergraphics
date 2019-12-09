using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnimation : MonoBehaviour
{
    public CharacterController playerController;
    public Animation anim;
    private bool isMoving;

    private bool left;
    private bool right;

    void Start()
    {
        left = true;
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputX != 0 || inputY != 0)
            isMoving = true;
        else if (inputX == 0 && inputY == 0)
            isMoving = false;

        CameraAnimations();
    }

    void CameraAnimations()
    {
        if(playerController.isGrounded == true)
        {
            if(isMoving == true)
            {
                if(left == true)
                {
                    if(!anim.isPlaying)
                    {
                        anim.Play("walkLeft");
                        left = false;
                        right = true;
                    }
                    if (right == true)
                    {
                        if (!anim.isPlaying)
                        {
                            anim.Play("walkRight");
                            right = false;
                            left = true;                        }
                    }
                }
            }
        }
    }
}
