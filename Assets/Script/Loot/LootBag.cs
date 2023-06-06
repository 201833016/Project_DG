using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();  

    
    private void Start() 
    {
        
    }

    Loot GetDroppedItem()
    {
        int randomnum = Random.Range(1, 101);   // 1 - 100
        List<Loot> possibleItem = new List<Loot>();

        foreach(Loot item in lootList)
        {
            if(randomnum <= item.dropChance)
            {
                possibleItem.Add(item);
            }
        }
        if(possibleItem.Count > 0)
        {
            Loot droppedItem = possibleItem[Random.Range(0, possibleItem.Count)];
            return droppedItem;
        }
        Debug.Log("드랍되지 않음");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if(droppedItem != null)
        {
            //GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            //lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.loopSprite;

            ItemManager.instance.DropItemPos(spawnPosition);

            //float dropForce = 300f;
            //Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            //lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);

        }
    }
}
