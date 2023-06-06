using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D rb;

    public float bossHP = 5f;
    public float bossMaxhp = 5f;
    GameManager gameManager;

    public GameObject symbolPrefab; // 보스 처치시 등장하는 신상 프리팹
    Vector3 pos;    // 신상 위치

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pos = this.transform.position;
        bossHP = bossMaxhp;
    }

    private void Update() 
    {
        rb.velocity = Vector3.zero; // 플레이어에게 밀림 방지
    }

    public void BossDamaged(float damageAmount)
    {
        // 보스 몬스터가 공격을 받을 시
        bossHP -= damageAmount;
        if(bossHP <= 0)
        {
            BossDie();
        }
    }

    private void BossDie()
    {
        //GetComponent<LootBag>().InstantiateLoot(transform.position);
        Instantiate(symbolPrefab, pos, Quaternion.identity); // Symbol을 보스몬스터 위치에 소환    
        Debug.Log("보스 몬스터 처치.");
        Destroy(gameObject);
        gameManager.MonsterScore(1000);
    }
}
