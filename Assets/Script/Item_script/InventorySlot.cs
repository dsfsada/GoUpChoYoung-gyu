using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //인벤토리 내 있는 슬롯의 아이콘 변경을 위한 스크립트

    //public Image icon;
    private Button button;
    
    private void Start()
    {
        button = GetComponent<Button>();
        ImgInactive();
        button.interactable = false;            //아이템이 없을 경우 버튼의 비활성화
    }

    public void Additem()
    {
        if(button.interactable == false)
        {
            StartCoroutine(AdditemCoroutine());
        }
    }
    IEnumerator AdditemCoroutine()            //아이템 버튼 활성화 시 잠깐의 딜레이
    {
        //icon.sprite = _item.itemIcon;             먹은 아이템이 인벤토리에 아이콘으로 표시되도록 만드려 한건데 필 없을듯
        yield return new WaitForSeconds(0.01f);     
        button.interactable = true;                 //자신버튼 활성화(버튼이 나오기도 전에 값을 참조하려 해서 0.01초의 딜레이를 줬음)
        ImgActivation();                            //하위 아이콘 색상 변경
    }



    public void ImgInactive()          //아이콘의 처음 비활성화의 색상을 검정으로 지정
    {
        foreach (Transform child in transform)   // 자식 오브젝트에서 Image 컴포넌트를 가져옴
        {
            Image img = child.GetComponent<Image>();

            if (img != null)
            {
                img.color = Color.gray;                 //색상을 회색으로 설정
            }
        }
    }
    
    public void ImgActivation()
    {
        foreach (Transform child in transform)   // 자식 오브젝트에서 Image 컴포넌트를 가져옴
        {
            Image img = child.GetComponent<Image>();

            if (img != null)
            {
                img.color = Color.white;                 //색상을 흰색으로 설정
            }
        }
    }


    /* 아이템 아이콘 제거하고 시작하는건데 필 없을 듯
      public void RemoveItem()
    {
        icon.sprite = Resources.Load("UI/Add Icon", typeof(Sprite)) as Sprite;      //기본 아이콘으로 변경
    }
     */
}
