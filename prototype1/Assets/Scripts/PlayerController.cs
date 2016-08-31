using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rigi;
    Animator playerAnim;

    // Use this for initialization
    void Start () {
        rigi = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }


    void FixedUpdate() {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHoriz, moveVert, 0.0f);
        rigi.velocity = movement * speed;

        if(moveHoriz == 0 && moveVert == 0) {
            playerAnim.SetInteger("State", 0);
        }
        if (moveHoriz > 0 && moveVert == 0) {
            playerAnim.SetInteger("State", 2);
        } else if (moveHoriz < 0 && moveVert == 0) {
            playerAnim.SetInteger("State", 4);
        } else if (moveHoriz == 0 && moveVert > 0) {
            playerAnim.SetInteger("State", 1);
        } else if (moveHoriz == 0 && moveVert < 0) {
            playerAnim.SetInteger("State", 3);
        } 
        // @TODO: make diagonal movements
        else if ((moveHoriz > 0 || moveHoriz < 0) && moveVert > 0) {
            playerAnim.SetInteger("State", 1);
        } else if ((moveHoriz > 0 || moveHoriz < 0) && moveVert < 0) {
            playerAnim.SetInteger("State", 3);
        } else {
            playerAnim.SetInteger("State", 0);
        }
    }
}
