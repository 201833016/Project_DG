using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    
    private void Awake() {
        instance = this;
    }
    public List<Item> itemDB = new List<Item>();

    public GameObject dropItemPrefab;

    public void DropItemPos(Vector3 itemPosition)
    {
        // 몬스터의 좌표를 가져옴, 몬스터 사망시
        GameObject go = Instantiate(dropItemPrefab, itemPosition, Quaternion.identity);
        go.GetComponent<DropItems>().SetItem(itemDB[Random.Range(0,3)]);

    }
}
