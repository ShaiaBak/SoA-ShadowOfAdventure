using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
    public bool npc_isTalking = false;
    public TextBoxManager textBoxManager;
    public GameObject[] npcs;
    public InterRadiusScript interRadiusScript;

    Animator npcAnim;
    GameObject gameController;
    

    //Animator playerAnim;
    //playerAnim.SetInteger("playerDir", 0);
    // playerAnim = GetComponent<Animator>();

    void Awake() {
        npcAnim = GetComponent<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        foreach(GameObject npc in npcs) {
            interRadiusScript = npc.GetComponent<InterRadiusScript>();
        }

        textBoxManager = gameController.GetComponent<TextBoxManager>();
    }

    void Update() {
        checkTalking();
    }

    void checkTalking() {
        if (textBoxManager.textBoxActive == true && interRadiusScript.npcInteract == true) {
            npc_isTalking = true;
        } else {
            npc_isTalking = false;
        }

        if (npc_isTalking) {
            npcAnim.SetBool("isTalking", true);
        } else {
            npcAnim.SetBool("isTalking", false);
        }
    }
}