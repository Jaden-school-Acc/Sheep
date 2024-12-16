using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public static Dictionary<string, byte> DoorNums = new Dictionary<string, byte>(){

        {"northDoor", 0},
        {"eastDoor", 1},
        {"southDoor", 2},
        {"westDoor", 3}
    };

    byte roomNum;
    byte doorNum;

    string[] split;

    void Start(){

        Door.DoorNums.TryGetValue(name, out doorNum);
        split = transform.parent.name.Split(" ");
        roomNum = (byte)int.Parse(split[1]);
    }
}
