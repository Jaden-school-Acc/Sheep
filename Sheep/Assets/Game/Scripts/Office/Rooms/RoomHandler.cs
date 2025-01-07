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

    Room previousFreddie = null;
    void Start(){

        foreach(Room room in rooms){

            for(int i = 0; i < room.activity.Length; i++){

                room.activity[i] = false;
                if(room.doors[i] != 0)
                    room.doors[i] = 2;
            }
            if(room.name == "Room 7"){

                room.activity[0] = true;
                previousFreddie = room;
            }
        }
    }

    void Update(){

        if(freddieReady){
            StartCoroutine(Freddie(Random.Range(5f,15f)));
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

            if(currentRoom.adjacentRooms[i] != null && currentRoom.adjacentRooms[i] != previousFreddie){

                if(currentRoom.doors[i] == 2)
                    choices.Add(currentRoom.adjacentRooms[i]);
            }
        }
        if(choices.Count == 0){

            freddieReady = true;
            yield break;
        }
        int c = Mathf.RoundToInt(Random.Range(0,choices.Count));
        Room selectedRoom = choices[c];
        currentRoom.activity[0] = false;
        selectedRoom.activity[0] = true;
        if(!(currentRoom.name == "Hall 18" && selectedRoom.name == "Room 11") && !(currentRoom.name == "Hall 13" && selectedRoom.name == "Room 22"))
            previousFreddie = currentRoom;

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
