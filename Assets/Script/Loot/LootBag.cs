using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;    // 드랍 아이템 프리팹
    public List<Loot> lootList = new List<Loot>();  // 드랍 아이템 리스트

    Loot GetDroppedItem()
    {
        int randomnum = Random.Range(1, 101);   // 1 - 100, 아이템 드랍을 위한 수치
        List<Loot> possibleItem = new List<Loot>(); // 드랍된 아이템 체크 리스트

        foreach(Loot item in lootList)  // 아이템 리스트 확인 반복
        {
            if(randomnum <= item.dropChance)    // 랜덤수치가 드랍률보다 낮으면
            {
                possibleItem.Add(item); // 아이템 드랍
            }
        }
        if(possibleItem.Count > 0)
        {
            Loot droppedItem = possibleItem[Random.Range(0, possibleItem.Count)];   // 아이템 리스트 중에서 랜덤 드랍
            return droppedItem;
        }
        Debug.Log("드랍되지 않음");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if(droppedItem != null) // 아이템 드랍이 일어난 경우
        {
            //GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            //lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.loopSprite;

            ItemManager.instance.DropItemPos(spawnPosition);    // 몬스터 사망 좌표에 아이템 생성

            //float dropForce = 300f;
            //Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            //lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);

        }
    }
}
