using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //Coin counter
    public int coinsCount;

    //PLayer Health
    public int healthPoints;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (input.getkeydown(keycode.w) || input.getkeydown(keycode.uparrow))
        //{
        //    anim.enabled = true;
        //    anim.settrigger("backwardanimation");
        //}

        //if (input.getkeydown(keycode.s) || input.getkeydown(keycode.downarrow))
        //{
        //    anim.enabled = true;
        //    anim.settrigger("forwardanimation");
        //}

        //if (input.getkeydown(keycode.a) || input.getkeydown(keycode.leftarrow))
        //{
        //    anim.enabled = true;
        //    anim.settrigger("leftanimation");
        //}

        //if (input.getkeydown(keycode.d) || input.getkeydown(keycode.rightarrow))
        //{
        //    anim.enabled = true;
        //    anim.settrigger("rightanimation");
        //}

        //if (input.getkeyup(keycode.w) || input.getkeyup(keycode.uparrow) || input.getkeyup(keycode.s) || input.getkeyup(keycode.downarrow) || input.getkeyup(keycode.s) || input.getkeyup(keycode.downarrow) || input.getkeyup(keycode.a) || input.getkeyup(keycode.leftarrow) || input.getkeyup(keycode.d) || input.getkeyup(keycode.rightarrow))
        //{
        //    anim.enabled = false;
        //}
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            coinsCount++;
        }
        if (collision.gameObject.CompareTag("Buffs"))
        {
            Transform col = collision.transform;
            col.transform.position = new Vector2(999, 999);
        }
    }
}
