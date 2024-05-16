using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRoom : MonoBehaviour
{
    public Button Button_1; //�������ͽ� ȭ�� on��ư
    public Button Button_2;
    public Button Button_3;
    public Button Button_4;

    public GameObject Ui_1; //�������ͽ� ȭ��
    public GameObject Ui_2;
    public GameObject Ui_3; //���� ȭ��
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


        BossEntrance.SetActive(false); //���� ��ȯ�� ������ ���� ȭ��

        BossEntrance.SetActive(false); //���� ��ȯ�� ������ ���� ȭ��

        Button_1.onClick.AddListener(OnClickButton_1);   //1�� ��ư Ŭ���� �������ͽ� ȭ�� on �� �ٸ� ȭ��� off
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

    IEnumerator Entrancefalse() //���� ����� ���� �����ִ� �ڷ�ƾ
    {
        BossEntrance.SetActive(true);
        yield return new WaitForSeconds(2f);
        BossEntrance.SetActive(false);
    }
}
