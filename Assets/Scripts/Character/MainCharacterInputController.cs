//Created by Jorik Weymans 2020

using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace Jorik
{
	public sealed class MainCharacterInputController : MonoBehaviour
    {
        private NavMeshAgent _Agent = null;

        private void Awake()
        {
            _Agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
           // if (Input.GetMouseButtonDown(0))
           // {
           //     Vector3 mousePos = Input.mousePosition;
           //
           //     Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
           //
           //     Ray r = Camera.main.ScreenPointToRay(mousePos);
           //
           //     Physics.Raycast(r, out  RaycastHit hit);
           //
           //     if (hit.collider.gameObject.CompareTag("Ground"))
           //     {
           //         _Agent.SetDestination(hit.point);
           //
           //     }
           //
           //
           //
           // }
           //
        }
    }
}

