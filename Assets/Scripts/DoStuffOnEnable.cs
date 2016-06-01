using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoStuffOnEnable : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasPrefab;
    [SerializeField]
    private Text textObject;
    private RectTransform rectTransform;
    private Vector2 textStartPosition, textEndPosition;
    private Color textStartColor, textEndColor;
    private float duration;

    void OnEnable ()
    {
        rectTransform = textObject.GetComponent<RectTransform>();
        textStartPosition = rectTransform.anchoredPosition;
        textEndPosition = new Vector2(textStartPosition.x, (textStartPosition.y + 200));
        textStartColor = textObject.color;
        textEndColor = new Color(textStartColor.r, textStartColor.g, textStartColor.b, 0f);
        duration = 1f;
        StartCoroutine(ShowText());
    }
    private IEnumerator ShowText()
    {
        float elapsedTime = 0;
        
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; //0 means the animation just started, 1 means it finished
            rectTransform.anchoredPosition = Vector2.Lerp(textStartPosition, textEndPosition, t);
            textObject.color = Color.Lerp(textStartColor, textEndColor, t);
            elapsedTime += Time.deltaTime * 1f;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
