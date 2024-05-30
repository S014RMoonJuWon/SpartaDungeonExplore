using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemDataSO data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract() // ������ ��ȣ�ۿ�
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.interact?.Invoke();

        switch (data.type)
        {
            case ItemType.Usable:
                UseItem();
                break;
            case ItemType.Stuff:
                break;
        }
    }

    private void UseItem() // displayName ���� �޼ҵ� �ߵ�
    {
        PlayerCondition condition = CharacterManager.Instance.Player.condition;
        switch (data.displayName)
        {
            case "���͸�":
                condition.AddSpeed(5.0f, 5.0f);
                break;
            case "ħ��":
                condition.Heal(20);
                break;
            case "��ǻ��":
                condition.Die();
                break;
            default:
                break;
        }
    }
}
