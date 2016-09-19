using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerController playerController;
    private CameraController cameraController;

	// Use this for initialization
	void Awake () {
        playerController = FindObjectOfType<PlayerController>();

        if(playerController == null) {
            return;
        }

        playerController.transform.position = transform.position;

        cameraController = FindObjectOfType<CameraController>();
        cameraController.transform.position = new Vector3(transform.position.x, transform.position.y, cameraController.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
