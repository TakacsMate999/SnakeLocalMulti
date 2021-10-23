using System.Collections;
using UnityEngine;

namespace Assets
{
    public class Tail : Cell
    {
        public Cell Source;
        public static Tail Instance { get; private set; }

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
        public void Move()
        {
            Current = new MovementData(Source.Previous.Movement, Source.Previous.Rotation);
            base.Move();
        }
    }
}