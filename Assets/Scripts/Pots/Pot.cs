using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Pot : Tap
{
    private bool occupied;
    [SerializeField]
    private Lock myLock;
    [SerializeField]
    private Plant plant;
    [SerializeField]
    private GameObject seedPanel;

    void Awake()
    {
        myLock = GetComponent<Lock>();
        if(myLock.isLocked)
        {
            this.enabled = false;
        }
    }
	void OnEnable()
    {
        myLock.enabled = false;
        plant = GetComponentInChildren<Plant>();
    }

    public void BuyPlant(PlantAsset myAsset)
    {
        plant.asset = myAsset;
        plant.enabled = true;
        occupied = true;
        DeactivateUI();
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            DeactivateUI();
        }
        if (!plant.isActiveAndEnabled)
        {
            occupied = false;
        }
    }

    public override void OnTapRelease()
    {
        base.OnTap();
        if (!occupied)
        {
            seedPanel.GetComponent<PlantGiver>().SetPlantObject(this);
            ActivateUI();
        }
    }

    public void ActivateUI()
    {
        seedPanel.SetActive(true);
    }
    public void DeactivateUI()
    {
        seedPanel.GetComponent<UIDisabler>().Disable();
    }
}
