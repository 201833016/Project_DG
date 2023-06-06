using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rigid;

    public float force;  // 총알 출력
    private float timer;    // 총알 유지 시간

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position; // 월드좌표에서의 플레이어 위치
        rigid.velocity = new Vector2(direction.x, direction.y).normalized * force;  // 총알 발사 방향
        
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;    // 총알 각도
        transform.rotation = Quaternion.Euler(0,0, rot + 90);   // 각도 초기화
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5)   // 총알 5초이상 유지 못하게
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("피격");
            // PLAYER 피 달기 코드 작성
            Destroy(gameObject);
        }
        else if(other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if(other.CompareTag("SpawnPoint"))
        {
            Debug.Log("SpawnPoint의 Destroy에 맞음.");

        }
    }
}
