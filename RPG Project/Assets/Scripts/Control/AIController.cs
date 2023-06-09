using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        
        [SerializeField] private float chaseDistance = 5f;

        private GameObject _player;
        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (DistanceToPlayer(_player) < chaseDistance)
            {
                print(gameObject.name + " should chase");
            }
                
        }

        private float DistanceToPlayer(GameObject player)
        {
            
            return Vector3.Distance(player.transform.position, transform.position);
        }
    }
}

