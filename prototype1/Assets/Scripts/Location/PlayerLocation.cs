using UnityEngine;
using System.Collections;

public class PlayerLocation {

    //world cords
    private Vector2 worldCord2D;

    //zone
    private ZoneTypes zone;
    public enum ZoneTypes {
        A,
        B,
        C,
        None
    }

    public Vector2 WorldCord2D {
        get { return worldCord2D; }
    }

    public ZoneTypes Zone {
        get { return zone; }
    }

    public PlayerLocation(Vector2 worldCord2D) {
        this.worldCord2D = worldCord2D;
        zone = ZoneTypes.None;
    }

    public bool Compare(PlayerLocation location) {
        if (worldCord2D != Vector2.zero && location.worldCord2D == worldCord2D) {
            return true;
        } else if (zone != ZoneTypes.None && location.zone == zone) {
            return true;
        } else {
            return false;
        }
    }
}