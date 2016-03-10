using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SeedButton : MonoBehaviour
{
    private Prices priceTag;

    private int price;

    private Button myButton;

    private MoneyAndDust money;

    void OnEnable()
    {
        priceTag = GetComponentInChildren<Prices>();
        myButton = GetComponent<Button>();
        money = GameObject.Find("CurrencyHolder").GetComponent<MoneyAndDust>();

        price = priceTag.price;

        if(money.Money < price)
        {
            myButton.interactable = false;
        }else
        {
            myButton.interactable = true;
        }
    }

    public void PayMoney()
    {
        money.Money -= price;
    }
}
