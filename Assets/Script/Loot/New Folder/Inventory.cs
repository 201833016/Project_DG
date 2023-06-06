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
   // 인벤토리 싱글톤

   public delegate void OnSlotCountChange(int val); // slotCnt의 개수 변경 대리자
   public OnSlotCountChange onSlotCountChange; 

   public delegate void OnChangeItem(); // 아이템 추가성공시 ,UI추가 대리자
   public OnChangeItem onchangeItem;

   public List<Item>items = new List<Item>();  // 플레이어가 획득한 아이템 담을 List 
   private int slotCnt; // 슬롯의 갯수.
   public int SlotCnt
   {
    get => slotCnt;
    set{
        slotCnt = value;
        onSlotCountChange.Invoke(slotCnt);  // 대리자 호출
    }
   }

   private void Start() 
   {
        SlotCnt = 5;    // 초기 제공 인벤토리 칸
   }

   public bool AddItem(Item _item)  // 아이템 List에 추가 메서드
   {
        if(items.Count < SlotCnt)   // 현재 슬롯 보다 적을때, 인벤토리 슬롯 여유 있을때
        {
            items.Add(_item);
            if(onchangeItem != null)
            {
                onchangeItem.Invoke();
            }
            return true;
        }
        return false;
   }

   private void OnTriggerEnter2D(Collider2D other) // 드롭 아이템과 플레이어 충돌시
   {
        if(other.CompareTag("Dropitem")) // 드롭 아이템과 충돌 시
        {
            DropItems dropItems = other.GetComponent<DropItems>();  // 드롭 아이템 정보 가져옴
            if(AddItem(dropItems.GetItem()))    // 아이템 추가 성공시 
            {
                dropItems.DestroyItem();        // 필드에 아이템 파괴
            }
        }
   }
}
