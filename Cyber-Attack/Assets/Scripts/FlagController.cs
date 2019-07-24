using UnityEngine;

public class FlagController : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite[] flags;
    private int i = 0;
    private bool offsetForward = true;
    public bool on;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = flags[i / 5];
            if (offsetForward)
            {
                i++;
                if (i >= flags.Length * 5)
                {
                    i--;
                    offsetForward = false;
                }
            }
            else
            {
                i--;
                if (i < 0)
                {
                    i++;
                    offsetForward = true;
                }
            }
        }
    }

    public void show(Vector3 catPos)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        transform.position = catPos;
        on = true;
    }
}
