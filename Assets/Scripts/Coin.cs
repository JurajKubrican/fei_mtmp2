using UnityEngine;

namespace Assets.Scripts
{
    public class Coin : MonoBehaviour
    {
        public float RotSpeed = 60; // degrees per second

        // Use this for initialization

        readonly float amplitudeY = 0.2f;
        readonly float omegaY = 1.0f;
        float _index;
        private Vector3 _initial;

        void Start()
        {
            _initial = transform.position;
        }


        void Update()
        {
            transform.Rotate(0, RotSpeed * Time.deltaTime, 0, Space.World);
            _index += Time.deltaTime;
            _initial.y = amplitudeY * Mathf.Sin(omegaY * _index) + .6f;
            transform.localPosition = _initial;
        }

    }
}