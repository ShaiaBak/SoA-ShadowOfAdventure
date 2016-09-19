using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Transform player;
    private GameObject playerCheck;

    // Use this for initialization
    void Start() {
        playerCheck = GameObject.FindGameObjectWithTag("Player");

        if (playerCheck == null) {
            Object newPlayer = Instantiate(player, transform.position, transform.rotation);
            newPlayer.name = "player";
        } else {
            // nothing
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
