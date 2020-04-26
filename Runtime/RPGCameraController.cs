using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PuiGame.RPGGameEngine
{
    [RequireComponent(typeof(Transform))]
    public class RPGCameraController : MonoBehaviour
    {

        [SerializeField]
        private Transform target;

        [SerializeField]
        private Vector3 offset = new Vector3(10, 10, 10);

        [SerializeField]
        private float movingSpeed = 10f;

        [SerializeField]
        private float rotatingSpeed = 5f;

        // Update is called once per frame
        void Update()
        {
            moveWithTarget();
            lookAtTarget();
        }

        private void moveWithTarget()
        {
            Vector3 finalPos = target.position + offset;
            Vector3 targetPos = Vector3.Slerp(finalPos, transform.position, movingSpeed * Time.deltaTime);
            transform.position += targetPos;
        }

        private void lookAtTarget()
        {
            Quaternion targetRot = Quaternion.LookRotation(target.position, transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, movingSpeed * Time.deltaTime);
        }
    }

}
