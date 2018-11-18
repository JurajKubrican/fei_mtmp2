using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMove : MonoBehaviour
    {
        public GameObject player;
        private Vector3 offset;
        private Vector3 dest;
        private float speed = 6f;

        void Start()
        {
            offset = new Vector3(0, 10, -8);
        }

        void LateUpdate()
        {
//        transform.position = player.transform.position + offset;


            dest = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, dest, speed * Time.deltaTime);
        }
    }
}