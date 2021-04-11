//Created by Jorik Weymans 2020

using System.Net.Mime;
using UnityEngine;

namespace Jorik
{
    public enum GemAttribute
    {
        Strength,
        Dexterity,
        Intelligence
    }

    public enum GemType
    {
        Active,
        Support
    }

	[CreateAssetMenu(fileName = "new GemData", menuName = "GemData")]
	public class GemData : ScriptableObject
	{
        [SerializeField] private string _Name = "Name";
        [SerializeField] private uint _ManaCost = 0;
        [SerializeField] [TextArea(3,6)] private string _Description = "Description";
        [SerializeField] private GemAttribute _Attribute = default;
        [SerializeField] private GemType _Type = default;


        public string Name => _Name;
        public uint ManaCost => _ManaCost; 
        public string Description => _Description;
        public GemAttribute GemAttribute => _Attribute;
        public GemType Type => _Type;

    }
}

