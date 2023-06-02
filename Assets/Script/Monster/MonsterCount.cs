using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCount : MonoBehaviour
{
    [Header("아이템 상자 ")]
    public GameObject itemBox;

    [Header("포탈 ")]
    public GameObject mapPotal;

    //public GameObject monster;

    //private MapPlayerVis playerVis;

    void Awake()
    {
        // 시작시 오브젝트 비활성화 
        itemBox.SetActive(false);
        mapPotal.SetActive(false);
        /*
        if(playerVis.PlayerIn)
        {
            
        }
        */
    }

    private void Update() 
    {
        if(this.transform.childCount == 0)  // 몬스터를 다 해치웠을 경우
        {
            itemBox.SetActive(true);    // 아이템 상자 활성화
            mapPotal.SetActive(true);  // 이동 포탈 활성화
        }        
    }

}
