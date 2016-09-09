using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;

    public PlayerController player;

    public bool textBoxActive;

	// Use this for initialization
	void Start () {
        if (textBoxActive) {
            enableTextBox();
        } else {
            disableTextBox();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Space)) {
            if (!textBoxActive) {
                enableTextBox();
            } else {
                disableTextBox();
            }
        }
	}

    public void enableTextBox() {
        textBox.SetActive(true);
        textBoxActive = true;
    }

    public void disableTextBox() {
        textBox.SetActive(false);
        textBoxActive = false;
    }
}
