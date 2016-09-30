using UnityEngine;
using System.Collections;
using System.Linq;

public class DoorManager : MonoBehaviour {

    public static GameObject FindDoorWithID(int id) {
        return FindDoorsWithID(id)[0];
    }

    public static GameObject[] FindDoorsWithID(int id) {
        return GameObject.FindObjectsOfType<LoadArea>().Where(x => x.id == id).Select(x => x.gameObject).ToArray();
    }
}
