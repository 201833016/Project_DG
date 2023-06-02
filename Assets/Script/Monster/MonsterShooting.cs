using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    public float HP = 3f;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() 
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 12)
        {
            timer += Time.deltaTime;
            if(timer > 2)
            {
                timer = 0;
                Shoot();
            }  
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    public void LongTakeDamaged(float damage)
    {
        // 몬스터가 공격을 받을 시
        HP -= damage;
        if(HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Debug.Log("몬스터 처치");
        Destroy(this.gameObject);
    }
}
