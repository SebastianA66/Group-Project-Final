using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KingdomGates
{
    public class PlayerController : MonoBehaviour
    {
        public bool rotateToMainCamera = false;
        public Transform weapon;
        public float moveSpeed = 10f;
        public float startSpeed = 10f;
        public float jumpheight = 10f;
        public Rigidbody rigid;
        private bool isGrounded = true;
        public float RayDistance = 1f;
        public Animator animReference;

        
        private void OnDrawGizmos()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);

            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * RayDistance);
        }

        bool IsGrounded()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(groundRay, out hit, RayDistance)) // cast a line beneath th player
            {
                return true; // is grounded so return true
            }
            return false; // is not grounded so return false
        }


        // Use this for initialization 
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float inputH = Input.GetAxis("Horizontal") * moveSpeed;
            float inputV = Input.GetAxis("Vertical") * moveSpeed;
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) //Are we running?
            {
                animReference.SetBool("CanRun", true);      //Are we running?
            }
            else //Did we stop running?
            {
                animReference.SetBool("CanRun", false);     //Go back to idle
            }
            Vector3 moveDir = new Vector3(inputH, 0f, inputV);
            Vector3 camEuler = Camera.main.transform.eulerAngles;
            if (rotateToMainCamera)
            {
                moveDir = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDir;
            }


            Vector3 force = new Vector3(moveDir.x, rigid.velocity.y, moveDir.z);



            if (Input.GetButton("Jump") && IsGrounded())
            {
                force.y = jumpheight;
            }

            rigid.velocity = force;
        }

    }
}
