using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxOpen : MonoBehaviour
{
    private ChatSentence chatsentence;
    public GameObject player;
    Animator anim;              // 상자 애니메이션
    public bool isPlayerEnter = false;  // 플레이어 접근 확인

    private MonsterCount monstercnt;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

        isPlayerEnter = false;
    }

    private void Update() 
    {
        if(isPlayerEnter == true && Input.GetKeyDown(KeyCode.E))
        {
            // 상자를 여는 애니메이션 실행을 위한 trigger 선언
            anim.SetBool("isOpen",true);
            Invoke("DestroyBox", 2f);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        // 상자 범위내에 Player가 오면
        isPlayerEnter = true;
    }
    
    private void OnTriggerExit2D(Collider2D other) 
    {
        // 상자 범위를 Player가 벗어나면
        isPlayerEnter = false;
    }

    private void DestroyBox()
    {
        Destroy(gameObject);  // itemBox를 true하는데서 오류남
    }
}
