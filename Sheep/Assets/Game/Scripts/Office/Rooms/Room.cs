using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Room", menuName = "Room", order = 1)]
[Serializable]
public class Room : ScriptableObject
{
    [SerializeField] // 0 = no door, 1 = closed door, 2 = open door
    [Tooltip("0 = no door, 1 = closed door, 2 = open door")]
    byte[] doors = new byte[]{

        0,0,0,0
    };
}
