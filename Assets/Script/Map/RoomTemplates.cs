using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    // 해당 위치로 연결 가능한 방 배열 변수 선언
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;  // 생성되는 Rooms의 리스트

    // 보스 몬스터 위치
    public float waitTime;  // 보스 출현까지의 시간
    private bool spawnedBoss;   // 보스 출현 여부
    public GameObject boss;

    void Update() 
    {

        if(waitTime <= 0 && spawnedBoss == false)   
        {
            Instantiate(boss, rooms[rooms.Count -1].transform.position, Quaternion.identity);    // 보스 생성
            spawnedBoss = true; // 보스 풀현 확인
        }
        else    // 보스가 출현하지 않았으면
        {
            waitTime -= Time.deltaTime;
        }
    }
}
