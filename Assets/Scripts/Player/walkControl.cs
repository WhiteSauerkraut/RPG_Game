using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkControl : MonoBehaviour
{
    CharacterController player;
    Animator animator;
    Vector3 moveDirection;

    public float walkSpeed = 3;
    public float runSpeed = 5;
    public float backSpeed = -2;
    public float gravity = 9.8f;

    PlayerAttribute playerAttribute;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        animator = this.transform.GetComponentInChildren<Animator>();
        playerAttribute = this.GetComponent<PlayerAttribute>();
    }

    // Update is called once per frame
    void Update()
    {
        //nomal 状态下可以控制
        if (playerAttribute.state == PlayerState.nomal)
        {
            //在空中的时候不能控制
            if (player.isGrounded)
            {
                //WASD控制
                if (Input.GetKey(KeyCode.W))
                {
                    Quaternion q = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
                    this.transform.rotation = q;
                    moveDirection = new Vector3(0.0f, 0.0f, 1);
                    moveDirection = transform.TransformDirection(moveDirection);

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        moveDirection = moveDirection * runSpeed;
                        animator.SetFloat("speed", 5);
                    }
                    else
                    {
                        moveDirection = moveDirection * walkSpeed;
                        animator.SetFloat("speed", 3);
                    }


                }
                else if (Input.GetKey(KeyCode.S))
                {
                    Quaternion q = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
                    this.transform.rotation = q;
                    moveDirection = new Vector3(0.0f, 0.0f, 1);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection = moveDirection * backSpeed;
                    animator.SetFloat("speed", -2);
                }
                else if (Input.GetKey(KeyCode.A))
                {

                    Quaternion q = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y - 90, 0);
                    this.transform.rotation = q;
                    moveDirection = new Vector3(0.0f, 0.0f, 1);
                    moveDirection = transform.TransformDirection(moveDirection);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        moveDirection = moveDirection * runSpeed;
                        animator.SetFloat("speed", 5);
                    }
                    else
                    {
                        moveDirection = moveDirection * walkSpeed;
                        animator.SetFloat("speed", 3);
                    }
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    Quaternion q = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y + 90, 0);
                    this.transform.rotation = q;
                    moveDirection = new Vector3(0.0f, 0.0f, 1);
                    moveDirection = transform.TransformDirection(moveDirection);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        moveDirection = moveDirection * runSpeed;
                        animator.SetFloat("speed", 5);
                    }
                    else
                    {
                        moveDirection = moveDirection * walkSpeed;
                        animator.SetFloat("speed", 3);
                    }
                }
                else
                {
                    moveDirection = Vector3.zero;
                    animator.SetFloat("speed", 0);
                }

            }
            // Apply gravity
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

            // Move the controller
            player.Move(moveDirection * Time.deltaTime);
        }
    }
}
