using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEngine.UI;

public class ClientHandle
{
    public void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");

        Client.instance.myId = _myId;
        // use ClientSend to send Data back to Server
        ClientSend.WelcomeReceived();
        Client.isConnected = true;
    }
    // You can add like below. You receive data through packet
    public void ReceivedUserInfo(Packet _packet)
    {
        string _name = _packet.ReadString();
        string[] name = _name.Split('/');
        int userIndex = int.Parse(name[0]) - 1;
        Debug.Log("index : " + userIndex);
        
        Debug.Log($"Sent user info: {_name}");
    }
    public void ButtonClick(Packet _packet)
    {
        
        string _msg = _packet.ReadString();
        Debug.Log(_msg);
        string[] split_data = _msg.Split(".");
        Debug.Log($"msg from server : {_msg[1]}");
        
        if (split_data[0] == "1")
        {
            string[] splitData = split_data[2].Split('*');
            string[] status = splitData[0].Split('^');
            string[] artifactsValues = splitData[1].Split('^');
            string[] artifacts = splitData[2].Split('^');

            for(int i = 0; i < 5; i++) {
                GameObject.Find("Statuse").GetComponent<Statuse>().upgradeState[i] = int.Parse(status[i]);
            }
            for(int i = 0;i < 3; i++) {
                for(int j= 0; j < 4; j++)
                {
                    GameObject.Find("Statuse").GetComponent<Statuse>().artifactsValues[i,j] = int.Parse(artifactsValues[i*4+j]);
                }
            }
            for (int i = 0;i<3 ; i++) {
                for (int j= 0;j < 2; j++) {
                    GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, j] = int.Parse(artifactsValues[i * 2 + j]);
                }
            }
            GameObject.Find("Statuse").GetComponent<Statuse>().coin = float.Parse(splitData[3]);
            GameObject.Find("Statuse").GetComponent<Statuse>().floor = float.Parse(splitData[4]);
            GameObject.Find("ButtonControl").GetComponent<ButtonControl>().dbData = split_data[2];
        }
        if (split_data[0] == "2")
        {
            GameObject.Find("ButtonControl").GetComponent<ButtonControl>().Id = split_data[2];
        }
    }
}

