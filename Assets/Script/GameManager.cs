using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Inventory inven;
    public GameObject menuSet;  // ESC 서브 메뉴 여는 키
    public GameObject invenPanel;   // 인벤토리 UI
    public Slot[] slots;    // 인벤토리용 배열 변수 선언
    public Transform slotHolder;    // 인벤 갯수 증가 변수


   public int totalScore = 0;   // 총점수
   public int playScore = 0;    // 현재 점수
   public int stageIndex;   // 현재 스테이지 위치

   public float playerHP = 3f;  // 현재 Player 체력
   public float playerAtk = 1f; // 현재 Player 공격력

   public PlayerMove player;
   public Text text;

    void Start() 
    {
        inven = Inventory.instance; // 인벤토리 초기화
        slots = slotHolder.GetComponentsInChildren<Slot>(); // 프리팹 Slot의 자식 오브젝트 가져오기
        inven.onSlotCountChange += SlotChange;  // 참조할 SlotChange 메서드 정의
        inven.onchangeItem += RedrawSlotUI;

        menuSet.SetActive(false); 
        invenPanel.SetActive(false);
        SetScoreText();
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i< slots.Length; i++)    // 초기 갯수 만큼만 활성화
        {
            if(i<inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;    // 설정 갯수 내는 활성화
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;   // 설정 갯수 외는 비활성화
            }
        }
    }

    void Update()
    {
        // ESC
        if(Input.GetButtonDown("Cancel"))   
        {
            // ESC키 입력시
            if(menuSet.activeSelf)
            {
                // 서브 메뉴가 켜져있으면
                menuSet.SetActive(false);
                invenPanel.SetActive(false);
                Time.timeScale = 1f;    // 일시정지 해제
            }
            else
            {
                // 서브 메뉴가 없었으면 
                menuSet.SetActive(true);
                invenPanel.SetActive(true);
                Time.timeScale = 0; // 일시정지
            }
        }
    }

    public void GameStay()
    {
        menuSet.SetActive(false);       // 서브 메뉴 비활성화
        invenPanel.SetActive(false);    // 인벤토리 비활성화
        Time.timeScale = 1f;    // 일시정지 해제
        
    }
    public void GameExit()  // 시작 화면 Scene으로 돌아가기
    {
        LoadingControllor.Instance.LoadScene("FirstScene");
    }

    public void GameEnd() // 게임을 종료하기
    {
        Application.Quit();
    }

    public void AddSlot()   // 슬롯 증가
    {
        inven.SlotCnt++;
    }

    void RedrawSlotUI() // 슬롯 초기화
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for(int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i]; // 아이템 갯수 만큼
            slots[i].UpdateSlotUI();        // 슬롯 추가
        }
    }

    private void SetScoreText()
    {
        text.text = "Score: " + playScore.ToString();   // 현재 스코어 업데이트
    }

    public void PlayerHPDown(float damaged)   //Player 피격시
    {
        playerHP -= damaged;
        // 피격 애니메이션 추가
        if(playerHP <= 0)
        {
            PlayerDie();
        }
    }

    public void PlayerDie() //Player 사망시
    {
        // 다운 에니메이션 추가
        // 점수 표기 추가
    }

    public void MonsterScore(int newScore)  // 몬스터 처치시 점수 추가
    {
        playScore += newScore;
        SetScoreText();
    }
}
