using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShoutBoxManager : MonoBehaviour {

    public GameObject shoutBox;
    public Text theText;
    public PlayerController player;
    public StaticTextBoxManager staticTextBoxManager;
    public OuterRadiusScript outerRadiusScript;

    public bool shoutBoxActive;
    public bool shoutWait;
    public float shoutWaitTime;
    public float elapsedTime;

    // Use this for initialization
    void Start() {
        player = FindObjectOfType<PlayerController>();
        staticTextBoxManager = GetComponent<StaticTextBoxManager>();
        //outerRadiusScript = FindObjectOfType<OuterRadiusScript>();

        if (shoutBoxActive) {
            enableShoutBox();
        } else {
            disableShoutBox();
        }
    }

    // Update is called once per frame
    void Update() {
        checkShoutRadius();
    }

    void checkShoutRadius() {
        if (staticTextBoxManager.textBoxActive == true) {        // is the static text box is there, close all shout boxes
            shoutWait = true;
            disableShoutBox();
            StopCoroutine("disableShoutBoxEnum");
            resetTimer();
            return;
        }

        if (shoutWait == true && staticTextBoxManager.textBoxActive == false) {
            StartCoroutine("disableShoutBoxEnum");
        }
        // if player is in range, and its not waiting, start shouting
        if (OuterRadiusScript.outerPlayerInteract == true && shoutWait == false) {
            enableShoutBox();
        } else if (OuterRadiusScript.outerPlayerInteract == false) {
            disableShoutBox();
        }

        if (OuterRadiusScript.outerPlayerInteract == false) {
            disableShoutBox();
        }
    }

    public void enableShoutBox() {
        shoutBox.SetActive(true);
        shoutBoxActive = true;
    }

    public void disableShoutBox() {
        shoutBox.SetActive(false);
        shoutBoxActive = false;
    }

    // doesnt allow shout box to appear right after static text box is closed. 
    IEnumerator disableShoutBoxEnum() {
        elapsedTime = 0;
        while (elapsedTime < shoutWaitTime) {
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        shoutWait = false;
    }

    void resetTimer() {
        elapsedTime = 0;
    }
}
