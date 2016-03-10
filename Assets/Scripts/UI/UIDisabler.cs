using UnityEngine;
using System.Collections;

public class UIDisabler : MonoBehaviour
{
    public void Disable()
    {
        StartCoroutine(DisableWindow());
    }

    IEnumerator DisableWindow()
    {
        //Debug.Log("Scaling down");
        while (this.gameObject.transform.localScale.y > 0)
        {
            Debug.Log("Scaling down");
            this.gameObject.transform.localScale = Vector3.MoveTowards(this.gameObject.transform.localScale, new Vector3(1, 0, 1), Time.deltaTime * 6);
            yield return null;
        }
        this.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        StopCoroutine(DisableWindow());
    }
}
