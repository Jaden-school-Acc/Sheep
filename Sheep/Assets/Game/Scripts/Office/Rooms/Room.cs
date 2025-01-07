using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Room", menuName = "Room", order = 1)]
[Serializable]
public class Room : ScriptableObject
{
    public bool isOffice;

    [Tooltip("0 = no door, 1 = unoccupied, 2 = occupied\norder is: N/E/S/W - 0/1/2/3")]
    public byte[] doorStatus = new byte[]{};

    // 0 = no door, 1 = closed door, 2 = open door
    [Tooltip("0 = no door, 1 = closed door, 2 = open door\norder is: N/E/S/W - 0/1/2/3")]
    public byte[] doors = new byte[]{

        0,0,0,0
    };

    [Tooltip("false = absent, true = present\norder is: Freddie/Bonnie/Foxy/Chica - 0/1")]
    // false = absent, true = present
    // [child],[sheep]
    public bool[] activity = new bool[]{

        false,false
    };

    [Tooltip("order is: N/E/S/W - 0/1/2/3")]
    public Room[] adjacentRooms = new Room[]{

        null,null,null,null
    };
}
