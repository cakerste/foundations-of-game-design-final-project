using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    public int missWeight;
    public int damageWeight;
    public string name, attackDesc;
    private GameObject player;
    private PlayerController p;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        p = player.GetComponent<PlayerController>();
    }

    public void updateHealth(int h)
    {
        if (p.isDefending) {
            h *= 2;
            p.isDefending = false;
        }        
        this.health += h;
    }

    public void basicAttack()
    {
        attackDesc = " did a basic attack";
        p.updateHealth(-damageWeight);
    }
    
    public void allOutAttack()
    {
        attackDesc = " did an all out attack";
        int strength = Random.Range(0, 2 * damageWeight + 1);
        if (strength <= missWeight) {
            attackDesc += ",\nbut missed!";
            strength = 0;
        }
        p.updateHealth(-strength);
    }
}
