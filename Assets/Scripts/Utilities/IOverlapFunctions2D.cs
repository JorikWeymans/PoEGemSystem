//Created by Jorik Weymans 2021

using UnityEngine;

namespace Jorik
{
    // if this is added to a MonoBehaviour it implements the built in functions (as intended)
    public interface IOverlapFunctions2D
    {
        void OnTriggerEnter2D(Collider2D coll);
        void OnTriggerExit2D(Collider2D coll);
        void OnTriggerStay2D(Collider2D coll);
    }
}