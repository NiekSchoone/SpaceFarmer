using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Price : MonoBehaviour
{
    public int price;

    public Text priceTag;

    void OnEnable()
    {
        priceTag.text = "$ " + price;
    }
}
