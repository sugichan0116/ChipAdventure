using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolContainer : MonoBehaviour, IContainer<GameObject>
{
    [SerializeField]
    private List<GameObject> symbols;

    public GameObject this[int index] => symbols[index];

    public int Count => symbols.Count;

    public GameObject Random() => this[UnityEngine.Random.Range(0, Count)];
}
