using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Statuse : MonoBehaviour
{
    /*enum Artifact // 아티팩트 종류
    {
        Attack = 0,
        Health = 1,
        CriticalDamage = 2
    }*/

    /*enum Status  // 능력치 항목
    {
        Attack = 0,
        Health = 1,
        CriticalAtk = 2,
        CriticalRate = 3,
        AtkSpeed = 4
    }*/
    private float[] basestate = { 1, 20, 0, 0, 1 };
    // 최종 능력치 값
    public float[] finalStatus = new float[5];
    // 돈 , 층수
    public float coin;
    public float floor;
    //업그레이드한 양
    public int[] upgradeState = new int[5];


    // 아티팩트 관련  --
    public int[,] artifactsValues = {//아티팩트들의 강화 수치 ex( artifactsValues[0][1] = > Attack 티어 1 의 강화 수치
        {0,0,0,0},{0,0,0,0},{0,0,0,0}
    };
    public int[,] artifactsNum = {//아티팩트 아이템 갯수
        {0,0,0,0},{0,0,0,0},{0,0,0,0}
    };
    public int[] Levelitem = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // 렙업에 필요한 파편 갯수
    //장착시킨 아티팩트
    public int[,] artifacts = {  // -1 안에 든 값 없음
        {-1,0}, {-1,-1}, {-1,0}
    };
    //아이템 종류
    public static List<Item> itemList = new List<Item>();

    public void ItemSet()
    {
        itemList.Add(new Item(10000, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));
        itemList.Add(new Item(10001, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));
        itemList.Add(new Item(10002, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));
        itemList.Add(new Item(10003, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));

        itemList.Add(new Item(10010, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));
        itemList.Add(new Item(10011, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));
        itemList.Add(new Item(10012, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));
        itemList.Add(new Item(10013, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));

        itemList.Add(new Item(10020, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));
        itemList.Add(new Item(10021, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));
        itemList.Add(new Item(10022, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));
        itemList.Add(new Item(10023, "공격력 아티팩트:RANK 1", Item.ItemType.Artifact));


    }

    public void StatuseUpdate()
    {
        // 능력치 업그레이드로 인한 능력치 변화
        finalStatus[0] = basestate[0] + 1 * upgradeState[0]; // ATk
        finalStatus[1] = basestate[1] + 20 * upgradeState[1]; // Health
        finalStatus[2] = basestate[2] + 1 * upgradeState[2]; //Crk
        finalStatus[3] = basestate[3] + 0.1f * upgradeState[3]; //Crkrate
        finalStatus[4] = basestate[4] - 0.01f * upgradeState[4]; //ats
        // 아티팩트 로 인한 능력치 변화
        for (int i = 0; i < 3; i++)
        {
            if (artifacts[i, 0] != -1)
            {
                finalStatus[artifacts[i, 0]] += (artifacts[i, 1]+1) * artifactsValues[artifacts[i, 0], artifacts[i, 1]];
            }
        }
        //player에게 정보 보내기
        GameObject.Find("Player").GetComponent<Player>().atk = finalStatus[0];
        GameObject.Find("Player").GetComponent<Player>().maxHealth = finalStatus[1];
        GameObject.Find("Player").GetComponent<Player>().criAtk = finalStatus[2];
        GameObject.Find("Player").GetComponent<Player>().criRate = finalStatus[3];
        GameObject.Find("Player").GetComponent<Player>().attackCool = finalStatus[4];
    }

    public void resetEquip()
    {
        for (int i = 0; i < 3; i++)
        {
            artifacts[i, 0] = -1;
        }
        GameObject.Find("ButtonControl").GetComponent<artifacts>().isEquip = new int[12];
    }

    public void CoinUsage(float _useCoin)   //업그레이드 버튼 클릭시 코인 사용
    {
        coin -= _useCoin;
    }

    private void Start()
    {
        ItemSet();
        StatuseUpdate();
    }

    //아이템 갯수확인 후 렙업 최대 

    public void upgradeAtk0()
    {
        int kind = 0;
        int num = 0;
        if (artifactsNum[kind, num] >= Levelitem[artifactsValues[kind, num]] && artifactsValues[kind, num] < 10)
        {
            artifactsValues[kind, num] += 1;
        }
    }
    public void upgradeItem(int kind = 0, int num = 0)     
    {

        if (artifactsNum[kind, num] >= Levelitem[artifactsValues[kind, num]] && artifactsValues[kind, num] < 10)
        {
            artifactsNum[kind, num] -= Levelitem[artifactsValues[kind, num]];
            artifactsValues[kind, num] += 1;

        }
    }


}