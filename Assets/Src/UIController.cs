using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Level level;

    public Text questionText;

    public List<Text> variantsText;

    public BaseUIController baseUIController;

    public int timeToShowLevel, timeToAnswer;

    public GameObject questionPanel;

    public GameObject timerPanel;

    public Text timerText;

    public Color32 timerColorDefault, timerColorWhenQuestionShowed, rightAnswerColor, wrongAnswerColor;

    void Awake(){
        questionPanel.SetActive(false);

        SetQuestionAndVariants();

        var animationTime = 1f;
        Invoke(nameof(ShowQuestionPanel), timeToShowLevel+animationTime);

        ChangeTimerTextColor(timerColorDefault);
        StartCoroutine(Timer(timeToShowLevel));
    }

    public void ChooseVariant(int variant){
        bool result = level.CheckAnswer(variant);

        if(result){
            variantsText[variant].GetComponent<Text>().color = rightAnswerColor;
            baseUIController.Win();
        } else {
            variantsText[variant].GetComponent<Text>().color = wrongAnswerColor;
            baseUIController.Lose();
        }

        StopAllCoroutines();
        CancelInvoke(nameof(ShowQuestionPanel));
        CancelInvoke(nameof(ShowAnswer));
    }

    public void SetQuestionAndVariants(){
        Question question = level.GetQuestion();

        variantsText = level.ShuffleAnswers(variantsText);

        for(int i=0; i<question.variants.Count; i++){
            variantsText[i].text = question.variants[i];
        }

        questionText.text = question.question;
    }

    private void ShowQuestionPanel(){
        questionPanel.SetActive(true);
        timerText.gameObject.SetActive(false);
        ChangeTimerTextColor(timerColorWhenQuestionShowed);

        var delay=1.5f;

        Invoke(nameof(ShowAnswer), timeToAnswer+delay);
        Invoke(nameof(RestartTimer), delay);
    }

    private void RestartTimer(){
        timerText.gameObject.SetActive(true);
        
        StopAllCoroutines();
        StartCoroutine(Timer(timeToAnswer));
    }

    private void ShowAnswer(){
        questionPanel.SetActive(false);

        baseUIController.Lose();
    }

    private void ChangeTimerTextColor(Color32 color){
        timerText.GetComponent<Text>().color = color;
    }

    IEnumerator Timer(int time){
        while(true){
            timerText.text = time.ToString();

            yield return new WaitForSeconds(1);

            time--;
            if(time < 0){
                break;
            }
        }
    }
}
