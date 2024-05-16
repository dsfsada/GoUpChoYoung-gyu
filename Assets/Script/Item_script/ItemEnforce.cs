using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ui -> Item_enforce_area -> ���� ������Ʈ �����θ��� �ο��� ��ũ��Ʈ

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

    public Sprite mountedImage; //��� ������ �̹���
    public Sprite clearImage; //��� ������ �̹���

    public GameObject targetGameObject;


    void Start()
    {
        artifact = GameObject.Find("Statuse");
        isEquip = GameObject.Find("ArtifactE");

        updateText();
        equipEffect();  //�ѹ� ����

        upgradeButton.onClick.AddListener(OnButtonClick);
        mountingButton.onClick.AddListener(equipEffect);   
    }

    private void Update()
    {
        updateText();
        //equipEffect();
    }

    public void OnButtonClick()         //��ư Ŭ����
    {
        //kind�� ����� 0����, 1ü��, 2ũ���� ���� # num ���ι�ȣ��
        GameObject.Find("Statuse").GetComponent<Statuse>().upgradeItem(kind, num);
        updateText();
    }
    public void updateText()   //���׷��̵� â�� text�� ������Ʈ ����
    {
        enforceShameText.text = artifact.GetComponent<Statuse>().artifactsValues[kind, num].ToString() + " -> " + (artifact.GetComponent<Statuse>().artifactsValues[kind, num] + 1f).ToString();
        enforceNumbeText.text = "��ȭ [" + artifact.GetComponent<Statuse>().Levelitem[artifact.GetComponent<Statuse>().artifactsValues[kind, num]] +
                                                                                                "/" + artifact.GetComponent<Statuse>().artifactsNum[kind, num] + "]";
        //��ȭ [��ȭ�� �ʿ� �������� ���� / ���� �������� ����]
    }

    public void equipEffect()   //����, ���� 
    {
        Image imageComponent = targetGameObject.GetComponent<Image>();
        int number = kind * 4 + num;
        if(isEquip.GetComponent<artifacts>().isEquip[number] == 1)  //Ư�� ��ȣ(���� ������)�� ��������(1,0) 1�̸� ����on
        {
            imageComponent.sprite = mountedImage;   //���������� icon
            Mounting.text = "����";
        }
        else
        {
            imageComponent.sprite = clearImage; //���������� icon
            Mounting.text = "����";         
        }
    }
    

}
