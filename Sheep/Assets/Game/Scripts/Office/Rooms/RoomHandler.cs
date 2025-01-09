using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    public Room[] rooms;
    public DoorVis[] doorsVis;

    bool freddieReady = true, bonnieReady = true, foxyReady = true, chicaReady = true;

    Room previousFreddie = null;
    Room previousBonnie = null;
    Room previousFoxy = null;
    Room previousChica = null;
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
            if(room.name == "Room 12"){

                room.activity[1] = true;
                previousBonnie = room;
            }
            if(room.name == "Room 8"){

                room.activity[2] = true;
                previousFoxy = room;
            }
            if(room.name == "Room 4"){

                room.activity[3] = true;
                previousChica = room;
            }
        }
    }

    void Update(){

        if(freddieReady){
            StartCoroutine(Freddie(Random.Range(5f,15f)));
        }
        if(bonnieReady){
            StartCoroutine(Bonnie(Random.Range(5f,15f)));
        }
        if(foxyReady){
            StartCoroutine(Foxy(Random.Range(5f, 15f)));
        }
        if(chicaReady){
            StartCoroutine(Chica(Random.Range(5f,15f)));
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
        if(!(currentRoom.name == "Hall 18" && selectedRoom.name == "Room 11") && !(currentRoom.name == "Hall 13" && selectedRoom.name == "Room 12") && !(currentRoom.name == "Hall 15" && selectedRoom.name == "Room 7"))
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

    IEnumerator Bonnie(float waitTime){

        bonnieReady = false;
        yield return new WaitForSeconds(waitTime);

        Room currentRoom = null;
        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i].activity[1]){

                currentRoom = rooms[i];
            }
        }
        List<Room> choices = new List<Room>();
        for(int i = 0; i < currentRoom.adjacentRooms.Length; i++){

            if(currentRoom.adjacentRooms[i] != null && currentRoom.adjacentRooms[i] != previousBonnie){

                if(currentRoom.doors[i] == 2)
                    choices.Add(currentRoom.adjacentRooms[i]);
            }
        }
        if(choices.Count == 0){

            bonnieReady = true;
            yield break;
        }
        int c = Mathf.RoundToInt(Random.Range(0,choices.Count));
        Room selectedRoom = choices[c];
        currentRoom.activity[1] = false;
        selectedRoom.activity[1] = true;
        if(!(currentRoom.name == "Hall 18" && selectedRoom.name == "Room 11") && !(currentRoom.name == "Hall 13" && selectedRoom.name == "Room 12") && !(currentRoom.name == "Hall 15" && selectedRoom.name == "Room 7"))
            previousBonnie = currentRoom;

        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i] == currentRoom){

                doorsVis[i].bonnie = false;
            }
            if(rooms[i] == selectedRoom){

                doorsVis[i].bonnie = true;
            }
        }

        bonnieReady = true;
    }

    IEnumerator Foxy(float waitTime){

        foxyReady = false;
        yield return new WaitForSeconds(waitTime);

        Room currentRoom = null;
        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i].activity[2]){

                currentRoom = rooms[i];
            }
        }
        List<Room> choices = new List<Room>();
        for(int i = 0; i < currentRoom.adjacentRooms.Length; i++){

            if(currentRoom.adjacentRooms[i] != null && currentRoom.adjacentRooms[i] != previousFoxy){

                if(currentRoom.doors[i] == 2)
                    choices.Add(currentRoom.adjacentRooms[i]);
            }
        }
        if(choices.Count == 0){

            foxyReady = true;
            yield break;
        }
        int c = Mathf.RoundToInt(Random.Range(0,choices.Count));
        Room selectedRoom = choices[c];
        currentRoom.activity[2] = false;
        selectedRoom.activity[2] = true;
        if(!(currentRoom.name == "Hall 18" && selectedRoom.name == "Room 11") && !(currentRoom.name == "Hall 13" && selectedRoom.name == "Room 12") && !(currentRoom.name == "Hall 15" && selectedRoom.name == "Room 7"))
            previousFoxy = currentRoom;

        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i] == currentRoom){

                doorsVis[i].foxy = false;
            }
            if(rooms[i] == selectedRoom){

                doorsVis[i].foxy = true;
            }
        }

        foxyReady = true;
    }

    IEnumerator Chica(float waitTime){

        chicaReady = false;
        yield return new WaitForSeconds(waitTime);

        Room currentRoom = null;
        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i].activity[3]){

                currentRoom = rooms[i];
            }
        }
        List<Room> choices = new List<Room>();
        for(int i = 0; i < currentRoom.adjacentRooms.Length; i++){

            if(currentRoom.adjacentRooms[i] != null && currentRoom.adjacentRooms[i] != previousChica){

                if(currentRoom.doors[i] == 2)
                    choices.Add(currentRoom.adjacentRooms[i]);
            }
        }
        if(choices.Count == 0){

            chicaReady = true;
            yield break;
        }
        int c = Mathf.RoundToInt(Random.Range(0,choices.Count));
        Room selectedRoom = choices[c];
        currentRoom.activity[3] = false;
        selectedRoom.activity[3] = true;
        if(!(currentRoom.name == "Hall 18" && selectedRoom.name == "Room 11") && !(currentRoom.name == "Hall 13" && selectedRoom.name == "Room 12") && !(currentRoom.name == "Hall 15" && selectedRoom.name == "Room 7"))
            previousChica = currentRoom;

        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i] == currentRoom){

                doorsVis[i].chica = false;
            }
            if(rooms[i] == selectedRoom){

                doorsVis[i].chica = true;
            }
        }

        chicaReady = true;
    }

}
