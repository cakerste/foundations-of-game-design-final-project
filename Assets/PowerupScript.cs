using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerupScript : MonoBehaviour
{
    private GameObject player;
    private PlayerController p;
    float originalY;
    public float floatStrength = 1, floatSpeed = 5;
    public int increase;

    void Start()
    {
        player = GameObject.Find("Player");
        p = player.GetComponent<PlayerController>();
        this.originalY = this.transform.position.y;
    }
    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalY + ((float)Math.Sin(Time.time * floatSpeed) * floatStrength), transform.position.z);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        p.updateHealth(increase);
        Destroy(gameObject);
    }
}
