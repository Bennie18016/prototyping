using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public string _name;
    public float _maxTime, _time;
    public int _moneyToGive;
    public MoneyHandler _mh;
    public TMP_Text _nameText, _levelText, _levelButtonText;
    public Slider _s;
    int _levelCost;

    private int level;


    public void Restart()
    {
        level = 0;
        _moneyToGive = 10;
        _time = 0;
        _levelCost = 0;
        _maxTime = 15;
    }

    private void Start()
    {
        _nameText.text = _name;
        _s.maxValue = _maxTime;
    }

    private void Update()
    {
        if (_time > _maxTime)
        {
            _mh.AddMoney(_moneyToGive);
            _time = 0;
        }
        if (level > 0) _time += 1 * Time.deltaTime;

        _levelButtonText.text = string.Format("Level Up\n{0}", _levelCost);
        _levelText.text = level.ToString();
        _s.value = _time;
        _s.maxValue = _maxTime;
    }

    public void Upgrade()
    {
        if (_mh.money < _levelCost) return;
        if (level == 100) return;
        if (_maxTime == 1)
        {
            _moneyToGive += 100 * level;
        }
        else
        {
            _moneyToGive += _moneyToGive;
            _maxTime--;
        }
        _mh.AddMoney(-_levelCost);
        level++;
        _levelCost += level * 10;
    }
}
