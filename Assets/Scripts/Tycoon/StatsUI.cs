using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public MoneyHandler _mh;
    public TMP_Text money, rebirth;

    private void Update()
    {
        rebirth.text = string.Format("Rebirths: {0}", _mh.rebirths);
        if (_mh.mill)
        {
            money.text = _mh._moneySub;
        }
        else
        {
            money.text = string.Format("Money: {0}", _mh.money);
        }
    }
}
