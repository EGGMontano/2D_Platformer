using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public Animator anim;
    public PlayerMovement player;
    public int trapDamage;
    public bool isPlayerOnTop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOnTop = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsActive", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTop = false;
            anim.SetBool("IsActive", false);
        }
    }

    public void PlayerDamage()
    {

        player.healthPoints -= trapDamage;
    }
}
