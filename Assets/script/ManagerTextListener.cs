using My.UI;
using My.Util;
using UniRx;
using UnityEngine;

public class ManagerTextListener : MonoBehaviour
{
    [SerializeField]
    private string key;
    private MapManager manager;
    private TextPoolBehaviour pool;

    // Start is called before the first frame update
    void Start()
    {
        manager = Finder.WithTag<MapManager>("Manager");
        pool = GetComponent<TextPoolBehaviour>();

        if (manager) manager.OnTextChanged
             .Where(message => message.key == key)
             .Subscribe(message =>
             {
                 Debug.Log("pop");
                 pool.Create(message.locate, message.text);
             });
    }

}
