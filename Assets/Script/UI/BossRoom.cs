using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRoom : MonoBehaviour
{
    public Button Button_1; //占쏙옙占쏙옙占쏙옙占싶쏙옙 화占쏙옙 on占쏙옙튼
    public Button Button_2;
    public Button Button_3;
    public Button Button_4;

    public GameObject Ui_1; //占쏙옙占쏙옙占쏙옙占싶쏙옙 화占쏙옙
    public GameObject Ui_2;
    public GameObject Ui_3; //占쏙옙占쏙옙 화占쏙옙
    public GameObject Ui_4;

    public Button EnterButtonGolem;
    public Button EnterButtonDeer;

    public GameObject BossEntrance;

    private void Start()
    {
        Ui_1.SetActive(false);
        Ui_2.SetActive(false);
        Ui_3.SetActive(false);
        Ui_4.SetActive(false);

        BossEntrance.SetActive(false); //占쏙옙占쏙옙 占쏙옙환占쏙옙 占쏙옙占쏙옙占쏙옙 占쏙옙占쏙옙 화占쏙옙

        Button_1.onClick.AddListener(OnClickButton_1);   //1占쏙옙 占쏙옙튼 클占쏙옙占쏙옙 占쏙옙占쏙옙占쏙옙占싶쏙옙 화占쏙옙 on 占쏙옙 占쌕몌옙 화占쏙옙占 off
        BossEntrance.SetActive(false); //보스 전환때 나오는 워링 화면

        Button_1.onClick.AddListener(OnClickButton_1);   //1번 버튼 클릭시 스테이터스 화면 on 및 다른 화면들 off
        Button_2.onClick.AddListener(OnClickButton_2);
        Button_3.onClick.AddListener(OnClickButton_3);
        Button_4.onClick.AddListener(OnClickButton_4);

        EnterButtonGolem.onClick.AddListener(OnClickButton_5);
        EnterButtonDeer.onClick.AddListener(OnClickButton_6);
    }

    public void OnClickButton_1()
    {
        Ui_1.SetActive(true);
        Ui_2.SetActive(false);
        Ui_3.SetActive(false);
        Ui_4.SetActive(false);
    }

    public void OnClickButton_2()
    {
        Ui_1.SetActive(false);
        Ui_2.SetActive(true);
        Ui_3.SetActive(false);
        Ui_4.SetActive(false);
    }

    public void OnClickButton_3()
    {
        Ui_1.SetActive(false);
        Ui_2.SetActive(false);
        Ui_3.SetActive(true);
        Ui_4.SetActive(false);
    }

    public void OnClickButton_4()
    {
        Ui_1.SetActive(false);
        Ui_2.SetActive(false);
        Ui_3.SetActive(false);
        Ui_4.SetActive(true);
    }

    public void OnClickButton_5() 
    {
        GameObject.Find("Player").GetComponent<Player>().PlayerMoveStartPoint(true, 0);
        StartCoroutine(Entrancefalse());
    }

    public void OnClickButton_6()
    {
        GameObject.Find("Player").GetComponent<Player>().PlayerMoveStartPoint(true, 1);
        StartCoroutine(Entrancefalse());
    }

    IEnumerator Entrancefalse() //占쏙옙占쏙옙 占쏙옙占쏙옙占 占쏙옙占쏙옙 占쏙옙占쏙옙占쌍댐옙 占쌘뤄옙틴
    {
        BossEntrance.SetActive(true);
        yield return new WaitForSeconds(2f);
        BossEntrance.SetActive(false);
    }
}
