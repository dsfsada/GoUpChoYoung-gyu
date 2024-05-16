using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuseButtonEvent : MonoBehaviour
{
    public Button upgradeAttack_button;         //���ݷ� ���׷��̵�
    public Button upgradeHealth_button;
    public Button upgradeCriticalAtk_button;
    public Button upgradeCriticalRate_button;

    [Header("CoinUsage")]
    private float atkCoin;
    private float healthCoin;
    private float criAtkCoin;
    private float criRateCoin;

    void Start()
    {
        atkCoin = GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[0] + 1f ;
        healthCoin = GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[1] + 1f ;
        criAtkCoin = GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[2] + 1f ;
        criRateCoin = GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[3] + 1f;

        if (GameObject.Find("Underbar").GetComponent<UnderBar>().Ui_1.activeSelf == true) //underbar ui1�� Ȱ��ȭ �Ǿ��ִ� ��쿡�� on
        {
            upgradeAttack_button.onClick.AddListener(OnClickUpgrade_AttackButton);                   //���ݷ� ���׷��̵�
            upgradeHealth_button.onClick.AddListener(OnClickUupgrade_HealthButton);                  //ü��
            upgradeCriticalAtk_button.onClick.AddListener(OnClickUpgrade_CriticalAtkButton);         //ġ��Ÿ ���ݷ�                                                                                
            upgradeCriticalRate_button.onClick.AddListener(OnClickUpgrade_CriticalRateButton);       //ġ��Ÿ Ȯ��
        }

    }

    public void OnClickUpgrade_AttackButton() //��ư Ŭ���� Statuse��ũ��Ʈ�� attack ����
    {
        if(GameObject.Find("Statuse").GetComponent<Statuse>().coin >= atkCoin)  //������ atkCoin���� ũ�� ����
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().CoinUsage(atkCoin);  //���� �Һ�
            GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[0]++;         //Statuse ��ũ��Ʈ�� ��ȣ�ۿ�(���ݷ�)
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();         //Statuse ��ũ��Ʈ ������Ʈ
            atkCoin++;
        }//���߿� else�ؼ� ���� �ִ��� �� ���ٰ� ǥ���ϴ� �� �߰�
    }

    public void OnClickUupgrade_HealthButton() //��ư Ŭ���� Statuse��ũ��Ʈ�� health ����
    {
        if (GameObject.Find("Statuse").GetComponent<Statuse>().coin >= healthCoin)
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().CoinUsage(healthCoin);  //���� �Һ�
            GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[1]++;         //Statuse ��ũ��Ʈ�� ��ȣ�ۿ�(ü��)
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();         //Statuse ��ũ��Ʈ ������Ʈ
            GameObject.Find("Player").GetComponent<Player>().health += 20;
            healthCoin++;
        }
    }

    public void OnClickUpgrade_CriticalAtkButton() //��ư Ŭ���� Statuse��ũ��Ʈ�� criAtk ����
    {
        if (GameObject.Find("Statuse").GetComponent<Statuse>().coin >= criAtkCoin)
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().CoinUsage(criAtkCoin);  //���� �Һ�
            GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[2]++;         //Statuse ��ũ��Ʈ�� ��ȣ�ۿ�(ũ��)
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();              //Statuse ��ũ��Ʈ ������Ʈ
            criAtkCoin++;
        }
    }

    public void OnClickUpgrade_CriticalRateButton() //��ư Ŭ���� Statuse��ũ��Ʈ�� criRate ����
    {
        if (GameObject.Find("Statuse").GetComponent<Statuse>().coin >= criRateCoin)
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().CoinUsage(criRateCoin);  //���� �Һ�
            GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[3]++;         //Statuse ��ũ��Ʈ�� ��ȣ�ۿ�(ũȮ)
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();               //Statuse ��ũ��Ʈ ������Ʈ
            criRateCoin++;
        }
    }

    
}
