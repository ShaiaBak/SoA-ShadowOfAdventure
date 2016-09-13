using UnityEngine;
using System.Collections;

public class InterRadiusScript : MonoBehaviour {

    public static bool playerInteract = false;      // static variable able to be accessed w/o extending class (getcomponent)
    public bool npcInteract = false;

    void Awake() {
        transform.localScale = new Vector3(3f, 3f, 0);  // set scale so all radii are consistant 
    }

    void OnTriggerEnter2D(Collider2D col) {
        // Debug.Log(col.collider.name);
       if (col.name == "player") {
            playerInteract = true;
            npcInteract = true;
       }

        //Debug.Log(playerInteract);
    }

    void OnTriggerExit2D(Collider2D col) {
        playerInteract = false;
        npcInteract = false;
    }
}