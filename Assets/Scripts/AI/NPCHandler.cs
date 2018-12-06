using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KingdomGates
{
    public class NPCHandler : MonoBehaviour
    {
        public float npcSpeed = 10;
        public int npcMaxHealth = 1;
        public bool npcAlive;
        public int npcDmg = 25;
        public bool doDMG;
        
        public int npcHealth = 1;





        public void OnTriggerEnter(Collider other)
        {
            // If enemy touches player
            if (other.gameObject.tag == "Player")
            {
                // Access player health
                CharHandler playerHealth = other.GetComponent<CharHandler>();
                if (playerHealth != null && !(other.GetComponent<PlayerController>().moveSpeed >= 30))
                {
                    // Player lose health
                    playerHealth.TakeDamage(npcDmg);
                    Debug.Log("Player takes damage and the guy doesn't know how to right debugs");
                }

                //DealDamage(npcDmg);
            }
        }

        private void NPCDeath()
        {

        }
        public void DealDamage(int npcDmg)
        {

        }
        public void TakeDMG(int playerDMG, BoxCollider playerBoxCollider)
        {
            npcMaxHealth -= playerDMG;
        }
    }
}