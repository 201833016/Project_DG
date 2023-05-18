using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject menuSet;  // ESC 서브 메뉴 여는 키


    void Awake() 
    {
        menuSet.SetActive(false);  
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            // ESC키 입력시
            if(menuSet.activeSelf)
            {
                // 서브 메뉴가 켜져있으면
                menuSet.SetActive(false);
                Time.timeScale = 1f;    // 일시정지 해제
            }
            else
            {
                // 서브 메뉴가 없었으면 
                menuSet.SetActive(true);
                Time.timeScale = 0; // 일시정지
            }
        }
    }

    public void GameExit()
    {
        // 시작 화면 Scene으로 돌아가기
    }

    public void GameEnd()
    {
        // 게임을 종료하기
        Application.Quit();
    }
}
