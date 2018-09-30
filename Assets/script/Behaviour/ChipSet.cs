using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace My.Behaviour.Chip
{
    public class ChipSet : MonoBehaviour
    {
        [SerializeField]
        private Vector2Int locationRate = new Vector2Int(2, 2);
        [SerializeField]
        private List<Vector2Int> location;
        [SerializeField]
        private List<string> next;

        private void Start()
        {

        }
        
        public (Vector2Int, string, List<int>) this[int i]
        {
            get
            {
                var (attr, content) = ParseConfig(next[i]);
                return (
                    NormalizeLocation(location[i]), 
                    attr,
                    ParseContent(content)
                );
            }
        }
        
        public int Count { get => Math.Min(location.Count, next.Count); }

        private Vector2Int NormalizeLocation(Vector2Int origin)
        {
            return new Vector2Int(
                origin.x * locationRate.x, 
                origin.y * locationRate.y
            );
        }

        private (string, string) ParseConfig(string text)
        {
            var match = Regex.Match(text, @"(\[(?<attr>.*?)\])?(?<content>.*)");
            
            return (match.Groups["attr"]?.Value, match.Groups["content"]?.Value);
        }
        
        private List<int> ParseContent(string text)
        {
            var list = new List<int>();
            foreach (var item in text.Split(','))
            {
                if (int.TryParse(item, out int index))
                {
                    list.Add(index);
                }
            }

            Debug.Log($"{text}: {list.Count}");

            return list;
        }

    }

}
