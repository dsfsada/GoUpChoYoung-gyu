using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    //아이템 생성

    public int itemId;
    public string itemName;
    public Sprite itemIcon;
    public ItemType itemType;

    public enum ItemType            //아이템 타입
    {
        Artifact

    }

    public Item(int _itemId, string _itemName, ItemType _itemType) //생성자를 이용해 외부 스크립트에서 아이템을 제작한다.(statuse 참조)
    {
        itemId = _itemId;
        itemName = _itemName;
        itemType = _itemType;
        itemIcon = Resources.Load("ItemIcon/" + itemId.ToString(), typeof(Sprite)) as Sprite;    //스프라이트로 icon을 가져옴

    }
}
