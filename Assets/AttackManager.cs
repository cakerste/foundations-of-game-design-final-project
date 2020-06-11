using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackManager : MonoBehaviour
{
    private GameObject playerHealthText, enemyHealthText, attackOp, attackText;
    private GameObject player, enemy;
    private TextMesh playerHealth, enemyHealth, attackOptions, attack;
    private PlayerController p;
    private EnemyScript e;
    private bool isPlayersTurn, hasAttacked;
    public string attackDesc;

    void Awake()
    {
        DontDestroyOnLoad(GameObject.Find("PlayerHealth"));
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        p = player.GetComponent<PlayerController>(); 
        e = enemy.GetComponent<EnemyScript>();

        playerHealthText = GameObject.Find("PlayerHealthText");
        playerHealth = playerHealthText.GetComponent<TextMesh>();
        
        enemyHealthText = GameObject.Find("EnemyHealthText");
        enemyHealth = enemyHealthText.GetComponent<TextMesh>();

        attackOp = GameObject.Find("AttackOptions");
        attackOptions = attackOp.GetComponent<TextMesh>();

        attackText = GameObject.Find("AttackText");
        attack = attackText.GetComponent<TextMesh>();
        
        updateText();
        isPlayersTurn = true;
        hasAttacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (p.health > 0) {
            if (isPlayersTurn) {
                if (Input.GetKeyDown(KeyCode.Alpha1)) {
                    p.basicAttack();
                    endTurn();
                } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                    p.allOutAttack();
                    endTurn();
                } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                    p.defend();
                    endTurn();  
                }
            } else {
                int attack = Random.Range(1, 6);
                if (attack == 1 || attack == 2) {
                    e.basicAttack();
                    endTurn();
                } else if (attack == 3 || attack == 4) {
                    e.allOutAttack();
                    endTurn();
                }
            }
        }
        if (hasAttacked && p.health > 0) {
            attackDesc = "You" + p.attackDesc + "\n" + e.name + e.attackDesc;
        }
        updateText();
        if (e.health <= 0) {
	    p.isAttacking = false;
            Destroy(enemy);
            enemyHealth.text = "";
            attackOptions.text = "";
            GameObject.Find("PlayerHealth").GetComponent<Health>().health = p.health;
        }
        GameObject.Find("PlayerHealth").GetComponent<Health>().health = p.health;
        if (p.health <= 0) {
            attackDesc = "You died!\nPress R to restart";
            if (Input.GetKeyDown(KeyCode.R)) {
                p.health = 100;
                GameObject.Find("PlayerHealth").GetComponent<Health>().health = p.health;
                SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
            }
        }
    }

    void updateText()
    {
        playerHealth.text = "Player Health: " + p.health;
        enemyHealth.text = "Enemy Health: " + e.health;
        attack.text = attackDesc; 
    }
    
    void endTurn()
    {
        hasAttacked = true;
        isPlayersTurn = !isPlayersTurn;
    }
}
