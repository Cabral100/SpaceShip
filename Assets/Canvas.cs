using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    public TMP_Text meuTexto;
    public player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuTexto.text = "Olá, mundo!";
    }

    // Update is called once per frame
    void Update()
    {
        meuTexto.text = "Pontuação: " + player.score + "\n Vidas: " + player.vidas;
    }
}
