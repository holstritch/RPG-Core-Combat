using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Core
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float weaponRange = 2f;
        [SerializeField] private float timeBetweenAttacks = 1f;
        [SerializeField] private float weaponDamage = 5f;
        
        private Health _target;
        private Mover _mover;
        private Animator _animator;
        
        private float timeSinceLastAttack = Mathf.Infinity;

        private void Start()
        {
            _mover = GetComponent<Mover>();
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            
            // null ref check so movement is only cancelled if we have a target and are fighting
            if (_target == null) return;
            if (_target.IsDead()) return;
            
            if (!IsInRange())
            {
                _mover.MoveTo(_target.transform.position);
            }
            else
            {
                _mover.Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(_target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                TriggerAttack();
                timeSinceLastAttack = 0;
            }

        }

        private void TriggerAttack()
        {
            _animator.ResetTrigger("stopAttack");
            // triggers Hit() when in range
            _animator.SetTrigger("attack");
        }

        // animation event
        void Hit()
        {
            if (_target == null) return;
            _target.TakeDamage(weaponDamage);
        }
        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, _target.transform.position) < weaponRange;
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;
            
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }
        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            _target = combatTarget.GetComponent<Health>();

        }

        public void Cancel()
        {
            StopAttack();
            _target = null;
        }

        private void StopAttack()
        {
            _animator.ResetTrigger("attack");
            _animator.SetTrigger("stopAttack");
        }
    }
}

