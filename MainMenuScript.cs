using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    SpriteRenderer spr;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        Color tempColor = spr.color;
        tempColor.a = 0;
        spr.color = tempColor;
    }

    void Update()
    {
        Color tempColor = spr.color;
        if(Mathf.Abs(tempColor.a - 1) > Mathf.Epsilon)
        {
            tempColor.a += Time.deltaTime/3;
            spr.color = tempColor;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }
}
