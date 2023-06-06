using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public Item item;   // 아이템 개체
    public SpriteRenderer image;    // 아이템 이미지


    public void SetItem(Item _item) // 아이템 정보, 획득 아이템 정보로 초기화
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        image.sprite = item.itemImage;
    }



    public Item GetItem()   // 아이템 획득 메서드
    {
        return item;
    }

    public void DestroyItem()   // 필드의 아이템 파괴 메서드 
    {
        Destroy(gameObject);
    }
}
