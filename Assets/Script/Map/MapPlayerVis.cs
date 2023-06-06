using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerVis : MonoBehaviour
{
    [Header("몬스터")] public GameObject Monster;
    public bool PlayerIn = false;   // 플레이어가 해당 Room에 있는지
    public bool BossIn = false;

    MonsterCount monsterCount;


    private void Start() 
    {
        Monster.SetActive(false);   // 몬스터 비가시화
        monsterCount = GameObject.Find("Monster").GetComponent<MonsterCount>();
    }

    private void Update() {
        if(PlayerIn)
        {
            MonsterAppear();
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            // 플레이어가 해당 Room에 들어 왔을경우, 몬스터 가시화
            MonsterAppear();
        }

        if(other.CompareTag("Boss"))
        {
            monsterCount.itemBox.SetActive(false);
            monsterCount.mapPotal.SetActive(false);
            Monster.SetActive(false);
            
        }

    }

    private void MonsterAppear()
    {
        // 몬스터 가시화
        Monster.SetActive(true);
        PlayerIn = true;
    }

    private void OnTriggerExit2D(PlayerMove player) 
    {
        // 플레이어가 해당 Room에 떠났을경우, 몬스터 비가시화
        if(player.gameObject.CompareTag("Player"))
        {
            Monster.SetActive(false);
            PlayerIn = false;
        }

    }
}
