using UnityEngine;
using System.Collections;

public class OnUIEnable : MonoBehaviour
{
    void OnEnable()
    {

        StartCoroutine(DisableWindow());
    }

    IEnumerator DisableWindow()
    {
        while (this.gameObject.transform.localScale.y < 1)
        {
            this.gameObject.transform.localScale = Vector3.MoveTowards(this.gameObject.transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 6);
            yield return null;
        }
    }
}
