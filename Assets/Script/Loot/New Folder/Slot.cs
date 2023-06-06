using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
   public Item item;
   public Image itemIcon;  // 인벤토리 UI에 넣을 이미지 

   public void UpdateSlotUI() // 아이템 추가시 활성화
   {
    itemIcon.sprite = item.itemImage;
    itemIcon.gameObject.SetActive(true);
   }

   public void RemoveSlot()   // 아이템 삭제시 비활성화
   {
    item = null;
    itemIcon.gameObject.SetActive(false);
   }
}
