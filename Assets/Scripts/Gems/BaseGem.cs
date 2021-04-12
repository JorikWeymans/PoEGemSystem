//Created by Jorik Weymans 2021

using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

namespace Jorik
{
    //Used internally to define where the gem is e.x. Inventory, on cursor,
    public enum GemState
    {
        CharacterInventory,
        Cursor,
        SkillInventory,
        OntheGround
    }


	public class BaseGem : MonoBehaviour
    {
        [SerializeField] private GemData _Data = null;
        [SerializeField] private GemState _State = GemState.CharacterInventory;
        public GemState State
        {
            get => _State;
            set => _State = value;
        }

        public GemType Type => _Data.Type;

        [SerializeField] private bool _StartOnCursor = false;// Temporary while testing
        private void Start()
        {

            if(_StartOnCursor)
                Cursor.SetGem(this);
        }

        private void Update()
        {
            //Debug.Log(Mouse.current.position.ReadValue());
            switch (_State)
            {
                case GemState.CharacterInventory:
                    break;
                case GemState.Cursor:
                {
                    transform.position = new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue());

                    Vector3 screenPoint = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y);
                    screenPoint.z = 10.0f; //distance of the plane from the camera
                    transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
                    }
                    break;
                case GemState.SkillInventory:
                {

                }
                    break;
                case GemState.OntheGround:
                    throw new NotImplementedException("BaseGem::_State::OnTheGround");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

