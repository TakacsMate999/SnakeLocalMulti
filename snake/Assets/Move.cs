using System.Collections;
using UnityEngine;

namespace Assets
{
    public class Move : MonoBehaviour
    {
        public MovementData Curr = new MovementData(new Vector3(0, 0, 0), new Vector3(-90, 0, 0));
        public MovementData Prev = new MovementData(new Vector3(0, 0, 0), new Vector3(-90, 0, 0));

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        public virtual void Act()
        {
            gameObject.transform.position = new Vector3(
               gameObject.transform.position.x + Curr.Position.x,
               gameObject.transform.position.y + Curr.Position.y,
               gameObject.transform.position.z + Curr.Position.z
               );
            gameObject.transform.eulerAngles = Curr.Rotation;

        }
    }
}