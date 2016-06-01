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

    void Awake()
    {
        if(!isLocked)
        {
            spriteRenderer.sprite = unlockedSprite;
        }
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
        DeactivateUI();
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
