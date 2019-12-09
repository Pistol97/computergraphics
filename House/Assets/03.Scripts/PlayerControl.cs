using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    
    public float moveSpeed = 12f;
    private float gravity = -9.81f;

    [SerializeField] private AudioClip[] footsteps;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource sigh;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isChanged = false;
    void Start()
    {
        footstep = GetComponent<AudioSource>();
        footstep.clip = footsteps[0];
        footstep.Play();
    }

    void Update()
    {
        if (RedBook.StartHorror == true && isChanged == false )
        {
            moveSpeed = 1.5f;
            footstep.clip = footsteps[1];
            footstep.Play();
            sigh.Play();
            isChanged = true;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //땅에 닿았을 경우
        if (isGrounded && velocity.y < 0)
            //강제로 중력속도 2로 고정
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //이동속도 좌표
        Vector3 move = (transform.right * x) + (transform.forward * z);

        //이동 속도
        controller.Move(move * moveSpeed * Time.deltaTime);

        //중력 가속도
        velocity.y += gravity * Time.deltaTime;

        //중력 중력속도 설정
        controller.Move(velocity * Time.deltaTime);

        if (move.x != 0 || move.y != 0)
        {
            footstep.mute = false;
        }
        else if (move.x == 0 && move.y == 0)
        {
            footstep.mute = true;
        }
    }
}
