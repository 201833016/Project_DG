using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance; // 다른 class에서 접근하기 위한 인스턴스
    
    private void Awake() {
        instance = this;
    }
    public List<Item> itemDB = new List<Item>();    // 아이템 종류 리스트

    public GameObject dropItemPrefab;   // 드롭 아이템 프리팹

    public void DropItemPos(Vector3 itemPosition)
    {
        GameObject go = Instantiate(dropItemPrefab, itemPosition, Quaternion.identity); // 몬스터 사망시, 해당 좌표에 아이템 드롭
        go.GetComponent<DropItems>().SetItem(itemDB[Random.Range(0,3)]);    // 아이템 3개중 랜덤으로 초기화

    }
}
