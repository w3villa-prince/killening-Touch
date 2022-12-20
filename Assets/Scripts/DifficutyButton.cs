using UnityEngine;
using UnityEngine.UI;

public class DifficutyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;

    // Start is called before the first frame update
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " WAs Click");
        gameManager.GameStart(difficulty);
    }
}
