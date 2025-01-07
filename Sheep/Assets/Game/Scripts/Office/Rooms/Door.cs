using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    RoomHandler handler;

    public static Dictionary<string, byte> DoorNums = new Dictionary<string, byte>(){

        {"northDoor", 0},
        {"eastDoor", 1},
        {"southDoor", 2},
        {"westDoor", 3}
    };

    public static Dictionary<int, int> DirOpp = new Dictionary<int, int>(){ // Diff is wrap +2

        {0, 2},
        {1, 3},
        {2, 0},
        {3, 1}
    };

    byte roomNum;
    byte doorNum;

    string[] split;

    void Start(){

        handler = transform.parent.parent.GetComponent<RoomHandler>();
        Door.DoorNums.TryGetValue(name, out doorNum);
        split = transform.parent.name.Split(" ");
        roomNum = (byte)int.Parse(split[1]);
    }

    void IPointerEnterHandler.OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData){


    }
    void IPointerExitHandler.OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData){


    }
    void IPointerClickHandler.OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData){


        switch(handler.rooms[roomNum].doors[doorNum]){

            case 1:
                handler.rooms[roomNum].doors[doorNum] = 2;
                handler.rooms[roomNum].adjacentRooms[doorNum].doors[DirOpp[doorNum]] = 2;
                handler.doorsVis[roomNum].doors[doorNum].color = new Color(0.2877358f, 1f, 0.3826894f);
                break;
            case 2:
                handler.rooms[roomNum].doors[doorNum] = 1;
                handler.rooms[roomNum].adjacentRooms[doorNum].doors[DirOpp[doorNum]] = 1;
                handler.doorsVis[roomNum].doors[doorNum].color = new Color(1f, 0.4005865f, 0.2862746f);
                break;
            case 0:
                break;
            default:
                break;
        }
    }
}
