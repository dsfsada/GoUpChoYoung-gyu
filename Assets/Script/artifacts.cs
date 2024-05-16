using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artifacts : MonoBehaviour
{
    public int[] isEquip = new int[12]; //해당 아이템이 장착 되었는가?
    
    // Start is called before the first frame update
    public void resetEquip() //아이템 장착 초기화 
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = -1;
        }
        isEquip = new int[12];
    }
    public void clearequip(int kind, int num) //아이템 장착 해제
    {
        int[,] value = GameObject.Find("Statuse").GetComponent<Statuse>().artifacts;
        for (int i = 0; i < 3; i++)
        {
            if (value[i, 0] == kind && value[i, 1] == num) GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = -1;
        }
    }


    private int checkartifacts() // 아이템장착할 자리 찾기 ( 있으면 해당 자리 없으면 -1 반환
    {

        int[,] value = GameObject.Find("Statuse").GetComponent<Statuse>().artifacts;

        for(int i = 0; i < 3; i++)
        {
            if (value[i,0]==-1)return i;
        }
        return -1;
    }
    // 밑으로는 죄다 아이템 장착 관련
    public void equipAtk0()
    {
        if (isEquip[0] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 0;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 0;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[0] = 1;
            }
        }
        else
        {
            clearequip(0, 0);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[0] = 0;
        }  
    }
    public void equipAtk1()
    {
        if (isEquip[1] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 0;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 1;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[1] = 1;
            }
        }
        else
        {
            clearequip(0, 1);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[1] = 0;
        }
    }
    public void equipAtk2()
    {
        if (isEquip[2] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 0;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 2;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[2] = 1;
            }
        }
        else
        {
            clearequip(0, 2);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[2] = 0;
        }
    }
    public void equipAtk3()
    {
        if (isEquip[3] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 0;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 3;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[3] = 1;
            }
        }
        else
        {
            clearequip(0, 3);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[3] = 0;
        }
    }
    public void equipHealth0()
    {
        if (isEquip[4] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 1;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 0;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[4] = 1;
            }
        }
        else
        {
            clearequip(1, 0);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[4] = 0;
        }
    }
    public void equipHealth1()
    {
        if (isEquip[5] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 1;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 1;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[5] = 1;
            }
        }
        else
        {
            clearequip(1, 1);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[5] = 0;
        }
    }
    public void equipHealth2()
    {
        if (isEquip[6] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 1;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 2;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[0] = 1;
            }
        }
        else
        {
            clearequip(1, 2);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[6] = 0;
        }
    }
    public void equipHealth3()
    {
        if (isEquip[7] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 1;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 3;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[7] = 1;
            }
        }
        else
        {
            clearequip(1, 3);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[7] = 0;
        }
    }
    public void equipCridamage0()
    {
        if (isEquip[8] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 2;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 0;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[8] = 1;
            }
        }
        else
        {
            clearequip(2, 0);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[8] = 0;
        }
    }
    public void equipCridamage1()
    {
        if (isEquip[9] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 2;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 1;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[9] = 1;
            }
        }
        else
        {
            clearequip(2, 1);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[9] = 0;
        }
    }
    public void equipCridamage2()
    {
        if (isEquip[10] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 2;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 2;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[10] = 1;
            }
        }
        else
        {
            clearequip(2, 2);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[10] = 0;
        }
    }
    public void equipCridamage3()
    {
        if (isEquip[11] == 0)
        {
            int i = checkartifacts();
            if (i != -1)
            {
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 0] = 2;
                GameObject.Find("Statuse").GetComponent<Statuse>().artifacts[i, 1] = 3;
                GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
                isEquip[11] = 1;
            }
        }
        else
        {
            clearequip(2, 3);
            GameObject.Find("Statuse").GetComponent<Statuse>().StatuseUpdate();
            isEquip[11] = 0;
        }
    }

}