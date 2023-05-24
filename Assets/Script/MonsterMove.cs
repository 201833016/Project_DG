using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rb;
    Transform targetPlayer;

    [Header("이동 속도")]
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 3f;  // 이동속도

    [Header("근접 거리")]
    [SerializeField] [Range(0f, 3f)] float playerDistance = 1f;    // 인지거리

    public int HP = 3;

    private bool follow = false;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    private void Update() {
        FollowTarget();
        rb.velocity = Vector3.zero; // 플레이어에게 밀림 방지

        if(HP <= 0 )
        {
            Destroy(this.gameObject);
        }
    }

    void FollowTarget()
    {
        if(Vector2.Distance(transform.position, targetPlayer.position) > playerDistance && (follow = true))
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
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

    public void TakeDamaged(int damage)
    {
        // 몬스터가 공격을 받을 시
        HP = HP - damage;
    }
}
