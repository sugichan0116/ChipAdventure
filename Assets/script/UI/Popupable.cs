using UniRx;
using UnityEngine;

public class TranslateBehaviour : MonoBehaviour
{
    public virtual void SetStartPosition(Vector3 position)
    {

    }
    
    public virtual ReactiveProperty<bool> OnDispose { get; }

    public virtual bool IsStop() => false;
}

public class Popupable : TranslateBehaviour
{
    [SerializeField]
    private Vector3 translate;
    [SerializeField]
    private float speed;
    private Vector3 target, start;
    private bool isInit;
    private ReactiveProperty<bool> isDispose;

    public override void SetStartPosition(Vector3 position)
    {
        start = position;
        isInit = false;
        isDispose = new ReactiveProperty<bool>(false);
    }
    
    // Update is called once per frame
    void Update()
    {

        if (isInit)
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                target,
                speed * Time.deltaTime
            );
            
            if(!isDispose.Value) isDispose.Value = ((transform.localPosition - target).magnitude < 10f);
        }
        else
        {
            RectTransform t = GetComponent<RectTransform>();
            t.anchoredPosition = start;
            target = start + translate;
            isInit = true;
        }
    }

    public override ReactiveProperty<bool> OnDispose
    {
        get => isDispose;
    }

    public override bool IsStop()
    {
        return isDispose.Value;
    }
}
