using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UnderBar : MonoBehaviour
{

    public Button Button_1 ; //�������ͽ� ȭ�� on��ư
    public Button Button_2 ; 
    public Button Button_3 ;    
    public Button Button_4 ;

    public GameObject Ui_1; //�������ͽ� ȭ��
    public GameObject Ui_2;
    public GameObject Ui_3; //���� ȭ��
    public GameObject Ui_4;

    public GameObject EnUi_1; //Item_enforce_area
    public GameObject EnUi_2; //boss_scroll_area

    public Animator Animator_1;
    public Animator Animator_2;
    public Animator Animator_3;
    public Animator Animator_4;

    private void Start()
    {
        OnClickButton_1();

        Button_1.onClick.AddListener(OnClickButton_1);   //1�� ��ư Ŭ���� �������ͽ� ȭ�� on �� �ٸ� ȭ��� off
        Button_2.onClick.AddListener(OnClickButton_2);
        Button_3.onClick.AddListener(OnClickButton_3);
        Button_4.onClick.AddListener(OnClickButton_4);
    }

    public void OnClickButton_1() 
    {
        ButtonReset();
        Button_1.GetComponent<Image>().color = new Color32(80, 255, 80, 255); //�ʷϻ�

        Animator_1.SetBool("click", true);    //Ǯ�� �ִϸ��̼�

        Ui_1.SetActive(true);
        Ui_2.SetActive(false);
        Ui_3.SetActive(false);
        Ui_4.SetActive(false);

        EnUi_1.SetActive(false);
        EnUi_2.SetActive(false);
    }

    public void OnClickButton_2()
    {
        ButtonReset();
        Button_2.GetComponent<Image>().color = new Color32(130, 200, 255, 255); //�ϴû�

        Animator_2.SetBool("click", true);

        Ui_1.SetActive(false);
        Ui_2.SetActive(true);
        Ui_3.SetActive(false);
        Ui_4.SetActive(false);

        EnUi_1.SetActive(true);
        EnUi_2.SetActive(false);
    }

    public void OnClickButton_3()
    {
        ButtonReset();
        Button_3.GetComponent<Image>().color = new Color32(220, 130, 255, 255); //�����

        Animator_3.SetBool("click", true);

        Ui_1.SetActive(false);
        Ui_2.SetActive(false);
        Ui_3.SetActive(true);
        Ui_4.SetActive(false);

        EnUi_1.SetActive(false);
        EnUi_2.SetActive(true);
    }

    public void OnClickButton_4()
    {
        ButtonReset();
        //Button_4.GetComponent<Image>().color = new Color32(220, 130, 255, 255); //�����

        //Animator_4.SetBool("click", true);

        Ui_1.SetActive(false);
        Ui_2.SetActive(false);
        Ui_3.SetActive(false);
        Ui_4.SetActive(true);

        EnUi_1.SetActive(false);
        EnUi_2.SetActive(false);
    }

    private void ButtonReset() //��ư �� �ʱ�ȭ
    {
        Button_1.GetComponent<Image>().color = Color.white;
        Button_2.GetComponent<Image>().color = Color.white;
        Button_3.GetComponent<Image>().color = Color.white;
        Button_4.GetComponent<Image>().color = Color.white;

        Animator_1.SetBool("click", false);    //Ǯ�� �ִϸ��̼�
        Animator_2.SetBool("click", false);    //������ �ִϸ��̼�
        Animator_3.SetBool("click", false);    //���� �ִϸ��̼�
        //Animator_4.SetBool("click", false);    

    }
}
