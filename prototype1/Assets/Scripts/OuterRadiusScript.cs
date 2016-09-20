using UnityEngine;
using System.Collections;

public class OuterRadiusScript : MonoBehaviour {

    public static bool outerPlayerInteract = false;      // static variable able to be accessed w/o extending class (getcomponent)
    public bool outerNpcInteract = false;

    void Awake() {
        transform.localScale = new Vector3(3f, 3f, 0);  // set scale so all radii are consistant 
    }

    void OnTriggerEnter2D(Collider2D col) {
        // Debug.Log(col.collider.name);
       if (col.name == "player") {      // @TODO: change method of finding ho is colliding
            outerPlayerInteract = true;
            outerNpcInteract = true;
       }

        //Debug.Log(outerPlayerInteract);
    }

    void OnTriggerExit2D(Collider2D col) {
        outerPlayerInteract = false;
        outerNpcInteract = false;
    }
}