using System.Collections;
using UnityEngine;

namespace Assets
{
    public class Tail_move : Move
    {
        public Move Source;
        public static Tail_move Instance { get; private set; }

        // Use this for initialization
        void Start()
        {

        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        // Update is called once per frame
        override
        public void Act()
        {
            Curr = new MovementData(Source.Prev.Position, Source.Prev.Rotation);
            base.Act();
        }
    }
}