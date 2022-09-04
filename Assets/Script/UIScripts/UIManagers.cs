using UnityEngine;

// ���� UI�� ��� �����ϰ� ������ �� �ֵ��� �ϴ� UI �Ŵ���

namespace UIScripts
{
    public class UIManagers : MonoBehaviour
    {
        public static UIManagers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<UIManagers>();
                }
                return instance;
            }
        }

        private static UIManagers instance;

        public void pauseGame()
        {
            Time.timeScale = 0f;
        }
        public void ResumeGame()
        {
            Time.timeScale = 1f;
        }

        public void OnClickQuit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}