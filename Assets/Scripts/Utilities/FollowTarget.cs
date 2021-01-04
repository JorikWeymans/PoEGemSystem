//Created by Jorik Weymans 2020

using UnityEngine;

namespace Jorik.Utilities
{
	public sealed class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform _Target = null;
        [SerializeField] private Vector3 _Distance = default;

        private void Awake() =>_Distance = transform.position - _Target.position;
        private void LateUpdate() => transform.position = _Target.position + _Distance;
    }
}

