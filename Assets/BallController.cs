using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // スコアを表示するテキスト
    private Text scoreText;
    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のScoreTextオブジェクトのTextコンポーネントを取得
        this.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.scoreText.text = "Score:" + (int.Parse(this.scoreText.text.Replace("Score:",""))+1);
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.scoreText.text = "Score:" + (int.Parse(this.scoreText.text.Replace("Score:", "")) + 3);
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.scoreText.text = "Score:" + (int.Parse(this.scoreText.text.Replace("Score:", "")) + 5);
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.scoreText.text = "Score:" + (int.Parse(this.scoreText.text.Replace("Score:", "")) + 10);
        }
    }
}
