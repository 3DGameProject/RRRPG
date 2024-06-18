using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition Hp { get { return uiCondition.Hp;  } }
    Condition Mp { get { return uiCondition.Mp; } }

}