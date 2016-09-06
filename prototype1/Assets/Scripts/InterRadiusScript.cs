using UnityEngine;
using System.Collections;

public class InterRadiusScript : MonoBehaviour {

    public bool playerInteract = false;

    void OnTriggerEnter2D(Collider2D col) {
        // Debug.Log(col.collider.name);
       if (col.name == "player") {
            playerInteract = true;
       }
    }

    void OnTriggerExit2D(Collider2D col) {
        playerInteract = false;
    }
}
