using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
    //�ɼ� ��ư Ŭ���� �߻��Ǵ� �̺�Ʈ
{
    public GameObject Panel;

    private void Start()
    {
        Panel.SetActive(false);
    }

    public void OnClickPanel()
    {
        Panel.SetActive(true);
    }

    public void OnClickPanelExit()
    {
        Panel.SetActive(false);
    }
}
