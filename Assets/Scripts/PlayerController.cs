using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public float Speed = 14;
        private Rigidbody _rb;
        private Camera _camera;
        private AudioSource _coinSound;
        private AudioSource _music;
        public int Points = 0;
        public int MaxPoints;

        public TextMeshProUGUI CountText;


        // Use this for initialization
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _camera = Camera.main;
            AudioSource[] cameraAudioSources = _camera.GetComponents<AudioSource>();

            _music = cameraAudioSources[0];
            _coinSound = cameraAudioSources[1];

            if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
            {
                return;
            }

            MaxPoints = GameObject.FindGameObjectsWithTag("Coin").Length;
            CountText.SetText(Points + "/" + MaxPoints);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_rb.velocity.magnitude < 10)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");
                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                _rb.AddForce(movement * Speed);
            }

            if (Input.GetKeyDown("m"))
            {
                if (_music.isPlaying)
                {
                    _music.Stop();
                }
                else
                {
                    _music.Play();
                }
            }
        }


        void OnTriggerEnter(Collider other)
        {
            
            if (other.tag == "Coin")
            {
                Debug.Log(gameObject.name);
                Debug.Log(other.name);
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
                _coinSound.Play();
                Points++;
                CountText.SetText(Points + "/" + MaxPoints);
            }
            else if (other.tag == "Finish")
            {
                if (Points >= MaxPoints)
                {
                    GameObject.FindGameObjectWithTag("UI").GetComponent<PauseMenu>().Win();
                }
            }
        }


   
    }
}