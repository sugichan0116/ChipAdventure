using UnityEngine;

public class TranslateBehaviour : MonoBehaviour
{
    public virtual void SetStartPosition(Vector3 position)
    {

    }
    public virtual bool IsStop()
    {
        return false;
    }
}

public class Popupable : TranslateBehaviour
{
    [SerializeField]
    private Vector3 translate;
    [SerializeField]
    private float speed;
    private Vector3 target;
    private Vector3 start;
    private bool isDestroy, isInit = false;

    public override void SetStartPosition(Vector3 position)
    {
        start = position;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        if (isInit)
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                target,
                speed * Time.deltaTime
            );
        }
        else
        {
            RectTransform t = GetComponent<RectTransform>();
            Debug.Log(t.anchoredPosition);
            t.anchoredPosition = start;
            target = start + translate;
            isInit = true;
        }
    }

    public override bool IsStop()
    {
        if (isDestroy == false) isDestroy = ((transform.localPosition - target).magnitude < 10f);
        return isDestroy;
    }
}
