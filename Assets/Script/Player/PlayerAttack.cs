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
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;    // 마우스 좌표값을 월드 좌표로 변경 , 그후 플레이어 좌표 감산
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;    // 파티고라스 공식, 대각선 각도 구하기
        transform.rotation = Quaternion.Euler(0,0,z);   // 계산한 각도 가져와서, 초기화

        if(curtime <= 0)    // 총알 발사 쿨타임이 아니면
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
