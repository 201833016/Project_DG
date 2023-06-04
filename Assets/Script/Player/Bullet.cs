using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed;
    public float distance;
    public LayerMask isLayer;

    GameManager gameManager;

    float bulletDamage;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("DestroyBullet", 2f); // 총알 유지 시간 2초 
    }

    void Update()
    {
        bulletDamage = gameManager.playerAtk;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if(ray.collider != null)
        {
            if(ray.collider.tag == "Monster")   // 근거리 몬스터 공격
            {
                
                ray.collider.GetComponent<MonsterMove>().TakeDamaged(bulletDamage);
            }
            else if(ray.collider.tag == "FarEnemy") // 원거리 몬스터 공격
            {
                ray.collider.GetComponent<MonsterShooting>().LongTakeDamaged(bulletDamage);
            }
            else if(ray.collider.tag == "Boss") // 보스 몬스터 공격
            {
                ray.collider.GetComponent<Boss>().BossDamaged(bulletDamage);
            }
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
}
