using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PuiGame.RPGGameEngine
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {

        private NavMeshAgent navMeshAgent;

        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();

            // Register event hander to input controller;
            RPGInputController.onGroundSelected += OnDestinationSet;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnDestinationSet(Vector3 point)
        {
            Debug.Log("Destination is set: " + point.x + ": " + point.y + ": " + point.z);
            navMeshAgent.SetDestination(point);
        }
    }
}

