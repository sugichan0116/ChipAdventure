using My.Behaviour.Chip;
using System.Collections.Generic;
using UnityEngine;

interface IContainer<T>
{
    T this[int index] { get; }
    int Count { get; }
}

public class ChipsetContainer : MonoBehaviour, IContainer<ChipSet>
{
    [SerializeField]
    private List<ChipSet> blueprints;

    public ChipSet this[int index]
    {
        get
        {
            return blueprints?[index];
        }
    }

    public int Count => blueprints.Count;

    public ChipSet Random() => this[UnityEngine.Random.Range(0, Count)];
}
