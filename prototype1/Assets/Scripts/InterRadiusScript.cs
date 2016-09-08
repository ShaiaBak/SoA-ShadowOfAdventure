using UnityEngine;
using System.Collections;

public class InterRadiusScript : MonoBehaviour {

    public bool playerInteract = false;

    void Awake() {
        transform.localScale = new Vector3(3f, 3f, 0);  // set scale so all radii are consistant 
    }

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