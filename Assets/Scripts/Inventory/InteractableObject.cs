using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    [SerializeField] string noum;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] Interaction[] interactions;

    public string Noum { get { return noum; } }
    public string Description { get { return description; } }
    public ReadOnlyCollection<Interaction> Interactions { get { return new ReadOnlyCollection<Interaction>(interactions); } }
}
