using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static GameData;
using static GameData.TapStatus;
using static BuyManager;

public class TapHandleManager : MonoBehaviour
{
    [System.Serializable]
    public class Tap_SEClip // タップの種類別に音を入れておくクラス
    {
        public AudioClip start;
        public AudioClip selectButton;
        public AudioClip buyButton_Growth;
        public AudioClip buyButton_Mamono;
        public AudioClip buyButton_Dragon;
    }

    [System.Serializable]
    public class stageByStage_SEClip // ステージ別に音を入れておくクラス
    {
        public AudioClip stage1_SE;
        public AudioClip stage2_SE;
        public AudioClip stage3_SE;
        public AudioClip stage4_SE;
    }

    // タップの種類ごとに対応する配列の要素を明示する変数
    private const int START_TAP_SE = 0, SELECT_BUTTON_TAP_SE = 1, BUY_BUTTON_GROWTH_TAP_SE = 2,
    BUY_BUTTON_MAMONO_TAP_SE = 3, BUY_BUTTON_DRAGON_TAP_SE = 4, ADD_SCORE_PERIODICALLYSE = 5;

    // 味方の出現ごとに対応する配列の要素を明示する変数
    private const int MAMONO_SE = 0, DRAGONS_SE = 1;

    // ステージごとに対応する配列の要素を明示する変数
    private const int STAGE_1 = 0, STAGE_2 = 1, STAGE_3 = 2, STAGE_4 = 3;

    private AudioSource[] TapSESource = new AudioSource[6]; // タップのオーディオソース配列
    private AudioSource[] DragonSESource = new AudioSource[MAX_STAGE_NUM]; // ドラゴンのオーディオソース配列
    private AudioSource[] BossSESource = new AudioSource[MAX_STAGE_NUM]; // ボスのオーディオソース配列
    private AudioSource[] EnemySESource = new AudioSource[MAX_STAGE_NUM]; // 敵のオーディオソース配列
    private AudioSource FriendPeriodicallySESource;

    private float SEVolume = 0.5f;
    private bool isStartButtonPlaySE = false;

    public Tap_SEClip TapSE;
    public stageByStage_SEClip StageByStage_DragonSE, StageByStage_BossSE, StageByStage_EnemySE;

    public AudioClip FriendPeriodicallySE;

    void Start()
    {
        for(int i = 0;i < 6;i++)
        {
            TapSESource[i] = gameObject.AddComponent<AudioSource>();
            TapSESource[i].volume = SEVolume;
        }
        for(int i = 0;i < MAX_STAGE_NUM;i++)
        {
            DragonSESource[i] = gameObject.AddComponent<AudioSource>();
            DragonSESource[i].volume = SEVolume;

            BossSESource[i] = gameObject.AddComponent<AudioSource>();
            BossSESource[i].volume = SEVolume;

            EnemySESource[i] = gameObject.AddComponent<AudioSource>();
            EnemySESource[i].volume = SEVolume;

        }
        FriendPeriodicallySESource = gameObject.AddComponent<AudioSource>();
        FriendPeriodicallySESource.volume = SEVolume;

        AddTapSEClip(); // タップのSEクリップを追加
        AddDragonSEClip(); // ドラゴンのタップSEクリップを追加
        AddBossSEClip(); // ボスのタップSEクリップを追加
        AddEnemySEClip(); // 敵のタップSEクリップを追加
        AddFriendPeriodicallySEClip(); // 一定時間で音が鳴るクリップを追加
    }

    void Update()
    {
        TapStatusHandler();

        PeriodicallySound();
    }
    
