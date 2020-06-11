using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    public bool isAttacking;

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    private GameObject enemy;

    private EnemyScript e;
    
    public int health;

    public bool isDefending;

    public string attackDesc;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
        enemy = GameObject.Find("Enemy");
        e = enemy.GetComponent<EnemyScript>();
        isDefending = false;
        health = GameObject.Find("PlayerHealth").GetComponent<Health>().health;
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = (int)(Input.GetAxisRaw ("Horizontal"));

        //Store the current vertical input in the float moveVertical.
        float moveVertical = (int)(Input.GetAxisRaw ("Vertical"));

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        if (!isAttacking) {
        	//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
                rb2d.AddForce(movement * speed);
        }
    }

    public void updateHealth(int h)
    {
        if (isDefending) {
            h /= 2;
        }
        health += h;
    }

    public void allOutAttack()
    {
        int strength = Random.Range(5, 21);
        attackDesc = " did an all out attack";
        if (strength <= 10) {
            strength = 0;
            attackDesc += ",\nbut missed!";
        }
        e.updateHealth(-strength);
    }

    public void basicAttack()
    {
        attackDesc = " did a basic attack";
        e.updateHealth(-10);
    }

    public void defend()
    {
        attackDesc = " defended";
        isDefending = true;   
    }
}
