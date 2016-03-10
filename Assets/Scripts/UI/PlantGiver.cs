using UnityEngine;
using System.Collections;

public class PlantGiver : MonoBehaviour
{
    private Pot assignedPot;

    public void GivePlant(PlantAsset plantToGive)
    {
        assignedPot.BuyPlant(plantToGive);
    }

	public void SetPlantObject(Pot pot)
    {
        assignedPot = pot;
    }
}
