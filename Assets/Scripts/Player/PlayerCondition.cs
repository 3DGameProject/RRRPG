using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition Hp { get { return uiCondition.Hp; } }
    Condition Mp { get { return uiCondition.Mp; } }

    // when collision is true
    public float getLarger = 10;
    public float getHeavier = 10;
    public bool isCollision = false;

    void Update()
    {
        Hp.Subtract(Hp.passiveValue * Time.deltaTime);

        if (Hp.curValue <= 0.0f)
        {
            GameManager.Instance.GameOver();
        }

        if(isCollision == true)
        {
            Hp.Add(getLarger);
            Mp.Add(getHeavier);
        }
    }
}