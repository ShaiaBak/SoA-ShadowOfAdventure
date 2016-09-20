using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaticTextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public GameObject player;
    public PlayerController playerController;
    public GameObject[] radii;
    public MidRadiusScript midRadiusScript;

    public bool textBoxActive;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        radii = GameObject.FindGameObjectsWithTag("InteractRadius");
        foreach(GameObject radius in radii) {
            midRadiusScript = radius.GetComponent<MidRadiusScript>();       // not needed for static vars
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
            // Debug.Log("can talk");
            if (!textBoxActive) {
                enableTextBox();
            } else {
                // Debug.Log("cant talk");
                disableTextBox();
            }
        } else if (Input.GetKeyUp(KeyCode.Space) && playerController.interact == false) {
            if (textBoxActive) {
                // Debug.Log("kill talk");
                disableTextBox();
            }
        }

        if (MidRadiusScript.midPlayerInteract == false) {
            // Debug.Log("will never talk");
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
