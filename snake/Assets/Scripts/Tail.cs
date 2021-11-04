using System.Collections;
using UnityEngine;

namespace Assets
{
    public class Tail : Cell
    {
        public Cell Source;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        override
        public void Move()
        {
            Current = new MovementData(Source.Previous.Movement, Source.Previous.Rotation);
            base.Move();
        }

        //Elpusztítjuk az almát ha olyan helyre kerül ahol kígyó van
        private void OnTriggerEnter2D(Collider2D target)
        {
            if (target.tag == Tags.Apple)
            {
                Apple.createApple();
                Destroy(target.gameObject);
            }
        }
    }
}