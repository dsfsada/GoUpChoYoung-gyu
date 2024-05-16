using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuseText : MonoBehaviour
{
    [Header("StatsLV")]
    public Text atkLV;
    public Text healthLV;
    public Text criAtkLV;
    public Text criRateLV;

    [Header("StatsUpgrade")]
    public Text atk_text;
    public Text health_text;
    public Text criAtk_text;
    public Text criRate_text;

    [Header("CoinUsage")]
    public Text atkCoin_text;
    public Text healthCoin_text;
    public Text criAtkCoin_text;
    public Text criRateCoin_text;

    void Update()
    {
        if(GameObject.Find("Underbar").GetComponent<UnderBar>().Ui_1.activeSelf == true) //underbar ui1이 활성화 되어있는 경우에만 on
        {
            atkLV.text = "LV." + GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[0].ToString();
            healthLV.text = "LV." + GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[1].ToString();
            criAtkLV.text = "LV." + GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[2].ToString();
            criRateLV.text = "LV." + GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[3].ToString();

            // float 값을 문자열로 변환하여 Text 필드에 할당
            atk_text.text = GameObject.Find("Statuse").GetComponent<Statuse>().finalStatus[0].ToString() + " -> " + (GameObject.Find("Statuse").GetComponent<Statuse>().finalStatus[0] + 1.0f).ToString();
            health_text.text = GameObject.Find("Statuse").GetComponent<Statuse>().finalStatus[1].ToString() + " -> " + (GameObject.Find("Statuse").GetComponent<Statuse>().finalStatus[1] + 20f).ToString();
            criAtk_text.text = GameObject.Find("Statuse").GetComponent<Statuse>().finalStatus[2].ToString()+ "% -> " + (GameObject.Find("Statuse").GetComponent<Statuse>().finalStatus[2] + 1f).ToString()+"%";
            criRate_text.text = GameObject.Find("Statuse").GetComponent<Statuse>().finalStatus[3].ToString() + "% -> " + (GameObject.Find("Statuse").GetComponent<Statuse>().finalStatus[3] + 0.1f).ToString() + "%";

            atkCoin_text.text = (GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[0] + 1f).ToString();
            healthCoin_text.text = (GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[1] + 1f).ToString();
            criAtkCoin_text.text = (GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[2] + 1f).ToString();
            criRateCoin_text.text = (GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[3] + 1f).ToString();
        }

    }
    
}
