using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaticTextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public GameObject player;
    public PlayerController playerController;
    public GameObject[] radii;
    public InterRadiusScript interRadiusScript;

    public bool textBoxActive;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        radii = GameObject.FindGameObjectsWithTag("InteractRadius");
        foreach(GameObject radius in radii) {
            interRadiusScript = radius.GetComponent<InterRadiusScript>();       // not needed for static vars
        }

        if (textBoxActive) {
            enableTextBox();
        } else {
            disableTextBox();
        }
	}
	
	// Update is called once per frame
	void Update () {
        checkTalkRadius();
    }

    // @TODO: BUG: if player crosses from one radius to another, and the player lives in both radii at the same times during the crossing, text box doesnt work.

    void checkTalkRadius() {
        // Debug.Log(InterRadiusScript.playerInteract);
        if (Input.GetKeyUp(KeyCode.Space) && playerController.interact == true) {
            if (!textBoxActive) {
                enableTextBox();
            } else {
                disableTextBox();
            }
        } else if (Input.GetKeyUp(KeyCode.Space) && playerController.interact == false) {
            if (textBoxActive) {
                disableTextBox();
            }
        }

        if (InterRadiusScript.playerInteract == false) {
            disableTextBox();
        }
    }

    public void enableTextBox() {
        textBox.SetActive(true);
        playerController.canMove = false;
        textBoxActive = true;
    }

    public void disableTextBox() {
        textBox.SetActive(false);
        playerController.canMove = true;
        textBoxActive = false;
    }
}
