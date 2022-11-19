using UnityEngine;
using UnityEngine.UI;

public class ScoreCal : MonoBehaviour
{
    [SerializeField] GameObject bubbleCal;
    [SerializeField] Transform spawnBC;
    [SerializeField] GameObject text;
    [SerializeField] public float score;
    public GameObject test;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BubbleCal")
        {
            AddScore(collision.gameObject.GetComponentInChildren<Text>().text);
            Destroy(collision.gameObject);
            Instantiate(bubbleCal, new Vector3(Random.Range(-20, 21), Random.Range(-8, 9), 0), Quaternion.identity, spawnBC);
        }
    }

    public void ScoreRound()
    {

        score = (int)score;
        SetScale();
        text.GetComponent<Text>().text = score.ToString();
    }

    void AddScore(string str)
    {
        switch (str[0])
        {
            case '+':
                score += int.Parse(str.Substring(1, str.Length - 1));
                break;
            case '-':
                score -= int.Parse(str.Substring(1, str.Length - 1));
                break;
            case 'x':
                score *= int.Parse(str.Substring(1, str.Length - 1));
                break;
            case '/':
                score /= int.Parse(str.Substring(1, str.Length - 1));
                break;
        }

        score = Mathf.Round(score * 100.0f) * 0.01f;
        // đặt lại cái giá trị min, max
        if (score >= 1000000)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("SetColor", 0.5f);
            score = 1000000;
        }
        else if (score <= -1000000)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("SetColor", 0.5f);
            score = -1000000;
        }

        text.GetComponent<Text>().text = score.ToString();

        SetScale();

    }

    void SetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void SetScale()
    {

        int soChuSo = Mathf.Abs(score).ToString().Length;

        gameObject.transform.localScale = new Vector3(soChuSo, soChuSo, soChuSo);

        text.GetComponent<RectTransform>().localScale = new Vector3(0.01f / soChuSo, 0.01f / soChuSo, 0.01f / soChuSo);
    }
}
