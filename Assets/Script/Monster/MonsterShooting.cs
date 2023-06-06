using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooting : MonoBehaviour
{
    public GameObject bullet;   // 총알 오브젝트
    public Transform bulletPos; // 총알 발사 위치

    private float timer;    // 총알 발사 쿨타임
    private GameObject player;
    public float monsterHP = 3f;
    private GameManager gameManager;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update() 
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);   // Player와 발사대의 거리  

        if(distance < 15)   
        {
            timer += Time.deltaTime;
            if(timer > 2)   // 총알 발사 쿨타임 2초
            {
                timer = 0;
                Shoot();
            }  
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);   // 총알 clone생성 (이미지, 발사위치, 회전)
    }

    public void LongTakeDamaged(float damage)
    {
        // 원거리 몬스터가 공격을 받을 시
        monsterHP -= damage;
        if(monsterHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);    // 드랍 테이블에서 아이템 드롭
        Debug.Log("원거리 몬스터 처치");
        Destroy(this.gameObject);   //  몬스터 처치후 파괴
        gameManager.MonsterScore(200);  // 점수는 200점
    }
}
