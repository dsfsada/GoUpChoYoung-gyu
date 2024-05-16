using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    //������ ����

    public int itemId;
    public string itemName;
    public Sprite itemIcon;
    public ItemType itemType;

    public enum ItemType            //������ Ÿ��
    {
        Artifact

    }

    public Item(int _itemId, string _itemName, ItemType _itemType) //�����ڸ� �̿��� �ܺ� ��ũ��Ʈ���� �������� �����Ѵ�.(statuse ����)
    {
        itemId = _itemId;
        itemName = _itemName;
        itemType = _itemType;
        itemIcon = Resources.Load("ItemIcon/" + itemId.ToString(), typeof(Sprite)) as Sprite;    //��������Ʈ�� icon�� ������

    }
}
