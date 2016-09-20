using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Transform player;
    private GameObject playerCheck;
    private PlayerStartPoint playerStartPoint;


    // Use this for initialization
    void Start() {
        playerCheck = GameObject.FindGameObjectWithTag("Player");

        // check to see if player exists, if not, create it and call the startpoint function
        if (playerCheck == null) {
            Object newPlayer = Instantiate(player, transform.position, transform.rotation);
            newPlayer.name = "player";
            playerStartPoint = FindObjectOfType<PlayerStartPoint>();
            //playerStartPoint.startPointFunc();        // current run by PlayerStartPoint script... uncomment if no longer the case
        } else {
            // nothing
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
