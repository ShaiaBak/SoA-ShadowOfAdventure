using UnityEngine;
using System.Collections;

public class InteractNotif : MonoBehaviour {
    public GameObject speechBubble;
    InterRadiusScript NPC;

    void Start() {
        NPC = transform.parent.GetComponent<InterRadiusScript>();                     // get parent script
    }

    void Update() {
        bubbleHandler();
    }

    public void bubbleHandler() {
        //  NPC = GameObject.Find("npc1").gameObject;        // find child gameobject

        if(NPC.playerInteract == true) {
            foreach (SpriteRenderer speechBubble in GetComponentsInChildren<SpriteRenderer>()) {
                speechBubble.material.color = new Color(1f, 1f, 1f, 1);
            }
        } else {
            foreach (SpriteRenderer speechBubble in GetComponentsInChildren<SpriteRenderer>()) {
                speechBubble.material.color = new Color(1f, 1f, 1f, 0);
            }
        }
    }
}