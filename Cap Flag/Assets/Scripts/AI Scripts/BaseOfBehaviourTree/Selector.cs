using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  
    public class Selector : Node
    {
        protected List<Node> childrenList = new List<Node>();

        public Selector(List<Node> childern)
        {
            this.childrenList = childern;
        }
        public override NodeState Evaluate()
        {
            foreach (Node child in childrenList)
            {
                
                if(child.Evaluate() == NodeState.Running)
                {
                   state = NodeState.Running;
                   return state;
                }
                else if (child.Evaluate() == NodeState.Success)
                {
                    state = NodeState.Success;
                    return state;
                }
                else if (child.Evaluate() == NodeState.Failure)
                {

                }
            }
            state = NodeState.Failure;
            return state;
        }
    }


