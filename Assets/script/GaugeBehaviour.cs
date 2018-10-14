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
    private float volume, max;
    [SerializeField]
    private Vector2 pivot;

    private IGauge gauge;
    private RectTransform rect;
    private Slider slider;
    
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        slider = GetComponent<Slider>();

        Init();
    }

    private void Init()
    {
        image.color = color;
        rect.pivot = pivot;
    }

    private void Update()
    {
        SetValue();
        SetWidth();
    }

    private void SetValue() => slider.value = gauge.NormalizedValue;

    private void SetWidth() => rect.sizeDelta = new Vector2(Mathf.Min(Width, max), 10);

    protected virtual float Width => Mathf.Log(gauge.Max) * 10 + 100;

    public void SetGauge(IGauge g) => gauge = g;
}
