using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerVis : MonoBehaviour
{
    [Header("몬스터")] public GameObject Monster;
    public bool PlayerIn;   // 플레이어가 해당 Room에 있는지

    private void Start() 
    {
        Monster.SetActive(false);   // 몬스터 비가시화
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            // 플레이어가 해당 Room에 들어 왔을경우, 몬스터 가시화
            Monster.SetActive(true);
            PlayerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        // 플레이어가 해당 Room에 떠났을경우, 몬스터 비가시화
        Monster.SetActive(false);
        PlayerIn = false;
    }
}
