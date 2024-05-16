using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditText : MonoBehaviour
{
    public Text floorText;
    public Text coinText;

    private float currentCoin = 0;

    private void Start()
    {
        updateFloor();
        updateCoin(GameObject.Find("Statuse").GetComponent<Statuse>().coin);
    }

    private void Update()
    {
        float coin = GameObject.Find("Statuse").GetComponent<Statuse>().coin;
        if (currentCoin != coin)  //코인값의 변경이 있을시 코인 업데이트
        {
            updateCoin(coin);
            currentCoin = coin;
        }

    }

    public void updateFloor()
    {
        floorText.text = "STAGE\n" + GameObject.Find("Statuse").GetComponent<Statuse>().floor;
    }
    public void updateCoin(float _coin)
    {
        coinText.text = _coin.ToString("N0", System.Globalization.CultureInfo.InvariantCulture);
    }

}
