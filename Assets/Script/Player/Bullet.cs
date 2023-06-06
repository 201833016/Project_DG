using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // 총알 속도
    public float distance;  // 총알의 ray 길이
    public LayerMask isLayer;   // layer 구분 (벽, 근거리 몬스터, 원거리 몬스터)

    GameManager gameManager;    

    float bulletDamage; // 총알 데미지
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   // 게임매니저 = Player의 공격력 가져오기
        Invoke("DestroyBullet", 2f); // 총알 유지 시간 2초 
    }

    void Update()
    {
        bulletDamage = gameManager.playerAtk;   // 총알 데미지 = 플레이어 공격력
        transform.Translate(Vector2.right * speed * Time.deltaTime);    // 총알 발사후 위치

        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if(ray.collider != null)    // raycast에 무언가 닿음녀
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

    void DestroyBullet()    // 총알이 닿으면 파괴
    {
        Destroy(gameObject);
    }
    
}
