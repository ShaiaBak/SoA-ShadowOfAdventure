using UnityEngine;
using System.Collections;

public class InteractNotif : MonoBehaviour {

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float fadeSpeed = 5.0f;
    public float threshold = float.Epsilon;

    public bool faded = false;

    public GameObject speechBubble;
    public SpriteRenderer sprite;
    InterRadiusScript NPC;

    void Awake() {
        NPC = transform.parent.GetComponent<InterRadiusScript>();   // get parent script
    }

    void Update() {
        bubbleHandler();
        StartCoroutine("doFade");
    }

    public void bubbleHandler() {
        // when player enters interact radius
        if (NPC.playerInteract == true) {
            faded = true;
        } else {
            faded = false;
        }
    }

    IEnumerator doFade() {
        float step = fadeSpeed * Time.deltaTime;

        if (faded) {
            sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(sprite.color.a, maximum, step));
            if (Mathf.Abs(maximum - sprite.color.a) <= threshold) {
                faded = false;
            }
            yield return new WaitForSeconds(fadeSpeed);
        } else {
            sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(sprite.color.a, minimum, step));
            if (Mathf.Abs(sprite.color.a - minimum) <= threshold) {
                faded = true;    
            }
            yield return new WaitForSeconds(fadeSpeed);
        }
    }
}