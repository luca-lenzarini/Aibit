using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite threeQuartersHeart;
    public Sprite halfHeart;
    public Sprite quarterHeart;
    public Sprite emptyHeart;
    public int initialValue = 5;
    public float playerCurrentHealth;

    // Start is called before the first frame update
    void Start() {
        InitEmptyHearts();
        updateHearts();        
    }

    public void InitEmptyHearts() {
        for(int i = 0; i < initialValue; i++) {
            this.hearts[i].gameObject.SetActive(true);
            this.hearts[i].sprite = emptyHeart;
        }
    }
    public void InitFullHearts() {
        for(int i = 0; i < initialValue; i++) {
            this.hearts[i].gameObject.SetActive(true);
            this.hearts[i].sprite = fullHeart;
        }
    }

    public void updateHearts() {
        float currentHearts = this.playerCurrentHealth / 20f; 
        int currentHeartsInt = (int) currentHearts;

        for(int i = 0; i < currentHeartsInt; i++) {
            this.hearts[i].sprite = fullHeart;
        }

        float healthDecimalPart =  currentHearts - currentHeartsInt;

        if(healthDecimalPart == 0.75f) {
            this.hearts[currentHeartsInt].sprite = threeQuartersHeart;
        }else if(healthDecimalPart == 0.5f) {
            this.hearts[currentHeartsInt].sprite = halfHeart;
        }else if(healthDecimalPart == 0.25f) {
            this.hearts[currentHeartsInt].sprite = quarterHeart;
        }
    }

}
