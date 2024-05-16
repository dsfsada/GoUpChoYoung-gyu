using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
    //옵션 버튼 클릭시 발생되는 이벤트
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
