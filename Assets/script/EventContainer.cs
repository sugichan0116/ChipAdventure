using My.GameSystem.Event;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer : MonoBehaviour, IContainer<IEvent>
{
    [SerializeField]
    private List<GameObject> events;
    [SerializeField]
    private IEvent test;

    public IEvent this[int index] => events?[index].GetComponent<IEvent>();

    public int Count => events.Count;

    public IEvent Random() => this[UnityEngine.Random.Range(0, Count)];
}
