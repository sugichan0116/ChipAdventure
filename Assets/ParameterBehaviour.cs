using My.GameSystem.Parameter;
using My.UI;
using UniRx;
using UnityEngine;

public class ParameterBehaviour : MonoBehaviour
{
    private TextGUI text;
    private IParameter para;
    
    void Awake()
    {
        text = transform.GetComponentInChildren<TextGUI>();
    }

    private void Update()
    {
        text?.SetText(para.ToString());
    }

    public void SetParameter(IParameter p) => para = p;
}
