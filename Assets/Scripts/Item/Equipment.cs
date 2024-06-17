using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;

    private PlayerCondition condition;

    void Start()
    {
        condition = CharacterManager.Instance.Player.condition;
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && curEquip != null)
        {
            curEquip.OnAttackInput();
        }
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();
    }

    public void UnEquip()
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }
}