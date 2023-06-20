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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("BackwardAnimation");
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("ForwardAnimation");
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("LeftAnimation");
        }
        
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("RightAnimation");
        }
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.enabled = false;
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
