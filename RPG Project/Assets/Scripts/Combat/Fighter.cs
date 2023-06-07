using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
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
                _mover.Cancel();
            }
        }

        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, _target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            _target = combatTarget.transform;

        }

        public void Cancel()
        {
            _target = null;
        }
    }
}

