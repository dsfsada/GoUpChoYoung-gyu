using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

//�κ��丮 �� ������ ������ ����
public class Inventory : MonoBehaviour
{
    
    public static Inventory Instance;
    
    public Transform tf;                     //slot�� �θ�ü

    public InventorySlot[] slots;           //�κ��丮 ���Ե�
    private List<Item> inventoryItemList;
    

    void Start()
    {
        Instance = this;                                         //�ܺο��� �κ��丮 ��ũ��Ʈ�� ���� �����ϰ� ����� ���� �ڵ�
        inventoryItemList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();     //tf�� ���� ���Ե��� �� slots�� �迭�� ����

    }


    public void ItemLcation(int _kind, int _num)
    {
        int number = _kind*4 + _num;

        if (GameObject.Find("Underbar").GetComponent<UnderBar>().Ui_2.activeSelf)
        {
            if (slots[number] != null)
            {
                slots[number].Additem();                      //������ ����Ʈ�� �ִ� ������ �߰�
            }
        }

    }


    public void GetAnItem(int _itemId)  //�������� ������ ���(itemPickup ��ũ��Ʈ ����)
    {
        for (int i = 0; i < Statuse.itemList.Count; i++)                    //�������ͽ� ��ũ��Ʈ���� �����ص� ������(��Ƽ��Ʈ)�� ������ŭ �ݺ�
        {
            if (_itemId == Statuse.itemList[i].itemId)                      //������ id�� �����ص� id ������ true
            {
                if (inventoryItemList.Count != 0)                           //�κ��丮�� �ƹ� ���� ���� ��� ������ �߻��Ͽ� ���� if��
                {
                    for (int j = 0; j < inventoryItemList.Count; j++)       //�κ��� ����ִ� ������ ������ŭ �ݺ�
                    {
                        if (inventoryItemList[j].itemId == _itemId)         //�����ϰ� �ִ� �������� ������� �׳� ��ȯ
                        {
                            return;
                        }
                    }
                }
                inventoryItemList.Add(Statuse.itemList[i]);                 //���� �������� id�� ���� �������� �κ��丮�� �߰�
                return; // �������� �߰��� �� �ٷ� �Լ��� �����մϴ�.
            }
        }
        Debug.LogError("�ش� id�� �������� ã������");
    }
}