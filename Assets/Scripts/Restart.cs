using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private Button btn;

    void Start()
    {
        btn = GameObject.Find("Canvas/Button").GetComponent<Button>();
    }
    // Start is called before the first frame update
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        btn.gameObject.SetActive(false);

    }
}
