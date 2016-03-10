using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Plant : Tap
{
    public PlantAsset asset;

    [SerializeField]
    private int growPercentage;
    private float delay;

    private SpriteRenderer spriteRenderer;
    private Sprite sprite;

    private int profit;

    private MoneyAndDust money;
    
    private ParticleSystem myParticles;

    [SerializeField]
    private GameObject FloatTextObject;
    private GameObject newFloatText;

	void OnEnable ()
    {
        money = GameObject.Find("CurrencyHolder").GetComponent<MoneyAndDust>();

        growPercentage = 0;

        delay = asset.myDelay;

        profit = Random.Range(asset.minMoney, asset.maxMoney);

        spriteRenderer = GetComponent<SpriteRenderer>();

        changeSprite(growPercentage);

        newFloatText = Instantiate(FloatTextObject, transform.position, Quaternion.identity) as GameObject;
        newFloatText.GetComponentInChildren<Text>().text = "$ " + profit;
    }

    void FixedUpdate()
    {
        if (growPercentage != 100)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                growPercentage++;
                changeSprite(growPercentage);
                delay = asset.myDelay;
            }
        }
    }

    public override void OnTapRelease()
    {
        base.OnTapRelease();
        if(growPercentage == 100)
        {
            SellPlant();
        }
    }

    void changeSprite(int percentage)
    {
        if(percentage == 0)
        {
            spriteRenderer.sprite = asset.sprites[0];
        }
        else if(percentage == 25)
        {
            spriteRenderer.sprite = asset.sprites[1];
            DoParticles();
        }
        else if (percentage == 50)
        {
            spriteRenderer.sprite = asset.sprites[2];
            DoParticles();
        }
        else if (percentage == 75)
        {
            spriteRenderer.sprite = asset.sprites[3];
            DoParticles();
        }
        else if(percentage == 100)
        {
            spriteRenderer.sprite = asset.sprites[4];
            DoParticles();
        }
    }

    void DoParticles()
    {
        if (myParticles != null)
        {
            myParticles = this.gameObject.AddComponent<ParticleSystem>();
            myParticles = asset.myParticles;
            myParticles.Play();
        }
    }

    void SellPlant()
    {
        newFloatText.SetActive(true);
        money.Money += profit;
        spriteRenderer.sprite = null;
        asset = null;
        newFloatText = null;
        this.enabled = false;
    }
}
