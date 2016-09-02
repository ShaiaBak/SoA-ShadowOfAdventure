using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class fadeScene : MonoBehaviour {

    public Texture2D fadeOutTexture;    // create 2D texture that will cover the screen
    public float fadeSpeed = 0.8f;      // fade speed

    private int drawDepth = -1000;      // the draw heirarchy for texture: low number means it will be on top  
    private float alpha = 1.0f;         // the textures alpha value (opacity)
    private int fadeDir = -1;           // the direction of fade: in (-1) or out(1)

    void OnGUI() {
        // fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        // force (clamp) the number between 0 and 1 because GUI.color uses alpha values beween 0 and 1 (like opacity)
        alpha = Mathf.Clamp01(alpha); // .Clamp01 makes it between 0 and 1

        // set color of the texture
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);            // set alpha value
        GUI.depth = drawDepth;                                                          // make the black texture render on top
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);   // draw the texture to fit the entire screen area
    }

    // sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
    public float BeginFade(int direction) {
        fadeDir = direction;
        return (fadeSpeed);     // return the fadeSpeed variable to its easy to time the Application.LoadLevel();
    }

    void OnEnable() { // when script is enabled
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable() { // when script is disabled
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        // alpha = 1;          // ise this if the aplha is not set to 1 by default
        BeginFade(-1);      // cal the fade in function
    }
}