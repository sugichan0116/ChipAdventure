using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableContainer : MonoBehaviour, IContainer<GameObject>
{
    [SerializeField]
    private List<GameObject> tables;

    public GameObject this[int index]
    {
        get
        {
            return tables?[index];
        }
    }

    public int Count => tables.Count;

    public GameObject Random() => this[UnityEngine.Random.Range(0, Count)];
}
