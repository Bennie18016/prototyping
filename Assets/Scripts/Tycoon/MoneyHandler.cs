using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    public float money;
    public string _moneySub;
    public int rebirths;
    public bool mill;

    public void AddMoney(int _money)
    {
        money += _money;
    }

    public void Rebirth()
    {
        rebirths++;
        money = 0;

        foreach (GameObject s in GameObject.FindGameObjectsWithTag("Shop"))
        {
            s.GetComponent<ShopManager>().Restart();
        }
    }

    private void Update()
    {
        mill = money / 1000000 > 1;
        if (mill)
        {
            _moneySub = string.Format("{0} million", money / 1000000);
        }
    }
}
