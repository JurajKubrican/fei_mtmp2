using UnityEngine;

namespace Assets.Scripts
{
    public class Flag : MonoBehaviour
    {
        public float RotSpeed = 60; // degrees per second
        private PlayerController _playerController;

        readonly float amplitudeY = 0.2f;
        readonly float omegaY = 1.0f;
        float _index;
        private float _growIndex = 1f;
        private Vector3 _initial;

        void Start()
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            _initial = transform.position;
        }


        void Update()
        {
            if (_playerController.Points == _playerController.MaxPoints)
            {
                transform.Rotate(0, RotSpeed * Time.deltaTime, 0, Space.World);
                _index += Time.deltaTime;
                _initial.y = amplitudeY * Mathf.Sin(omegaY * _index) + .6f;
                transform.localPosition = _initial;

                transform.localScale = new Vector3(_growIndex, _growIndex * .5f, _growIndex);
                if (_growIndex < 1.5f)
                {
                    _growIndex += .01f;
                }
            }
        }
    }
}