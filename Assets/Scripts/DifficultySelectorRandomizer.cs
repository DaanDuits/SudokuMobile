using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultySelectorRandomizer : MonoBehaviour
{
    private const int maxSize = 9;
    [SerializeField] private int amountHidden = 9;
    private List<int> usedValues, unusedValues; 
    private List<Transform> children = new List<Transform>();

    void Start()
    {
        System.Random random = new System.Random();
        usedValues = new List<int>();
        unusedValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        for (int i = 0; i < maxSize; i++) 
        {       
            int randomNumber = unusedValues[random.Next(0, unusedValues.Count)];
            transform.GetChild(i).GetComponent<TMP_Text>().text = randomNumber.ToString();
            usedValues.Add(randomNumber);
            unusedValues.Remove(randomNumber);
        }

        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        for (int i = amountHidden;  i > 0; i--)
        {
            int randomTChild = random.Next(0, children.Count);
            children[randomTChild].GetComponent<TMP_Text>().text = "";
            children.Remove(children[randomTChild]);
        }
    }
}
