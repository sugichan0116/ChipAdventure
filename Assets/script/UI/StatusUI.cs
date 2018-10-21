using UnityEngine;
using My.GameSystem.Charactor;
using My.GameSystem.Status;
using UniRx;
using My.GameSystem.Parameter;
using System.Collections.Generic;

namespace My.UI
{
    public class StatusUI : MonoBehaviour
    {
        [SerializeField]
        private Player player;
        private ICharactor target;
        [SerializeField]
        private ParameterBehaviour gaugeParameter, parameter;

        private ReactiveProperty<IStatus> status;
        private Dictionary<IParameter, ParameterBehaviour> list;

        //きもいので必ず修正しましょう！
        void Start()
        {
            Init((player as ICharactorable).Charactor);
        }

        public void Init(ICharactor target)
        {
            status = new ReactiveProperty<IStatus>(target.Status);
            list = new Dictionary<IParameter, ParameterBehaviour>();

            foreach (var key in status.Value.Keys())
            {
                list.Add(status.Value[key], CreateParameter(status.Value[key]));
            }

            status.Subscribe(status => {
                Debug.Log("ohho!!!" + status);
                foreach (var key in status.Keys())
                {
                    UpdateParameter(status[key]);
                }
            });
        }
        
        private void UpdateParameter(IParameter p)
        {
            if(list.ContainsKey(p) == false)
            {
                list.Add(p, CreateParameter(p));
            }
        }

        private ParameterBehaviour CreateParameter(IParameter p)
        {
            ParameterBehaviour pb;
            if (p is IGauge g)
            {
                pb = Instantiate(gaugeParameter);
                pb.GetComponentInChildren<GaugeBehaviour>().SetGauge(g);
            }
            else pb = Instantiate(parameter);

            pb.transform.SetParent(transform);
            pb.SetParameter(p);
            return pb;
        }
    }
}