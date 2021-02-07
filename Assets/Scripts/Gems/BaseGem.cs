//Created by Jorik Weymans 2020

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

    public enum GemAttribute
    {
        Strength,
        Dexterity,
        Intelligence
    }
	public sealed class BaseGem : MonoBehaviour
    {
        [SerializeField] private string _Name = "Name";
        [SerializeField] private uint _ManaCost = 0;
        [SerializeField] private string _Description = "Description";
        [SerializeField] private GemState _State = GemState.CharacterInventory;
        [SerializeField] private GemAttribute _Attribute = GemAttribute.Intelligence;


        private void Update()
        {
            switch (_State)
            {
                case GemState.CharacterInventory:
                    break;
                case GemState.Cursor:
                {
                    transform.position = new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue());
                }
                    break;
                case GemState.SkillInventory:
                {

                }
                    break;
                case GemState.OntheGround:
                    throw new NotImplementedException("BaseGem::_State::OnTheGround");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

