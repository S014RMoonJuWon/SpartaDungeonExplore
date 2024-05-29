using System.Collections;
using System.Collections.Generic;
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
        return "";
    }

    public void OnInteract()
    {
        
    }
}
