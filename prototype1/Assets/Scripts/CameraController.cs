using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public float camVelocity;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start() {
        targetPos = transform.position;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (target) {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * camVelocity;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }

    void Update() {
        if (target == null) {
            // if player is not created before run, check for player until it is created
            target = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("running");
        }
    }
}
