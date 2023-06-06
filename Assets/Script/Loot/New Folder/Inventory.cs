using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   #region Singleton 
   public static Inventory instance;

   private void Awake() 
   {
    if(instance != null)
    {
        Destroy(gameObject);
        return;
    }
    instance = this;
   }
   #endregion

   public delegate void OnSlotCountChange(int val); // 슬롯 개수 변경 대리자
   public OnSlotCountChange onSlotCountChange; 

   public delegate void OnChangeItem();
   public OnChangeItem onchangeItem;

   public List<Item>items = new List<Item>();  // 아이템 담을 List 
   private int slotCnt; // 슬롯의 갯수.
   public int SlotCnt
   {
    get => slotCnt;
    set{
        slotCnt = value;
        onSlotCountChange.Invoke(slotCnt);
    }
   }

   private void Start() 
   {
        SlotCnt = 5;    // 초기 제공 인벤토리 칸
   }

   public bool AddItem(Item _item)
   {
        if(items.Count < SlotCnt)   // 현재 슬롯 보다 적을때
        {
            items.Add(_item);
            if(onchangeItem != null)
            onchangeItem.Invoke();
            return true;
        }
        return false;
   }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.CompareTag("Dropitem")) 
        {
            DropItems dropItems = other.GetComponent<DropItems>();
            if(AddItem(dropItems.GetItem()))
            {
                dropItems.DestroyItem();
            }
        }
   }
}
