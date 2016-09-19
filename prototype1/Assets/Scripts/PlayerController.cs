using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static float speed;
    public bool interact = false;
    public Transform lineStart;
    public Transform lineEnd;
    public string playerDirection;
    public bool canMove;

    private Rigidbody2D rigi;
    private static bool playerExists;       // all objects that has this script, share the static information

    Animator playerAnim;
    RaycastHit2D hitInstance;

    // Use this for initialization
    void Awake () {
        if (!playerExists) {     // if player exist on the scene do stuff
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject);
        }

        rigi = GetComponent<Rigidbody2D>();
        rigi.freezeRotation = true;                 // Freeze the rotation
        playerAnim = GetComponent<Animator>();
        playerDirection = "UP";
        canMove = true;
        speed = 3;
    }

    void FixedUpdate() {
        movement();
        Raycasting();
        handleDir();
    }

    void handleDir() {
        if (playerDirection == "UP") {
            lineEnd.transform.localPosition = new Vector2(0, 0.4f);
        } else if (playerDirection == "RIGHT") {
            lineEnd.transform.localPosition = new Vector2(0.4f, 0);
        } else if (playerDirection == "DOWN") {
            lineEnd.transform.localPosition = new Vector2(0, -0.4f);
        } else if (playerDirection == "LEFT") {
            lineEnd.transform.localPosition = new Vector2(-0.4f, 0);
        }
    }

    void Raycasting() {
        Debug.DrawLine(lineStart.position, lineEnd.position, Color.green);      // draw the linecast so its visible for debugging

        if(Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer("InteractTrigger"))) {
            hitInstance = Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer("InteractTrigger"));  // get specific NPC (or instance) that you hit
            interact = true;
        } else {
            interact = false;
        }
    }

    void movement() {
        // if can move is false, exit out of function
        if(!canMove) {
            playerAnim.SetInteger("playerDir", 0);      // set idle animation
            return;
        }

        float moveHoriz = Input.GetAxisRaw("Horizontal");
        float moveVert = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHoriz, moveVert);
        rigi.velocity = movement * speed;

        // player animation direction
            if (moveHoriz == 0 && moveVert == 0) {
                playerAnim.SetInteger("playerDir", 0);
            }
            if (moveHoriz > 0 && moveVert == 0) {
                playerAnim.SetInteger("playerDir", 2);
                playerDirection = "RIGHT";
            } else if (moveHoriz < 0 && moveVert == 0) {
                playerAnim.SetInteger("playerDir", 4);
                playerDirection = "LEFT";
            } else if (moveHoriz == 0 && moveVert > 0) {
                playerAnim.SetInteger("playerDir", 1);
                playerDirection = "UP";
            } else if (moveHoriz == 0 && moveVert < 0) {
                playerAnim.SetInteger("playerDir", 3);
                playerDirection = "DOWN";
            }
            // @TODO: make diagonal movements
            else if ((moveHoriz > 0 || moveHoriz < 0) && moveVert > 0) {
                playerAnim.SetInteger("playerDir", 1);
            } else if ((moveHoriz > 0 || moveHoriz < 0) && moveVert < 0) {
                playerAnim.SetInteger("playerDir", 3);
            } else {
                playerAnim.SetInteger("playerDir", 0);
            }
    }
}
