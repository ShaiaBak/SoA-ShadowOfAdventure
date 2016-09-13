using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaticTextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public PlayerController player;
    public GameObject[] radii;
    public InterRadiusScript interRadiusScript;

    public bool textBoxActive;

    // Use this for initialization
    void Start () {
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

    void checkTalkRadius() {
        // Debug.Log(InterRadiusScript.playerInteract);
        if (Input.GetKeyUp(KeyCode.Space) && player.interact == true) {
            if (!textBoxActive) {
                enableTextBox();
            } else {
                disableTextBox();
            }
        } else if (Input.GetKeyUp(KeyCode.Space) && player.interact == false) {
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
        player.canMove = false;
        textBoxActive = true;
    }

    public void disableTextBox() {
        textBox.SetActive(false);
        player.canMove = true;
        textBoxActive = false;
    }
}
