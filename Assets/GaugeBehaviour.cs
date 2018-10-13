using My.GameSystem.Parameter;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBehaviour : MonoBehaviour
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private Image image;
    [SerializeField]
    private float volume;
    [SerializeField]
    private Vector2 pivot;
    private IGauge gauge;

    // Start is called before the first frame update
    void Start()
    {
        image.color = color;
        RectTransform rect = GetComponent<RectTransform>();
        rect.pivot = pivot;
        rect.sizeDelta = new Vector2(volume, 10);
        gauge = new Gauge("HP", 100, 0, 200);
        GetComponent<Slider>().value = gauge.NormalizedValue;
    }
}
