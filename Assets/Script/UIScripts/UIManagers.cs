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


        public GameObject GameOverUI;
        
        //���� ������ Ȱ��ȭ�Ǵ� UI

        // ���ӿ��� UI Ȱ��ȭ
        public void SetActiveGameoverUI(bool active)
        {
            GameOverUI.SetActive(active);
        }

        public void pauseGame()
        {
            Time.timeScale = 0f;
        }
        public void ResumeGame()
        {
            Time.timeScale = 1f;
        }


        // ���� ����� ��ư
        /* public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   */

        // ���� ���� ��ư
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