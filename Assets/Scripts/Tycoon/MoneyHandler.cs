using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    public int money;
    public int rebirths;

    public void AddMoney(int _money){
        money += _money;
    }

    public void Rebirth(){
        rebirths++;
        money = 0;
    }
}
