using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UnderBar : MonoBehaviour
{

    public Button Button_1 ; //스테이터스 화면 on버튼
    public Button Button_2 ; 
    public Button Button_3 ;    
    public Button Button_4 ;

    public GameObject Ui_1; //스테이터스 화면
    public GameObject Ui_2;
    public GameObject Ui_3; //보스 화면
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

        Button_1.onClick.AddListener(OnClickButton_1);   //1번 버튼 클릭시 스테이터스 화면 on 및 다른 화면들 off
        Button_2.onClick.AddListener(OnClickButton_2);
        Button_3.onClick.AddListener(OnClickButton_3);
        Button_4.onClick.AddListener(OnClickButton_4);
    }

    public void OnClickButton_1() 
    {
        ButtonReset();
        Button_1.GetComponent<Image>().color = new Color32(80, 255, 80, 255); //초록색

        Animator_1.SetBool("click", true);    //풀잎 애니메이션

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
        Button_2.GetComponent<Image>().color = new Color32(130, 200, 255, 255); //하늘색

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
        Button_3.GetComponent<Image>().color = new Color32(220, 130, 255, 255); //보라색

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
        //Button_4.GetComponent<Image>().color = new Color32(220, 130, 255, 255); //보라색

        //Animator_4.SetBool("click", true);

        Ui_1.SetActive(false);
        Ui_2.SetActive(false);
        Ui_3.SetActive(false);
        Ui_4.SetActive(true);

        EnUi_1.SetActive(false);
        EnUi_2.SetActive(false);
    }

    private void ButtonReset() //버튼 색 초기화
    {
        Button_1.GetComponent<Image>().color = Color.white;
        Button_2.GetComponent<Image>().color = Color.white;
        Button_3.GetComponent<Image>().color = Color.white;
        Button_4.GetComponent<Image>().color = Color.white;

        Animator_1.SetBool("click", false);    //풀잎 애니메이션
        Animator_2.SetBool("click", false);    //아이템 애니메이션
        Animator_3.SetBool("click", false);    //보스 애니메이션
        //Animator_4.SetBool("click", false);    

    }
}
