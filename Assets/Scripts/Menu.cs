using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Menu : MonoBehaviour
    {
        private GameObject _mainGameObject;
        private GameObject _lsGameObject;

        void Start()
        {
            _mainGameObject = transform.Find("Main").gameObject;
            _lsGameObject = transform.Find("Levels").gameObject;
        }

        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        public void Credits()
        {
            SceneManager.LoadScene("Credits");
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void LevelSelect()
        {
            _lsGameObject.SetActive(true);
            _mainGameObject.SetActive(false);
        }

        public void BackToMain()
        {
            _lsGameObject.SetActive(false);
            _mainGameObject.SetActive(true);
        }

        public void LoadLevel(int level)
        {
            SceneManager.LoadScene(level);
        }

        void Update()
        {

            if (Input.GetKeyDown("escape"))
            {
                BackToMain();
            }
        }
    }
}