using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public Text scoreText;
    public RectTransform clickableArea; // 클릭 가능한 영역을 지정할 RectTransform

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
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // 클릭 위치가 클릭 가능한 영역 내에 있는지 확인
        if (RectTransformUtility.RectangleContainsScreenPoint(clickableArea, mousePosition, Camera.main))
        {
            score += clickPower;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        GameManager.Instance.scoreToCash = score;
        scoreText.text = score.ToString();
    }
}
