using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class UiController : MonoBehaviour
{
    [SerializeField] private PlayerCreator _playerCreator;
    [SerializeField] private Text _points;
    [SerializeField] private Text _savePoints;
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private GameObject _startGamePanel;
     private  float PointsCount = 0f;
     public static Conditions Condition;
     private Points points;
     
    private void OnEnable() 
     {
        LoadFile();
     }
     private void KeepDelayBeforeRestart()
     {
        Condition = Conditions.Game;
     }
    private void OnDisable()
      {
        SaveField();
      }


   private void Update() 
    {    
       ShowPoints();
       SetScene(1,false,false, Conditions.Game);
       SetScene(0,false,true, Conditions.StartGame);
       SetScene(0,true, false, Conditions.EndGame);
    }

   public void OnClickStart()
    {
       Condition = Conditions.Game;   
    }
    

   public void Restart()
    {
       Condition = Conditions.Game;
      
    }

   public void ChangeLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       Condition = Conditions.StartGame;
       
    }
   private void ShowPoints()
    {
       PointsCount += Time.deltaTime;
       _points.text = PointsCount.ToString("00");
       _savePoints.text = points.Count.ToString("00");

       if(PointsCount >= points.Count)
       {
          points.Count = PointsCount;
          SaveField();
       }
    }
   private void SetScene(byte timeScale, bool endGameActive, bool startGameActive,Conditions condition)
    {
       if(Condition == condition)
         {
            Time.timeScale = timeScale;
            _endGamePanel.SetActive(endGameActive);
            _startGamePanel.SetActive(startGameActive);
        }
    }
    

   public void LoadFile()
    {
       points = JsonUtility.FromJson<Points>(File.ReadAllText(Application.streamingAssetsPath + "/Points.json"));
    }

   public void SaveField()
    {
        File.WriteAllText(Application.streamingAssetsPath + "/Points.json", JsonUtility.ToJson(points));
    }

 [System.Serializable] public class Points
    {
       public float Count;
    }
 }
 public enum Conditions
  {  
   StartGame,
   Game,
   EndGame
   }
