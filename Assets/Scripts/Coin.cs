using UnityEngine;

namespace Assets.Scripts
{
    public class Coin : MonoBehaviour
    {
        public float RotSpeed = 60; // degrees per second

        // Use this for initialization

        readonly float amplitudeY = 0.005f;
        readonly float omegaY = 1.0f;
        float _index;


        void Update()
        {
            transform.Rotate(0, RotSpeed * Time.deltaTime, 0, Space.World);
            _index += Time.deltaTime;
            
            Vector3 l = transform.localPosition;
            l.y += amplitudeY * Mathf.Sin(omegaY * _index);
            transform.localPosition = l;
        }
    }
}