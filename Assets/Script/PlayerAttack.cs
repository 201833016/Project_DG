using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;   // 발사체
    public Transform AttackPosition;    // 발사위치
    public float cooltime;  // 발사간격
    private float curtime;  // 현재 시간

    void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;    // 마우스 좌표값 월드 좌표
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,z); 

        if(curtime <= 0)
        {
            if(Input.GetKey(KeyCode.Z))
            {
                Instantiate(bullet, AttackPosition.position, transform.rotation);   // 마우스 좌표로 공격
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }


}
