using UnityEngine;

namespace Assets.Scripts
{
    public class Flag : MonoBehaviour
    {
        public float RotSpeed = 60; // degrees per second
        private PlayerController _playerController;

        readonly float amplitudeY = 0.2f;
        readonly float omegaY = .01f;
        float _index;
        private float _growIndex = 1f;

        void Start()
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }


        void Update()
        {
            if (_playerController.Points == _playerController.MaxPoints)
            {
                transform.Rotate(0, RotSpeed * Time.deltaTime, 0, Space.World);
                _index += Time.deltaTime;

                transform.localScale = new Vector3(_growIndex, _growIndex * .5f, _growIndex);
                if (_growIndex < 1.5f)
                {
                    _growIndex += .01f;
                }
            }
        }
    }
}