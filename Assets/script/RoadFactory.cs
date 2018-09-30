using My.Behaviour.Chip;
using System.Collections.Generic;
using UnityEngine;

public class RoadFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject road;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = road.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecorateRoad(ChipBehaviour c)
    {
        Vector3 pos = c.transform.position;

        foreach (var target in c.NextPositions())
        {
            Vector3 dist = target - pos;
            var points = new List<Vector3>();

            points.Add(pos);
            if (dist.z != 0 && dist.x != 0)
            {
                points.Add(pos + new Vector3(dist.x/2, 0, 0));
                points.Add(pos + new Vector3(dist.x/2, 0, dist.z));
            }
            points.Add(target);

            AddRoads(c, points);
        }
    }

    private void AddRoads(ChipBehaviour c, List<Vector3> points)
    {
        for (int i = 0, h = points.Count - 1; i < h; i++)
        {
            CreateRoad(points[i], points[i+1]).transform.parent = c.transform;
        }
    }

    private GameObject CreateRoad(Vector3 a, Vector3 b)
    {
        Vector3 dr = b - a, scale = new Vector3(origin.z, origin.y, origin.z);
        GameObject r = Instantiate(road);

        if (dr.z == 0) scale.x = dr.x * origin.x;
        if (dr.x == 0) scale.z = dr.z * origin.x;
        r.transform.position = (a + b) / 2;
        r.transform.localScale = scale;
        return r;
    }
}
