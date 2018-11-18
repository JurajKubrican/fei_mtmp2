using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        private GameObject _winGameObject;
        private GameObject _pauseGameObject;
        public bool IsWin = false;

        void Start()
        {
            gameObject.transform.Find("Panel").gameObject.SetActive(false);
            _winGameObject = gameObject.transform.Find("Panel").Find("Win").gameObject;
            _winGameObject.SetActive(IsWin);
            _pauseGameObject = gameObject.transform.Find("Panel").Find("Pause").gameObject;
        }

        void Update()
        {
            if (Input.GetKeyDown("escape") && !IsWin)
            {
                bool active = gameObject.transform.Find("Panel").gameObject.activeSelf;
                Time.timeScale = active ? 1 : 0;
                gameObject.transform.Find("Panel").gameObject.SetActive(!active);
            }
        }

        public void Resume()
        {
            gameObject.transform.Find("Panel").gameObject.SetActive(false);
            Time.timeScale = 1;
        }


        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        public void NextLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        public void Exit()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        public void Win()
        {
            Time.timeScale = 0;
            gameObject.transform.Find("Panel").gameObject.SetActive(true);
            IsWin = true;
            _winGameObject.SetActive(true);
            _pauseGameObject.SetActive(false);
        }
    }
}