using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorVis : MonoBehaviour
{
    public RawImage[] doors = new RawImage[4];
    RawImage self;

    public bool freddie, bonnie, foxy, chica;

    void Start(){

        self = GetComponent<RawImage>();

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

    void Update(){

        if(freddie){

            self.color = new Color(0.4f,0.2f,0,1);
        }
        else if(bonnie){

            self.color = new Color(1,0,1,1);
        }
        else if(foxy){

            self.color = new Color(1,0,0,1);
        }
        else if(chica){
            self.color = new Color(1,1,0,1);
        }
        else
            self.color = new Color(1,1,1,1);
    }
}
