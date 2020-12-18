using UnityEngine;
using UnityEngine.PlayerLoop;

public class Pool : MonoBehaviour
{
    public GameObject[] list;

    public void Put(int index)
    {
        list[index % list.Length].SetActive(false);
    }
    public int Strip(int index)
    {
        if (list[index % list.Length].activeSelf)
        {
            int outsinde = 0;
            while (true)
            {
                outsinde++;
                if (outsinde > list.Length)
                {
                    return -1;
                }
                index++;
                if (!list[index % list.Length].activeSelf)
                {
                    list[index % list.Length].SetActive(true);
                    return index % list.Length;
                }
            }
        }
        else
        {
            list[index % list.Length].SetActive(true);
            return index % list.Length;
        }
    }
}
