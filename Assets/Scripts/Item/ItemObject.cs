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

    public void OnInteract() // 아이템 상호작용
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

    private void UseItem() // displayName 비교후 메소드 발동
    {
        PlayerCondition condition = CharacterManager.Instance.Player.condition;
        switch (data.displayName)
        {
            case "배터리":
                condition.AddSpeed(5.0f, 5.0f);
                break;
            case "침대":
                condition.Heal(20);
                break;
            case "컴퓨터":
                condition.Die();
                break;
            default:
                break;
        }
    }
}
