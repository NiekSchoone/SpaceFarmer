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

    private int cash;
    private int dust;

    private MoneyAndDust money;
    
    [SerializeField]
    private GameObject FloatTextObject;
    private GameObject newFloatText;

	void OnEnable ()
    {
        money = GameObject.Find("CurrencyHolder").GetComponent<MoneyAndDust>();

        growPercentage = 0;

        delay = asset.myDelay;

        cash = Random.Range(asset.minMoney, asset.maxMoney);
        dust = Random.Range(asset.minDust, asset.maxDust);

        spriteRenderer = GetComponent<SpriteRenderer>();

        changeSprite(growPercentage);

        newFloatText = Instantiate(FloatTextObject, transform.position, Quaternion.identity) as GameObject;
        newFloatText.GetComponentInChildren<Text>().text = "$ " + cash;
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
            //DoParticles();
        }
        else if (percentage == 50)
        {
            spriteRenderer.sprite = asset.sprites[2];
            //DoParticles();
        }
        else if (percentage == 75)
        {
            spriteRenderer.sprite = asset.sprites[3];
            //DoParticles();
        }
        else if(percentage == 100)
        {
            spriteRenderer.sprite = asset.sprites[4];
            //DoParticles();
        }
    }

    void SellPlant()
    {
        DoParticles();
        DoDust();
        newFloatText.SetActive(true);
        money.Money = cash;
        spriteRenderer.sprite = null;
        asset = null;
        newFloatText = null;
        this.enabled = false;
    }

    void DoParticles()
    {
        if (asset.plantParticles != null)
        {
            Instantiate(asset.plantParticles, this.transform.position, Quaternion.Euler(-90,0,0));
        }
    }
    
    void DoDust()
    {
        if(dust > 0)
        {
            int particleAmount = dust / 10;
            Debug.Log(particleAmount);

            for (int i = 0; i < particleAmount; i++)
            {
                GameObject newDustParticle = Instantiate(asset.dustParticle, this.transform.position, Quaternion.identity) as GameObject;
                newDustParticle.GetComponent<MysteryDust>().Value = dust / particleAmount;
            }
        }
    }
}
