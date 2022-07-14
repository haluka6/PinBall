using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //スコアを定義する
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //シーンの中のGameOverTextオブジェクトを取得する
        this.gameoverText = GameObject.Find("GameOverText");

        //シーンの中のScoreTextオブジェクトを取得する
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
        //GameoverTextにゲームオーバを表示
        this.gameoverText.GetComponent<Text> ().text = "Game Over GG";

        //ScoreTextにスコアを表示
        this.scoreText.GetComponent<Text> ().text = $"score: {score}";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 20;
        }
        else if (other.gameObject.tag == "SmallStarTag")
        {
            score += 1;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 15;
        }
    }
}
