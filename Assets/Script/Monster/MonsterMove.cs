using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    
    Rigidbody2D rb;
    Transform targetPlayer; // 목표 Player 위치

    [Header("이동 속도")]
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 3f;  // 몬스터 이동속도

    [Header("근접 거리")]
    [SerializeField] [Range(0f, 3f)] float playerDistance = 1f;    // 몬스터의 Player의 거리

    public float monsterHP = 3f;
    public float monsterMaxhp = 3f;
    private bool follow = false;
    GameManager gameManager;
    
    
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        monsterHP = monsterMaxhp;
    }

    private void Update() {
        FollowTarget();
        rb.velocity = Vector3.zero; // 플레이어에게 밀림 방지
    }

    void FollowTarget()
    {
        if(Vector2.Distance(transform.position, targetPlayer.position) > playerDistance && (follow = true)) // Player와의 거리 > 좌표 1 차이
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);    // 몬스터 위치이동
        }
        else
        {
            rb.velocity = Vector2.zero; // 몬스터 멈춤
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // 플레이어가 몬스터의 인지거리에 닿으면
        follow = true;   
    }

    private void OnTriggerExit2D(Collider2D other) {
        follow = false;
    }

    public void TakeDamaged(float damageAmount)
    {
        // 몬스터가 공격을 받을 시
        monsterHP -= damageAmount;
        if(monsterHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {    
        GetComponent<LootBag>().InstantiateLoot(transform.position);    // 드랍 테이블에서 아이템 드롭
        Debug.Log("몬스터 처치");
        Destroy(gameObject);    //  몬스터 처치후 파괴
        gameManager.MonsterScore(100);  // 점수는 100점
    }

    
}
