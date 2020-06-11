using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public int nextLevel;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        DontDestroyOnLoad(GameObject.Find("PlayerHealth"));
        SceneManager.LoadScene(nextLevel);
    }
}
