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

    private float counterSpeed;
    private float counter;
    private int moneyCurve;

    void Start()
    {
        dustInBank = 0;
        moneyInBank = 600;
        targetMoney = moneyInBank;
        counterSpeed = 100;
        counter = 1;

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
            targetMoney = value;
            moneyCurve = Mathf.CeilToInt(targetMoney - moneyInBank) / 100;
            if (moneyCurve <= 1) { moneyCurve = 1; }
            if (targetMoney < moneyInBank){ moneyCurve = -moneyCurve; }
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
            dustInBank = value;
            dustText.text = dustInBank.ToString();
        }
    }

    IEnumerator MoneyCounter()
    {
        while(moneyInBank != targetMoney)
        {
            counter -= Time.deltaTime * counterSpeed;
            if (counter <= 0)
            {
                moneyInBank+=moneyCurve;
                currencyText.text = moneyInBank.ToString();
                counter = 1;
            }
            yield return null;
        }
    }
}
