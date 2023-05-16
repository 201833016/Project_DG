using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxOpen : MonoBehaviour
{
    public GameObject player;
    Animator anim;              // 상자 애니메이션
    public bool isPlayerEnter = false;  // 플레이어 접근 확인

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

        // isPlayerEnter = false;
    }

    /*
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Player가 상자와 가까이 았을 경우
        if(other.CompareTag("Player"))
        {   
            isPlayerEnter = true;
            anim.SetBool("isOpen",false);
        }
    }
    */

    private void OnTriggerStay2D(Collider2D other) 
    {
        isPlayerEnter = true;
        if(Input.GetKeyDown(KeyCode.E))
        {
            // 상자를 여는 애니메이션 실행을 위한 trigger 선언
            anim.SetBool("isOpen",true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) 
    {
        isPlayerEnter = false;
        /*
        // Player가 상자와 가까이 있지 않을 경우
        if(other.CompareTag("Player"))
        {
            isPlayerEnter = false;
            anim.SetBool("isOpen",false);
        }
        */
    }
}
