using UnityEngine;
using System.Collections;

public class AnimateText : MonoBehaviour {
    public AnimateText() { }

    public void animateText(string strComplete) {
        int i = 0;
        string str = "";
        while (i < strComplete.Length) {
            str += strComplete[i++];
            new WaitForSeconds(0.5f);
        }
    }
}
