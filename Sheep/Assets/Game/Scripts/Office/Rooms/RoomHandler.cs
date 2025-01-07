using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    public Room[] rooms;
    public DoorVis[] doorsVis;

    bool freddieReady = true;
    void Update(){

        if(freddieReady){
            StartCoroutine(Freddie(Random.Range(0f,10f)));
        }
    }

    IEnumerator Freddie(float waitTime){

        freddieReady = false;
        yield return new WaitForSeconds(waitTime);

        Room currentRoom = null;
        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i].activity[0]){

                currentRoom = rooms[i];
            }
        }
        List<Room> choices = new List<Room>();
        for(int i = 0; i < currentRoom.adjacentRooms.Length; i++){

            if(currentRoom.adjacentRooms[i] != null){

                if(currentRoom.doors[i] == 2)
                    choices.Add(currentRoom.adjacentRooms[i].GetComponent<Room>());
            }
        }
        int c = Mathf.RoundToInt(Random.Range(0,choices.Count-1));
        Room selectedRoom = choices[c];
        currentRoom.activity[0] = false;
        selectedRoom.activity[0] = true;

        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i] == currentRoom){

                doorsVis[i].freddie = false;
            }
            if(rooms[i] == selectedRoom){

                doorsVis[i].freddie = true;
            }
        }

        freddieReady = true;
    }
}
