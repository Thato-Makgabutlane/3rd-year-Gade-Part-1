using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Inverter : Node
    {
        protected Node invertNode;

        public Inverter(Node invertNode)
        {
            this.invertNode = invertNode;
        }

        public override NodeState Evaluate()
        {
            if (invertNode.Evaluate() == NodeState.Running)
            {
                state = NodeState.Running;
            }
            else if (invertNode.Evaluate() == NodeState.Success)
            {
                state = NodeState.Failure;
            }
            else if (invertNode.Evaluate() == NodeState.Failure)
            {
                state = NodeState.Success;
            }
            return state;
        }
    }

