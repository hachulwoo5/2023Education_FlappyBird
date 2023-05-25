using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Sprite[] digitSprites; // 0���� 9������ ���� ��������Ʈ���� ������� �迭�� �����մϴ�.
    public Image[] digitImages = new Image[3]; // 3�ڸ� ���ڸ� ǥ���� Image UI ��� �迭

   
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
        int startIndex = Mathf.Max(scoreString.Length - digitImages.Length, 0); // ���� �̹��� �迭�� ���� �ε���

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