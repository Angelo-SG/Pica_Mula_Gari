using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public RaiseFunds proft;
    public Distance punctuation;

    public GameObject[] record;
    private int[] amount;
    public ScoreData data;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        data = SaveLoadSys.LoadScore();
        amount = data.value;
    }
    public void Order()
    {
        int neo = NewRocord();
        int aux = 0;
        for (int i = 0; i < amount.Length; i++)
        {
            for (int j = 0; j < amount.Length; j++)
            {
                if (amount[i] > amount[j])
                {
                    aux = amount[i];
                    amount[i] = amount[j];
                    amount[j] = aux;
                }
            }
        }
        for (int i = 0; i < amount.Length; i++)
        {
            if (amount[i] <= neo)
            {
                amount[i] = neo;
                break;
            }
        }
        for (int i = 0; i < record.Length; i++)
        {
            record[i].GetComponent<TextMeshProUGUI>().text = amount[i].ToString();
        }
        data = new ScoreData(amount);
    }
    private int NewRocord()
    {
        return proft.Value() + punctuation.Value();
    }
}
