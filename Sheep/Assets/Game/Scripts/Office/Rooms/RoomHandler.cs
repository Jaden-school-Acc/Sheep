using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{

    OfficeMovement player;

    public Room[] rooms;
    public DoorVis[] doorsVis;

    [SerializeField] GameObject[] animatronics;

    bool freddyReady = true, bonnieReady = true, foxyReady = true, chicaReady = true;
    bool freddyReadyAfter = true, bonnieReadyAfter = true, foxyReadyAfter = true, chicaReadyAfter = true;

    Room previousFreddy = null;
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
                previousFreddy = room;
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
    
        player = GameObject.Find("Player").GetComponent<OfficeMovement>();
    }

    void Update(){

        if(freddyReady){
            StartCoroutine(Freddy(Random.Range(5f,15f)));
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
    IEnumerator Freddy(float waitTime){

        
        freddyReady = false;

        Room currentRoom = null;
        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i].activity[0]){

                currentRoom = rooms[i];
            }
        }
        if(currentRoom.name == "Office 0")
            animatronics[0].SetActive(true);
        yield return new WaitForSeconds(waitTime);

        if(currentRoom.name == "Office 0"){
        
            freddyReadyAfter = false;
            bonnieReadyAfter = false;
            foxyReadyAfter = false;
            chicaReadyAfter = false;
            yield return new WaitForSeconds(2f);
            if(!player.maskOn){

                Debug.Log("(Insert Jumpscare Here)");
                yield break;
            }
            else{
                Debug.Log("Safe.");
                animatronics[0].SetActive(false);
                freddyReadyAfter = true;
                bonnieReadyAfter = true;
                foxyReadyAfter = true;
                chicaReadyAfter = true;
            }
        }

        yield return new WaitUntil(() => freddyReadyAfter);
        freddyReadyAfter = false;
        List<Room> choices = new List<Room>();
        for(int i = 0; i < currentRoom.adjacentRooms.Length; i++){

            if(currentRoom.adjacentRooms[i] != null && currentRoom.adjacentRooms[i] != previousFreddy){

                if(currentRoom.doors[i] == 2){

                    for(int j = 0; j < currentRoom.adjacentRooms[i].soundLevel + 1; j++){

                        choices.Add(currentRoom.adjacentRooms[i]);
                    }
                }
            }
        }
        if(choices.Count == 0){

            freddyReady = true;
            yield break;
        }
        for(int i = 0; i < choices.Count; i++){
            
            if(choices[i].name == "Office 0"){

                if(currentRoom.name != "Hall 14"){
                    choices.RemoveAt(i);
                    i = 0;
                }
            }
        }
        if(choices.Count == 0){

            freddyReady = true;
            yield break;
        }
        int c = Mathf.RoundToInt(Random.Range(0,choices.Count));
        Room selectedRoom = choices[c];
        currentRoom.activity[0] = false;
        selectedRoom.activity[0] = true;
        if(!(currentRoom.name == "Hall 18" && selectedRoom.name == "Room 11") && !(currentRoom.name == "Hall 13" && selectedRoom.name == "Room 12") && !(currentRoom.name == "Hall 15" && selectedRoom.name == "Room 7"))
            previousFreddy = currentRoom;

        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i] == currentRoom){

                doorsVis[i].freddy = false;
            }
            if(rooms[i] == selectedRoom){

                doorsVis[i].freddy = true;
            }
        }

        freddyReady = true;
        freddyReadyAfter = true;
    }

    IEnumerator Bonnie(float waitTime){

        
        bonnieReady = false;

        Room currentRoom = null;
        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i].activity[1]){

                currentRoom = rooms[i];
            }
        }
        if(currentRoom.name == "Office 0")
            animatronics[1].SetActive(true);
        yield return new WaitForSeconds(waitTime);

        if(currentRoom.name == "Office 0"){

            freddyReadyAfter = false;
            bonnieReadyAfter = false;
            foxyReadyAfter = false;
            chicaReadyAfter = false;
            yield return new WaitForSeconds(2f);
            if(!player.maskOn){

                Debug.Log("(Insert Jumpscare Here)");
                yield break;
            }
            else{
                Debug.Log("Safe.");
                animatronics[1].SetActive(false);
                freddyReadyAfter = true;
                bonnieReadyAfter = true;
                foxyReadyAfter = true;
                chicaReadyAfter = true;
            }
        }

        yield return new WaitUntil(() => bonnieReadyAfter);
        bonnieReadyAfter = false;
        List<Room> choices = new List<Room>();
        for(int i = 0; i < currentRoom.adjacentRooms.Length; i++){

            if(currentRoom.adjacentRooms[i] != null && currentRoom.adjacentRooms[i] != previousBonnie){

                if(currentRoom.doors[i] == 2){

                    for(int j = 0; j < currentRoom.adjacentRooms[i].soundLevel + 1; j++){

                        choices.Add(currentRoom.adjacentRooms[i]);
                    }
                }
            }
        }
        if(choices.Count == 0){

            bonnieReady = true;
            yield break;
        }
        for(int i = 0; i < choices.Count; i++){
            
            if(choices[i].name == "Office 0"){

                if(currentRoom.name != "Hall 13"){
                    choices.RemoveAt(i);
                    i = 0;
                }
            }
            if(choices[i].name == "Hall 14"){

                choices.RemoveAt(i);
                i = 0;
            }
        }
        if(choices.Count == 0){

            freddyReady = true;
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
        bonnieReadyAfter = true;
    }

    IEnumerator Foxy(float waitTime){

        
        foxyReady = false;

        Room currentRoom = null;
        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i].activity[2]){

                currentRoom = rooms[i];
            }
        }
        if(currentRoom.name == "Office 0")
            animatronics[2].SetActive(true);
        yield return new WaitForSeconds(waitTime);

        if(currentRoom.name == "Office 0"){
            
            freddyReadyAfter = false;
            bonnieReadyAfter = false;
            foxyReadyAfter = false;
            chicaReadyAfter = false;
            yield return new WaitForSeconds(2f);
            if(!player.maskOn){

                Debug.Log("(Insert Jumpscare Here)");
                yield break;
            }
            else{
                Debug.Log("Safe.");
                animatronics[2].SetActive(false);
                freddyReadyAfter = true;
                bonnieReadyAfter = true;
                foxyReadyAfter = true;
                chicaReadyAfter = true;
            }
        }

        yield return new WaitUntil(() => foxyReadyAfter);
        foxyReadyAfter = false;
        List<Room> choices = new List<Room>();
        for(int i = 0; i < currentRoom.adjacentRooms.Length; i++){

            if(currentRoom.adjacentRooms[i] != null && currentRoom.adjacentRooms[i] != previousFoxy){

                if(currentRoom.doors[i] == 2){

                    for(int j = 0; j < currentRoom.adjacentRooms[i].soundLevel + 1; j++){

                        choices.Add(currentRoom.adjacentRooms[i]);
                    }
                }
            }
        }
        if(choices.Count == 0){

            foxyReady = true;
            yield break;
        }
        for(int i = 0; i < choices.Count; i++){
            
            if(choices[i].name == "Office 0"){

                if(currentRoom.name != "Hall 14"){
                    choices.RemoveAt(i);
                    i = 0;
                }
            }
        }
        if(choices.Count == 0){

            freddyReady = true;
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
        foxyReadyAfter = true;
    }

    IEnumerator Chica(float waitTime){

        
        chicaReady = false;

        Room currentRoom = null;
        for(int i = 0; i < rooms.Length; i++){

            if(rooms[i].activity[3]){

                currentRoom = rooms[i];
            }
        }
        if(currentRoom.name == "Office 0")
            animatronics[3].SetActive(true);
        yield return new WaitForSeconds(waitTime);

        if(currentRoom.name == "Office 0"){
            
            freddyReadyAfter = false;
            bonnieReadyAfter = false;
            foxyReadyAfter = false;
            chicaReadyAfter = false;
            yield return new WaitForSeconds(2f);
            if(!player.maskOn){

                Debug.Log("(Insert Jumpscare Here)");
                yield break;
            }
            else{
                Debug.Log("Safe.");
                animatronics[3].SetActive(false);
                freddyReadyAfter = true;
                bonnieReadyAfter = true;
                foxyReadyAfter = true;
                chicaReadyAfter = true;
            }
        }

        yield return new WaitUntil(() => chicaReadyAfter);
        chicaReadyAfter = false;
        List<Room> choices = new List<Room>();
        for(int i = 0; i < currentRoom.adjacentRooms.Length; i++){

            if(currentRoom.adjacentRooms[i] != null && currentRoom.adjacentRooms[i] != previousChica){

                if(currentRoom.doors[i] == 2){

                    for(int j = 0; j < currentRoom.adjacentRooms[i].soundLevel + 1; j++){

                        choices.Add(currentRoom.adjacentRooms[i]);
                    }
                }
            }
        }
        if(choices.Count == 0){

            chicaReady = true;
            yield break;
        }
        for(int i = 0; i < choices.Count; i++){
            
            if(choices[i].name == "Office 0"){

                if(currentRoom.name != "Hall 16"){
                    choices.RemoveAt(i);
                    i = 0;
                }
            }
            if(choices[i].name == "Hall 14"){

                choices.RemoveAt(i);
                i = 0;
            }
        }
        if(choices.Count == 0){

            freddyReady = true;
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
        chicaReadyAfter = true;
    }

}
