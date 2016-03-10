using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lock : Tap
{
    [SerializeField]
    public bool isLocked = true;
    [SerializeField]
    private Pot myPot;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite lockedSpite;
    [SerializeField]
    private Sprite unlockedSprite;

    [SerializeField]
    private GameObject buyPotPanel;
    [SerializeField]
    private  Button buyButton;

    private MoneyAndDust money;

    void Awake()
    {
        if(!isLocked)
        {
            spriteRenderer.sprite = unlockedSprite;
        }

        money = GameObject.Find("CurrencyHolder").GetComponent<MoneyAndDust>();
    }

	void Start ()
    {
        myPot = GetComponent<Pot>();
        
        if (isLocked)
        {
            spriteRenderer.sprite = lockedSpite;
            myPot.enabled = false;
        }else
        {
            myPot.enabled = true;
        }
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeactivateUI();
        }
    }

    public void UnlockPot()
    {
        isLocked = false;
        spriteRenderer.sprite = unlockedSprite;
        myPot.enabled = true;
        money.Money -= 500;
        DeactivateUI();
        Debug.Log(money.Money);
    }

    public override void OnTapRelease()
    {
        base.OnTap();
        buyPotPanel.GetComponent<PotBuyer>().SetPotLock(this);
        ActivateUI();
    }

    public void ActivateUI()
    {
        buyPotPanel.SetActive(true);
    }
    public void DeactivateUI()
    {
        buyPotPanel.SetActive(false);
    }
}
