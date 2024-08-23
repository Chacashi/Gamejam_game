using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "ScriptableObjects/QuestData", order = 2)]
public class QuestData : ScriptableObject
{
    [SerializeField] private bool[] Quetions = new bool[6];
    public void AddCorretAnswer(int index)
    {
        Quetions[index - 1] = true;
    }
}