using System;
using System.Collections;
using Game.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.SceneManagment
{
    public class SceneLoader : MonoBehaviour
    {
        private const string FADER_PATH = "SceneLoader";

        public static SceneLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    SceneLoader prefab = Resources.Load<SceneLoader>(FADER_PATH);
                    _instance = Instantiate(prefab);
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }

        private static SceneLoader _instance;

        private bool _isLoading;

        public void LoadNextScene()
        {
            Load(GetSceneName(GetSceneIndex() + 1));
        }

        public void LoadPreviousScene()
        {
            Load(GetSceneName(GetSceneIndex() - 1));
        }

        public void Load(string sceneName)
        {
            if (_isLoading == true)
                return;

            string currentSceneName = SceneManager.GetActiveScene().name;

            if (currentSceneName == sceneName)
                throw new Exception("You are tring to load an already opened scene.");

            StartCoroutine(LoadSceneCoroutine(sceneName));
        }

        public string GetSceneName()
        {
            return GetSceneName(GetSceneIndex());
        }

        public string GetSceneName(int index)
        {
            return SceneManager.GetSceneByBuildIndex(index).name;
        }

        public int GetSceneIndex()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }

        public int GetSceneIndex(string sceneName)
        {
            return SceneManager.GetSceneByName(sceneName).buildIndex;
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            _isLoading = true;

            bool isWaitingForFading = true;
            Fader.Instance.FadeIn(() => isWaitingForFading = false);

            while (isWaitingForFading == true)
                yield return null;

            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)
            {
                yield return null;
            }

            async.allowSceneActivation = true;

            isWaitingForFading = true;
            Fader.Instance.FadeOut(() => isWaitingForFading = false);

            while (isWaitingForFading == true)
                yield return null;

            _isLoading = false;
        }
    }
}
