#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } // ENCAPSULATION
    public bool isGameActive { get; private set; }// ENCAPSULATION
    [SerializeField] private GameObject _endScreen,
                                        _startScreen,
                                        topScoreParent,
                                        _player;
    [SerializeField] private float startTime,
                                   endTime;
    [SerializeField] private Text timeSurvivedText,
                                  topResultText;
    private void Awake()
    {
        if (GameController.Instance!=null)
        {
           Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetGameState(bool val)
    {
        isGameActive = val;
        if (!val)
        {
            GameEnded();
        }
        else
        {
            GameStarted();
        }
    }

    private void GameEnded()
    {
        _endScreen.SetActive(true);
        topScoreParent.SetActive(true);
        endTime=Time.time;
        var result = (int) (endTime - startTime);
        timeSurvivedText.text =""+result ;
        DataContainer.Instance.CheckGameResult(result);
        UpdateStartTopScore();
    }

    private void GameStarted()
    {
        _startScreen.SetActive(false);
        topScoreParent.SetActive(false);
        Difficulty.SetLevelStartTime();
        startTime = Time.time;
        endTime = 0;
        PoolController.Instance.Hide();
        _player.transform.position = new Vector3(0, _player.transform.position.y, _player.transform.position.z);
        _player.SetActive(true);  
    }

    public void Restart()
    {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       _endScreen.SetActive(false);
       topScoreParent.SetActive(false);
       Difficulty.SetLevelStartTime();
       SetGameState(true);
    }

    public void ToMenu()
    {
        _endScreen.SetActive(false);
        _startScreen.SetActive(true);
        PoolController.Instance.Hide();
        _player.SetActive(true);
    }

    public void UpdateStartTopScore()
    {
        topScoreParent.SetActive(true);
        topResultText.text = DataContainer.Instance.NameFromJson + " " +
                             DataContainer.Instance.ScoreFromJson;
    }
    
    public void Exit()
    {
        MainManager.Instance.SaveColor(); 
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
