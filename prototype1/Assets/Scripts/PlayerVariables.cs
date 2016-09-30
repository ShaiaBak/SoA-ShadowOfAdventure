using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerVariables : MonoBehaviour {

    public static bool door0 = false;
    public static bool door1 = false;
    public static bool door2 = false;
    public static bool door3 = false;

    void Awake() {

        GameObject door = DoorManager.FindDoorWithID(1);
        checkLock();
    }

    void checkLock() {

    }
    
}