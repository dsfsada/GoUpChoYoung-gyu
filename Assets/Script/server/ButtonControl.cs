using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public string dbType = "1"; // 1 insert ,,, 2 select data 3 update 
    public string Id = "0";
    public string Passward = "1234";
    public string dbData = "";
    ClientSend clientsend = new ClientSend();
    public void InsertClick() //insert
    {
        // 보낼 데이터 수집
        float coin = GameObject.Find("Statuse").GetComponent<Statuse>().coin;
        float floor = GameObject.Find("Statuse").GetComponent<Statuse>().floor;

        int[] status = GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState;
        int[,] artifactsValues = GameObject.Find("Statuse").GetComponent<Statuse>().artifactsValues;
        int[,] artifacts = GameObject.Find("Statuse").GetComponent<Statuse>().artifacts;

        dbData = ""; // db 데이터 초기화

        //보낼 값 작성
        for(int i = 0; i < status.Length; i++) {
            dbData += $"{status[i]}^";
        }
        dbData = dbData.TrimEnd('^');
        dbData += "*";
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 4; j++) {
                dbData += $"{artifactsValues[i, j]}^";
            }
        }
        dbData = dbData.TrimEnd('^');
        dbData += "*";
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 2; j++)
            {
                dbData += $"{artifacts[i, j]}^";
            }
        }
        dbData = dbData.TrimEnd('^');
        dbData += $"*{coin}";
        dbData += $"*{floor}";

        Debug.Log(dbData);
        string msg = $"1.{Id}.{Passward}.{dbData}";
        clientsend.ButtonClick(msg);
    }
    public void SerectClick() //serect
    {
        
        Debug.Log("Button is clicked");
        string msg = $"2.{Id}.{Passward}.{dbData}";
        clientsend.ButtonClick(msg);
    }
    public void UpdateClick() //update
    {
        int[] status = GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState;
        int[,] artifactsValues = GameObject.Find("Statuse").GetComponent<Statuse>().artifactsValues;
        int[,] artifacts = GameObject.Find("Statuse").GetComponent<Statuse>().artifacts;
        float coin = GameObject.Find("Statuse").GetComponent<Statuse>().coin;
        float floor = GameObject.Find("Statuse").GetComponent<Statuse>().floor;
        dbData = ""; // db 데이터 초기화

        //보낼 값 작성
        for (int i = 0; i < status.Length; i++)
        {
            dbData += $"{status[i]}^";
        }
        dbData = dbData.TrimEnd('^');
        dbData += "*";
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                dbData += $"{artifactsValues[i, j]}^";
            }
        }
        dbData = dbData.TrimEnd('^');
        dbData += "*";
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                dbData += $"{artifacts[i, j]}^";
            }
        }
        dbData = dbData.TrimEnd('^');
        dbData += $"*{coin}";
        dbData += $"*{floor}";

        Debug.Log("Button is clicked");
        string msg = $"3.{Id}.{Passward}.{dbData}";
        clientsend.ButtonClick(msg);
    }
}
