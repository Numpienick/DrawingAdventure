using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : SceneManagement
{
    public TextMeshProUGUI inkText;
    public TextMeshProUGUI levelCountText;

    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();

        string currentLevelName = SceneManager.GetActiveScene().name;
        int levelCount;
        int.TryParse(new string(currentLevelName.Replace("Level", string.Empty).ToCharArray()), out levelCount);
        levelCount += 1;
        levelCountText.SetText("Level " + levelCount);
    }
    void Update()
    {
        inkText.text = string.Format("{0}%", Mathf.FloorToInt(player.CalculateInk() * 100));
    }
}
