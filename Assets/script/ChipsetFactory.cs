using My.Behaviour.Chip;
using System.Collections.Generic;
using UnityEngine;

public class ChipsetFactory : MonoBehaviour
{
    [SerializeField]
    private RoadFactory roadFactory;
    [SerializeField]
    private ChipFactory chipFactory;

    [SerializeField]
    private ChipsetContainer chipsetContainer;

    public ChipBehaviour Init()
    {
        //initial chip
        ChipBehaviour c = chipFactory.Create(new Vector3(0, 0, 2));
        BuildMapFrom(c);
        return c;
    }

    public void BuildMapFrom(ChipBehaviour origin)
    {
        BuildChipSet(origin, chipsetContainer.Random());
    }

    public void BuildChipSet(ChipBehaviour origin, ChipSet chipSet)
    {
        Debug.Log(chipSet);
        var instances = new Dictionary<int, ChipBehaviour>();
        build(0, origin);
        roadFactory.DecorateRoad(origin);

        void build(int i, ChipBehaviour source)
        {
            if (i >= chipSet.Count) return;

            //既に存在する時生成しない
            if (instances.ContainsKey(i))
            {
                source.PushNextChip(instances[i]);
                return;
            }

            (Vector2 location, string attr, List<int> content) = chipSet[i];

            ChipBehaviour self = chipFactory.CreateFrom(source, location);
            instances.Add(i, self);

            if (attr == "end") return;

            if (content.Count == 0) build(i + 1, self);
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

}
