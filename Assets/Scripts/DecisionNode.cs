using UnityEngine;

[CreateAssetMenu(fileName = "New Decision Node", menuName = "Decision/Decision Node")]
public class DecisionNode : ScriptableObject
{
    [TextArea(3, 6)]
    public string description;

    //Hijo izquierdo
    public string option1Text;
    public DecisionNode option1Next;
    
    //Hijo derecho
    public string option2Text;
    public DecisionNode option2Next;
}