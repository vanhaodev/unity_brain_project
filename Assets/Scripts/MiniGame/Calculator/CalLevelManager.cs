using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalLevelManager : MonoBehaviour
{
    [SerializeField] GameObject calculation;
    [SerializeField] GameObject btnInexist;
    public GameObject audioSource;

    int a, b, c;

    char operation;

    void Start()
    {
        GetCalculation();
    }

    void GetCalculation()
    {
        switch(PlayerPrefs.GetInt("CalLevel"))
        {
            case 0:
                CalLevel1();
                break;
            case 1:
                CalLevel1();
                break;
            case 2:
                CalLevel2();
                break;
            case 3:
                CalLevel3();
                btnInexist.SetActive(true);
                break;
            case 4:
                CalLevel4();
                btnInexist.SetActive(true);
                break;
            case 5:
                CalLevel5();
                btnInexist.SetActive(true);
                break;
        }
    }    

    void CalLevel1()
    {
        a = Random.Range(-10, 11);
        b = Random.Range(-10, 11);
        switch (Random.Range(1, 3))
        {
            case 1:
                operation = '+';
                break;
            case 2:
                operation = '-';
                break;
        }

        calculation.GetComponentInChildren<TextMeshProUGUI>().text = a.ToString() + " " + operation + " " + (b < 0 ? "(" + b.ToString() + ")" : b.ToString()) + " = " + "?";
    }

    void CalLevel2()
    {
        a = Random.Range(-100, 101);
        b = Random.Range(-100, 101);
        switch (Random.Range(1, 5))
        {
            case 1:
                operation = '+';
                break;
            case 2:
                operation = '-';
                break;
            case 3:
                operation = 'x';
                break;
            case 4:
                operation = 'E';
                break;
        }

        calculation.GetComponentInChildren<TextMeshProUGUI>().text = a.ToString() + " " + operation + " " + (b < 0 ? "(" + b.ToString() + ")" : b.ToString()) + " = " + "?";
    }

    void CalLevel3()
    {
        a = Random.Range(-9, 10);
        b = Random.Range(-9, 10);

        calculation.GetComponentInChildren<TextMeshProUGUI>().text = a.ToString() + "X " + (b < 0 ? "- " + Mathf.Abs(b).ToString() : "+ " + b.ToString()) + " = 0";
    }
    void CalLevel4()
    {
        a = Random.Range(-9, 10);
        b = Random.Range(-9, 10);
        c = Random.Range(-9, 10);

        calculation.GetComponentInChildren<TextMeshProUGUI>().text = a.ToString() + "X<sup>2</sup> " + (b < 0 ? "- " + Mathf.Abs(b).ToString() : "+ " + b.ToString())+ "X " + (c < 0 ? "- " + Mathf.Abs(c).ToString() : "+ " + c.ToString()) + " = 0";
    }

    void CalLevel5()
    {
        a = Random.Range(-9, 10);
        b = Random.Range(-9, 10);
        c = Random.Range(-9, 10);

        operation = Random.Range(0, 2) == 0 ? '>' : '<';

        calculation.GetComponentInChildren<TextMeshProUGUI>().text = a.ToString() + "X<sup>2</sup> " + (b < 0 ? "- " + Mathf.Abs(b).ToString() : "+ " + b.ToString()) + "X " + (c < 0 ? "- " + Mathf.Abs(c).ToString() : "+ " + c.ToString()) + " " + operation + " 0";
    }

    float Result(int a, int b, char operation)
    {
        switch (operation)
        {
            case '+':
                return (a + b);
            case '-':
                return (a - b);
            case 'x':
                return (a * b);
            case 'E':
                return (Mathf.Round((float)a / b * 100.0f) * 0.01f);
        }
        return 0;
    }

    bool ReSultPTB1(int a, int b, float x)
    {
        if ((Mathf.Round(x * 100.0f) * 0.01f) == (Mathf.Round(((float)-b / a) * 100.0f) * 0.01f))
            return true;
        return false;
    }

    bool ReSultPTB2(int a, int b, int c, float x)   
    {
        if ((Mathf.Round(x * 100.0f) * 0.01f) == (Mathf.Round(((float)-b / 2 * a) * 100.0f) * 0.01f) 
            || (Mathf.Round(x * 100.0f) * 0.01f) == (Mathf.Round(((-b + Mathf.Pow(b * b - 4 * a * c, -2))/ 2 * a) * 100.0f) * 0.01f)
            || (Mathf.Round(x * 100.0f) * 0.01f) == (Mathf.Round(((-b - Mathf.Pow(b * b - 4 * a * c, -2)) / 2 * a) * 100.0f) * 0.01f))
            return true;
        return false;
    }

    bool ReSultBPTB2(int a, int b, int c, float x, char opera)
    {
        if (opera == '>')
        {
            if (a * Mathf.Pow(x, 2) + b * x + c > 0)
                return true;
        }
        else
        {
            if (a * Mathf.Pow(x, 2) + b * x + c < 0)
                return true;
        }    
        return false;
    }

    public void Inexist()
    {
        switch (PlayerPrefs.GetInt("CalLevel"))
        {
            case 3:
                Win_Lose(a == 0 && b != 0);
                break;
            case 4:
                Win_Lose(b*b - 4*a*c < 0);
                break;
            case 5:
                if(operation == '>')
                    Win_Lose((a < 0) && (b * b - 4 * a * c <= 0)); 
                else
                    Win_Lose((a > 0) && (b * b - 4 * a * c <= 0));
                break;
        }
    }    

    public void OK()
    {
        float score = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreCal>().score;

        switch(PlayerPrefs.GetInt("CalLevel"))
        {
            case 0:
                Win_Lose(score == Result(a, b, operation));
                break;
            case 1:
                Win_Lose(score == Result(a, b, operation));
                break;
            case 2:
                Win_Lose(score == Result(a, b, operation));
                break;
            case 3:
                Win_Lose(ReSultPTB1(a, b, score));
                break;
            case 4:
                Win_Lose(ReSultPTB2(a, b, c, score));
                break;
            case 5:
                Win_Lose(ReSultBPTB2(a, b, c, score, operation));
                break;

        }
    }

    void Win_Lose(bool kq)
    {
        if (kq)
        {
            audioSource.GetComponent<SoundMiniGame>().PlayWinSong();
            PopupManager.Instance.OnWin();
        }
        else
        {
            audioSource.GetComponent<SoundMiniGame>().PlayLoseSong();
            PopupManager.Instance.OnLose();
        }

        btnInexist.SetActive(false);
    }    

    public void SelectLevel1()
    {
        PlayerPrefs.SetInt("CalLevel", 1);
        SceneManager.LoadScene("CalculatorGame", LoadSceneMode.Single);
    }

    public void SelectLevel2()
    {
        PlayerPrefs.SetInt("CalLevel", 2);
        SceneManager.LoadScene("CalculatorGame", LoadSceneMode.Single);
    }
    public void SelectLevel3()
    {
        PlayerPrefs.SetInt("CalLevel", 3);
        SceneManager.LoadScene("CalculatorGame", LoadSceneMode.Single);
    }
    public void SelectLevel4()
    {
        PlayerPrefs.SetInt("CalLevel", 4);
        SceneManager.LoadScene("CalculatorGame", LoadSceneMode.Single);
    }
    public void SelectLevel5()
    {
        PlayerPrefs.SetInt("CalLevel", 5);
        SceneManager.LoadScene("CalculatorGame", LoadSceneMode.Single);
    }
}
