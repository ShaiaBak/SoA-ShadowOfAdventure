using UnityEngine;
using System.Collections;

public class MidRadiusScript : MonoBehaviour {

    public static bool midPlayerInteract = false;      // static variable able to be accessed w/o extending class (getcomponent)
    public bool midNpcInteract = false;

    void Awake() {
    }

    void OnTriggerStay2D(Collider2D col) {
        // Debug.Log(col.collider.name);
        if (col.name == "player") {      // @TODO: change method of finding ho is colliding
            midPlayerInteract = true;
            midNpcInteract = true;
        }

        //Debug.Log(midPlayerInteract);
    }

    void OnTriggerExit2D(Collider2D col) {
        midPlayerInteract = false;
        midNpcInteract = false;
    }
}
