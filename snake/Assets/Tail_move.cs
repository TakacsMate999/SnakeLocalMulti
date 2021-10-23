using System.Collections;
using UnityEngine;
using _snake;

namespace Assets
{
    public class Tail_move : Move
    {

        int time = 0;
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
        protected void Update()
        {
            time++;
            if (time % 100 == 0)
            {
                Prev = Curr;
                //Valamiért a Prev-el egyel lemarad az előtte lévő szegmenstől
                Curr = new MovementData(Source.Curr.Position, Source.Curr.Rotation);
                base.Update();
            }
        }
    }
}