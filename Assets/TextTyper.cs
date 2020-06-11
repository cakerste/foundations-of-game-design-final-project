 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 using UnityEngine.SceneManagement;
 
 public class TextTyper : MonoBehaviour {
 
     public float letterPause = 0.2f;

     private bool ended = false;
 
     string message;
     TextMesh textComp;
 
     // Use this for initialization
     void Start () {
         textComp = GetComponent<TextMesh>();
         message = textComp.text;
         textComp.text = "";
         StartCoroutine(TypeText ());
     }
 
     IEnumerator TypeText () {
         foreach (char letter in message.ToCharArray()) {
             textComp.text += letter;
             yield return new WaitForSeconds (letterPause);
         }
         
         yield return new WaitForSeconds(2.0f);
         message = "Use the arrow keys to move,\nUse 1, 2, and 3 to choose an attack\n\n[Press Space to continue]";
         textComp.text = "";
         
         foreach (char letter in message.ToCharArray()) {
             textComp.text += letter;
             yield return new WaitForSeconds (letterPause);
         }

         ended = true;
     }

     void Update()
     {
         if (ended) {
             if (Input.GetKeyDown(KeyCode.Space)) {
                 SceneManager.LoadScene(1);
             }
         }
     }
 }