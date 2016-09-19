using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadArea : MonoBehaviour {

    public Rigidbody2D playerRigi;
    public string AreaToLoad;

    IEnumerator OnTriggerEnter2D(Collider2D other) {

        yield return new WaitForSeconds(0.2f);      // pause before loading

        float fadeTime = GameObject.Find("GameController").GetComponent<fadeScene>().BeginFade(1);  // find fadeScene script in GameController; 1 is in BeginFade(1) cuz 1 is fade out and -1 is fade in
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerController>().canMove = false;
            playerRigi = other.gameObject.GetComponent<Rigidbody2D>();
            playerRigi.velocity = Vector2.zero;                                                     // stops player
        }
        yield return new WaitForSeconds(fadeTime);                                                  // pause until fade is done  
        SceneManager.LoadScene(AreaToLoad);                                                         // load new scene
    }
}