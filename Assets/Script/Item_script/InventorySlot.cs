using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //�κ��丮 �� �ִ� ������ ������ ������ ���� ��ũ��Ʈ

    //public Image icon;
    private Button button;
    
    private void Start()
    {
        button = GetComponent<Button>();
        ImgInactive();
        button.interactable = false;            //�������� ���� ��� ��ư�� ��Ȱ��ȭ
    }

    public void Additem()
    {
        if(button.interactable == false)
        {
            StartCoroutine(AdditemCoroutine());
        }
    }
    IEnumerator AdditemCoroutine()            //������ ��ư Ȱ��ȭ �� ����� ������
    {
        //icon.sprite = _item.itemIcon;             ���� �������� �κ��丮�� ���������� ǥ�õǵ��� ����� �Ѱǵ� �� ������
        yield return new WaitForSeconds(0.01f);     
        button.interactable = true;                 //�ڽŹ�ư Ȱ��ȭ(��ư�� �����⵵ ���� ���� �����Ϸ� �ؼ� 0.01���� �����̸� ����)
        ImgActivation();                            //���� ������ ���� ����
    }



    public void ImgInactive()          //�������� ó�� ��Ȱ��ȭ�� ������ �������� ����
    {
        foreach (Transform child in transform)   // �ڽ� ������Ʈ���� Image ������Ʈ�� ������
        {
            Image img = child.GetComponent<Image>();

            if (img != null)
            {
                img.color = Color.gray;                 //������ ȸ������ ����
            }
        }
    }
    
    public void ImgActivation()
    {
        foreach (Transform child in transform)   // �ڽ� ������Ʈ���� Image ������Ʈ�� ������
        {
            Image img = child.GetComponent<Image>();

            if (img != null)
            {
                img.color = Color.white;                 //������ ������� ����
            }
        }
    }


    /* ������ ������ �����ϰ� �����ϴ°ǵ� �� ���� ��
      public void RemoveItem()
    {
        icon.sprite = Resources.Load("UI/Add Icon", typeof(Sprite)) as Sprite;      //�⺻ ���������� ����
    }
     */
}
