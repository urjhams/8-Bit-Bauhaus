using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;
    [SerializeField]
    private Camera uiCamera = null;
    private Text tooltipText;
    private RectTransform backgroundRectTransform;

    private void Awake()
    {
        instance = this;
        backgroundRectTransform = transform.Find("background").GetComponent<RectTransform>();
        tooltipText = transform.Find("text").GetComponent<Text>();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        localPoint.x += 10;
        transform.localPosition = localPoint;
    }

    private void ShowToolTip(string tooltipString)
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);

        tooltipText.text = tooltipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textPaddingSize * 2f, tooltipText.preferredHeight + textPaddingSize * 2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void HideToolTip()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
    }

    public static void showTooltip_Static(string tooltipString)
    {
        if (instance != null)
            instance.ShowToolTip(tooltipString);
    }

    public static void hideToolTip_Static()
    {
        if (instance != null)
            instance.HideToolTip();
    }
}
