using UnityEngine;
using UnityEngine.UI;
public class BandelBar : MonoBehaviour
{
    public static BandelBar instance { get; private set; }

    public Image mask;
    float originalSize = 200;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
