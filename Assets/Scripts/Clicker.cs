using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public Text scoreText;

    private int score = 0;
    private int clickPower = 10;

    private InputAction clickAction;

    void OnEnable()
    {
        clickAction = new InputAction(binding: "<Mouse>/leftButton");
        clickAction.Enable();

        clickAction.started += ctx => ClickButtonClicked();
    }

    void OnDisable()
    {
        clickAction.Disable();
    }

    void ClickButtonClicked()
    {
        score += clickPower;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = score.ToString(); 
    }
}
