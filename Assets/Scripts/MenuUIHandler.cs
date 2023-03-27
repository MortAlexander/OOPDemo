#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPickerBG;
    public ColorPicker ColorPickerPlayer;
    public ColorPicker ColorPickerObstacle;

    public SpriteRenderer Player;
    public SpriteRenderer Obstacle1;
    public SpriteRenderer Obstacle2;
    public void NewColorSelectedBG(Color color)
    {
        MainManager.Instance.BGColor = color;
        Camera.main.backgroundColor = ColorPickerBG.SelectedColor;
    }
    public void NewColorSelectedPlayer(Color color)
    {
        MainManager.Instance.PlayerColor = color;
        Player.color = ColorPickerPlayer.SelectedColor;
    }public void NewColorSelectedObstacle(Color color)
    {
        MainManager.Instance.ObstacleColor = color;
        Obstacle1.color = ColorPickerObstacle.SelectedColor;
        Obstacle2.color = ColorPickerObstacle.SelectedColor;
        PoolController.Instance.ChangeColor(color);
    }
    private void Start()
    {
        ColorPickerBG.Init();
        ColorPickerBG.onColorChanged += NewColorSelectedBG;
        ColorPickerBG.SelectColor(MainManager.Instance.BGColor);
        
        ColorPickerPlayer.Init();
        ColorPickerPlayer.onColorChanged += NewColorSelectedPlayer;
        ColorPickerPlayer.SelectColor(MainManager.Instance.PlayerColor);
        
        ColorPickerObstacle.Init();
        ColorPickerObstacle.onColorChanged += NewColorSelectedObstacle;
        ColorPickerObstacle.SelectColor(MainManager.Instance.ObstacleColor);
    }
    
    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }

   // public void LoadColorClicked()
   // {
   //     MainManager.Instance.LoadColor();
   //     ColorPickerBG.SelectColor(MainManager.Instance.BGColor);
   //     ColorPickerPlayer.SelectColor(MainManager.Instance.PlayerColor);
   //     ColorPickerObstacle.SelectColor(MainManager.Instance.ObstacleColor);
   // }
}
