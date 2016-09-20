using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
    public bool npc_isTalking = false;
    public StaticTextBoxManager textBoxManager;
    public GameObject npc;
    public OuterRadiusScript outerRadiusScript;
    public PlayerController playerController;

    Animator npcAnim;
    GameObject gameController;
    GameObject player;

    void Awake() {
        playerController = FindObjectOfType<PlayerController>();
        npcAnim = GetComponent<Animator>();

        npc = transform.gameObject;

        // npc radius
        outerRadiusScript = GetComponentInChildren<OuterRadiusScript>();

        // game controller
        gameController = GameObject.FindGameObjectWithTag("GameController");
        textBoxManager = gameController.GetComponent<StaticTextBoxManager>();

        // player controller
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        checkTalking();

        if(playerController == null) {
            playerController = FindObjectOfType<PlayerController>();
        }
    }

    void checkTalking() {
        if (textBoxManager.textBoxActive == true && outerRadiusScript.outerNpcInteract == true && playerController.interact == true) {
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