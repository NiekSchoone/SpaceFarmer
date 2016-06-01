using UnityEngine;
using System.Collections;

public class MysteryDust : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 bending;

    [SerializeField]
    private GameObject target;

    private int myValue;

    private MoneyAndDust currencyHolder;

    private float speed;

    public int Value
    {
        get
        {
            return myValue;
        }
        set
        {
            myValue = value;
        }
    }

    void Awake()
    {
        currencyHolder = GameObject.Find("CurrencyHolder").GetComponent<MoneyAndDust>();

        target = GameObject.Find("DustTarget");

        startPos = this.transform.position;
        endPos = target.transform.position;
        bending = new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f));

        speed = Random.Range(0.5f, 1.5f);
    }

    void OnEnable()
    {
        StartCoroutine(MoveOverCurve());
    }

    IEnumerator MoveOverCurve()
    {
        float beziertime = 0;

        while (beziertime<1/*Vector2.Distance(transform.position, endPos) >= 0.2f*/)
        {
            beziertime += Time.deltaTime * speed;
            transform.position = Bezier2(startPos, bending, endPos, beziertime);
            
            yield return null;
        }
        currencyHolder.Dust = myValue;
        Destroy(this.gameObject);
    }

    Vector2 Bezier2(Vector2 Start, Vector2 Control, Vector2 End, float t)
    {
        return (((1-t)*(1-t)) * Start) + (2 * t* (1 - t) * Control) + ((t* t) * End);
    }
}
