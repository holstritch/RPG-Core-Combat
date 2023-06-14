using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using UnityEngine;


namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        
        [SerializeField] private float chaseDistance = 5f;

        private GameObject _player;
        private Fighter _fighter;
        private Health _health;
        private Mover _mover;

        private Vector3 _guardPosition;
        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _fighter = GetComponent<Fighter>();
            _health = GetComponent<Health>();
            _mover = GetComponent<Mover>();

            _guardPosition = transform.position;
        }

        private void Update()
        {
            if (_health.IsDead()) return;
            
            if (InAttackRangeOfPlayer() && _fighter.CanAttack(_player))
            {
                _fighter.Attack(_player);
            }
            else
            {
                // this method also cancels fighting
                _mover.StartMoveAction(_guardPosition);
                
            }
                
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        // called by unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}

