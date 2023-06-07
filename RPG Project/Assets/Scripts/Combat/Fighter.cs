using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float weaponRange = 2f;
        private Transform _target;
        private Mover _mover;

        private void Start()
        {
            _mover = GetComponent<Mover>();
        }

        void Update()
        {
            // null ref check so movement is only cancelled if we have a target and are fighting
            if (_target == null)
            {
                return;
            }
            if (!IsInRange())
            {
                _mover.MoveTo(_target.position);
            }
            else
            {
                _mover.Stop();
            }
        }

        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, _target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            _target = combatTarget.transform;

        }

        public void CancelTarget()
        {
            _target = null;
        }
    }
}

