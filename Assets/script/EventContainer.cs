using My.GameSystem.Event;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer : MonoBehaviour, IContainer<IChipEvent>
{
    [SerializeField]
    private List<GameObject> events;
    [SerializeField]
    private IChipEvent test;

    public IChipEvent this[int index] => events?[index].GetComponent<IChipEvent>();

    public int Count => events.Count;

    public IChipEvent Random() => this[UnityEngine.Random.Range(0, Count)];
}
