using UnityEngine;
using System.Collections;

public class PotBuyer : MonoBehaviour
{
    private Lock assignedLock;

	public void SetPotLock(Lock myLock)
    {
        assignedLock = myLock;
    }

    public void BuyPot()
    {
        assignedLock.UnlockPot();
    }
}