    // タップしたもの別に様々な処理をする
    void TapStatusHandler()
    {
        switch(isTap)
        {
            // スタートボタンを押したらインゲームにシーン遷移する
            case var istap when istap[(int)start] == true:
            if(!CheckPlaySound(TapSESource[START_TAP_SE]))
            if(!isStartButtonPlaySE)
            {
                PlaySound(TapSESource[START_TAP_SE]);
                isStartButtonPlaySE = true;
            }
            else if(!CheckPlaySound(TapSESource[START_TAP_SE]))
            {
                SceneManager.LoadScene("InGame");
                isTap[(int)start] = false;
            }
            break;

            // ドラゴンかボスを押したらスコアを加算する
            case var istap when istap[(int)dragon] == true:
            Debug.Log("Tap");
            PlaySound(DragonSESource[currentStage]); // 音を鳴らす関数
            Score += AddTapScore;
            isTap[(int)dragon] = false;
            break;

            case var istap when istap[(int)boss] == true:
            PlaySound(BossSESource[currentStage]); // 音を鳴らす関数
            Score += AddTapScore;
            isTap[(int)boss] = false;
            break;

            // 敵画像を押したらタップで増えるスコア×２加算する
            case var istap when istap[(int)enemy] == true:
            PlaySound(EnemySESource[currentStage]); // 音を鳴らす関数
            Score += AddTapScore * 2;
            isTap[(int)enemy] = false;
            break;

            // 右矢印か左矢印を押すと購入ボタンを切り替える
            case var istap when istap[(int)selectButtonRight] == true:
            PlaySound(TapSESource[SELECT_BUTTON_TAP_SE]); // サウンド処理
            currentBuyButtons++;
            
            isTap[(int)selectButtonRight] = false;
            break;

            case var istap when istap[(int)selectButtonLeft] == true:
            PlaySound(TapSESource[SELECT_BUTTON_TAP_SE]); // サウンド処理
            currentBuyButtons--;
            isTap[(int)selectButtonLeft] = false;
            break;

            // 購入ボタン上
            case var istap when istap[(int)buyButtonUp] == true:
            TryPurchase((int)buyButtonUp-6); // 0を渡したいため-6している

            if(isBuySound) // サウンド処理
            {
                if(currentBuyButtons == 0)
                {
                    PlaySound(TapSESource[BUY_BUTTON_GROWTH_TAP_SE]);
                }
                else
                {
                    PlaySound(TapSESource[BUY_BUTTON_DRAGON_TAP_SE]);
                }
                isBuySound = false;
            }
            isTap[(int)buyButtonUp] = false;
            break;

            // 購入ボタン中央
            case var istap when istap[(int)buyButtonCenter] == true:
            TryPurchase((int)buyButtonCenter-6); // 1を渡したいため-6している

            if(isBuySound) // サウンド処理
            {
                if(currentBuyButtons == 0)
                {
                    PlaySound(TapSESource[BUY_BUTTON_MAMONO_TAP_SE]);
                }
                else
                {
                    PlaySound(TapSESource[BUY_BUTTON_DRAGON_TAP_SE]);
                }
                isBuySound = false;
            }
            isTap[(int)buyButtonCenter] = false;
            break;

            // 購入ボタン下
            case var istap when istap[(int)buyButtonDown] == true:
            TryPurchase((int)buyButtonDown-6); // 2を渡したいため-6している

            if(isBuySound) // サウンド処理
            {
                PlaySound(TapSESource[BUY_BUTTON_DRAGON_TAP_SE]);
                isBuySound = false;
            }
            isTap[(int)buyButtonDown] = false;
            break;

            default:
            break;
        }
    }

    /*サウンド関数群*/
    // タップのSEクリップを追加
    void AddTapSEClip()
    {
        TapSESource[START_TAP_SE].clip = TapSE.start;
        TapSESource[SELECT_BUTTON_TAP_SE].clip = TapSE.selectButton;
        TapSESource[BUY_BUTTON_GROWTH_TAP_SE].clip = TapSE.buyButton_Growth;
        TapSESource[BUY_BUTTON_MAMONO_TAP_SE].clip = TapSE.buyButton_Mamono;
        TapSESource[BUY_BUTTON_DRAGON_TAP_SE].clip = TapSE.buyButton_Dragon;
    }

    // ドラゴンのタップSEクリップを追加
    void AddDragonSEClip()
    {
        DragonSESource[STAGE_1].clip = StageByStage_DragonSE.stage1_SE;
        DragonSESource[STAGE_2].clip = StageByStage_DragonSE.stage2_SE;
        DragonSESource[STAGE_3].clip = StageByStage_DragonSE.stage3_SE;
        DragonSESource[STAGE_4].clip = StageByStage_DragonSE.stage4_SE;
    }
    // ボスのタップSEクリップを追加
    void AddBossSEClip()
    {
        BossSESource[STAGE_1].clip = StageByStage_BossSE.stage1_SE;
        BossSESource[STAGE_2].clip = StageByStage_BossSE.stage2_SE;
        BossSESource[STAGE_3].clip = StageByStage_BossSE.stage3_SE;
        BossSESource[STAGE_4].clip = StageByStage_BossSE.stage4_SE;
    }
    // 敵のタップSEクリップを追加
    void AddEnemySEClip()
    {
        EnemySESource[STAGE_1].clip = StageByStage_EnemySE.stage1_SE;
        EnemySESource[STAGE_2].clip = StageByStage_EnemySE.stage2_SE;
        EnemySESource[STAGE_3].clip = StageByStage_EnemySE.stage3_SE;
        EnemySESource[STAGE_4].clip = StageByStage_EnemySE.stage4_SE;
    }

    void AddFriendPeriodicallySEClip()
    {
        FriendPeriodicallySESource.clip = FriendPeriodicallySE;
    }

    void PlaySound(AudioSource PlayAudioSource)
    {
        Debug.Log("PlaySound");
        if(PlayAudioSource.clip != null)
        {
            Debug.Log("OK");
        }
        else
        {
            Debug.Log("NO");
        }
        PlayAudioSource.Play();
    }
    
    bool CheckPlaySound(AudioSource checkAubioSource)
    {
        if(checkAubioSource.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void PeriodicallySound()
    {
        if(isAddScorePeriodicallySound)
        {
            if(CheckPlaySound(DragonSESource[currentStage])) return;
            if(CheckPlaySound(BossSESource[currentStage])) return;
            if(CheckPlaySound(EnemySESource[currentStage])) return;
            if(CheckPlaySound(FriendPeriodicallySESource)) return;
            PlaySound(FriendPeriodicallySESource);
            isAddScorePeriodicallySound = false;
        }
    }
}
