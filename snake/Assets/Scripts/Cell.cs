﻿using System.Collections;
using UnityEngine;

namespace Assets
{
    //Sejtek őse.
    //Ennek a move metódusával mozog az összes sejt, miután beállította az aktuális mozgás paramétereit.
    public class Cell : MonoBehaviour
    {
        //Következő mozgás paraméterei
        public MovementData Current = new MovementData(Movement.STOP, Direction.UP);
        //Előző mozgás paraméterei
        public MovementData Previous = new MovementData(Movement.STOP, Direction.UP);

        // Update is called once per frame
        //Elmozgatjuk és elforgatjuk a Current-nek megfelelő értékekkel
        public virtual void Move()
        {
            gameObject.transform.position = new Vector3(
               gameObject.transform.position.x + Current.Movement.x,
               gameObject.transform.position.y + Current.Movement.y,
               gameObject.transform.position.z + Current.Movement.z
               );
            gameObject.transform.eulerAngles = Current.Rotation;

        }
    }
}