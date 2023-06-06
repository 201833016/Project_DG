using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,  // 장비
    HP,         // HP관련
    Portion,    // 회복
    Etc         // 기타 등등
}

[System.Serializable]   // 클래스 직렬화
public class Item 
{
    public ItemType itemType;   // 아이템 분류
    public string itemName;     // 아이템 이름
    public Sprite itemImage;    // 아이템 이미지

    public bool Use()
    {
        return false;   // 아이템 사용 여부 확인
    }

}