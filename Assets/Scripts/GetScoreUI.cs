using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreUI : MonoBehaviour
{
    public TextMeshProUGUI CountScoreText;

    private void Update()
    {
        CountScoreText.text = GameManager.Instance.scoreToCash.ToString();
    }
}