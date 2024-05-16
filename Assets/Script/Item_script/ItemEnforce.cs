using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ui -> Item_enforce_area -> 게임 오브젝트 개개인마다 부여할 스크립트

public class ItemEnforce : MonoBehaviour
{
    public int kind, num;

    public Text enforceShameText;
    public Text enforceNumbeText;
    public Text Mounting;

    private GameObject artifact;
    private GameObject isEquip;

    public Button upgradeButton;
    public Button mountingButton;

    public Sprite mountedImage; //장비 장착시 이미지
    public Sprite clearImage; //장비 해제시 이미지

    public GameObject targetGameObject;


    void Start()
    {
        artifact = GameObject.Find("Statuse");
        isEquip = GameObject.Find("ArtifactE");

        updateText();
        equipEffect();  //한번 실행

        upgradeButton.onClick.AddListener(OnButtonClick);
        mountingButton.onClick.AddListener(equipEffect);   
    }

    private void Update()
    {
        updateText();
        //equipEffect();
    }

    public void OnButtonClick()         //버튼 클릭시
    {
        //kind는 장비의 0공격, 1체력, 2크뎀을 선택 # num 세부번호들
        GameObject.Find("Statuse").GetComponent<Statuse>().upgradeItem(kind, num);
        updateText();
    }
    public void updateText()   //업그레이드 창의 text를 업데이트 해줌
    {
        enforceShameText.text = artifact.GetComponent<Statuse>().artifactsValues[kind, num].ToString() + " -> " + (artifact.GetComponent<Statuse>().artifactsValues[kind, num] + 1f).ToString();
        enforceNumbeText.text = "강화 [" + artifact.GetComponent<Statuse>().Levelitem[artifact.GetComponent<Statuse>().artifactsValues[kind, num]] +
                                                                                                "/" + artifact.GetComponent<Statuse>().artifactsNum[kind, num] + "]";
        //강화 [강화시 필요 아이템의 개수 / 현재 아이템의 개수]
    }

    public void equipEffect()   //장착, 해제 
    {
        Image imageComponent = targetGameObject.GetComponent<Image>();
        int number = kind * 4 + num;
        if(isEquip.GetComponent<artifacts>().isEquip[number] == 1)  //특정 번호(현재 아이템)의 장착여부(1,0) 1이면 장착on
        {
            imageComponent.sprite = mountedImage;   //장착상태의 icon
            Mounting.text = "해제";
        }
        else
        {
            imageComponent.sprite = clearImage; //해제상태의 icon
            Mounting.text = "장착";         
        }
    }
    

}
