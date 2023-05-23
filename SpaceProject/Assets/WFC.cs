using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class WFC : MonoBehaviour
{
    [SerializeField] public GameObject[] rooms;
    [SerializeField] Transform  canvas;
    [SerializeField] public int width;
    [SerializeField] public int height;
    // Start is called before the first frame update
    void Start()
    //DODAĆ: Przypadki w rogach
    {        
        int x = 0;
        GameObject[] instantiatedRooms = new GameObject[width * height];
        
        int currentRoom = 0;
        int roomsInColumn  = height / 20;
        int roomsInRow = width / 20;
        while (x < width)
        {
            int z = 0;
            while (z < height)
            {   
                int breakCounter = 0;
                int currentRow = Mathf.RoundToInt(currentRoom / roomsInColumn);
                int currentColumn = currentRoom % roomsInColumn;
                while(true){
                    breakCounter++;
                    int random = Random.Range(0, rooms.Length);
                    GameObject room = rooms[random];
                    // pierwsza kolumna
                    if (currentRoom < roomsInColumn){
                        if (currentRoom == 0){
                            room = rooms[0];
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                        }
                        else if ((instantiatedRooms[currentRoom - 1].GetComponent<WFCoptions>().bottom == room.GetComponent<WFCoptions>().top)
                        & (room.GetComponent<WFCoptions>().left == false)){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                        }
                        else if (breakCounter > 20){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                        }

                    }
                    // pierwszy rząd
                    else if (currentRoom == roomsInColumn * currentRow){
                         if ((instantiatedRooms[currentRoom - roomsInColumn].GetComponent<WFCoptions>().left == room.GetComponent<WFCoptions>().right)
                         & (room.GetComponent<WFCoptions>().bottom == false)){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                         else if (breakCounter > 20){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                    }
                                        // ostatnia kolumna
                    else if (currentColumn == roomsInRow-1){
                        if (room.GetComponent<WFCoptions>().top == false){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                         else if (breakCounter > 20){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                    }
                    // ostatni rząd
                    else if (currentRow == roomsInColumn-1){
                        if (room.GetComponent<WFCoptions>().right == false){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                        
                         }
                         else if (breakCounter > 20){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }     
                    }
                    // kolejne kolumny - kolejne rzędy
                    else{
                        if ((instantiatedRooms[currentRoom - roomsInColumn].GetComponent<WFCoptions>().right == room.GetComponent<WFCoptions>().left)
                        & (instantiatedRooms[currentRoom - 1].GetComponent<WFCoptions>().top == room.GetComponent<WFCoptions>().bottom))
                        {
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                        }
                        else if (breakCounter > 20){
                            instantiatedRooms[currentRoom] = Instantiate(room, new Vector3(x, 0, z), Quaternion.identity * room.transform.localRotation, parent: canvas);
                            currentRoom++;
                            break;
                         }
                    }
                }
                z = z + 20;
            }
            x = x + 20;
        }
    }       
}

