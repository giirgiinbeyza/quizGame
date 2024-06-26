using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]

public class Questions : ScriptableObject
{
    [System.Serializable]

    public class QuestionData
    {
        public string question = string.Empty;
        public bool isTrue = false;
        public bool questioned = false;
    }

    public int currentQuestion = 0;
    public List<QuestionData> questionsList;

    public void AddQuestion()
    {
        questionsList.Add(item: new QuestionData());
    }


}
