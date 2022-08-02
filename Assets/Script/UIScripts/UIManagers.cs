using UnityEngine;

// ���� UI�� ��� �����ϰ� ������ �� �ֵ��� �ϴ� UI �Ŵ���

namespace Script.UIScripts
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


        public GameObject GameOverUI; //���� ������ Ȱ��ȭ�Ǵ� UI

        // ���ӿ��� UI Ȱ��ȭ
        public void SetActiveGameoverUI(bool active)
        {
            GameOverUI.SetActive(active);
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