using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;

    private void Start()
    {
        Invoke("DestroyBullet", 2f); // 총알 유지 시간 2초
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if(ray.collider != null)
        {
            if(ray.collider.tag == "Monster")
            {
                // Debug.Log("몬스터 명중");
                ray.collider.GetComponent<MonsterMove>().TakeDamaged(1);
            }
            else if(ray.collider.tag == "FarEnemy")
            {
                ray.collider.GetComponent<MonsterShooting>().LongTakeDamaged(1);
            }
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
