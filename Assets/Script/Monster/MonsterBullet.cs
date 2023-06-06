using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rigid;


    public float force;
    private float timer;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rigid.velocity = new Vector2(direction.x, direction.y).normalized * force;
        
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot + 90);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5)
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
