using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class townTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene("prototype-town1");
        Debug.Log("collide");
    }
}