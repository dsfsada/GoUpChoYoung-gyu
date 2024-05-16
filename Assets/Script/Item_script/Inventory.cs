using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

//인벤토리 내 슬롯의 아이템 저장
public class Inventory : MonoBehaviour
{
    
    public static Inventory Instance;
    
    public Transform tf;                     //slot의 부모객체

    public InventorySlot[] slots;           //인벤토리 슬롯들
    private List<Item> inventoryItemList;
    

    void Start()
    {
        Instance = this;                                         //외부에서 인벤토리 스크립트를 쉽게 참조하게 만들기 위한 코드
        inventoryItemList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();     //tf의 하위 슬롯들이 다 slots의 배열로 저장

    }


    public void ItemLcation(int _kind, int _num)
    {
        int number = _kind*4 + _num;

        if (GameObject.Find("Underbar").GetComponent<UnderBar>().Ui_2.activeSelf)
        {
            if (slots[number] != null)
            {
                slots[number].Additem();                      //아이템 리스트의 있는 아이템 추가
            }
        }

    }


    public void GetAnItem(int _itemId)  //아이템을 습득할 경우(itemPickup 스크립트 참조)
    {
        for (int i = 0; i < Statuse.itemList.Count; i++)                    //스테이터스 스크립트에서 정의해둔 아이템(아티팩트)의 개수만큼 반복
        {
            if (_itemId == Statuse.itemList[i].itemId)                      //아이템 id와 정의해둔 id 같으면 true
            {
                if (inventoryItemList.Count != 0)                           //인벤토리의 아무 값도 없을 경우 오류가 발생하여 만든 if문
                {
                    for (int j = 0; j < inventoryItemList.Count; j++)       //인벤의 들어있는 아이템 개수만큼 반복
                    {
                        if (inventoryItemList[j].itemId == _itemId)         //소지하고 있는 아이템을 먹을경우 그냥 반환
                        {
                            return;
                        }
                    }
                }
                inventoryItemList.Add(Statuse.itemList[i]);                 //먹은 아이템의 id와 같은 아이템을 인벤토리에 추가
                return; // 아이템을 추가한 후 바로 함수를 종료합니다.
            }
        }
        Debug.LogError("해당 id의 아이템을 찾지못함");
    }
}