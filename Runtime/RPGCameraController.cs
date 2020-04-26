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

        private Vector3 targetPos;
        private Quaternion targetRot;

        // Update is called once per frame
        void Update()
        {
            moveWithTarget();
            lookAtTarget();
        }

        private void moveWithTarget()
        {
            targetPos = target.position + offset;
            transform.position = Vector3.Slerp(transform.position, targetPos, movingSpeed * Time.deltaTime);
        }

        private void lookAtTarget()
        {
            targetRot = Quaternion.LookRotation(target.position, transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotatingSpeed * Time.deltaTime);
        }
    }

}
