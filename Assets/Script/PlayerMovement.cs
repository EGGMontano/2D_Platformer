using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Speed (How fast the player will navigate the game)
    public float moveSpeed;

    //RigidBody (handles physics, makes player move)
    public Rigidbody2D rigidBody;

    //Dictates where the player is moving
    private Vector2 movementInput;

    //Access our Animator to play animations
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("BackwardAnimation");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetTrigger("BackwardsIdle");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("ForwardAnimation");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetTrigger("ForwardIdle");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("LeftAnimation");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetTrigger("LeftIdle");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("RightAnimation");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetTrigger("RightIdle");
        }
    }
    // For physics calculations
    private void FixedUpdate()
    {
        //makes our player move
        rigidBody.velocity = movementInput * moveSpeed;
    }
    //
    private void LateUpdate()
    {

    }


    //To get Input System Clicks
    private void OnMove(InputValue inputValue)
    {
        //WASD = to Vector 2 values
        movementInput = inputValue.Get<Vector2>();
    }
}
