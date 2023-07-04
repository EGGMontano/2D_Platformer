using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool speed, health;
    public int speedBoost, healthBoost, duration;
    private float baseMovespeed;
    public PlayerMovement Player;

    private void Start()
    {
        baseMovespeed = Player.moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (speed)
        {
            Player.moveSpeed += speedBoost;
            StartCoroutine(BackToBaseSpeed());
        }
        if (health)
        {
            Player.healthPoints += healthBoost;
        }
    }

    IEnumerator BackToBaseSpeed()
    {
        yield return new WaitForSeconds(duration);
        Player.moveSpeed = baseMovespeed;
    }
}