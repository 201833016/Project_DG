using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public int openingDirection;
    // 1 = 아래, 2 = 위, 3 = 좌측, 4 = 우측

    private RoomTemplates templates;    // 방 연결 변수
    private int rand;   // 랜덤을 위한 변수
    public bool spawned = false;

    public bool playerVisible = true;
    public float waitTime = 4f;

    void Start() 
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();   
        Invoke("Spawn", 0.1f);  // 0.1초 단위로 생성
    }
    void Spawn() 
    {
        if(spawned == false)
        {
            if(openingDirection == 1)
            {
                // 아래 방 연결
                rand = Random.Range(0, templates.bottomRooms.Length);   // 방연결이 가능한 배열 중 랜덤
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);   // 방 생성
            }
            else if(openingDirection == 2)
            {
                // 위 방 연결
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }   
            else if(openingDirection == 3)
            {
                // 왼쪽 방 연결
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }   
            else if(openingDirection == 4)
            {
                // 오른쪽 방 연결
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }   
            spawned = true;
            playerVisible = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("SpawnPoint"))  // Spawnpoint와 접촉시
        {
            if(other.GetComponent<RoomSpawn>().spawned == false && spawned == false)
            {
                // 끝부분에 벽이 막히는 방이 오도록
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                // player를 제외한 나머지만 지우게 하기
                Destroy(gameObject);                
            }
            spawned = true; // 방생성시 겹치지 않게
        }

        if(other.CompareTag("Player"))
        {
            playerVisible = true;
        }
    }

}
