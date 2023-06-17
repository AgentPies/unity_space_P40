using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class WFC : MonoBehaviour
{
    [SerializeField] public GameObject[] rooms;
    [SerializeField] Transform  canvas;
    [SerializeField] public int roomsInColumn;
    [SerializeField] public GameObject lastRoom;
       
    [SerializeField] public int roomsInRow;
    // Start is called before the first frame update
    void Start()
    {         
        int currentRoom = 0;
        
        roomsInColumn = roomsInColumn-1;
        roomsInRow = roomsInRow-1;

        GameObject[] instantiatedRooms = new GameObject[100];
        float x = 0;
        int currentRow = 0;
        int currentColumn = 0;
        while (x <= (roomsInRow) * 67)
        {
            float z = 0;
            while (z <= (roomsInColumn) * 67)
            {   
                int breakCounter = 0;
                while(true){
                    breakCounter++;
                    int random = Random.Range(0, rooms.Length);
                    GameObject room = rooms[random];
                    // pierwsza kolumna
                    if (currentRoom < roomsInColumn){
                        if (currentRoom == 0){
                            foreach (GameObject room1 in rooms){
                                if ((room1.GetComponent<WFCoptions>().left == false)&(room1.GetComponent<WFCoptions>().bottom == false)){
                                    room = room1;
                                    instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                                    currentRoom++;
                                    break;
                                }
                            }
                            break;
                        }
                        else if ((instantiatedRooms[currentRoom - 1].GetComponent<WFCoptions>().top == room.GetComponent<WFCoptions>().bottom)
                        & (room.GetComponent<WFCoptions>().left == false)){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                        }
                        else if (breakCounter > 30){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                        }
                    }
                    // pierwszy wiersz
                    else if (currentRow == 0){
                         if ((instantiatedRooms[currentRoom - roomsInColumn].GetComponent<WFCoptions>().right == room.GetComponent<WFCoptions>().left)
                         & (room.GetComponent<WFCoptions>().bottom == false))
                         {
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                         else if (breakCounter > 30){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                    }
                    // ostatnia kolumna
                    else if (currentColumn == roomsInRow){
                        if (currentRow == 0){
                            foreach (GameObject room1 in rooms){
                                if ((room1.GetComponent<WFCoptions>().right == false)&(room1.GetComponent<WFCoptions>().bottom == false)){
                                    room = room1;
                                    instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                                    currentRoom++;
                                    break;
                                }
                            }
                            break;
                        }
                        else if (currentRow == roomsInColumn){
                                room = lastRoom;
                                instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                                currentRoom++;
                                break;
                            }                        
                        else if ((room.GetComponent<WFCoptions>().right == false) & 
                        (instantiatedRooms[currentRoom - 1].GetComponent<WFCoptions>().top == room.GetComponent<WFCoptions>().bottom) &
                        (instantiatedRooms[currentRoom - roomsInColumn].GetComponent<WFCoptions>().right == room.GetComponent<WFCoptions>().left))
                        {
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                         else if (breakCounter > 30){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                    }
                    // ostatni wiersz
                    else if (currentRow == roomsInColumn)
                   {
                        if (currentColumn == 0){
                            foreach (GameObject room1 in rooms){
                                if ((room1.GetComponent<WFCoptions>().left == false)&(room1.GetComponent<WFCoptions>().top == false)){
                                    room = room1;
                                    instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                                    currentRoom++;
                                    break;
                                }
                            }
                            break;
                        }
                        else if ( (instantiatedRooms[currentRoom - 1].GetComponent<WFCoptions>().top == room.GetComponent<WFCoptions>().bottom) &
                        (instantiatedRooms[currentRoom - roomsInColumn].GetComponent<WFCoptions>().right == room.GetComponent<WFCoptions>().left)
                        & (room.GetComponent<WFCoptions>().top == false)){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                         else if (breakCounter > 30){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }     
                    }
                    // kolejne kolumny - kolejne rzędy
                    else{
                        if ((room.GetComponent<WFCoptions>().left) & (room.GetComponent<WFCoptions>().right) &
                        (room.GetComponent<WFCoptions>().bottom) & (room.GetComponent<WFCoptions>().top))
                        {
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);   
                            currentRoom++;
                            break;
                        }
                        else if (breakCounter > 30){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                    }
                }
                Debug.Log("room: " + currentRoom);
                z = z + 67;
                currentRow++;
            }
            x = x + 67;
            currentRow = 0;
            currentColumn++;
        }
    }   
}

