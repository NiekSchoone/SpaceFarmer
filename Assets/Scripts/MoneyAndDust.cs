using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyAndDust : MonoBehaviour
{
    private int moneyInBank;
    private int targetMoney;

    private int dustInBank;

    [SerializeField]
    private Text currencyText;
    [SerializeField]
    private Text dustText;
    
    private int step;

    void Start()
    {
        dustInBank = 0;
        moneyInBank = 600;
        targetMoney = moneyInBank;
        currencyText.text = moneyInBank.ToString();
        dustText.text = dustInBank.ToString();
    }
    
    public int Money
    {
        get
        {
            return moneyInBank;
        }set
        {
            targetMoney += value;
            step = moneyInBank - targetMoney;

            if(step < 0)
            {
                step -= (step * 2);
            }
            StartCoroutine(MoneyCounter());
            Debug.Log(targetMoney);
        }
    }
    public int Dust
    {
        get
        {
            return dustInBank;
        }set
        {
            dustInBank += value;
            dustText.text = dustInBank.ToString();
        }
    }

    IEnumerator MoneyCounter()
    {
        while(moneyInBank != targetMoney)
        {
            moneyInBank = (int)Mathf.MoveTowards(moneyInBank, targetMoney, Time.deltaTime * step);
            currencyText.text = moneyInBank.ToString();
            yield return null;
        }
    }
}
