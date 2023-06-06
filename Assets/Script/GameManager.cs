using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    Inventory inven;
    public GameObject menuSet;  // ESC 서브 메뉴 여는 키
    public GameObject invenPanel;   // 인벤토리
    public Slot[] slots;
    public Transform slotHolder;


   public int totalScore = 0;   // 총점수
   public int playScore = 0;    // 현재 점수
   public int stageIndex;   // 현재 스테이지 위치

   public float playerHP = 3f;  // 현재 Player 체력
   public float playerAtk = 1f; // 현재 Player 공격력

   public PlayerMove player;
   public Text text;

    void Start() 
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onchangeItem += RedrawSlotUI;

        menuSet.SetActive(false); 
        invenPanel.SetActive(false);
        SetScoreText();
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i< slots.Length; i++)
        {
            if(i<inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
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

    public void GameExit()  // 시작 화면 Scene으로 돌아가기
    {
        
    }

    public void GameEnd() // 게임을 종료하기
    {
        Application.Quit();
    }

    public void AddSlot()
    {
        inven.SlotCnt++;
    }

    void RedrawSlotUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for(int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }

    private void SetScoreText()
    {
        text.text = "Score: " + playScore.ToString();
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

    public void MonsterScore(int newScore)
    {
        playScore += newScore;
        SetScoreText();
    }
}
