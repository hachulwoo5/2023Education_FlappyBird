using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Sprite[] sprites;
    public float animationSpeed = 0.1f;

    private Image image;
    private Material material;
    private int currentSpriteIndex = 0;
    private float timeElapsed = 0f;

    void Start()
    {
        image = GetComponent<Image>();
        material = Instantiate(image.material); // ���� Material ����
        image.material = material; // ���ο� Material �Ҵ�
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= animationSpeed)
        {
            timeElapsed = 0f;
            currentSpriteIndex++;

            if (currentSpriteIndex >= sprites.Length)
            {
                currentSpriteIndex = 0;
            }

            material.mainTexture = sprites[currentSpriteIndex].texture;
        }
    }
}
