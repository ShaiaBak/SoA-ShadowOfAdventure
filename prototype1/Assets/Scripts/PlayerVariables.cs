using UnityEngine;
using System.Collections;
using System.Linq;

public static class PlayerVariables {

    public static bool door_proto1a = false;

    public static GameObject FindDoorWithID(string id) {
        return FindDoorsWithID(id)[0];
    }

    public static GameObject[] FindDoorsWithID(string id) {
        return GameObject.FindObjectsOfType<LoadArea>().Where(x => x.id == id).Select(x => x.gameObject).ToArray();
    }
}