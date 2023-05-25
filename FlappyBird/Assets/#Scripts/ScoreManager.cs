using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Sprite[] digitSprites; // 0부터 9까지의 숫자 스프라이트들을 순서대로 배열에 저장합니다.
    public Image[] digitImages = new Image[3]; // 3자리 숫자를 표시할 Image UI 요소 배열

   
    public int score;

    private void Start()
    {
        UpdateScoreUI();
    }

    private void Update()
    {
        
    }
    private void UpdateScoreUI()
    {
        string scoreString = score.ToString();
        int startIndex = Mathf.Max(scoreString.Length - digitImages.Length, 0); // 숫자 이미지 배열의 시작 인덱스

        for (int i = 0; i < digitImages.Length; i++)
        {
            if (i < scoreString.Length)
            {
                int digit = int.Parse(scoreString[startIndex + i].ToString());
                digitImages[i].sprite = digitSprites[digit];
                digitImages[i].gameObject.SetActive(true);
            }
            else
            {
                digitImages[i].gameObject.SetActive(false);
            }
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void DecreaseScore(int amount)
    {
        score = Mathf.Max(score - amount, 0);
        UpdateScoreUI();
    }
}