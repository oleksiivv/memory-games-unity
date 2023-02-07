using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static int lastShowedQuestion = - 1;

    public List<Question> questions;

    public int levelNumber;

    private int currentQuestionId;

    public List<Text> ShuffleAnswers(List<Text> answers){
        List<Vector3> positions = new List<Vector3>();

        var answersNew = new List<Text>();

        foreach(var answer in answers){
            positions.Add(answer.GetComponent<RectTransform>().localPosition);
        }
        
        foreach(var answer in answers){
            int n = Random.Range(0, positions.Count);
            var position = positions[n];

            answer.GetComponent<RectTransform>().localPosition = position;

            answersNew.Add(answer);

            positions.RemoveAt(n);
        }

        return answersNew;
    }

    public bool CheckAnswer(int answer){
        bool result = questions[currentQuestionId].correctVariantId == answer;

        if(result){
            this.SetLevelIsCompleted(1);
        }

        return result;
    }

    public Question GetQuestion(){
        currentQuestionId = GetRandomNumber(0, questions.Count, lastShowedQuestion);

        return questions[currentQuestionId];
    }

    public int LevelIsCompleted(){
        return DBController.GetLevelIsCompleted(levelNumber);
    }

    private int GetRandomNumber(int from, int to, int exclude){
        int randomNumber = Random.Range(from, to);

        if(randomNumber == exclude){
            randomNumber = GetRandomNumber(from, to, exclude);
        }

        lastShowedQuestion = randomNumber;

        return randomNumber;
    }

    private void SetLevelIsCompleted(int completed){
        DBController.SetLevelIsCompleted(levelNumber, completed);
    }
}
