using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TextChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _player1_text;
    [SerializeField] private TextMeshProUGUI _player2_text;
    // Start is called before the first frame update

    public static bool is_witch;
    private void Start()
    {
        if(is_witch == false)
        {
            Player1Win();
        }
        else if(is_witch == true)
        {
            Player2Win();
        }
    }
    public void Player1Win()
    {
        _player1_text.text = "LOSE!";
        _player2_text.text = "WIN!";
    }
    public void Player2Win()
    {
        _player1_text.text = "WIN!";
        _player2_text.text = "LOSE!";
    }
}
