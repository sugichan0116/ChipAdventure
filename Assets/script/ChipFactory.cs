using My.Behaviour.Chip;
using System.Collections.Generic;
using UnityEngine;

public class ChipFactory : MonoBehaviour
{
    [SerializeField]
    private ChipPool chipPool;
    [SerializeField]
    private MapManager manager;
    [SerializeField]
    private RoadFactory roadFactory;

    [SerializeField]
    private List<ChipBehaviour> modelChips;
    [SerializeField]
    private List<ChipSet> blueprints;

    // Start is called before the first frame update
    void Start()
    {
    }

    public ChipBehaviour Init()
    {
        //initial chip
        ChipBehaviour c = CreateChip(new Vector3(0, 0, 2));
        BuildMapFrom(c);
        return c;
    }


    public void BuildMapFrom(ChipBehaviour origin)
    {
        BuildChipSet(origin, GetRandomChipSet());
    }

    private ChipSet GetRandomChipSet()
    {
        return blueprints[Random.Range(0, blueprints.Count)];
    }

    public void BuildChipSet(ChipBehaviour origin, ChipSet chipSet)
    {
        var instances = new Dictionary<int, ChipBehaviour>();
        build(0, origin);
        roadFactory.DecorateRoad(origin);

        void build(int i, ChipBehaviour source)
        {
            if (i >= chipSet.Count) return;

            //既に存在する時生成しない
            if(instances.ContainsKey(i))
            {
                source.PushNextChip(instances[i]);
                return;
            }

            (Vector2 location, string attr, List<int> content) = chipSet[i];

            ChipBehaviour self = CreateChipFrom(source, location);
            instances.Add(i, self);

            if (attr == "end") return;

            if(content.Count == 0) build(i + 1, self);
            else
            {
                foreach (var index in content)
                {
                    build(index, self);
                }
            }

            roadFactory.DecorateRoad(self);
        }
    }
    
    public ChipBehaviour CreateChipFrom(ChipBehaviour origin, Vector2 v)
    {
        Vector3 locate = origin.transform.position;
        locate.x += v.x;
        locate.z += v.y;
        ChipBehaviour c = CreateChip(locate);
        origin.PushNextChip(c);
        return c;
    }

    public ChipBehaviour CreateChip(Vector3 v)
    {
        GameObject c;
        c = Instantiate(modelChips[0].gameObject);
        c.transform.Translate(v);
        c.transform.parent = chipPool.transform;
        ChipBehaviour inner = c.GetComponent<ChipBehaviour>();
        inner.SetManager(manager);
        return inner;
    }
}
