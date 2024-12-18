using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorVis : MonoBehaviour
{
    public RawImage[] doors = new RawImage[4];

    void Start(){

        foreach(RawImage door in transform.GetComponentsInChildren<RawImage>()){
            
            switch(Door.DoorNums.GetValueOrDefault(door.name)){

                case 0:
                    doors[0] = door;
                    break;
                case 1:
                    doors[1] = door;
                    break;
                case 2:
                    doors[2] = door;
                    break;
                case 3:
                    doors[3] = door;
                    break;
                default:
                    break;
            }
        }
    }
}
