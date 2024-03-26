using System.Collections;
using System.Collections.Generic;



    public enum NodeState
    {
        Running,
        Success,
        Failure
    }
    public abstract class Node
    {
        //define Node state
        protected NodeState state;
        public NodeState nodeState { get { return state; } }
        public abstract NodeState Evaluate();
    }


