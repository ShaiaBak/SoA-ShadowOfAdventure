using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
    public bool npc_isTalking = false;
    public StaticTextBoxManager textBoxManager;
    public GameObject npc;
    public InterRadiusScript interRadiusScript;
    public PlayerController playerController;

    Animator npcAnim;
    GameObject gameController;
    GameObject player;

    void Awake() {
        npcAnim = GetComponent<Animator>();

        // npc radius
        interRadiusScript = GetComponentInChildren<InterRadiusScript>();

        // game controller
        gameController = GameObject.FindGameObjectWithTag("GameController");
        textBoxManager = gameController.GetComponent<StaticTextBoxManager>();

        // player controller
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update() {
        checkTalking();
    }

    void checkTalking() {
        if (textBoxManager.textBoxActive == true && interRadiusScript.npcInteract == true && playerController.interact == true) {
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