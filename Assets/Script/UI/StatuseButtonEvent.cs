using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuseButtonEvent : MonoBehaviour
{
    public Button upgradeAttack_button;         //공격력 업그레이드
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

        if (GameObject.Find("Underbar").GetComponent<UnderBar>().Ui_1.activeSelf == true) //underbar ui1이 활성화 되어있는 경우에만 on
        {
            upgradeAttack_button.onClick.AddListener(OnClickUpgrade_AttackButton);                   //공격력 업그레이드
            upgradeHealth_button.onClick.AddListener(OnClickUupgrade_HealthButton);                  //체력
            upgradeCriticalAtk_button.onClick.AddListener(OnClickUpgrade_CriticalAtkButton);         //치명타 공격력                                                                                
            upgradeCriticalRate_button.onClick.AddListener(OnClickUpgrade_CriticalRateButton);       //치명타 확률
        }

    }

    public void OnClickUpgrade_AttackButton() //버튼 클릭시 Statuse스크립트의 attack 증가
    {
        if(GameObject.Find("Statuse").GetComponent<Statuse>().coin >= atkCoin)  //코인이 atkCoin보다 크면 실행
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().CoinUsage(atkCoin);  //코인 소비
            GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[0]++;         //Statuse 스크립트와 상호작용(공격력)
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();         //Statuse 스크립트 업데이트
            atkCoin++;
        }//나중에 else해서 사운드 넣던가 돈 없다고 표시하는 문 추가
    }

    public void OnClickUupgrade_HealthButton() //버튼 클릭시 Statuse스크립트의 health 증가
    {
        if (GameObject.Find("Statuse").GetComponent<Statuse>().coin >= healthCoin)
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().CoinUsage(healthCoin);  //코인 소비
            GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[1]++;         //Statuse 스크립트와 상호작용(체력)
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();         //Statuse 스크립트 업데이트
            GameObject.Find("Player").GetComponent<Player>().health += 20;
            healthCoin++;
        }
    }

    public void OnClickUpgrade_CriticalAtkButton() //버튼 클릭시 Statuse스크립트의 criAtk 증가
    {
        if (GameObject.Find("Statuse").GetComponent<Statuse>().coin >= criAtkCoin)
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().CoinUsage(criAtkCoin);  //코인 소비
            GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[2]++;         //Statuse 스크립트와 상호작용(크뎀)
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();              //Statuse 스크립트 업데이트
            criAtkCoin++;
        }
    }

    public void OnClickUpgrade_CriticalRateButton() //버튼 클릭시 Statuse스크립트의 criRate 증가
    {
        if (GameObject.Find("Statuse").GetComponent<Statuse>().coin >= criRateCoin)
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().CoinUsage(criRateCoin);  //코인 소비
            GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[3]++;         //Statuse 스크립트와 상호작용(크확)
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();               //Statuse 스크립트 업데이트
            criRateCoin++;
        }
    }

    
}
