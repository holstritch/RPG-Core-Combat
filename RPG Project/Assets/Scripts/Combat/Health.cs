using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        public float health = 100f;

        private bool isDead = false;

        // public method so other classes can access bool variable
        public bool IsDead()
        {
            return isDead;
        }
        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            print(health);

            if (health == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;
            
            GetComponent<Animator>().SetTrigger("die");
            isDead = true;
        }
    }
}

