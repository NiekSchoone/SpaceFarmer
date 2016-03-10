using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Prices : MonoBehaviour
{
    public int price;

    public Text priceTag;

    void OnEnable()
    {
        priceTag.text = "$" + price;
    }
}
