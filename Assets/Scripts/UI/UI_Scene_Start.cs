using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Lobby : MonoBehaviour
{
    #region Field

    [Header("Buttons")]
    [SerializeField] private Button startBtn;

    #endregion

    #region Unity Flow

    private void Start()
    {
        startBtn.onClick.AddListener(OnStartGame);
    }

    #endregion

    #region OnClick

    // ���� ����
    private void OnStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}
