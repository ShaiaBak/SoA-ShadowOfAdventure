using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class townTrigger : MonoBehaviour {

    public Rigidbody2D playerRigi;

    IEnumerator OnTriggerEnter2D(Collider2D other) {

        yield return new WaitForSeconds(0.2f);      // pause before loading

        float fadeTime = GameObject.Find("GameController").GetComponent<fadeScene>().BeginFade(1);  // find fadeScene script in GameController; 1 is in BeginFade(1) cuz 1 is fade out and -1 is fade in
        if (other.gameObject.tag == "Player") {
            playerRigi = other.gameObject.GetComponent<Rigidbody2D>();
            playerRigi.isKinematic = true;                                                          // ignores colliders
            playerRigi.velocity = Vector2.zero;                                                     // stops player

            other.gameObject.GetComponent<PlayerController>().speed = 0;
        }
        yield return new WaitForSeconds(fadeTime);                                                  // pause until fade is done  
        SceneManager.LoadScene("prototype-town1");                                                  // load new scene
    }
}