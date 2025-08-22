unity
#6
Unityのバージョンについて
		　  マイナーバージョン
　　　　　　  ↓
Unity 2020.1.1f1←ビルドバージョン
	  ↑西暦↑
		　メジャーバージョン(4だと長期サポートされる)LTS版
alpha,beta,fix版か


#12
リジッドボディ　重力　
Collider 当たり判定　コンポーネント

物理演算
物体をはねさせる　プロジェクト右→作成→物理マテリアル　バウンズネス１
スフィアコライダーのマテリアルに物理マテリアルをドラック＆ドロップ

#13
プログラミング　C#　ビジュアルスタジオ
スクリプトをキューブにあどどコンポーネント
実体化＝インスタンス化 デバッグログ　コンソール

Debug.Log("かえるちゃん");
デバッグログに書き出す
transform.position += Vector3.right;
トランスフォームポジション　右にものすごいスピードで動かす　毎フレームXに1足す


#14
フレームとは　画像１→画像２（１フレーム）
フレームレートとは　１秒間に何回画像を出力できるか　FPS（frame per second） 60FPS(1秒間に60回画像を出力)　ディスプレイの画面更新に合わせている
60→30→15→10→5→0　フレームレートが変動するとガクつく
プレーヤーがどう入力するかわからないので画面に表示してからでないと計算できない
ゲームの移動は点の移動　当たり判定をすり抜ける場合がある　物理演算で事前に計算する設定があるが重い　全ての移動は瞬間移動　間に補完が入るかどうか

＃15
同じタイミングで呼ばれるメソッドはどのような順序で呼ばれてもいいようにしよう
プログラムの実行順序　順序結果が変わる

＃16
変数とは　いろんなところで使い回せる　おお（変数（名前））よ！死んでしまうとはなにごとじゃ！
int a = 1;  整数系の変数　「int」にaと名付けて中に１を入れる　どのような種類を使うか（型）　なんという名前を付けるか　中身に何を入れるか（省略可）　自分で定義して使う
int a = 1;  Debug.Log(a); 　デバッグログにaではなく１と表示される（変数の中身がログに表示される）
赤字エラーは　プログラムの書き方が違う　コンソールのログをダブルクリックすると間違っているところに飛べる
public{int 下OK   void{int 下エラー　範囲＝スコープ　２つの変数が定義されていたらメソッド内（すぐ上に記載したもの）の変数が優先される（メソッド内（void内が有効で他は無視される））　スコープが狭い方が有効になる
基本的な型
int型		整数
float型	有効桁数７桁の浮動小数		1.234567
double型	有効桁数１６桁の浮動小数
char型	１文字
string型	文字列
bool型	真か偽か

string name = "かえるちゃん”;／／本来入力してもらったものを保存しておく
Debug.Log("おお" + name + "よ！");
Debug.Log("暑いとは　なにごとじゃ！");


=====================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test: MonoBehaviour
{
    string name = "かえるちゃん";

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("おお" + name + "よ！");
        Debug.Log("暑いとは　なにごとじゃ！");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=======================================

＃17
C#　オブジェクト指向型　設計図class  →　実体インスタンス　public class test : MonoBehaviour
															　↑この中で定義されている　※正確にはMonoBehaviourがさらに継承している先で定義されている
クラス型変数
transform.position += Vector3.right;
↑変数　　　↑変数　　　　　　　↑変数
↑Transform型
↑class
↑using UnityEngine
↑アドレスが入っている
設計図の中に別の設計図の実体を動かす仕組みを作ることができる
.(ドット)はTransformクラスの中の変数positionにアクセス
positionはVector3型
Vector3型
x　float型
y　float型
z　float型
コンポーネントとは　モジュール　コンポーネントではないクラス（設計図）もある　コンポーネントは全てクラス　オブジェクトはモノ
コンポーネントはスクリプトからコントロールできる

Vector3.rightはstatic変数　クラスではなく構造型(設計図)struct
クラスは参照型　構造型は値型


＃18　計算をしてみよう　基本的な演算
算術演算子
int a;
a = 1 + 1; 	// 2 	足し算
a = 1 - 1; 	// 0 	引き算
a = 1 * 1; 	// 1 	掛け算
a = 1 / 1; 	// 1 	割り算
a = 1 % 1; // 0 	余り％
C#では＝は代入する　右辺を計算して左辺に代入する　
int b = 1;
b = b + 1; //2
b += 1; 同じ変数（b）なら省略できる
==等しい　　!=等しくない
transform.position += Vector3.right;
↓本来は
transform.position = transform.position + Vector3.right;
b -= 1;
b *= 1;
b /= 1;
b %= 1;

b = b + 1;
同じ変数（b）かつ１なら省略できる
++b; 	b++;		インクリメント演算子
—b;		b—;		デクリメント演算子
++変数、—変数　１の足し引きを先に行う
変数++、変数—　１の足し引きを後で行う
int型は小数点以下切り捨て
int a = 1 / 2; //0
float a = 1 / 2; //0　1と2が整数なのでintと認識してしまう
float a = (float)1 / (float)2; // 0.5　キャスト（型名）変数もしくは値
float a = 1f / 2f; // 0.5　サフィックス　数値の最後に型の頭文字を書いて型を表す　計算の際に何の型なのか明示してあげる必要がある
明示なしの整数→int型
明示なしの少数→double型
float b = 0.5f / 0.1f;
double b = 0.5 / 0.1;
double b = 0.5f / 0.1f;　でかい箱から小さい箱はエラーにならない

string a = “あいうえお” + “かきくけこ” + 1 + 2;　あいうえおかきくけこ12 　　文字列として扱われる
char a = “あ”　char型で””を使うとエラーとなる
char a = ‘あ’	一文字はシングルクォーテーション
char a = (ahar)(‘あ’  + ’い’);　キャスト（char）を入れないとエラーとなる　ひらがなの中身は文字コードなので数字になっている


＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int playerHp = 100;
        int playerAtk = 50;

        int bossHp = 100;
        int bossAtk = 20;

        Debug.Log("魔王が現れた！");
        Debug.Log("勇者HP" + playerHp);
        Debug.Log("魔王HP" + bossHp);

        Debug.Log("勇者の攻撃　魔王に" + playerAtk + "のダメージを与えた");
        Debug.Log("魔王の攻撃　勇者に" + bossAtk + "のダメージを与えた");

        playerHp -= bossAtk;
        bossHp -= playerAtk;


        Debug.Log("勇者HP" + playerHp);
        Debug.Log("魔王HP" + bossHp);

        Debug.Log("勇者の攻撃　魔王に" + playerAtk + "のダメージを与えた");
        Debug.Log("魔王の攻撃　勇者に" + bossAtk + "のダメージを与えた");

        playerHp -= bossAtk;
        bossHp -= playerAtk;

        Debug.Log("魔王のHPが" + bossHp + "になった。魔王をやっつけた！");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

#19　メソッドを使ってみよう
メソッド　void Start Update ←Unity側から呼ばれている特別なメソッド
void 何も返さない
<メソッド>
呼び出される　＞　直ちに実行
処理が終わる　＞　呼び出し元に返る
この一連の流れは1フレーム内で行われる
aaa();メソッドの呼び出しは何回でも実行できる
aaa();
aaa();
スコープの範囲で適応される

========================================================
void Start()
{
aaa(1);
aaa(2);
aaa(3);				←データが渡される		型があっていればいろんなデータを送れる
}					↓
					↓
void aaa(int b)			←引数（バトン）変数（箱の名前）
{
	Debug.Log(b);
}
========================================================

＜参照型の場合＞変数は別でも中身が一緒なので注意　←変数の中に実体のアドレスが入っているタイプの型
スコープの範囲がかぶった場合、スコープが狭い方が優先される
引数は「,」で区切ると複数定期できる　
========================================================
void Start()
{
aaa(1,2,3);			←複数データを渡せる　ログは６
}
void aaa(int a,int b, int c)
{
	Debug.Log(a + b + c);
}

voidをintに変更しreturnで返すようにする
void Start()
{
	int d = aaa(1,2,3);			←　③returnがデータを返す　④返ってきたデータを代入←代入しないと結果はでない　
	Debug.Log(d);					ログは６
}
int aaa(int a,int b, int c)			←　①返すデータの型
{
	return a + b + c;			←　②定義した型と同じ型のデータ　リターンでデータを返すとメソッドの処理終わり
	Debug.Log("aaa");			←　ログは呼ばれない
}
========================================================

========================================================
void Start()
{
	int b = 0;
	b = aaa(b);				←③１を代入
	b = aaa(b);				←⑥２を代入
	b = aaa(b);				←⑨３を代入
	Debug.Log(d);				←⑩ログは３
}
int aaa(int b)					←①０を渡す④１を渡す⑦２を渡す
{
	return ++b;				←②１を返す⑤２を返す⑧３を返す
}
========================================================
わかりやすい変数名をつけてね！※解説のために名前を被せています


メソッドを追加void Turn() Turn();Turn(); intのスコープを大きくして省略化
==================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    int playerHp = 100;
    int playerAtk = 50;
    int bossHp = 100;
    int bossAtk = 20;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("魔王が現れた！");
        Turn();
        Turn();
        Debug.Log("魔王のHPが" + bossHp + "になった。魔王をやっつけた！");
    }

    void Turn()
    {
        Debug.Log("勇者HP" + playerHp);
        Debug.Log("魔王HP" + bossHp);

        Debug.Log("勇者の攻撃　魔王に" + playerAtk + "のダメージを与えた");
        Debug.Log("魔王の攻撃　勇者に" + bossAtk + "のダメージを与えた");

        playerHp -= bossAtk;
        bossHp -= playerAtk;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
========================================================


#２０　条件分岐をやってみよう（if文）

========================================================
    void Start()
    {

        int a = 1;				←変数を代入
        if (a > 0)				←if(条件）
        {
            Debug.Log("通った");	←｛カッコ内｝条件を満たした場合のみ実行される
        }

    }
========================================================

＜条件式＞
A == B	AとBは等しい
A != B	AとBは等しくない
A < B	AはBより小さい　AとBは等しくない（＝が入っていないので等しい場合は条件に当てはまわらない）
A > B	AはBより大きい　AとBは等しくない
A <= B	AはB以下　AとBは等しい　必ず＝は右側
A >= B	AはB以上　AとBは等しい

条件を満たさなかった場合はスキップされる

========================================================
void Start()
    {

        int a = 1;
        if (a < 0)
        {
            Debug.Log("上を通った");
        }
        else						条件を満たさなかったので下を通ったがログに表示される
        {
            Debug.Log("下を通った");
        }
    }
========================================================

========================================================
void Start()
    {

        int a = 1;
        if (a < 0)
        {
            Debug.Log("上を通った");
        }
        else if(a > 0)				条件を満たすので真ん中を通ったがログに表示される
        {
            Debug.Log("真ん中を通った");
        }

        else
        {
            Debug.Log("下を通った");
        }
    }
========================================================

========================================================
void Start()
    {

        int a = 1;
        if (a > 0)						条件○	
        {
            Debug.Log("上を通った");			上と真ん中の条件を満たしていると上に書いてある一番上の上を通っただけ実行される
        }
        else if(a == 1)					条件○	
        {
            Debug.Log("真ん中を通った");
        }

        else							条件✗
        {
            Debug.Log("下を通った");
        }
    }
========================================================

条件式の型
bool型
真か偽かを表す
２種類の値しか入れられない
true		真○
false		偽✗
＜例＞bool a = true;

========================================================
void Start()
    {

        int a = 1;
        bool jouken1 = a > 0;
        bool jouken2 = a == 1;

        if(jouken1)
        {
            Debug.Log("上を通った");
        }
        else if(jouken2)
        {
            Debug.Log("真ん中を通った");
        }

        else
        {
            Debug.Log("下を通った");
        }
    }
========================================================

複数の条件を書く
&と|は論理演算と言う

int a = 2;
if(a > 0 & a <2)		左○右✗でfalse
bool型&bool型（アンド）
trueかつtrueで真　	片方でもfalseなら偽

else if( a > 0 | a < 2)	左○右✗でtrue
bool型|bool型（パイプ）
trueまたはtrueで真	どちらか一方がtrueなら真　両方がfalseなら偽
========================================================
public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int a = 2;

        if(a > 0 && a < 2)
        {
            Debug.Log("上を通った");
        }
        else if(a > 0 | | a < 2)
        {
            Debug.Log("真ん中を通った");	//このログが表示される
        }

        else
        {
            Debug.Log("下を通った");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
========================================================
＜短絡評価＞
＆＆　｜｜		記号を２回連続で書く　左側を見るだけで確定した場合　右側を見ない　処理の無駄が省ける！

========================================================

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int a = 1;
        int b = 2;

        if((a > 0 && b < 0) && (a == 1 && b == 2))
        {
            Debug.Log("上を通った");
        }
        else if((a < 0 || b > 0) || (a != 1 || b != 2))	//b＞０が条件に一致する
        {
            Debug.Log("真ん中を通った");
        }
        else
        {
            Debug.Log("下を通った");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
========================================================

（）をつけなくてもできるが｜があると読みづらいので（）を使うのがオススメ

switch文
switch(比較対象)
{					⇅一致した場合
	case 比較するもの:
		 処理内容				←処理を行う
		 break;
}

switch (a)
{					⇅aが0の場合
	case 0:
		Debug.Log(“aは0です”);	←処理を行う
		break;
}


========================================================

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int a = 1;

        switch (a)
        {
            case 0:
                Debug.Log("aは0です");
                break;
            case 1:
                Debug.Log("aは1です");			//aは１です
                break;
            case 2:
                Debug.Log("aは2です");
                break;
            case 3:
            case 4:
                Debug.Log("aは3もしくは4です");
                break;
            default:
                Debug.Log("aは01234以外です");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
========================================================
条件式はtrueかfalseしかない
＜if文、switch文＞
状況に応じて使い分けよう

↓下記のコードはswitch文よりif文を使ったほうが良い　
========================================================

int a = 1;
int b = 2;

switch (a == b)
{
	case true:
		break;
	case false:
		break;
}
========================================================

========================================================

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int a = 1;
        int b = 2;

        switch (a == b)
        {
            case true:
                Debug.Log("真");
                break;
            case false:
                Debug.Log("偽");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
========================================================


#21　ループ文を書いてみよう　
while(bool型)ホワイルループ
{
　ループ中身
}
========================================================

void Start()
    {

        int a = 0;
        while(a < 5)		//trueの場合処理される
        {
            Debug.Log("aは" + a + "です");
            ++a;
        }
        
    }
========================================================
条件が5 < 5 falseになると次の処理へ

Unityがフリーズする無限ループに気をつける　強制終了しかなくなる　保存してないデータが消えてしまう　終われるような条件にしよう
int a = 0;
bool b = a < 5;		←ループ外で代入している
while(b)			←条件が一生true   bに値を入れ直していないのでbがずっと変わらないままになってしまう
{
            Debug.Log("aは" + a + "です");
            ++a;
	　b = a < 5;	←ループ毎に更新される　これを入れれば無限ループにならない　ｂに値を入れてあげる
 }

Updateとの違い
Update　＞　毎フレーム呼ばれるメソッド		□	□	□	□	□	（4フレーム）　
ループ文　＞　１フレーム内で完結する命令		□				□	（1フレーム）　※例外あり
========================================================

void Start()
    {
        int a = 0;
        while(transform.position.x < 5)
        {
            Debug.Log("このCubeのx座標は" + transform.position.x + "です");
            transform.position += Vector3.right;     //Xが５になるまで足す処理
        }
        
    }
========================================================

continue とbreak
========================================================

void Start()
    {
        int a = 0;
        while (true)		//絶対にループする
        {
            ++a;
            if(a < 10)		//1 < 10 true　++aを繰り返す　　10 < 10 falseになると次の処理に移る→ログを表示→break
            {
                continue;		//trueならwhileに戻る
            }
            Debug.Log(a);	
            break;			//ループ文を抜ける
        }
        
    }
========================================================

do while文
=====================  falseとなる為、一度も実行されない
 void Start()
    {
        int a = 0;
        while (a > 5)
        {
            ++a;
            Debug.Log(a);
        }
        
    }
=====================

do に書き換えて　whileを下にもっていき；をつけると一回実行される
=====================
void Start()
    {
        int a = 0;
        do
        {
            ++a;			//処理を行ってから
            Debug.Log(a);
        }
        while (a > 5);		//条件の判定を行う
    }
=====================

for文
=====================
void Start()
    {
        for(int i = 0; i < 5; ++i)
        {
            Debug.Log(i);
        }
    }
=====================
for(
int i = 0;　←最初に１度だけ行う処理を書く　←変数の定義を書く事が多い　iを０として定義している
 i < 5;	←ループする条件　条件判定が行われてiが5よりも小さいのでtrue 0 < 5 true→ログ吐き出し　5 < 5 falseになるとループ文を抜ける
 ++i)		←処理が終わるたびに行う処理　ログ吐き出し後に　i 0→1
３つの項目は好きなように書き換えて大丈夫



while文(上と全く同じ処理だがfor文を使ったほうがコンパクトで無限ループも防ぎやすい)
=====================
int i =0;
while(i < 5)
{
	Debug.Log(i);
	++i;
}
=====================

for( ; ; )		←無限ループ
{
}
while (true)
{
}


#22　配列を使ってみよう
変数　データを入れる箱
配列　複数の箱をまとめたもの
＜配列を定義＞
型[ ] 　配列名　=　new　型[要素数]；
↑↑		↑		↑　↑	↑
何も書かなくて大丈夫	　　
↑	　	↑		↑
↑		好きな名前　※一部例外あり
↑				↑
↑				＝でつなぎ新しく作るという意味
同じ型			　同じ型　
						↑
						いくつデータが入るか　数は整数になる

int[] a = new int[3];
			  ↑
			  int型のデータが３つ入る
int[] a = new int[3];
a[0] = 1;
a[1] = 2;
a[2] = 3;
   ↑
　何番目に入れるか　配列は０から始まる　[□□□]
								０１２　←３つのデータ
a[3] = 4; //エラー
a = 1;  //エラー

このような書き方もできる
int [] a = { 1, 2, 3};
		0  1  2  ←データ[ ]
大きいデータ
int[] a = new int[50];
			   ↑
			　この数のデータを入れるのは大変　そのような時はループ文を使う
int[] a = new int[50];
for(int i = 0; i < a.Length; ++i)
{				↑
	a[i] = i;		↑   //配列の最初から最後までの値を入れている　ここを変えれば色々なデータを入れられる
}				↑
				「配列.Length」配列の要素数を返す（50）

多次元配列
int[,,] a = new int[3, 4, 2];
　  ↑				↑
「,」で区切る
[3, 4, 2]	□１データ	
   01  01  01
0□□□□□□
1□□□□□□
2□□□■□□
3□□□□□□
    0     1    2
a[1,2,1]■となる

=====================
void Start()
    {
        int[,,] a = new int[3, 4, 2]
                {
			//↓２つのデータ
                   { { 1, 2 }, { 1, 2 }, { 1, 2 }, { 1, 2 } },　//4セットが３セット　書くのがシンドイので可能ならループ文を使おう
                   { { 1, 2 }, { 1, 2 }, { 1, 2 }, { 1, 2 } },
                   { { 1, 2 }, { 1, 2 }, { 1, 2 }, { 1, 2 } }
                };
    }
=====================
=====================
int[,,] a = new int[3, 4, 2];
				↑
				ここの数がわからないとループ文が作りづらい

        int[,,] a = new int[3, 4, 2];

        Debug.Log(a.Length);	//配列の総数３×４×２＝２４
        Debug.Log(a.GetLength(1));	//1は"０１２←データ[ 3, 4, 2]に当てはまる　指定したところの数４　配列の変更（数字の変更）を後で行った場合数字を直打ちだと修正が入るから使う
=====================

配列.GetLength(知りたい数)
この状態で実行すると２４と４になる
＜プログラミングの基本＞
数字直打ちはなるべく避けよう！

=====================
void Start()
    {
        int[,,] a = new int[3, 4, 2];

        for(int i = 0; i < a.GetLength(0); ++i)
        {
            for(int j = 0; j < a.GetLength(1); ++j)
            {
                for(int k = 0; k < a.GetLength(2); ++k)
                {
                    a[i, j, k] = i + j + k; //代入　（今回は適当な値を入れている）
                    Debug.Log("a[" + i + "," + j + "," + k + "]に代入する");
                }
            }
        }
    }
=====================
a[0,0,0]に代入する
a[0,0,1]に代入する
a[0,1,0]に代入する
a[0,1,1]に代入する
a[0,2,0]に代入する
a[0,2,1]に代入する
a[0,3,0]に代入する
a[0,3,1]に代入する
a[1,0,0]に代入する
a[1,0,1]に代入する
a[1,1,0]に代入する
a[1,1,1]に代入する
a[1,2,0]に代入する
a[1,2,1]に代入する
a[1,3,0]に代入する
a[1,3,1]に代入する
a[2,0,0]に代入する
a[2,0,1]に代入する
a[2,1,0]に代入する
a[2,1,1]に代入する
a[2,2,0]に代入する
a[2,2,1]に代入する
a[2,3,0]に代入する
a[2,3,1]に代入する
UnityEngine.Debug:Log(Object)
test:Start() (at Assets/test.cs:19)

[3, 4, 2]　24個の配列結果が見れる

foreach フォアい～ち
＜foreach文＞
複数の要素を持つものを順番に取り出してくれるループ文
foreach(仮の入れ物　in 取り出し元)
{
}

=====================
void Start()
    {
        int[] a = { 1, 2, 3, 4, 5 };　//int 配列にはいっているものは同じ型
        foreach(int i in a) //①aの中を取り出そうとしている　②取り出したもの１を仮の変数iに入れる
        {
            Debug.Log(i);　//③（）の中に入る　i←1　④処理が終わったらループする　２〜５へ　全ての要素を取り出すまでループする　全ての要素を取り出したら抜ける
        }

    }
=====================

＃23　インスタンスを取得しよう
さまざまなものへのアクセス方法
C#　＞　オブジェクト指向型
設計図class →　実体インスタンス　設計図を元に作成
コンポーネント（Transformなど）としてインスタンス化していた　transformの場合はこのインスタンスのアドレスが変数Transformに入っていた　Unityが全部やってくれてた
今回は自分で変数を定義して自分で中身を入れてみよう

Box Colliderを取得して変数に入れてみる

=====================

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider box = null;				//取得したいコンポーネントの型を書く　コンポーネントの型名は大体インスペクターに書いてあった名前と同じ　null 変数の中を空にする
        Debug.Log(box);					//Null
        box = GetComponent<BoxCollider>();
        Debug.Log(box);					//Cube
    }
=====================
GetComponent＜型名＞();　ゲームオブジェクトについているコンポーネントを取得する命令　※MonoBehaviour（モノビヘイビア）を継承しているので使える
今書いているスクリプトと同じゲームオブジェクトの中から指定した型と同じコンポーネントのアドレスを取得して変数（box）に代入する
！同じ型のコンポーネントが複数あるとどれを取得するかがわからない
<GetComponent>アドレスを取得することでコンポーネントにアクセスできる

GameObjectを取得してみよう

GameObject.Find("");
※大文字		　　↑
			　　ゲームオブジェクト名
指定した名前のゲームオブジェクトのインスタンスのアドレスを取得できる　using Untiy Engine;のおかげで使用できる

=====================

void Start()
    {
        GameObject g = null;
        Debug.Log(g);							//Null
        g = GameObject.Find("Directional Light");
        Debug.Log(g);							//Directional Light
    }
=====================
<GameObject.Find()>
アドレスを取得することでゲームオブジェクトにアクセスできる

他のゲームオブジェクトのコンポーネントを取得
Directional LightのLightを取得する
=====================

void Start()
    {
        GameObject g = null;
        Light l = null;
        Debug.Log(g);							//Null
        Debug.Log(l);							//Null
        g = GameObject.Find("Directional Light");
        l = g.GetComponent<Light>();			//Directional Lightにアクセス　Directional Lightの中のLightコンポーネントを取得
        Debug.Log(g);							//Directional Light  (UnityEngine.GameObject)
        Debug.Log(l);							//Directional Light  (UnityEngine.Light)
    }
=====================
"Directional Light" →　"DirectionalLight"　スペースを消すとエラーとなる　NullReferenceException cs:15←15行目でエラー
名前指定はスペースも合わせる必要がある
＜NullReferenceException＞
何もないところにアクセスしようとしている
=====================

void Start()
    {
        GameObject g = null;
        Light l = null;
        g = GameObject.Find("DirectionalLight");	←Findが失敗
        Debug.Log(g);							//Null　GameObject.Find　GetComponent失敗するとNullが返ってくる
        l = g.GetComponent<Light>();			←空っぽにアクセスしようとしている＜NullReferenceException＞
        Debug.Log("確認");						←エラー以降は実行されない
    }
=====================

インスタンスを作成　当たり判定3倍　コンポーネントにアクセスしてパラメータをスクリプトから変更できる　←ゲーム中にパラメータを変更できる
=====================

void Start()
    {
        Vector3 v = new Vector3();						//newでインスタンス作成　目に見える形ではなくメモリ上に存在する
        v.x = 3;
        v.y = 3;
        v.z = 3;

        BoxCollider box = GetComponent<BoxCollider>();
        box.size = v;
    }
=====================
設計図を元に作成
設計図　→　実体インスタンス
↑
みたいな型と配列はnewできる
コンポーネントもnewできるが、ゲームオブジェクトに付いてないとStartとUpdateは呼ばれない
構造体も設計図から実体化させる形なのでnewできる


＃24　値型と参照型
データの取り扱い方
＜型の種類＞　データの取り扱いが違う

参照型	メモリのアドレスを取り扱う
値型		データを直接取り扱う

↓ちゃんとキューブが移動する↓参照型　アドレスでデータを扱う型
=====================

public class test : MonoBehaviour
{
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        t = transform;								//transformのアドレスが変数tに代入される
    }
    // Update is called once per frame
    void Update()
    {
        t.position += Vector3.right;					//ちゃんとtransformのポジションに渡している
    }

}
=====================

↓動かない　値型　それぞれ（v と position）が実データを持つ
=====================

public class test : MonoBehaviour
{
    Vector3 v;

    // Start is called before the first frame update
    void Start()
    {
        v = transform.position;						//transform.positionを代入する時にコピーが渡される　同じ値だけど別物
    }
    // Update is called once per frame
    void Update()
    {
        v += Vector3.right;							//Transformとは無関係なのでキューブは動かない
    }

}
=====================

＜参照型＞
実体が１つ　ー　1回の作成　１つ分のメモリ消費　実データが存在しないのでアクセスしに行く時間が発生する　アクセスしなきゃメモリは食わない

＜値型＞
１つ１つで、実データ作成　アクセス時間が短い　ただし何度もコピーするのであれば参照型の方が処理が早くなる

軽いデータは値型の方が早く　それ以外は参照型の方が早い

データを変更した時　↓ありがちなミス　メソッドでのデータ受け渡し時は注意
値型で元データに反映されていない
参照型で元データを変えてしまった

何が値型で何が参照型か
＜値型＞
int
float
double
char
bool
構造体 struct　クラスと似ている　クラスとの違いは値型か参照型かの違い　クラスclass(設計図)→実体インスタンス(transform)　構造体struct(設計図)→実体インスタンス(Vector3)
値型もどき　string  ほんとは参照型だが挙動は値型と同じ
＜参照型＞
class
配列　←値型の配列でも配列自体は参照型

クラスと構造体の見分け方
transformとエディタで書いた時クラスはclassと表示される
Vector3はstructと表示される


＃25スクリプトの構造を知ろう
・名前空間
・メンバ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
＜名前空間＞
フォルダみたいなもの
↑
using ○○;でフォルダの中に入っている機能を使える
namespace 好きな名前
{
	//クラスなどを書く　←名前空間の中にある機能
}

namespace FolderA
{
	namespace FolderB
	{
		//クラスなどを書く
	}
}
↓こう書いてもよい
namespace FolderA.FolderB
{
	//クラスなどを書く
}
＿＿＿＿＿＿＿＿＿＿＿＿
｜※名前空間 FolderA　｜
｜＿＿＿＿＿＿＿＿＿＿ ｜
｜｜名前空間 FolderB｜｜
｜｜class A		 ｜｜
｜｜＿＿＿＿＿＿＿＿ ｜｜
｜＿＿＿＿＿＿＿＿＿＿ ｜

名前空間内にアクセス
Aはクラス名　今はBのクラスに記載
void Start()
{
	FolderA.FolderB.A a = GetComponent<FloderA.FolderB.A>();


using FoderA.FolderB;			←これを書くことで（階層を全部書く）

void Start()
{
	A a = GetComponent<A>();　←名前空間を書かなくても使える
}

名前空間を書くメリットは？
メリット１　名前が被ってもいい　存在する名前空間が違うと同じ名前でもOK　クラスA　クラスA
プレイヤー攻撃クラス			敵攻撃クラス			区別が必要なので名前が長くなりやすい
PlayerAttackLaser			EnemyAttackLaser
PlayerAttackBomb			EnemyAttackBomb
PlayerAttackHomingMissile	EnemyAttackHomingMissile
	　　・						・
	　　・						・
	　　・						・
＿＿＿＿＿＿＿＿＿＿＿＿　	＿＿＿＿＿＿＿＿＿＿＿＿
｜Player                     　｜	｜Enemy            	     ｜		
｜＿＿＿ ＿＿＿＿＿＿＿ ｜		｜＿＿＿＿＿＿＿＿＿＿  ｜		
｜｜Attack                 ｜｜		｜｜Attack                 ｜｜		
｜｜Laser  		 ｜｜		｜｜Laser  		 ｜｜		
｜｜Bomb  		 ｜｜		｜｜Bomb  		 ｜｜		
｜｜HomingMissile  	 ｜｜		｜｜HomingMissile  	 ｜｜		
｜｜＿＿＿＿＿＿＿＿ ｜｜		｜｜＿＿＿＿＿＿＿＿ ｜｜		
｜＿＿＿＿＿＿＿＿＿＿ ｜		｜＿＿＿＿＿＿＿＿＿＿ ｜		
　　
長い名前を防止できる　ミスを減らせる
他の人との名前衝突を避ける
＜メリット２＞クラス名を覚えなくてもいい　　名前空間.で中身の一覧が見れる　チーム開発で他の人が把握するのに便利　他の人が名前空間から機能を把握しやすい

＜名前空間内に書ける型＞
クラス
構造体

namespace FolderA
{
	public class A
	{
	}

	public struct B 構造体も書ける
	{
	}
}
名前空間を書かない場合　自動的にglobal namespaceに入れられる

＜クラスや構造体の中に書けるもの＞
メンバ

クラスや構造体の中に書ける型
クラスや構造体の中に定義できる変数をフィールドもしくはメンバ変数という

namespace FolderA
{
	public class A
	{
		int a; //フィールド（メンバ変数）

		void B() //メンバメソッド
		{

		}

		class C //入れ子にされた型（内部クラス）
		{

		}

		struct D //入れ子にされた型
		{	

		}
	}

	public class B
	{

	}
}


#26 アクセス修飾子
公開範囲
シリアライズ化
public class   アクセス修飾子
＜アクセス修飾子＞アクセスできるものを指定する

AとBのスクリプト
Aのスクリプト
=====================
public class A : MonoBehaviour
{
   	 // Start is called before the first frame update
    	void Start()
    	{
        
    	}
    	// Update is called once per frame
    	void Update()
    	{

    	}

	public void Test()		//追加   //publicを追加
	{

	}
}
=====================
Bのスクリプト
=====================
public class B : MonoBehaviour
{
   	 // Start is called before the first frame update
    	void Start()
    	{
        		A a = GetComponent<A>();	
		a.Test();					//アクセスできない　//アクセス可能
    	}
    	// Update is called once per frame
    	private void Update()			//メソッドにも書くことができる これもデフォルトはprivate
    	{

    	}
}

internal struct test4				//メンバではない型はpublicかinternalしか書くことができない
{
								//MonoBehaviourを継承しているとpublicしか書けない
}
struct test4						//何も書いてないとinternalと同じ
{

}

=====================
アクセスしたい場合はアクセス修飾子を使ってアクセスできるようにしよう
<アクセス修飾子>他スクリプトからのアクセスをコントロールできる

＜アクセス修飾子の種類＞ 型やメソッドのメンバにつけられる
private			その型をメンバに含んでいる場合にのみアクセス可能		←それ以外			private int a = 0;
public			どこからでもアクセス可能							←アクセスしたい時	public int b = 0;
protected			その型を継承した型のみアクセス可能									protected int c = 0;
internal			同じアセンブリの型からのみアクセス可能								internal int d = 0;
protected internal	同じアセンブリに書かれてかつその型を継承した型からのみアクセス可能		protected internal int e =0;

型やメソッドの修飾子を付けないとprivateと同じ扱い  なにも書いてない状態だとアクセスできない
int f = 0;

namespace Test //名前空間にはアクセス修飾子はつけられないが挙動はpublicと同じ

シリアライズ化とは　ソフトウェア内部で扱っているデータをそのまま、保存したり送受信することが出来るように変換すること
＜publicな変数＞
unityでシリアライズ化される場合がある


=====================

public class test : MonoBehaviour
    {
        private int a = 0;
        public int b = 0;
        protected int c = 0;
        internal int d = 0;
        protected internal int e = 0;

        int f = 0; //privateと同じ

        // Start is called before the first frame update
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {
	Debug.Log(b);
        }

    }
=====================
public int bだけがインスペクターに表示される　unityの仕様でBと表示される
スクリプトを変更しなくても値を追加できる　インスペクターで編集できる　スクリプトとインスペクターの値が反映される 

シリアライズ化できる型
public class test : MonoBehaviour
{
	public int a;
}
できる↓
public int [] c; ←シリアライズ可能な型の配列も可能
public float
public double
public char
public string
public bool
public A d; ←MonoBehaviourを継承した型
public GameObject e; ←ゲームオブジェクト
public Transform f;　←コンポーネント

できない↓
構造体　
public Vector3 b; 基本的にはできないがUnityが定義したものは可能なものがある　自分が定義したものは工夫しないとできない
public test4 g; MonoBehaviourを継承していないクラス ※一部例外有り
=====================

public class test : MonoBehaviour
{
    public int a;				//シリアライズ化された型はインスペクターに表示される
    public Vector3 b;
    public int[] c;			//配列[]は要素数を入れてあげる
    public A d;
    public GameObject e;		//ヒイラルキーからドラッグアンドドロップ可能　インスタンスの参照を初期値として持てる
    public Transform f;		//ヒイラルキーからドラッグアンドドロップ可能

    public test g;
=====================

＜まとめ＞
他のスクリプトからアクセスしたい
インスペクターから値を調整したい
↑
publicを使おう　ただしpublicにするのは必要最低限にしよう　混乱するから


＃27　UIを作ってみよう
・絵の表示
・テキストの表示
・ボタン作成
UIとはユーザーインターフェース　UIを便利に作れる機能　UGUIを使う
ヒエラルキー右クリック→UI→キャンバスグループ＝Canvas & EventSystem
Canvas ←UGUIを表示させるために必要　UGUIを子オブジェクトにして使う　画面は可変する
UGUIとはUI配下に陳列されているものキャンバスグループもUGUIの一つ　UGUIを使用するにやキャンバスが必要
EventSystemとは画面上で起きたイベントをUGUIに伝える役割
白い□がキャンバスの枠　ゲームビューの大きさを変えると白枠の大きさも変わる
Canvasとはゲーム画面に合わせてUIの大きさを調整してくれる機能

絵を表示してみよう
Pixelmatorで適当な絵を書く　a.pngで書き出し　unity006に保存　unityのプロジェクトへドロップ
インスペクター　テクスチャタイプをスプライト（2D and UI）に変更　適用する
Spriteは２Dグラフィックオブジェクト
UGUIの画像を選択　■が出現　Canvasの下のImageを選択　
Imageのソース画像にa.pngをドロップ
位置、幅、高さを変更できる　Image をCanvasの子オブジェクトから外すと使えなくなる

テキストを表示してみよう
UGUIのテキストを選択　Textを選択した状態でインスペクターでテキストを編集できる

ボタンを作成してみよう
UGUIのXボタンを押下　見た目はImageとTextから出来ている
=====================

void Update()
        {
        }
        public void TestClick()
        {
            Debug.Log("ボタンを押した");
        }
    }
=====================
上の記載　Buttonのコンポーネントを追加にスクリプトをドロップ
ボタンのインスペクターにクリック時（）　リストは空です　＋−が出現　＋を押下
オブジェクトを入れる項目が出現　ヒエラルキーのボタンをオブジェクトへドロップ
No Functionをtest（作成したスクリプト）.TestClick（作成したメソッド）を選択
シーンを再生して▶ゲーム画面からボタンを押すとログにボタンを押したと表示される
ボタンからメソッドを呼び出せる

＃28　プレハブを使ってみよう
オブジェクトの複製方法
アセッツ右クリック作成　マテリアル
command + Dで複製可能　ヒエラルキー右クリック　複製でも可能
＜プレハブとは＞元ファイルのようなもの　元ファイルから複製を作成　元ファイル↔複製物　リンクしている

ヒエラルキーのCubeをプロジェクトウィンドウにドラッグアンドドロップ（アセッツAssets等）プレハブが作成される
プロジェクトウィンドウからシーンビューにドラッグアンドドロップすると複製される
プレハブとリンクするオブジェクトは青色になる

プレハブモードを使おう
オブジェクトのプレハブを選択　プレハブを開く　プレハブモードになる（元ファイルを編集するモード）
編集後　シーンか＜で反映される
Cube右クリック→プレハブ→展開　もしくは　すべてを展開でプレハブが解除される

ゲームオブジェクト側の変更
プレハブの一つを変更すると変更した箇所が青い縦線がつく｜
独自の変更がある場合　プレハブの影響を受けなくなる　変更が適用されないのは独自に変更したパラメータのみ
一番親の位置と回転は独自の変更として扱われない

独自変更をプレハブに適用しよう
独自に変更したプレハブを選び　インスペクターのオーバーライド🔽クリックすると独自の変更一覧が表示される
ここで　すべてもとに戻す（元のプレハブと同じに戻る）とすべて適用するを押すと
すべてのプレハブに独自の変更が適用される


＃29　プレハブの入れ子と派生
プレハブの親子関係について
Nested Prefabs
Prefab Variants

キューブ作成　子スフィア作成　キューブをプレハブにする　スフィア（Sphere）の文字だけが青くなる
プレハブは子オブジェクトを含むことが出来る
新たにカプセルを作成しキューブに入れようとするとエラーとなる（プレハブインスタンスの子は削除、移動ができない）
＜プレハブの親子関係＞独自の変更を持つことが出来ない←そんなわけないんですよね
スフィアの下にドロップすると＋カプセルとなる（プラスマークがつく）変更を加えたから
キューブ　インスペクター　オーバーライド　すべて適用する　でプレハブに追加できる　カプセル
キューブを追加　キューブ右クリック　Added GameObject プレハブキューブ１に適用でプレハブに含めることができる　個別に変更を適用できる
キューブ１　インスペクター　コンポーネントを追加　ri  Rigidbody 追加したリジッドボディ（コンポーネント）にも＋が付き青い線が付く
こちらも・・・Added GameObject プレハブキューブ１に適用で個別に適用できる
パラメータの変更もパラメータを変更した後・・・Modified Component プレハブキューブ１に適用で適用できる
Box Colliderも同様に出来る
＜プレハブ内の子オブジェクト＞順移動、解除、削除は独自変更できない　プレハブモードにすると変更できる
＜プレハブ内の子オブジェクト＞全てのプレハブに変更を適用するしかない　親子関係に注意！

Nested Prefabs　ネステッドプレハブ
シリンダーを作成　プロジェクトにドロップ　■キューブと■シリンダー別々のプレハブができる
シリンダーを＋にする
キューブ　インスペクター　オーバーライド　すべてを適用する　→プレハブの中にプレハブを含めることができる
🔽■Cube	<Nested Prefabs>プレハブの中にプレハブがあるプレハブ　ネステッドプレハブ
	■Sphere
	■Capsule
	■Cylinder  プレハブモードで編集すると変更される
同じプレハブ↓は適用できない

	
＋Cubeは２種類のプレハブにぞくしているので　＋Cube右クリック→Added GameObject→Cube適用かCylinder適用を選べる

どのプレハブに適用するか選べる　オーバーライドからも適用できる

Prefab Variant プレハブバリアント
プレハブの派生
プレハブを作り、同じようにドロップするとプレハブバリアントにするか聞かれる
元々変更→　○　→派生
派生変更→　✗　→元々
ドロップすると元々のプレハブがヒエラルキーから消えるのでプロジェクトからドロップする（元を使いたければ）
プロジェクトのプレハブ右クリック→作成→プレハブバリアントでも作成できる
派生同士に直接の繋がりはない
派生したものに元（ベース）を変更したい場合はプロジェクトの派生を選択→プレハブを開く→オーバーライド→すべてをベースに適用
ただし個別に変更した同じ種類の変更は適用されない
いくつでも派生可能
プレハブバリアントはベースのプレハブとNestedな状態にすることができない

Unpack Prefab Completely アンパックプレハブ　コンプリートリイ
ヒエラルキープレハブ右クリック→プレハブ→展開（プレハブ解除）すべてを展開（子オブジェクトも含みプレハブ解除）　


#３０ Unityのちょっとした注意点
再生中▶に変更したものでも元に戻らないものもある →バージョンUPで解決済み
<シリアライズ化された値>インスペクターの変更よりスクリプトの変更が優先される

インスペクターで値を変更できる
=====================

public class test : MonoBehaviour
{
        public int a = 1;

        // Start is called before the first frame update
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {
        a = 1;		//値を指定するとインスペクターで変更不可となる
        Debug.Log(a);
        }
    }
=====================
インスペクターで変更できないモノは何かの処理で値を変更されている
値だけでなく、様々なモノが動かせない場合、何かに変更を加えられている
インスペクターの変数に初期値を入れる意味　public int a = 1;	貼り付けた時　最初から値が入るので便利
セーブ
ファイル→プロジェクトを保存はシーンは保存されない
ファイル→保存　セーブプロジェクトの内容も含めてセーブ


#３２　デバッグのやり方
不具合の原因を突き止める方法
エラーを確認しよう　コンソール❗エラー　無視してもいいエラーもある　エラーを選択するとエラーの詳細がでてくる　これをドラックコピー翻訳検索　エラー何？把握
無視しても大丈夫なエラーは無視しても大丈夫という検索結果がでる
エラーログをダブルクリックでエラー箇所が開く　開かない場合はエラーのファイル名の何行目〜何行目かを確認する（14,10）:error
ファイル名が無い場合（Assets\test.cs）システム的エラーか何かの処理をした際のエラーの可能性がある
コンソールの消去を押下しても消えない場合
・プログラムが間違っている　・入れられないファイルがある
消える場合
・タイミングで起きるエラー
プログラム（コード）が間違っている場合、ビジュアルスタジオのエラー一覧を見たら原因が大体解る

状況を把握しよう
・どのタイミングでエラーになっているかわからない　・エラーにはなってないが思った動きになっていない　・どういった処理になっているかよくわからない
調べればOK
Debug.Logを使おう
＜ログが表示されない場合＞
・セーブし忘れ　・スクリプト貼り忘れ　・スクリプトが有効ではない　・メソッド名が違う　・ログがオフになっている
void Starta()
{
	Debug.Log(“確認”);
}
凡ミスじゃないなら処理を通ってない

↓確認は表示された　ボタン押した表示されない場合
Debug.Log(“確認”);
if(ボタンを押したら)	←false
{
	Debug.Log(“ボタン押した”);
}
考えられる原因
毎フレームではない場合、フレーム内にボタンを押さないといけない
ボタンを押したらという条件がうまく機能していない　←条件を調べよう
Debug.Log(“確認”);
if(Input. GetKey (KeyCode. Space)) //スペースキー押すと○押さないfalse
{
	Debug.Log(“ボタン押した”);
}
上手く行かない場合　調査あるのみ　[Input GetKey 動かない]Google
決めつけはミスの元　どこが原因かを明確にする
デバックログは通ったか通ってないかの確認だけではなく変数の中身をみることができる

NullReferenceException: Object reference not set to an instance of an object
kaeru.Start () (at Assets/kaeru.cs:18)
↑何かよくわからないエラー
=====================

void Start()
    {
        Vector3 v = new Vector3();
        v.x = 3;
        v.y = 1;
        v.z = 2;

        GameObject g = GameObject.Find("Enemy");	//原因はコレ　GameObjectを取得できていない
        Debug.Log(g);					//そこで使っている変数やメソッドなど原因になりうるもの全てをログに出力しまくる　	//Null
        Debug.Log(v);																					//(3.0, 1.0, 2.0)Vector3の値
        Debug.Log(g.transform);			//Nullにアクセス													//謎のエラー
        Debug.Log(g.transform.position);
        g.transform.position = v;			//この行のエラーは解るが何がエラーかわからない
    }
=====================
Debug.Logで原因を突き止めよう

シリアライズ化を使おう
調査方法はDebug.Logだけじゃない

=====================

public class kaeru : MonoBehaviour
{
    int a;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ++a;				//どう変化しているか知りたい場合
        Debug.Log(a);
    }
}
=====================
ログが流れてしまってよくわからない…　

２
３
４
…
変数をシリアライズ化してしまう
=====================

public class kaeru : MonoBehaviour
{
    public int a;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ++a;
    }
}
=====================

値の変化をインスペクターで見ることが出来る	123456789…
随時変化していくものを調査したい場合　便利　
元々変数でないものを調査したい場合でもデバック用の変数を作ってその中に入れて調査する方法もある

ブレークポイントを張ろう
=====================

public class kaeru : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 1;					//①変数　aを定義

        if(a ==1)					//②if文で条件判定			//aを10に変更　if文がfalseとなり
        {
            Debug.Log("ifの中に入った");
            a = 2;					//③aの数値を２にする
            a = Test();				//④メソッドからの返り値を返す
            a = 4;					//⑥aの数値を４にする
        }
        Debug.Log(a);										//10を表示
    } 

    // Update is called once per frame
    void Update()
    {
     
    }

    int Test()
    {
        return 3;					//⑤３を返しているだけ
    }
}
=====================
↑単に値を増やしていくだけのスクリプト

ビジュアルスタジオの▶を押す（デバッグモード）Unityとビジュアルスタジオが連携する
左側をクリックすると◎が付く

この状態でUnityを実行すると▶

↑処理がここで止まる　処理を中断して、その瞬間の状況を調べることが出来る

↑カーソルを合わせると変数の中身を見ることが出来る

↑現在取り扱っている変数とその値が表示されている

↑クリックすることで値が変更できる

↑10に変更した状態でビジュアルスタジオ▶を押すとログに表示される
if(a ==1)で処理が止まっている間にaを１０に変更した

処理途中の状況把握　値を指定したテストが可能
処理が止まっている間はUnityを触ることが出来ない　ビジュアルスタジオの停止ボタン■で解除できる
◎は何個も付けることができるビジュアルスタジオの▶で次の◎に以降する

↑ステップオーバーで処理を一行ずつ実行することが出来る　メソッド内は処理を追わない　メソッド中では停止せずに次に進む

↑ステップインで処理を中断したところから一行ずつ実行することが出来る　メソッドに入った時そのメソッドにおって順に進んでいく　メソッド内の処理が終われば返る

↑ステップアウト　メソッド内からメソッドの呼び出し元まで戻ることができる

Debug.Log、シリアライズ化、ブレークポイント使い分けよう

その他確認すべきこと
同じスクリプトが複数ついている　←外す
シリアライズ化されていたスクリプトがMissing(参照が外れた)　←付け直せ
スクリプト自体の参照が外れた　The associated script can not be loaded. 　←対象のスクリプトをもう一回貼り付ける　もしくはエラーを直す
スクリプトを貼り付けた際　Can’t add script component ぶらぶらぶら…　スクリプトのクラス名とファイル名が違う　←クラス名とファイル名を揃える
物体がピンク色になった場合　シェーダーエラー　シェーダープログラムを直すのは難しい　←別のシェーダーを使う
Unity自体がフリーズしてしまったら
ブレークポイントを貼っていないか
重い処理中か　←待つ
無限ループではないか
Unity自体がおかしい場合　

↑コンソールウィンドウの右上からエディターログを開くでUnity自体のログを見ることが出来る（できてない）


#３２　作り始める前にやるべきこと
Step1 プラットフォームを切り替えよう
プラットフォームの設定切り替え　ファイルの変換処理が入るので一番最初にやってしまうと吉
ファイル→ビルド設定

モジュールの追加は　#６を参照
プラットフォームによっては契約が必要なものがある　SP4など　モジュール追加にもない場合企業の案内を確認
プラットフォームの一覧にあったとしてもNo module loadedの場合はモジュールの追加が必要
変更したいプラットフォームを選択しSwitch Platformを選択→変換処理（プラットフォームの切り替わりが走る）
Unityアイコンが完了の証

Step2 解像度とアスペクト比を考えよう
＜ゲームでの解像度＞画面のピクセル数（画面解像度）
幅と高さのピクセル数□←比率をアスペクト比
ディスプレイの解像度　プレイヤー次第で異なる場合がある　機種によって違う　最初に考えないと、はみ出る物を再配置しないといけなくなる
画面設計
１６：９　４：３　２；１
＜どう対策するのか＞
UI部分の調整　ゲーム部分のアスペクト比　画面全体の解像度
＜UI部分の調整＞
４：３　縮小→□←　↑位置調整　|Stage3 			Score 10|
拡大縮小の設定・・・Canvas
位置調整・・・個別に調整可能
＜UIの調整＞
設定すればUnityが調整してくれる
＜ゲーム部分のアスペクト比＞
ゲームによって変わる
調整しない　←画面を広くとれる
帯を入れて調整〓（画面の比率を調整）
＜何故アスペクト比を調整するのか？＞
余白があるとビジュアルに違和感がある
余白が必要
見えたり見えなかったりするのでゲーム中で使う物を入れられない　余白部分はゲーム中必須ではないものを表示することとなる
余白で画面に違和感　見せたくないものを画面外に置きづらい
ディスプレイによって有利・不利が発生する←　２Dアクションでは非常に重要
横スクロールアクションの場合　横有利　縦不利　ゲーム外で有利、不利が発生するのはよくない
２Dアクションは縦・横共に有利不利が発生する場合が多い　余白を持たせないためにアスペクト比を固定する場合が多い　アスペクト比固定で進める　←固定じゃなくても良い
アスペクト比を固定する以外の方法もあるが初心者向けではない
＜アスペクト比を固定する方法＞
自分でアスペクト比を決めることが出来る　やる事　アスペクト比を決めよう　分からない人は真ん中ぐらいのアスペクト比を選択すればOK
４：３		iPad					4/3		1.333333333333333
１６：９		iPhone（5c 〜　8plus)	16/9		1.777777777777778
１９．５：９	iPhone（X 〜 １１）		19.5/9	2.166666666666667
2:3								3/2		1.5
40:71							71/40	1.775						
139:199							199/139	1.431654676258993

４：３		iPad					4/3		1.333333333333333	▲正方形より
139:199							199/139	1.431654676258993	
2:3								3/2		1.5					真ん中くらいでいいが　１６：９が無難
40:71							71/40	1.775				
１６：９		iPhone（5c 〜　8plus)	16/9		1.777777777777778	
１９．５：９	iPhone（X 〜 １１）		19.5/9	2.166666666666667	▼横に長い

＜画面全体の解像度について＞
最近のディスプレイは高解像度過ぎる！　重すぎてカクカクになる！　GPUがついてこれない　←解像度の上限値を決めて超えるなら下げる必要がある
やること　解像度の上限値を決めよう　上限値がどんな値がいいのかは状況や時代によって変わる　分からない人は９６０ぐらいが無難
縦横の解像度を計算しよう
最大解像度÷アスペクト比の大きい方の数値×アスペクト比の小さい方の数値
＜無難な場合の例＞
９６０÷１６×９＝５４０
アスペクト比	１６：９
解像度		９６０×５４０
＜解像度とアスペクト比のプログラム＞
現段階では難しいので応急処置をとる
ゲームビュー下のFree Aspectをクリック→　＋　↓		

ラベル名を入力し解像度を入力しOK　Unityで見るゲームビューが固定される　擬似的にアスペクト比と解像度を固定することが出来た
ゲームオブジェクト位置を後で調整するというミスを避けることが出来る　擬似的でも固定されていればゲーム制作中は問題ない
完了　アスペクト比の決定　最大解像度の決定
ToDo  UI部分の調整　アスペクト比の固定　解像度を下げる　←ブラウザゲームはこれで完了　やる必要がない　解像度を自分で指定できるので調整がいらない


＃３３　タイトルシールを作成しよう
Step3 タイトルを一枚絵で表現しよう
シーンの作り方は無限大だが　一枚絵でタイトルシーン作成　非常に簡単な作り方　初期シーンが軽くなる
デフォルトのシーンはSAMPLEシーンになっているので新しくシーンを作成する
ファイル→新しいシーン　ファイル→別名で保存
/Users/me-do/Desktop/unity/006/006/Assets/Scenes/titleScenes.unity
やること　Canvasの設定
ヒエラルキー右クリックUI→キャンバスグループ（ヒエラルキーにCanvas とEventSystemが作成される）
ヒエラルキーのCanvasを選択した状態でインスペクターのCanvasレンダーモードをスクリーンスペースーカメラに変更する
キャンバスのレンダーモードはUIを表示する空間の設定　全面表示→カメラに変更　後々調整がやりやすくなる
表示されるパラメータが変わってレンダーカメラが出現　ここにMain Cameraをドラッグアンドドロップ　UIがメインカメラに映るようになる
インスペクターのCanvas Scaler
Canvas ScalerとはCanvas配下のUIの大きさを調整するコンポーネント
UIスケールモードを画面サイズに拡大に変更　UI Scale Mode 大きさを変更する基準　ピクセル数→画面の大きさ
参照解像度をX９６０　Y５４０に変更　画面の解像度から計算して拡大縮小するようになる
スクリーンマッチモード　Screen Match Mode どのように拡大縮小するのかという設定　Match Width Or Height デフォルト　画面の横側に合わせる
マッチで画面の幅か高さに合わせるかを設定できるがアスペクト比固定する場合　後でスクリプトで変更をかけるので　今はどちらでも構わない
完了　Canvasの設定
ToDo カメラのアスペクト比　←どんな絵にも対応するため　固定する
やること　絵の配置
Image作成　ヒエラルキーCanvasを選択した状態で右クリックUI→画像
インスペクターのRect Transform UGUI版トランスフォーム　
UGUIの位置、回転、拡大縮小、幅高さ、UIのどの位置を中心にするのか（中心位置）、どこを基準にして配置するのか（基準位置）		
幅と高さを画面に合わせるWidth幅９６０Height高さ５４０		

Pixelmatorを開く

下書きを作成
＜何故下書きを推奨するのか＞
ゲームの根幹部分の作成やわからないところをやってみる　仕様を一部分だけ持ってきても食い合わせが悪い場合がある

他人の仕様を試しもせずに突っ込むと痛い目を見ます　やったことない　分からない事は試しに作ってみよう　ここでグラフィックを完璧にする必要はない
モック	２０％	試しに作ってみる		シーン１	シーン２	シーン３
α版		４０％	ある程度形にする		シーン１	シーン２	シーン３	グラフィックを差し替えていく
β版		８０％	完成に近づける			シーン１	シーン２	シーン３　シーン４　シーン５　ある程度やり方が解っている　追加のシーンを作成していく
Fix版		９０％	調整・ブラッシュアップ	シーン１	シーン２	シーン３　シーン４　シーン５　全体をよく見る
Fix版		１００％	デバッグ				シーン１	シーン２	シーン３　シーン４　シーン５　完成
作り方は人それぞれだけど分からない間はモックから入ろう
titleBackGround.pngで保存(日本語にしない！　時々へんなバクになる)
/Users/me-do/Desktop/unity/006/titleBackGround.png

プロジェクトウィンドウ右クリック作成→フォルダ  　フォルダ名をTextureに変更　整理整頓の意味もあるが後で作業を一気に終わらす為
特殊な方法を使うと上書きでTextureに差し替えられる　下書きから本番用に変更時　再配置する必要がなくなる
プロジェクトのTexture配下にtitleBackGround.pngをドラッグアンドドロップ
titleBackGround.pngを選択した状態でインスペクターのテクスチャタイプをスプライトに変更
ヒエラルキーImageを選択→適応→インスペクターImage ソース画像にtitleBackGround.pngをドラッグアンドドロップ

Step4　テキストを使いこなそう
やること　タイトル文字をテキストで作成
ヒエラルキーCanbasを選択右クリックUI→テキスト
ヒエラルキーテキストを選択　インスペクターParagraph水面オーバーフローをOverflow　垂直オーバーフローをOverflow
テキストを　タイトルにして画面の中心にもってくる（フォントサイズ８３　白　整列　真ん中）※90に変更

TextがImageの下にくるようにする　下にある方が全面表示
＜Textの注意点＞
文字の大きさに注意
Textインスペクター　拡大/縮小 X Y Z　と　フォントサイズ　で修正する２つのパターンが存在する　どちらを使えば？　ScaleとFont Size両方使用する　
文字はテクスチャ　Scaleは単なる拡大縮小　小さいテクスチャ（絵）を引き伸ばしたらボケる
Font Sizeが１でも違うと別物の文字がテクスチャに生成される　フォントサイズがバラバラな文字を使うとメモリをバカ食いする　ロール時間遅い　クラッシュの原因となる
フォントサイズを全て一緒にしたら？　←小さいフォントサイズだけだと文字がボケる　大きいフォントサイズだけだとメモリをバカ食いする
・大きいフォントサイズ	→拡大		90
					→縮小
・中位フォントサイズ		→拡大		60
					→縮小
・小さいフォントサイズ	→拡大		30
					→縮小
↑ある程度メモリにやさしく運用できる
テキストを置いたら、使ったフォントサイズをメモしておこう
近いフォントサイズを使用してスケールで大きさを調整する

Step5 スタートボタンを設置しよう
ヒエラルキーCanvasを選択した状態で右クリックUI→X ボタン
シーンを２D表示にする　
ヒエラルキーButtonを選択した状態でインスペクターRect Transform　位置Y-176　幅200　高さ60

↑ボタンの下のテキストもフォントサイズ　26メモする　文字はStart　※30に変更

プロジェクトのアセッツ配下にScriptフォルダを作成　プロジェクトAssets選択右クリックー作成ーフォルダ　名前をScript
プロジェクトのスクリプト配下にスクリプトを配置　名前Title  Scriptフォルダ右クリックー作成ーC＃　スクリプト　名前をTitle
スクリプトをダブルクリックでバーチャルスタジオを立ち上げる　public class Titleに修正する
=====================
public class Title : MonoBehaviour
{
    //スタートボタンを押されたら呼ばれる
    public void PressStart()
    {
        Debug.Log("Press Start!");
    }
}
=====================
↑スクリプトをアタッチ　ヒエラルキーCanvasを選択　インスペクターのコンポーネントを追加にスクリプトをドラッグアンドドロップ
ヒエラルキーButtonを選択　インスペクター　クリック時（）の＋を押下　オブジェクトにCanvasをドラッグアンドドロップ
No FunctionをTitle-PressStartに変更
Unity実行▶　ゲーム画面のボタンを押す　ログにPress Start!と表示される
このままでは連打されると命令が何度も呼び出されてしまう！　連打対策をしよう！
=====================
public class Title : MonoBehaviour
{
    private bool firstPush = false;

    //スタートボタンを押されたら呼ばれる
    public void PressStart()
    {
        Debug.Log("Press Start!");

        if (!firstPush)				//falseじゃないと通らない
        { 
	    Debug.Log("Go Next Scene!");	//ログを仕込んで動作確認
            //ここに次のシーンへ行く命令を書く
            //
            firstPush = true;			//trueにするので一度しか通らない
        }
    }
}
=====================
Press Start!はボタンを押されるたびにログが出るがGo Next Scene!は一度しかログにでない
完了　タイトルシーンの土台完成
ToDo　次のシーンへの遷移　グラフィックの差し替え


#３４　アニメーションを作ってみよう
Step6  キャラクターを作ろう
やること　キャラクターの下書きを作る　使用するお絵かきソフトは背景を透明にできるソフトを使用（GIMP,FireAlpaca等）
＜画像の大きさ＞
幅、高さを２のべき乗にしよう！
＜なぜ２のべき乗にするのか＞
圧縮ができないから→重くなる
２のべき乗　１，２，４，８，１６，３２，６４，１２８，２５６，５１２，１０２４，２０４８，４０９６
小さいサイズから徐々に大きくして試してみよう　←大きいと重くなる為　ロード時間が長くなる
画像の綺麗さと大きさのバランスがいいところを探そう　幅１２８　高さ２５６　と　３００×１５０
iOSは正方形でないと圧縮できない　iOSが使う圧縮形式が正方形じゃないと出来ない　変な余白ができたとしても正方形にする　２５６　２５６
やること　動きの種類を決めよう
＜作成する動き＞
・立ち
・走り
・ジャンプ（上昇・下降）
・クリア（クリア時のモーション）
・ダウン（やられた時のモーション）
↑パラパラ漫画のように描いてみる
幅２５６　高２５６　解像度９６０

↑titleScenesの左横の目を押すとタイトルシーン画面が消える

右クリック新規シーンを追加でUntitledを追加する

地面につくなら足を枠の一番下まで書く
可能な限り絵の大きさは同じに
枠の大きさが違う場合は中心を意識する
他の画像と中心が合わない場合Unity側で調整できる
テクスチャタイプTexture TypeをスプライトSprite(2D and UI)に変更しピボットPivotをカスタムCustom  X Y で調整　中心を値で指定(0,0)左下（1,1）右上
中心の調整を個々にするのは大変なのでなるべく画像側で揃えよう

以下をiPadのProcreate＋アップルペンシルを使って作成する
背景なしのPNG画像の名前は頭に使用用途を書くと便利
player_down1
player_down2
player_down3
player_jump_down
player_jump_up
player_run1
player_run2
player_run3
player_stand
player_win
作成したpngを　/Users/me-do/Desktop/unity/006/に保存
↑をUnityのプロジェクトTextureにドラッグアンドドロップ

↑プロジェクトウィンドウの右上アイコンからTextureを選択  ←テクスチャのみを表示
さらに名前検索することで目的のファイルのみ表示↓
🔍t:Texture player
↑これらをシフトを押しながら全選択　テクスチャタイプをスプライト　iOS用に上書き　適用する
やること
アニメーションの作成
player_standをヒエラルキーにドラッグアンドドロップ

↑シーンにかえるちゃんが出現
ヒエラルキーのplayer_standを選択した状態でインスペクターのコンポーネントを追加を押下　animatorを検索してアニメーター押下
アニメーション用のフォルダ作成 プロジェクトAssets配下で右クリック作成ーフォルダ　フォルダ名Animation
Animation配下で右クリックCreate作成ーAnimator Controllerアニメーターコントローラーを押下 名前player_animator
ヒエラルキーplayer_standを選択した状態でplayer_animatorをインスペクターAnimatorのControllerコントローラーへドラッグアンドドロップ
これでキャラクターにアニメーションを付ける下準備ができた
Unity上のタブ　ウィンドウーアニメーションーアニメーションを選択　アニメーションウィンドウが開く
ヒエラルキーのキャラクターplayer_standを選択した状態でアニメーションウィンドウのCreate作成を押下  ←アニメーションファイル新規作成
作成するアニメーション名で保存　player_stand.anim save

/Users/me-do/Desktop/unity/006/006/Assets/Animation/player_stand.anim
アニメーションウィンドウに時系列の表が付く

ヒエラルキーのplayer_standを選択した状態でプロジェクトのplayer_standをアニメーションウィンドウのプロパティーを追加にドラッグアンドドロップ▼押下

↑立ちモーションのアニメーション　画像１つだけバージョン
別のアニメーション作成　走る
player_stand横の▼をクリックー新しいクリップを作成…を押下　新規アニメーションが立ち上がる　アニメーション名（player_run.anim）を入力してSave

↑プロジェクトのplayer_run1〜3をアニメーションウィンドウにドラッグアンドドロップ　(0:00.run1) (0:10.run2) (0:20.run3)に配置
アニメーションウィンドウのプレビュー横▶（再生ボタン）を押下するとかえるちゃんが走る
ぎこちない走りする（最後の一コマが一瞬で終わってしまっている）ので同じ画像を(0:30.run1)に配置する　▶走っているように見えるようになる
配置する感覚を狭くするとアニメーションの速度が早くなる（0:00  0:05 0:10 0:15）
感覚を空けると走る速度が遅くなる（0:00 0:15 0:30 0:45）

↓同じようにして全部のアニメーションを作る
PNG				時間			アニメーション名
player_down1		(0:00 0:45)	player_down
player_down2		(0:15)
player_down3		(0:30)
player_jump_down	(0:00)		player_jump_down
player_jump_up	(0:00)		player_jump_up
player_run1
player_run2
player_run3
player_stand
player_win		(0:00)		player_win



＃３５　アニメーションを制御しよう
Step7  アニメーターとアニメーション
やること　ちゃんとゲームでアニメーションを使えるようにする
ウィンドウーアニメーションーアニメーターを選択　　　アニメーターウィンドウが開く
Animation 	アニメーションファイルそのもの
Animator 		Animator Controllerから前回作ったアニメーションを制御するもの

↑アニメーターとは　これの中身を表示するもの　

↑中身が表・示される　player_animatorの中身　キャラクターにアニメーターのコンポーネントがささっていてそこにアニメーターコントローラーがついているから
□四角一つ一つが前回作ったアニメーション
何も表示されていない場合はプレイヤーを選択するかアニメーションファイルをドラッグアンドドロップする
と表示
される
プロジェクトAnimation配下のplayer_downを選択した状態でインスペクターのループ時間の☑を外す　ループしたくないものは外す　ループ再生オンオフ
アニメーションファイルが乱雑に配置されているので整頓する

上３つの小さい四角は今回は無視　オレンジ色になっているものはデフォルトで再生されるアニメーション
デフォルトで再生されるアニメーションの変更はアニメーションを右クリックーレイヤーデフォルトステートとして登録するを押下
やること　アニメーションを切り替えていけるように　アニメーションの遷移を作る
立ち↔走り
player_standを右クリック遷移を作成 Make Transitionを押下　←やじるしが出現  player_runに繋げる
＜間違えた場合＞矢印をクリックしてdelete+commandキー
矢印をクリックするとアニメーション遷移をインスペクターに表示することが出来る
この設定を変更することでアニメーションからどのアニメーションに切り替わっていくのかを制御することが出来る　←やじるしの内容
やじるしインスペクターの終了時間ありHas Exit Time☑を外す  ←遷移にアニメーションが終わったらという条件を追加するもの
立ちモーションから走りモーションに移行する際にボタンを押したら即座に移行してほしい為☑を外す
☑がついていると　走りボタンを押されても　立ちモーションが終わる時間まで待機して走ることになる
やじるしインスペクターの▼Settingsをクリックすると詳細が表示される
遷移間隔Transition Duration (s)を０にする　アニメーションからアニメーションの移行期間　２つのアニメーションがブレンドしながら移行する
↑テクスチャ（２D）のアニメーションはブレンドできない  無意味　２Dだと変な間ができてしまう
↓！警告がでている　終了時間ありの☑を外した為　矢印を通る条件がなくなってしまった為

やること　矢印を通る条件を作る
アニメーターウィンドウのパラメーターParameters　→＋　→（なんのパラメーターを追加するのか）bool　→名前（run）
Trigger(Animatorの場合) オンオフを表すパラメーター　矢印を進むと自動でオフになる
＜パラメーターの使い方＞
float 	- 浮動小数　	例＞スピードが一定以上に達したらアニメーションを制御させる　ある値で条件を制御させる等
int		- 整数		例＞複数のアニメーションのパターンが存在して番号を割り振って制御したい時
bool 		- 真偽		例＞ON　OFFなどのフラグによる制御をしたい時
Trigger				例＞矢印を進むとOFFになるという仕様上　一方通行なアニメーションの遷移で使用されることが多い   
＜Trigger＞〇〇が起こったらという意味で使われることが多い
（Animatorの場合）
オンオフを表すパラメーター　矢印を進むと自動でオフになる
今回は走り立ちという２つのモーションの判定がとれればいいのでtrueの時走り、falseの時立ちにすれば上手くいく
runフラグがtrueの時走り、falseの時立ちにする
作成した↓を選択した状態でインスペクターConditionsリストは空です下の＋を押下

↑パラメーターを条件に追加することが出来る（矢印を通る条件を追加）
runのパラメーターを通る時、この矢印を通るという条件を追加することが出来た
＋−でさらに条件を追加したり削除することが出来る　ーボタンはrun左側の=を押す(パラメーターを選択)ことで選択して削除することが出来る
run横の▼を押下で、どのパラメーターを使うか選択することが出来る　その右側に表示されるもの(true)はパラメーターの種類によって変わる
Triggerは自動でOFFになる都合上　条件としてはONの時だけになるので右側には何も表示されない

逆側もやっていく
player_run右クリックー遷移を作成ーplayer_standに繋げる
↑を選択した状態で終了時間☑を外す　遷移間隔を０に
Conditions＋	run	▼falseを追加

↓true	↑false	runフラグがtrueの時、走るようになり、falseの時、立ち状態になるように出来た
後はこのフラグをボタンを入力した時、切り替えてあげればアニメーションを制御できる
やること　スクリプトからキー入力を受け取ってボタンが押されたらrunフラグを切り替えるようにしていく
キャラクター制御用のプログラムを作成していく
プロジェクトAssets-Script配下で右クリックー作成ーC#　スクリプト　名前Player

=====================
public class Player : MonoBehaviour
{
    private Animator anim = null;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalKey = Input.GetAxis("");
    }
}
=====================
Input.GetAxis()　　←Unityの入力を受け取る機能　入力の方向軸を受け取る
＜キー・ボタン入力判定の種類＞
たくさん種類がある
GetKey,GetKeyDown,GetKeyUp
GetButton,GetButtonUp,
GetButtonDown,GetAxis,GetAxisRaw
GetMouseButton,GetMouseButtonUp,
GetMouseButtonDown,GetTouch
anyKey,anyKeyDownなど
たくさん種類がある中から何故GetAxisを選択したか
＞大きく分けると２種類ある
・入力を直接みる判定
・InputManagerを介して入力判定　←Input,GetAxis()はこっち

＜入力を直接見る判定＞
if(Spaceキーを押した)			←特定のボタンやキー入力を受け取っている
{
	//処理する　
}
if(左クリックした)				←特定のボタンやキー入力を受け取っている
{
	//処理する
}
＜InputManagerを介する判定＞
if(設定したボタン、キーを押した)	←一度設定を中継する方法
{
	//処理する
}
↑どのようなメリットがあるかは仕様変更やマルチプラットフォームに対応しやすくなる

Unity一番上の編集Editープロジェクト設定ProjectSettingをクリック　←設定ウィンドウが開く
プロジェクト設定左側のInput Managerを押下▼を押下　←中身が展開する
▼水平Horizontalを展開　横軸
負方向ボタン　Negative Button	left	←コレを書き換えれば
性方向ボタン　Positive Button		right	←コレ			入力キーを変更出来る
キー入力は文字列で表すことが出来る　leftは「←」左矢印キー　rightは「→」右矢印キー　を押すと反応する
↓各種キーやボタンに対応する文字列が存在する
・通常キー		：a,b,c …
・数字キー		：1.2.3…
・矢印キー		：up, down, left, right
・キーパッド	：[1], [+], [equals]など
・修正キー		：right shift, left shift など
・マウスボタン	：mouse 0, mouse 1 …
・ジョイスティック	：joystick button 0 …
・特殊キー			：backspace, return など
・Functionキー		：f1, f2, f3 …

＜InputManagerのメリット＞
InputMangerを介さない場合　	Input.GetKey(”left”) ←キーの内容をプログラムに直接書くこととなる
キーを変更したい時やプラットフォームを変更したい時に全てのプログラムを書き換えなければならない
InputManagerを介す場合　	Input.GetAxis(”Horizontal”) ←設定の内容をプログラムに書く
プログラムを一切変更せず　キー入力を変更できる！　変更はInput Managerの設定を変えるだけでよい
何があるかわからないので変化に強いプログラムを書こう　別のゲームに流用できる

＜InputManager・判定方法＞InputManagerを介した判定方法もたくさん種類がある
GetButton		GetButton系は、そのボタンやキーを押したかどうか
GetButtonUp
GetButtonDown
GetAxis			GetAxis系は２つのボタンやキーから入力の方向をみる		←スムージング有り
GetAxisRaw													←スムージング無し
↑走る場合はこちらの方がいい　一つのボタンより左右の方向をみたほうがいいので
＜GetAxisの方向軸について＞
方向軸は−１〜１で表される
・例　Horizontalの場合
−１		０		１
 ←	    入力なし	→
<スムージング>　ジョイスティックなど　間の値を判定することが出来る　キーボードの場合は押した長さ
-1, 0, 1の間の少数まで判定する		スムージングなしの判定は-1, 0, 1の３種類のみ
スムージングにするかどうかはお好み　スムージングにする

InputManagerからスムージングを調整できる	無効 Dead 0.001
↓デフォルトでは予備キーが設定されている　←ボタン死んだので使うかもということで下記のように変更
負方向ボタン（副）　Alt Negative Button		a　→　z		左になる
性方向ボタン（副）　Alt Positive Button		b　→　x		右になる
=====================
void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");

        if(horizontalKey > 0)		←右ボタンを押されている場合
        {
		transform.localScale = new Vector3(1, 1, 1);
   		anim.SetBool("run", true);
        }
        else if(horizontalKey < 0)	←左ボタンを押されている場合
        {
		transform.localScale = new Vector3(-1, 1, 1);
		anim.SetBool("run", true);
        }
        else						←入力なし　ボタンを押されていない場合
        {
		anim.SetBool("run", false);
        }
=====================
  SetBool(“パラメーター”名, 値);	アニメーターコントローラーで定義したbool型のパラメーターの値を指定した物に変更する
アニメーターのインスタンスにアクセスしセットブル、ラン、トルゥと書く　つまりrunフラグのtrueとなる
あと２つも同じようにして入力が無いときはfalseにする

PlayerスクリプトをヒエラルキーPlayer_standのコンポーネントを追加にドラッグアンドドロップ　（スクリプトを入れる）
▶実行してみると右を押しても左を押しても右に走るようになる

ゲームオブジェクトをマイナススケールにすると反転する　Xのスケールをーマイナスにすると左右が反転する
右を押すと右にいき　左をおすとマイナススケールで反転し左を向く　左右が変わったようにみえる
かえるちゃんが右を押したら右に走り　左を押したら　左に走るようになったが　ゲームビューがタイトル画面のままである
メインカメラを選択した状態で上のタブ　ゲームオブジェクトーアクティブ状態を切り替えるを2回押すとゲームビューが切り替わるが▶実行するともとに戻る

入力とアニメーションの制御が出来るようになった


＃３６　ステージを作成しよう
Step8	タイルマップを使おう
<Tilemapの導入>
Unity2017.2より前は動かない　Unity2017.2〜Unity2019.1は最初から入ってる　Unity2019.2以降はインストールが必要
上のメニューのウィンドウWindowーパッケージマネージャPackage Manager

↑真ん中▼のPackages:In ProjectをPacages: Unity Registryに変更する　少し出てくるまで時間がかかる　通信中 通信が完了すると項目が増える
パッケージマネージャPackage ManagerとはUnityに更に機能を追加できるもの
2D Tilemap Editorを選択し右下のインストールを押下する　in Projectにインストールされた　タイルマップ

やること　タイルマップを使うための下準備
ヒエラルキー右クリックー2D オブジェクト2D ObjectータイルマップTilemapを押下　←Gridというゲームオブジェクトが作成される
ヒエラルキーGridを選択した状態で上メニューのウィンドウWindowー２DータイルパレットTile Paletteを選択　←タイルパレットウィンドウが開く
新しいパレットを作成横のCreate New Palette▼をクリック

名前は作成するパレットの名前Name stage1　グリッドGridは配置する絵の形（短形Rectangle　角が直角の四角形）セルサイズは1マスの大きさ＞自動Automatic
作成Createを押下  
/Users/me-do/Desktop/unity/006/006/Assets/Tilemap/stage1.prefab
↑Assets配下にTilemapフォルダを作成して保存

やること　マップチップ作成
Pixelmatorを立ち上げる　新規作成　２のべき乗サイズ　幅128　高さ128　解像度960  ピクセル
#804B10  茶色
#179600　緑色
Assets > Texture にmap_ground1.pngとmap_ground2.pngを保存する
map_ground1.pngとmap_ground2.pngを選択してインスペクターのテクスチャタイプをスプライトに変更する　☑iOS用に上書きー適用する
map_ground2.pngをタイルパレットウィンドウへドラッグアンドドロップ　　すると保存先を聞かれるので下記に保存
/Users/me-do/Desktop/unity/006/006/Assets/Tilemap/map_ground2.asset
同様にmap_ground1.pngも実施　タイルパレットへマップチップを登録することが出来た
左クリック＞マップチップ選択　		ホイール＞視点ズーム		中ドラッグ＞視点の平行移動

↑アイコンお押下した後、マップチップを選択するとシーンビューのカーソル部分にマップチップが出現する
これをドラックすることでグリット上にマップチップを塗ることができる　２Dを選択していると塗りやすい　消しゴムで消すこともできる
タイルマップTilemapとは　Tile Paletteにマップチップを登録してグリッドに塗る機能
ステージの形に制限がでてきてしまうが簡単にステージをつくっていけるようになる

やること　当たり判定をつける
ヒエラルキーのTilemapを選択した状態でインスペクターのコンポーネントを追加から２Dタイルマップコライダーを追加
🔍tilemap Collider 2d　←検索ウィンドウで入力すると出てくる　緑の□がついて当たり判定が付いた状態となる
２DタイルマップコライダーTilemap Collider 2DとはTilemapで塗ったマップチップに自動で当たり判定を付けてくれるコンポーネント
細かい設定をしなくても当たり判定を一瞬で終わらせることができる　ただし…　位置を絶対に動かしてはいけない　□１つ１つが当たり判定なので動かすとめっちゃ重い！
例えば地面の揺れを表現したい場合は地面を揺らさずカメラを揺らす　地面にだけ当たり判定が付いている状態　プレイヤーにも当たり判定を付けていく

ヒエラルキーでプレイヤー(player_stand)を選択した状態でインスペクターのコンポーネントを追加から２Dカプセルコライダーを選択
🔍capsule collider 2d　←検索ウィンドウで入力すると出てくる　かえるちゃんの周りにカプセル型の当たり判定が付く

↑キャラクターに合わせて当たり判定を調整する　インスペクターのオフセットX[-0.1],Y[-0.12]とサイズX[1.6],Y[2.03]
何故カプセルコライダーを使用するか　←四角いコライダーだと角がつっかえるから　
🔍rigidbody 2d　←検索ウィンドウで入力　ヒエラルキーのコンポーネントを追加　２Dリジッドボディを追加　プレイヤーに物理演算を付与する
キャラクターがちゃんと地面に付くようになる
完了　ステージ制作基本部分
ToDo　ちゃんとしたステージにする


＃３７	キャラクターを移動させよう
Step9	移動方法を考えよう
＜Unityの移動方法＞
・無限パターン存在する　作りたいゲームによって方法が変わる　同じ方向で動きが違うものであったり　速度が違うものや　
見た目は同じ移動でも中身が全く違う種類の移動がたくさん存在する　まだまだたくさん種類がある　設定の組み合わせも違う
・物理演算を考慮しない移動					・物理演算を考慮する移動
・物理演算を考慮し、直前のフレームから補完する移動	・物理演算を考慮し、現在の速度から次のフレームの位置を予測して補完する移動
見た目が一緒ならいいのでは？　
・移動が早いと挙動が変わる	・ぶつかると挙動が変わる		
・処理の重さが違う　←何がどう重くなるのかが状況によって変わる場合がある　←重い処理が複数重なると症状がでるので原因に気付きづらい
物体の移動はよく考えよう
この解説ではマリオのような２Dアクションゲームを作っていきます　←同じ２Dアクションでも種類が違えば作り方が違う
違うタイプを作る場合は考え方だけ参考にしてください		作るゲームの形が違えば上手く行かない可能性がある

移動は大きく分けると２種類
・Transform操作	
Transform操作　←位置情報を直接制御する方法（ただ移動するだけ）ゲームオブジェクトの位置を動かすだけ
トランスフォームに触っていないつもりでもトランスフォーム操作されている場合があるので注意が必要
物理演算に関係するオブジェクトの場合、移動後再計算が走る　←Transform操作は基本的に軽いが物理演算に関係すると逆に重くなる
・物理エンジン操作
物理演算で位置を計算　移動する際、周囲を考慮した計算をしてくれる　Unity側が物理的計算を全てやってくれるので便利

マリオのようなゲームの場合
・当たり判定を利用したい　←物理エンジン操作が必要だが物理法則は無視する
空中でジャンプの軌道が変わる　動く床・２段ジャンプ・空中ダッシュ等
やること　物理的挙動を無視した物理エンジン操作で移動作成
プレイヤーのスクリプト（以前からの続き）Player.cs
=====================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed;							//③スピードを調整できるようにpublicで変数を定義する　インスペクターでスピードを調整できる

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;					//①リジッドボディ２Dの変数を用意してインスタンスに入れる（2D用と3D用がある）

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();			//②リジッドボディ２Dにアクセス出来るようになった
    }

    // Update is called once per frame
    void Update()
    {
        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;							//④左右のキーを押されたら横軸の速さを入れる変数を用意する

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;							//⑤右を入力したらインスペクターで設定したスピードがでるプラス（速度6.66）正の速度
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;						//⑥左を入力したらマイナスをかけて反対方向になるようにする　負の速度　方向を指定
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;							//⑦何も押していない時　速度を0にする
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);	//⑧リジッドボディ２Dにアクセスしベロシティに値を代入
    }
}
=====================
Rigidbody2D.velocity　←重要ポイント　物理的挙動を無視した物理エンジン操作ができる
・RigidbodyもしくはRigidbody2Dから操作した場合、物理エンジンを使用する
velocityは速度を表す変数　ベロシティに値を代入するということは物体の速さを決めるということ
何故velocityに代入しただけで物理的挙動を無視するのか？
→□物体に様々な力がかかっている　物理的な働きから速度が算出される　その結果が→velocityに代入さる
　↓

①物理的な様々な計算←⑤破棄
②↓速度を算出
③velocity←④スクリプトから値を上書き
⑥↓移動位置を算出
⑦周囲の物との物理的な計算（当たり判定があるのもとぶつかっていないかなどの物理的な計算が行われる）衝突判定など

velocityに値を代入することで物理的な挙動を無視しつつ当たり判定などの物理演算をしてもらえる
Rigidbody2D.velocityで物体を操作する場合
◎物理法則を無視する動きに強く　マリオOK
✗物理法則に従った動きに弱い　　現実的なやつNG
ゲームを作る際は物理演算をどう使用するかを考えよう

								Y軸の速度をそのままに（いずれ変更する）
								↓
 rb.velocity = new Vector2(xSpeed, rb.velocity.y);	
						↑
						X軸の速度を指定したものに設定

ヒイラルキーplayer_standを選択した状態でインスペクターPlayer(Script)Speed 0 →1.06に変更する　0のままだと動かない　
このまま実行▶するとキャラクターがコケる
インスペクターのRigidbody 2DーConstraints ▼回転を固定Freeze Rotation☑Zをチェックする　Z軸で回転しなくなる 速度を4に設定


＃３８　	接地判定を作ってみよう
Step10	IsTriggerを使ってみよう　イズトリガー
走ったりジャンプするには地面についているかを判断する必要がある
やること　地面を認識する判定を作る
ヒエラルキーUntitledシーンを保存　player_standをGridの下にもってくる
player_stand右クリックー空のオブジェクトを作成Create Empty(プレイヤーの子に)　名前GameObject →GroundCheck
GroundCheckを選択した状態でコンポーネントを追加「🔍box」2D ボックスコライダー

↑細長くしてキャラ判定の下に
インスペクターBox Collider 2D トリガーにするIs Trigger☑つける
Is Triggerイズトリガーとはコライダーの当たり判定が無くなる　代わりに判定内に入った物を取得できるようになる　この判定で地面を取得する
プロジェクトAssets>Script右クリックー作成ーC# スクリプト　名前：GroundCheck
ボックスコライダー２Dの判定の中に何かが入ったかどうかを調べるスクリプトを書いていく　ちゃんと動作するかの確認スクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)	//必ずこの通りに書く　OnTriggerEnter2Dというメソッド
    {
        Debug.Log("何かが判定に入りました");
    }


    private void OnTriggerStay2D(Collider2D collision)	
    {
        Debug.Log("何かが判定に入り続けています");
    }


    private void OnTriggerExit2D(Collider2D collision)	
    {
        Debug.Log("何かが判定を出ました");
    }
}
=====================
OnTriggerEnter2D　Unity側から呼ばれる特別なメソッド
メソッド名、引数の種類を決められた形にするとUnity側からこのメソッドを呼ぶ　その為、必ずこの通りに書く

<OnTriggerEnter2Dが呼ばれる条件>全て満たす必要あり
1.	Is Triggerな2Dコライダーがそのゲームオブジェクトもしくは子オブジェクトについている
スクリプトがついているゲームオブジェクト(GroundCheck)にIs Triggerなコライダー(かえるちゃんの下の細長い□)がついている

2.	そのゲームオブジェクト、もしくは親、もしくは相手の方にRigidbody2Dがついている
親オブジェクト(▼Player)にRigidbody2DがついているのでOK

3.	Is Triggerな２Dコライダーの判定内に別の2Dコライダーが侵入した
細長い□に地面が入ってくればOK　地面の方にはタイルマップ２Dが入っているのでコライダーである

OnTrigger系のメソッドは他にも種類がある Is Triggerへの侵入を検知する特別なメソッド
OnTriggerEnter2D	判定内に２Dコライダーが侵入したら呼ばれる
OnTriggerStay2D	判定内に２Dコライダーが入り続けていたら呼ばれる
OnTriggerExit2D	判定内から２Dコライダーが出たら呼ばれる
↑これらのメソッドを使い分けることで現在の足物を調べられる

ヒエラルキーplayer_standを選択した状態で実行▶
[挙動]							[Debug.Log]
キャラクターが着地					何かが判定に入りました
キャラクターが地面に接触し続けている	何かが判定に入り続けています
キャラクターが地面から落ちる			何かが判定を出ました
↑判定は取ることが出来た

やること　判定に入ったものが地面かどうかを判別できるようにする　地面が侵入したか判別する
ヒエラルキーTilemapを選択した状態でインスペクターのタグUntagged▼タグを追加…Add Tag…　←自分の好きなタグを追加できる
これが地面だと解るタグを追加してゲームオブジェクトに付けていく　地面だとわかるタグを追加する
タグ　リストは空ですList is Empty右下の＋を押下  追加するタグの名前；Ground を入力してSaveを押下　←タグを追加できた　Tag 0 Ground
もう一度ヒエラルキーTilemapを選択　もう一度　タグUntagged▼を押下すると先程追加したタグGroundを選択　←Tilemapに地面用のタグを付けることができた

次はスクリプト側で判定内に侵入したコライダーが地面なのかどうかを判別していく
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";			//プログラムを書きやすくする為、ストリング型の変数にタグを同じ文字列(Ground)を使用	

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)		//判定内に入った２Dコライダー（タイルマップ２Dが含まれる）
    {
        if (collision.tag == groundTag)			//判定内に入った２Dコライダーが張り付いているゲームオブジェクトのタグを見ることが出来る　タグの名前がGroundなら通る
        {
            Debug.Log("地面が判定に入りました");
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)			//地面の判定ができるようになる　上と同じメソッド
        {
            Debug.Log("地面が判定に入り続けています");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)			//地面の判定ができるようになる　上と同じメソッド
        {
            Debug.Log("地面が判定を出ました");
        }
    }
}
=====================
[挙動]							[Debug.Log]
キャラクターが着地					地面が判定に入りました		Enter
キャラクターが地面に接触し続けている	地面が判定に入り続けています	Stay
キャラクターが地面から落ちる			地面が判定を出ました			Exit

タグを元に戻すとログが表示されない　Ground→Untagged　←ちゃんとタグが機能していたことが解る　確認が終わらったら　タグをGroundに戻す　地面を取得することが出来た
やること　接地判定を作る

GroundCheck.cs　←接地判定のスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    private bool isGround = false;						//①接地判定用のフラグ
    private bool isGroundEnter, isGroundStay, isGroundExit;	//②3つのフラグを作成する

    //物理判定の更新毎に呼ぶ必要がある					//欠点：Unityの物理演算の判定のたびにこのメソッドを呼ぶ必要がある
												//各種オントリガーメソッドに使っているフラグを下ろしてあげる(false)必要がある為このような制約ができる
												//もっといい書き方があるが今の段階では難しいので今回はコメント対応で妥協
    public bool IsGround()								//⑥プレイヤーのスクリプトから読めるようにpublicでメソッドを書いていく　返り値として地面にちゃんと設置しているかを返す
    {
        if(isGroundEnter || isGroundStay)					//⑦EnterもしくはStayを通っていた場合、接地判定をtrueにする
        {
            isGround = true;
        }
        else if (isGroundExit)							//⑧Exitを通っていた場合、接地判定をfalseにする　Exitを通っていた場合でもEnterかStayが呼ばれたら、地面に着いているとみなす
        {											//またelse文が無い為、どのメソッドも通っていない場合、isGround(接地判定フラグ)はそのままとなる
            isGround = false;								//キャラクターがしばらく止まるなどしてStayが呼ばれない状態となったとしても対応できる
        }

        isGroundEnter = false;							//⑨呼び出されたら各種フラグをfalseにして元の状態に戻す
        isGroundStay = false;
        isGroundExit = false;
        return isGround;								//⑩接地判定を返す
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;							//③それぞれのフラグをそれぞれのメソッドでtrueにする（trueになったらこのメソッドを通ったとみなす）
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;							//④それぞれのフラグをそれぞれのメソッドでtrueにする（trueになったらこのメソッドを通ったとみなす）
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;							//⑤それぞれのフラグをそれぞれのメソッドでtrueにする（trueになったらこのメソッドを通ったとみなす）
        }
    }
}
=====================
＜接地判定＞
・地面が判定内に入る　	→ true
・地面が判定内から出る	→ false
↑ではちょっと足りない
プレイヤーの進行方向→　←床の進行方向
↑地面から出た		　　↑地面に入った
！同時に起きる事があるのでEnterとExitだけでは不十分　falseのままになってしまう
OnTriggerStay2Dで居続けるのを判定しては？
Stayで呼ばれている時　true 呼ばれていない時　false　←✗出来ません　しばらく止まっているとOnTriggerStay2Dは呼ばれなくなる　←処理負荷軽減の為、動いていないものを処理しなくなる
止まり続けると地面から離れたとみなされる


ちょっと不格好だが接地判定が出来たのでプレイヤーほうで呼び出していく
↓プレイヤーのスクリプト
Player.cs
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed;
    public GroundCheck ground;					//①パブリックでシリアライズ化し、GroundCheck.csからインスペクターから設定できるようにする

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;					//②接地判定を入れておく変数を用意する

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()							//④Fixedを追記
    {
        //接地判定を得る
        isGround = ground.IsGround();				//③接地判定のスクリプトのインスタンスから先程作ったメソッドを使って接地判定フラグを受け取る
											//これで様々なアクションを作る際、地面に着いているかどうかを判別することができる
        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal”);		//FixidUpdateが呼ばれなくても次のフレームで押し続けていればOK
        float xSpeed = 0.0f;

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);		//速度を入れている　FixedUpdateが連続で呼ばれても何も変わらない
    }
}
=====================
後はパブリックからインスペクターで設定できるようにしたのでヒエラルキーのPlayer_standを選択した状態で
Player(スクリプト)のGround⦿を押下　シーンGroundCheckスクリプトを選択　（ドラッグアンドドロップできなかった）


＃39　FixedUpdateについて
・FixedUpdateとは・Updateとの使い分け
Unity側が呼び出す特別なメソッド
Update > 毎フレーム呼ばれる　FixedUpdate > 一定間隔で呼ばれる
						↑フレームレートに依存しないと解説されることが多い　←勘違いの元　現実時間ではなくゲーム内時間で一定間隔
・物理演算の処理の前に毎回呼ばれる　→　物理演算ってどういうタイミング？　→ゲーム内時間で一定間隔呼ばれる
＜FixedUpdate＞
 物理演算の前にしたい処理を書く
フレームレートは現実時間の流れと同じ　処理が間に合わず落ちてしまう場合がある
現実時間に合わせた場合、一定の時間で処理できるとは限らない　→物理的なシュミレーションがうまくいかないケースが出てくる
（先の予測が必要なものなど）別の時間の概念が必要　→ゲーム内時間
現実時間の流れ　→線　ゲーム時間の流れ　｜進｜進｜　進　　｜進　｜進　　　　｜進　点　一つ一つで一定時間進める　
どうみても一定間隔ではないが進めている時間が一定　現実時間でバラバラな処理でもゲーム内では一定間隔で処理される
｜進←このタイミングでFixedUpdateが呼ばれる　FixedUpdateの次に物理演算も行われるので物理演算もこのタイミング呼ばれる
↑この中でゲーム内時間更新→FixedUpdate→物理演算が呼ばれている
ーーーーーーーーーーーゲーム内時間流れーーーーーーーーーーーーー

◇UpdateとFixedUpdate◇

Updateは1フレームの間に必ず呼ばれる
FixedUpdateは1フレームの間に呼ばれたり呼ばれなかったり、複数回呼ばれたりする
FixedUpdateが呼ばれる回数がどのような基準になっているかというと
Unity上メニューー編集Editープロジェクト設定ProjectSettigー時間Timeを押下
固定時間ステップFixed Timestep 0.02 ゲーム内時間を進める秒数　0.02秒づつゲーム内時間が更新される
30FPSは一秒間に30回フレームを出力している　1÷30=0.033333…←1フレームあたり秒　画像出力現実時間0.03→ 0.06→ 0.09秒
｜		0.03|			｜		0.06|		｜			0.09|				3回呼ばれた　Update
↑FixedUpdate 0秒			↑0.02秒				↑0.04秒、0.06秒					4回呼ばれた　FixedUpdate
ゲーム内時間　一回呼ばれる	固定時間ステップ秒　		0.09秒を超えない範囲で2回呼ばれる
FixedUpdateはゲーム内時間と現実時間がなるべく同じ様になるように処理される

しかしながら現実時間とゲーム時間が大きく離れるケースがある
		　3.333…
ーー・・・→｜
処理落ちした
3.333…÷0.02=166.666…
166回FixedUpdateを呼ばなくてはいけない　←処理が重すぎる
先程の時間ウィンドウで最大許容時間ステップMaximum Allowed Timestep で1フレームで進められる限界の時間が決められている 0.3333333
この限界時間以上にゲーム時間を進められない

03.333…
ーー・・・→｜
処理落ちした
0.3333333までしか進められない　0.333…÷0.02=16.666666…　となりFixedUpdateは16回呼ばれる
＜FixedUpdateの呼ばれ方＞※Fixed Timestepがデフォルトの場合
フレームレートが高いと1フレーム内で呼ばれない場合が多くなる　←1フレームの秒数が0.02より下回るから(60FPS 1÷60=0.01666…)
|0.016	0.032|	0.048|	0.064|	0.08		0.096|	0.112|	0.128|	0.144|	0.16		0.176|	0.192|
逆にフレームレートが低いと1フレーム内で複数回呼ばれやすくなる
！FixedUpdateに重い処理を書くとフレームレートが落ちた時に複数回呼ばれる場合が多くなる為、重い時、重さが更に加速する
物理演算に関係する処理だからといって何も考えずに突っ込むのはやめましょう

◇入力とFixedUpdate◇
ボタン入力→物理演算で動かす←よくある
↑
ボタン入力は1フレーム内で一回判定　FixedUpdateは1フレーム内で呼ばれたり呼ばれなかったりする

↓例えばこのようなコードがあったとします
//Start等でインスタンスを取得している物とする
private Rigidbody r;
private void FixedUpdate()
{
	if (Input.GetKeyDown(KeyCode. RightArrow))　←「→」右矢印キーを押した瞬間だけtrueになる
	{
		r.AddForce(Vector3.right, ForceMode. Impulse);　←右側の方向に瞬間的に力を加える命令
	}	↑
}		↑
		物理演算に関係する処理なのでFixedUpdateに書くのが一見正しいように見えるが…

順番に処理をみていく
①まずFixedUpdateが呼ばれ物理演算処理が終わった後、入力判定が行われます
	入力判定
	｜
	→ー｜→ー｜→ー｜
↑	｜	
↑	FixedUpdate
↑
②この判定の手前でボタンを押していた場合↓
	入力判定
	｜	｜←この間　（③Input.GetKeyDownは次の入力判定までtrueになる）
	→ー｜　ー｜→ー｜
	　　　↑
	④FixedUpdateが呼ばれなかった場合はどうなる？
	⑤FixedUpdateが呼ばれていないのでボタンを入力したのに処理が行われない
	入力判定←こちらがtrueとは限らない
	｜	｜
	→ー｜　ー｜→ー｜
	↑		　↑
			　FixedUpdate
	⑥次でFixedUpdateが呼ばれたとしても入力がtrueとは限らない
FixedUpdateで瞬間的に入力すると入力がなかった事になる場合がある

逆に処理落ちなどしてFixedUpdateが16回呼ばれた場合
入力判定←こちらがtrueとは限らない
	｜	｜
	→ー｜→ー｜→ー｜
	　　　↑
		FixedUpdate16回
瞬間的な力が１６連打される　すさまじい勢いで右側に吹き飛んでいく
入力とFiexdUpdateはよく考えて使用する

＜今までの解説＞今つくっているやつは大丈夫？
Input.GetAxis(“Horizontal”);
↑押しっぱなしを判定
FixidUpdateが呼ばれなくても次のフレームで押し続けていればOK
Rigidbody.velocity
↑速度を入れている　
FixedUpdateが連続で呼ばれても何も変わらない

何故FixedUpdateにしたか
・Updateで速度を指定すると物理演算が連続で呼ばれた時、摩擦等で減衰してしまう為
物理演算が何回も呼ばれてしまうと速度の入れ直しが行われないまま物理演算が行われてしまうので一定の速度にしたつもりが減衰が起こる

・接地判定のフラグを物理演算前に降ろして物理演算でまた判定し直したい為
オントリガーエンター、ステイ、イクジットのフラグを物理演算の前に降ろしておかないと前の物理演算のフラグがそのままになってしまい
前のものが分からなくなってしまうので物理演算前に呼ばれるFixedUpdateにしたわけです　

＜FixedUpdate まとめ＞
・物理演算の前に毎回呼ばれる
・そのタイミングはゲーム内時間で一定間隔で呼ばれる
・１フレームの間に呼ばれなかったり複数回呼ばれたりする

・物理演算の前にしたい処理を書こう
・可能なら重い処理は他へ逃がそう
・瞬間的な処理は相性が悪いので書く場合はよく考えてから


＃４０	ジャンプを作ってみよう
Step10	物理演算を無視したジャンプ

スクリプトを書き写したい場合↓
Unity 2Dアクションの作り方【ジャンプ】【高さを押した長さで変更可】 | ゲームの作り方！

やること　押した長さで高さが変わるジャンプを実装する
ヒエラルキーplayer_standを選択した状態でRigidbody 2D 重力スケールGravity Scaleを１→０に変更 　←これで重力が働かなくなる
Y軸の物理演算を止めて自前の物に変更していく　＃３７でX軸は完了　今回はY軸やるで
プレイヤーのスクリプトをビジュアルスタジオで開く
Player.cs
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float jumpSpeed; //ジャンプ速度			//⑤ジャンプ速度をインスペクターで設定でき調整しやすくする　変数を作成
    public float gravity; //重力　					//①重力の値をインスペクターで設定できるようにする為　変数を作成
    public GroundCheck ground; //接地判定

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");		//⑥↑縦軸のキー入力を受けとる  バーティカル
											//キー入力は#35参照　次は地面についている時ジャンプできるようにする
        float xSpeed = 0.0f;
        float ySpeed = -gravity;						//②Y軸のスピードをプログラムから調整できるように変数を作成
											//Y軸に対して何もしていない時　重力を働かせる　その為、初期値に値を設定する
        if(isGround)								//⑦地面についている時で（地面から離れた場合の処理が足りない）
        {										//接地判定は#38参照
            if(verticalKey > 0)						//↑上方向のキーが入力されている時
            {
                ySpeed = jumpSpeed;					//Y軸の速度を設定したものになるようにする
            }
        }

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);		//③リジッドボディ２Dに渡している速度のY軸をこちらで指定したものに変更する
    }											//変数(xSpeed, ySpeed)を調整すればキャラクターを好きな速度で動かすことができる
}
=====================
④インスペクターで重力の値を設定する
ヒエラルキーplayyer_standを選択した状態でインスペクターPlayer(スクリプト)重力Gravity0→3を入力
この状態で実行▶すると自前の重力がキャラクターにかかる　次はジャンプを作っていく
⑧インスペクターでジャンプスピードの値を設定する
ヒエラルキーplayyer_standを選択した状態でインスペクターPlayer(スクリプト)Jump Speed0→5を入力
この状態で実行▶するとぴょこぴょこ動くだけでジャンプできない
地面から離れた場合の処理が足りないので次はジャンプ中の処理を書いていく

=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float jumpSpeed; //ジャンプ速度
    public float gravity; //重力
    public GroundCheck ground; //接地判定

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isJump = false;					//①ジャンプしているかどうかのフラグを作成

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        if (isGround)
        {
            if(verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                isJump = true;							//②↑キーが押されている場合true
            }
            else
            {
                isJump = false;						//↑キーが押されていない場合false
            }
        }
        else if (isJump)							//③ジャンプ中の処理を追加
        {
            if(verticalKey > 0)
            {
                ySpeed = jumpSpeed;					//↑キー押している場合はジャンプ速度にする
            }
            else
            {
                isJump = false;						//↑キー押していないならジャンプフラグをfalseにする
            }
        }

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
=====================
この状態で実行▶するとジャンプはできたが無限にジャンプできてしまうので次はジャンプに制限をつける

Player.cs　　
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float jumpSpeed; //ジャンプ速度
    public float jumpHeight; //ジャンプする高さ		//②インスペクターでジャンプする高さを設定できるようにする
    public float gravity; //重力
    public GroundCheck ground; //接地判定

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;				//①ジャンプした位置を記録する変数を作る

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        if (isGround)							//←地面から
        {
            if(verticalKey > 0)					//←ジャンプした時
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する　//③←高さを保存
                isJump = true;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //上ボタンが押されているかつ、現在の高さがジャンプした位置から自分が飛べる高さより下にいる時、上昇する
            if(verticalKey > 0 && jumpPos + jumpHeight > transform.position.y)　//④←地面でジャンプした位置から＋ジャンプできる高さ＝飛べる高さ
            {														　//飛べる高さ＞自分のY座標　の場合true
                ySpeed = jumpSpeed;
            }
            else
            {
                isJump = false;
            }
        }

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
=====================
⑤インスペクターのPlayer(スクリプト)Jump Heightを0→3に変更する　ジャンプする高さ
この状態で実行▶すると　とりあえずジャンプするようになる　高さ制限付き　まだ足りない　
Unity上メニューウィンドウー２Dータイルパレットを表示し、適当に空中にブロックを作る
空中のタイルパレットに頭をぶつけると無限に飛べてしまう　これを直していく

ヒエラルキーGroundCheck右クリックー複製Duplicateー名前：HeadCheck 　頭用
↓その判定をキャラクターの頭の上にもってくる

この判定内に地面が入ったら上昇を止める

Player .csを編集する
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float jumpSpeed; //ジャンプ速度
    public float jumpHeight; //ジャンプする高さ
    public float jumpLimitTime; //ジャンプ制限時間		//②何かにつっかえた時の為、ジャンプに制限時間を追加　
    public float gravity; //重力
    public GroundCheck ground; //接地判定
    public GroundCheck head; //頭をぶつけた判定		//①インスペクターで設定できるようにpublicに設定

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;					//③頭をぶつけたフラグを追加
    private bool isJump = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;					//④滞空時間を計る変数を追加

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();					//⑤接地判定の時と同じ用に頭の判定もとっていく

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        if (isGround)
        {
            if(verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;						//⑥ジャンプしている時間を計りたいのでジャンプした時、時間をリセットする
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)							
        {
            //上方向キーを押しているか					//⑦見づらくなってきたので条件式を分解　条件を変数に入れて見やすくしていく
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか			//⑧左記の判定を追加
            bool canTime = jumpLimitTime > jumpTime;	//制限時間＞ジャンプしている時間でtrueになる

            if(pushUpKey && canHeight && canTime && !isHead)	//⑨if文に書いていく上方向キーを押しているかつ飛べる高さより下にいるかつ
            {												//ジャンプの時間がオーバーしていないかつ頭ぶつけていない時上昇する
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;						//⑩ジャンプ中の時間を計る　ジャンプ時間を計測する変数にTime.deltaTimeを足す
            }												//上昇している間に進んだゲーム内時間を毎回足すのでその合計はジャンプで上昇している時間になる
            else											//経過時間を毎回足すことによって時間を計測できる
            {
                isJump = false;
                jumpTime = 0.0f;								//⑪上昇できなくなった時時間をリセットする
            }
        }

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
=====================
頭ぶつけていない判定についてはFixedUpdateが呼ばれるたびに更新する必要がある為if文の中には書かない（ isHead）
Time.deltaTime	最後のフレームからの通過時間（秒）　FixedUpdate内ではゲーム内時間を進める秒数　ゲーム内時間＃３９
プログラムが出来たらインスペクター設定を忘れないようにする

Player(Script)
Speed 速度		4
Jump Speed		5
Jump Height		3
Jump Limit Time	5
Gravity 重力		5
Ground			GroundCheck	(GroundCheck.cs)
Head 頭			HeadCheck	(GroundCheck.cs)		⦿から選択する
この状態で実行▶すると上の地面に頭をぶつけるとちゃんと降りるようになる

やること　ジャンプアニメーションをつける
上メニューのウィンドウWindowー アニメーションAnimationー アニメーターAnimatorを選択して　アニメーターウィンドウを開く　アニメーション制御＃３５

◇ジャンプ　上昇モーション
アニメーターウィンドウのplayer_stand右クリックー遷移を作成ーplayer_jump_upに→やじるしをくっつける
同じようにしてplayer_run右クリックー遷移を作成ーplayer_jump_upに→
アニメーターウィンドウのパラメーターを選択した状態で＋Bool 名前をjumpにする

→をクリックしてインスペクターから▶Settingsをクリックー終了時間ありHas Exit Time☑を外すと遷移時間(s)Transition Duratior0.25→0にする
Conditions リストは空です右下の＋を押下し　run▼をクリックしてjumpに変更　jump true
jumpフラグがtrueの時jumpフラグに遷移するようにする
→も→と同様な設定にする

◇ジャンプ下降モーション
player_jump_up右クリックー遷移を作成ーplayer_jump_downに→やじるしをくっつける
→も→と同様な設定にするがjump trueではなくjump falseと設定する

player_jump_downからplayer_standへ←を引っ張る	ground : true	jump : false	Has Exit Time□	遷移時間0
player_jump_upからplayer_standへ←を引っ張る	ground : true	jump : false	Has Exit Time□	遷移時間0
アニメーターウィンドウのパラメーターを選択した状態で＋Bool 名前をgroundにする

ジャンプせずに落下する場合がある為の設定↓
player_stand→player_jump_down	ground : false	Has Exit Time□	遷移時間0
player_run→player_jump_down	ground : false	Has Exit Time□	遷移時間0


player_standを選択　インスペクターTransitions配下に立ち状態からの矢印一覧が表示されている　上の矢印が優先される

↑優先したい矢印を上にもっていく
1.上昇
2.下降
3.走り
同じ用に走りモーションも設定する　player_run

アニメーションをループさせたくない場合は
プロジェクトーAssets ーAnimation ーplayer_jump_downを選択
インスペクターのループ時間Loop Time☑を外す

後はアニメーションのフラグに今の状態を渡してあげる

=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float jumpSpeed; //ジャンプ速度
    public float jumpHeight; //ジャンプする高さ
    public float jumpLimitTime; //ジャンプ制限時間
    public float gravity; //重力
    public GroundCheck ground; //接地判定
    public GroundCheck head; //頭をぶつけた判定

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        if (isGround)
        {
            if(verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if(pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }

        anim.SetBool("jump", isJump);
        anim.SetBool("ground", isGround);
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
=====================
この状態で実行▶するとちゃんとアニメーションする


＃４１	移動を滑らかに表現しよう
Step11	アニメーションカーブを使ってみよう
＜いままで作ったもの＞ずっとキャラクターの速度が同じ　Rigidbody2D.velocityに固定値を入れているので一定速度になる
動きにメリハリがないので工夫してみる
移動　	→　だんだん早く
ジャンプ	→　最初は早く頂点ではゆっくり

プレイヤーのスクリプト Player.cs 
=====================
//インスペクターで設定する
    public float speed; //速度
    public float jumpSpeed; //ジャンプ速度
    public float jumpHeight; //ジャンプする高さ
    public float jumpLimitTime; //ジャンプ制限時間
    public float gravity; //重力
    public GroundCheck ground; //接地判定
    public GroundCheck head; //頭をぶつけた判定
    public AnimationCurve dashCurve;			//パブリックでアニメーションカーブの変数を作成する　ダッシュ用の変数
    public AnimationCurve jumpCurve;			//パブリックでアニメーションカーブの変数を作成する　ジャンプ用の変数
=====================
ヒエラルキーのplayer_standを選択した状態でインスペクターのスクリプトを見ると下記の灰色のDashCurve■をクリックする

AnimationCurveとは時間からカーブで設定した値を得るもの　時間経過での数値の変化を表現するのに便利
カーブウィンドウが開く　デフォルトの状態↓
1.0	
	↑返す値
0.5	
		　→時間
0	　0.5	　1.0
線が／の場合、0.5秒の時の値を教えてと言うと0.5の値を返してくれる　　速度×時間で大きくなる値→加速する表現になる
右クリックで編集点を追加できる
編集点右クリックEditKeyで点の縦横の座標を数値で指定することができる
編集点右クリックブロークンBrokenでハンドルが両側で連動しなくなる
ブロークンされたハンドルは編集点右クリックフラットFlatで元に戻すことができる
編集点右クリックDelete Keyで編集点を消すことができる
端っこの⚙歯車を左クリックするとループLoopさせたり折返しループPing Pongさせることができる

ダッシュ用

↑Dash Curve 最高速に早く達する形に↗   頂点の大きさ1.0　初速を早く↑　←最高速に達する時間を短く
下	0.000	0.100
上	0.500 	1.000

ジャンプ用

上		0		1
真ん中	0.85		0.725
下		1		0.65
初速を早く　上昇するにつれゆっくりになるようにしている　　ポイントは終点を0にしない
0にしてしまうとジャンプ中に失速してしまうので挙動がおかしくなる

playerのスクリプト　移動とジャンプに↑を適用していく
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float jumpSpeed; //ジャンプ速度
    public float jumpHeight; //ジャンプする高さ
    public float jumpLimitTime; //ジャンプ制限時間
    public float gravity; //重力
    public GroundCheck ground; //接地判定
    public GroundCheck head; //頭をぶつけた判定
    public AnimationCurve dashCurve;
    public AnimationCurve jumpCurve;

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;
    private float dashTime = 0.0f;				//①ダッシュ用の時間計測の変数
    private float beforeKey = 0.0f;				//②前の入力を保存しておく変数

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        if (isGround)
        {
            if(verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if(pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            dashTime += Time.deltaTime;			//③横へ移動している時、時間を計測する　ダッシュ中の時間を計測
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            dashTime += Time.deltaTime;			//③横へ移動している時、時間を計測する　ダッシュ中の時間を計測
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            dashTime = 0.0f;						//④止まったら0に　止まったら時間をリセットする
            xSpeed = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if(horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if(horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }
        beforeKey = horizontalKey;

        //アニメーションカーブを速度に適用
        xSpeed *= dashCurve.Evaluate(dashTime);
        if(isJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }

        anim.SetBool("jump", isJump);
        anim.SetBool("ground", isGround);
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
=====================
⑤前のキー入力と反対のキーを押したらダッシュの継続時間をリセットするようにする
前回のキー入力と今回の入力の方向が違う場合という条件で判定し、ダッシュの継続時間を0にする
キー入力が反対になる　つまり反転した場合　加速をリセットするようになる
⑥Xの移動速度にアニメーションカーブをかけてあげれば加速の表現になる
ダッシュ用のアニメーションカーブに.Evaluateと書く
AnimationCurve.Evaluate(時間)　アニメーションカーブから指定された時間の値を返す
先程のアニメーションカーブをグラフで作成していたものを実行するメソッドとなる
⑦ジャンプも同様にする　ジャンプの時間は前回作ったものをそのまま流用する

移動とジャンプにちょっとした色をつけることができた



＃４２	カメラを追従させてみよう
Step12	Chinemachineを使ってみよう
キャラにカメラがついてくるように　Chinemachineという機能を使用
やること　ChinemachineをUnityに追加　シネマシーンはデフォルトのUnityに入っていない
上メニューのウィンドウWindowーパッケージマネージャPackage Manager   ウィンドウが開く　Packages:Unity Registry▼に変更
Chinemachineを選択　Unityバージョン2020.1.1f1ではChinemachine2.6.2をインストールしようとすると下記エラーとなりインストール出来ない

An error occurred(Unable to add package[com.unity.cinemachine@2.6.2]:
Cannnot fetch authorization code. User access token is expired or user is not logged in.). See console for more details.
Smart camera tools for passionate creators. 
エラーが発生しました(Unable to add to package[com.unity.cinemachine@2.6.2].
Cannnot fetch authorization code. ユーザーアクセストークンの有効期限が切れているか、ユーザーがログインしていません。) 詳細はコンソールを参照してください。情熱的なクリエイターのためのスマートカメラツール。

IMPORTANT NOTE: If you are upgrading from the Asset Store version of Cinemachine, delete the Cinemachine asset from your project BEFORE installing this version from the Package Manager.
重要：CinemachineのAsset Storeバージョンからアップグレードする場合は、パッケージマネージャからこのバージョンをインストールする前に、プロジェクトからCinemachineのアセットを削除してください。

Unity 2020.1 からパッケージマネージャで発見できなくなったパッケージのインストール方法 – ユニティ・テクノロジーズ・ジャパン合同会社
↑Unity日本語ヘルプデスクにUnity 2020.1からCinemachineのインストール方法が記載

動画のコメントに書き投稿があり
2020年6月にCinemachine ver2.6が出ているようですがUnity2019.4.4f1にインストールしようとするとエラーが出ました。Cinemachine ver2.5だと問題なくインストールできたので最新版は不具合があるのか相性の問題だと思います。自分が引っ掛かった個所なのでメモ代わりに残しておきます。

＜解決策＞
パッケージマネージャの左上の＋ボタンから Add package from git URL を選択し、下記パッケージ名を入力
com.unity.cinemachine@2.5

↑ちゃんとインストールされるとプロジェクトのパッケージの中にシネマシーンが追加される
シネマシーン自体を勝手に配布・販売✗　シネマシーンを使って作ったゲームを配布・販売○　著作権は私にある

上メニューにChinemachineが追加されているのでこれをクリックしてCreate 2D Cameraを選択すると
CM vcam1（CMVカム１）というゲームオブジェクトがヒエラルキーに作成される
ヒエラルキーのMain Cameraを選択するとインスペクターにCinemachineBrainシネマシーンブレインというコンポーネントが新たに作成されている

やること　カメラをプレイヤーに追従するようにする
ヒエラルキーのCM vcam1を選択した状態でインスペクターCinemachineVirtualCameraのFollow⦿をクリックするとウィンドウが立ち上がるので
シーンのplayer_standを選択する
↓CM vcam1を選択した状態でゲームビューにすると変な枠が表示される

↑タイトルシーンがずっとじゃまなので消したい
Unity：ヒエラルキー（Hierarchy）ビューの使い方 | Unity+AssetStoreおすすめ情報
＜解決策＞
シーンを保存した後にプロジェクトAssetsーScenes　UnitledをダブルクリックでUnitiledのみヒエラルキーに表示される

カメラがカエルちゃんを追いかけるようにできた　が画面外までついていってしまう　見えてほしくない場所までカメラが映してしまう
現時点での動画との差異　Player - player_stand	test - Untitled		ファイルが種類別で表示されない

やること　カメラの移動範囲に制限をかけていく
ヒエラルキーMain Cameraを選択している状態で
インスペクターCameraー投影方法Projectionー透視Perspectiveから平行投影Orthographicに変更
↑画面を平面的に映すようになる　シーンビューの２Dボタンを押すと解りやすい

ヒエラルキーCM vcam1を選択した状態でインスペクターCinemachineVirtualCameraーLens  　
平行投影サイズ		Orthographic Size	5	←カメラの映す範囲を調整　		□大きさ
ニアクリップ面		Near Clip Plane	0.3	←どれだけ近くまでカメラに映すか		
ファークリップ面	Far Clip Plane		10	←どれだけ遠くまでカメラに映すか	

ヒエラルキーCM vcam1を選択した状態でインスペクターAdd Extension select▼ーCinemachine Confineをクリック
シネマシーンコンファインというコンポーネントが追加される

ヒエラルキーで右クリックー空のオブジェクトを作成（GameObject）名前：CameraCollider 　わかりやすいものに
インスペクターTransform…リセット　で位置をリセット
このゲームオブジェクトはカメラの移動範囲を表すのに使用する

コンポーネントを追加から🔍polygon collider 2d	2D ポリゴンコライダーPolygon Collider 2Dを追加

↑五角形のコライダーが出現　五角形では使いづらいので四角形にする
インスペクターPolygon Collider 2Dー▼ポイントー▼パスー▼要素0ーサイズ5→4に変更
ヒエラルキーCameraColliderから別のものを選択して再びCameraColliderを選択すると変な四角形になる

↑Polygon Collider 2Dのコライダーの編集Edit Colliderをクリックする  ←コライダーを動かせるようになるので□を広げていく
ウィンドウー２Dータイルパレットを選択してタイルパレットの位置を修正した
緑の四角の範囲がカメラが移動可能な範囲になる　白い四角より大きくなるようにする　（四角形じゃなくてもOK）

↑座標の数値を入れることで綺麗にすることができる　変な線ができたらヒエラルキーの別のゲームオブジェクト選択　元のゲームオブジェクト選択で消える
ヒエラルキーCameraColliderを選択した状態でインスペクターPolygon Collider 2D☑をオフ　←後で☑つけます
ヒエラルキーCM vcam1を選択した状態でインスペクターCinemachine Confiner (Script)ーBounding Shape 2Dに
ヒエラルキーCameraColliderオブジェクトをドラッグアンドドロップ
この状態で実行すると　カメラが範囲内しか動かないようになるが　ならない　うまくいかない　Unityのバージョンによるものと思われる
カメラが変な位置で固定された
ヒエラルキーCameraColliderオブジェクトを選択した状態でインスペクターPolygon Collider 2D☑をつける　トリガーするIs Trigger☑つける



＃４３	プログラムを整理しよう
Step13	今までのプログラムを整理しよう
Unity 2Dアクションの作り方【プログラムを整理しよう】【入門】 | ゲームの作り方！
覚えながら作るとぐちゃぐちゃになりやすい…　ぐちゃついたら定期的に整理整頓しよう

プレイヤーのスクリプトのインスペクターがたくさんあってわかりづらい
変数の前に[]をつける
Attribute　アトリビュート
クラスやメソッド、変数の前に　[属性]を書くと特殊な挙動になる　Unityの機能

//インスペクターで設定する
    public float speed; //速度
    public float jumpSpeed; //ジャンプ速度
    public float jumpHeight; //ジャンプする高さ
    public float jumpLimitTime; //ジャンプ制限時間
    public float gravity; //重力
    public GroundCheck ground; //接地判定
    public GroundCheck head; //頭をぶつけた判定
    public AnimationCurve dashCurve;
    public AnimationCurve jumpCurve;
↓
//インスペクターで設定する
[Header("移動速度")] public float speed;
[Header("重力")] public float gravity;
[Header("ジャンプ速度")] public float jumpSpeed;
[Header("ジャンプする高さ")] public float jumpHeight;
[Header("ジャンプ制限時間")] public float jumpLimitTime;
[Header("接地判定")] public GroundCheck ground;
[Header("頭をぶつけた判定")] public GroundCheck head;
[Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
[Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
↑ヘッダーの属性を使う[Header(“コメント”)] 　全部のパブリックの変数に適用していく

↑変数に説明がつく

Next　FixedUpdate内に何でもかんでも書きすぎ　解りやすいように機能ごとにプログラムを分離していく
縦横の速度の決定を分離できそう
Y軸の速度を決定して返すメソッドを作成する
private float GetYSpeed()
    {

    }
↓FixedUpdate内にあるY軸に関係するプログラムを切り取り貼り付けする
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプ制限時間")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("頭をぶつけた判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;
    private float dashTime = 0.0f;
    private float beforeKey = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        if (isGround)
        {
            if(verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if(pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            dashTime = 0.0f;
            xSpeed = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if(horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if(horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }
        beforeKey = horizontalKey;

        //アニメーションカーブを速度に適用
        xSpeed *= dashCurve.Evaluate(dashTime);
        if(isJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }

        anim.SetBool("jump", isJump);
        anim.SetBool("ground", isGround);
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    private float GetYSpeed()
    {

    }
}
=====================

↓Y軸に関係するプログラムを移動させた
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプ制限時間")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("頭をぶつけた判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;
    private float dashTime = 0.0f;
    private float beforeKey = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
       
        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            dashTime = 0.0f;
            xSpeed = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if(horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if(horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }
        beforeKey = horizontalKey;

        //アニメーションカーブを速度に適用
        xSpeed *= dashCurve.Evaluate(dashTime);
        
        anim.SetBool("jump", isJump);
        anim.SetBool("ground", isGround);
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    private float GetYSpeed()
    {
	 float verticalKey = Input.GetAxis("Vertical");
	 float ySpeed = -gravity;

        if (isGround)
        {
            if(verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if(pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }        
	}

	//アニメーションカーブを速度に適用
        if (isJump)
        {
              ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
	
	return ySpeed;			//移動が完了したらリターンを返す
    }
}
=====================

作ったメソッド上で///スラッシュを3回書くと下記が出現
/// <summary>
///
/// </summary>
/// <returns></returns>
private float GetYSpeed()

<summary></summary>  の間に書いたコメントが呼び出す際に表示される

このメソッドについてのコメントを書いてみる
/// <summary>
/// Y成分で必要な計算をし、速度を返す
/// </summary>
/// <returns>Y軸の速さ</returns>

float ySpeed = GetYSpeed();　を追記
↑書いたメソッドをFixedUpdate内で呼び出してみる　書いたメソッドにカーソルを合わせると先ほど書いたコメントが表示されるようになる
チームで作るとコメントを入れることができてコードがわかりやすくなる

完成したもの
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプ制限時間")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("頭をぶつけた判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;
    private float dashTime = 0.0f;
    private float beforeKey = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");

        float xSpeed = 0.0f;
        float ySpeed = GetYSpeed();

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);			//次で差し替えられる

            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);			//次で差し替えられる
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);			//次で差し替えられる
            dashTime = 0.0f;
            xSpeed = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if(horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if(horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }
        beforeKey = horizontalKey;

        //アニメーションカーブを速度に適用
        xSpeed *= dashCurve.Evaluate(dashTime);

        anim.SetBool("jump", isJump);		//次で移動する
        anim.SetBool("ground", isGround);		//次で移動する
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        if (isGround)
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }
}
=====================

次は同じ用にX軸の速度をまとめてみる　ただしX軸のプログラムにアニメーションが混じっている　anim.SetBool(“run”, true); ←これを分解する

=====================
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 public class Player : MonoBehaviour
 {
     #region//インスペクターで設定する					//⑭折りたたむ機能を追加
     [Header("移動速度")] public float speed;
     [Header("重力")] public float gravity;
     [Header("ジャンプ速度")] public float jumpSpeed;
     [Header("ジャンプする高さ")] public float jumpHeight;
     [Header("ジャンプする長さ")] public float jumpLimitTime;
     [Header("接地判定")] public GroundCheck ground;
     [Header("天井判定")] public GroundCheck head;
     [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
     [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
     #endregion										//⑭折りたたむ機能を追加

     #region//プライベート変数							//⑭折りたたむ機能を追加

     private Animator anim = null;
     private Rigidbody2D rb = null;
     private bool isGround = false;
     private bool isJump = false;
     private bool isRun = false;							//①走っているかどうかのフラグを作成
     private bool isHead = false; 
     private float jumpPos = 0.0f;
     private float dashTime, jumpTime;
     private float beforeKey;
     #endregion										//⑭折りたたむ機能を追加

     void Start()
     {
          //コンポーネントのインスタンスを捕まえる
          anim = GetComponent<Animator>();
          rb = GetComponent<Rigidbody2D>();
     }

     void FixedUpdate()
     {
          //接地判定を得る
          isGround = ground.IsGround();
          isHead = head.IsGround(); 

          //各種座標軸の速度を求める
          float xSpeed = GetXSpeed();					//⑦FixedUpdateで呼び出す
          float ySpeed = GetYSpeed();					//各種メソッドに明確な役割を与えたのでこの中を変更すれば速度を変えられる

          //アニメーションを適用							//⑫FixedUpdateで呼び出す
          SetAnimation();								//各種メソッドに明確な役割を与えたのでこの中を変更すればアニメーションを変えられる

          //移動速度を設定								//⑬コメント記載
          rb.velocity = new Vector2(xSpeed, ySpeed);
     }

     /// <summary>
     /// Y成分で必要な計算をし、速度を返す。
     /// </summary>
     /// <returns>Y軸の速さ</returns>
     private float GetYSpeed()
     {
          float verticalKey = Input.GetAxis("Vertical");
          float ySpeed = -gravity;

          if (isGround)
          {
              if (verticalKey > 0)
              {
                  ySpeed = jumpSpeed;
                  jumpPos = transform.position.y; //ジャンプした位置を記録する
                  isJump = true;
                  jumpTime = 0.0f;
              }
              else
              {
                  isJump = false;
              }
          }
          else if (isJump)
          {
              //上方向キーを押しているか
　　　　　　　bool pushUpKey = verticalKey > 0;
　　　　　　　//現在の高さが飛べる高さより下か
　　　　　　　bool canHeight = jumpPos + jumpHeight > transform.position.y;
　　　　　　　//ジャンプ時間が長くなりすぎてないか
　　　　　　　bool canTime = jumpLimitTime > jumpTime;

　　　　　　　if (pushUpKey && canHeight && canTime && !isHead)
             {
                  ySpeed = jumpSpeed;
                  jumpTime += Time.deltaTime;
              }
              else
              {
                  isJump = false;
                  jumpTime = 0.0f;
              }
          }

          if (isJump)
          {
              ySpeed *= jumpCurve.Evaluate(jumpTime);
          }

          return ySpeed;
     }

     /// <summary>									//⑥サマリーでコメントを書く
     /// X成分で必要な計算をし、速度を返す。
     /// </summary>
     /// <returns>X軸の速さ</returns>
     private float GetXSpeed()							//②メソッドを作成する
     {
          float horizontalKey = Input.GetAxis("Horizontal");	//③X軸に関する処理を新しいメソッドに移動させる
          float xSpeed = 0.0f;

          if (horizontalKey > 0)
          {
              transform.localScale = new Vector3(1, 1, 1);
              isRun = true;								//④アニメーションの部分をフラグに差し替える
              dashTime += Time.deltaTime;
              xSpeed = speed;
          }
          else if (horizontalKey < 0)
          {
              transform.localScale = new Vector3(-1, 1, 1);
              isRun = true;								//④アニメーションの部分をフラグに差し替える
              dashTime += Time.deltaTime;
              xSpeed = -speed;
          }
          else
          {
              isRun = false;								//④アニメーションの部分をフラグに差し替える
              xSpeed = 0.0f;
              dashTime = 0.0f;
          }

          //前回の入力からダッシュの反転を判断して速度を変える
          if (horizontalKey > 0 && beforeKey < 0)
          {
              dashTime = 0.0f;
          }
          else if (horizontalKey < 0 && beforeKey > 0)
          {
              dashTime = 0.0f;
          }

          beforeKey = horizontalKey;
          xSpeed *= dashCurve.Evaluate(dashTime);
          beforeKey = horizontalKey;
          return xSpeed;								//⑤リターンで返す
     }

     /// <summary>									//⑪サマリーを書く
     /// アニメーションを設定する
     /// </summary>
     private void SetAnimation()						//⑧アニメーション用のメソッドを用意し
     {
          anim.SetBool("jump", isJump);					//⑨移動させる
          anim.SetBool("ground", isGround);
          anim.SetBool("run", isRun);						//⑩先程作成した走るフラグを書く
     }
 }
=====================
↑今後の処理の変更や追加がやりやすくなった
#region - #endregion ＃リージョン　＃エンドリージョン　の間に書かれたものを折りたたむ機能

後は今まで通り動けばOK



＃４４	敵を作ってみよう・その１
Step14	敵の当たり判定を作ってみよう
マリオのクリボーのような敵を作ってみよう
＜クリボーの特徴＞
・衝突するとプレイヤーはやられる　←今回はここ
・踏んづけるとプレイヤーはちょっと跳ねて敵はやられる
・画面内に入ると動き出す
・動いている間一定方向に動く
・壁に当たると判定側へ動く

下書きで適当に絵を書いていく　なぜ下書きにするか　＃３３　
歩き2コマ		enemy_walk1.png		enemy_walk2.png　
やられた1コマ　enemy_dead.png
合計3コマ

iPadのProcreateで作成でぴよった　 画像を作成してUnityに入れたら背景が黒いがテクスチャタイプを２Dにして　適応すれば浸透化される
敵画像３つをUnityのプロジェクトAssetsーTexture配下に配置する
敵画像３つを選択した状態でインスペクターのテクスチャータイプースプライト(2DとUI)に変更後、適用するを押下　←すると浸透化される
enemy_walk1をシーン上(Untitled配下)にドラッグアンドドロップする

↑enemy_walk1を選択した状態でインスペクターコンポーネントを追加からBox Collider 2Dを追加
↓角がつっかえるので少し大きさを小さくしてエッジの半径Edge Radiusを0.14とすると角が丸くなる　後は敵に合わせてコライダーを調整する

もし、複雑な形の敵だったら？
Colliderの性質として親にRigidbodyやリジッドボディ2Dがある場合、子オブジェクトも同一の物体として扱う　ただし子オブジェクトにリジッドボディがついていない場合
子オブジェクトにリジッドボディがついていると別の物体として扱われる　＃１２物理演算について

空のオブジェクト作成
コンポーネントの追加
🔍CircleCollider2D		2D サークルコライダー
🔍CapsuleCollider2D	2D カプセルコライダー
🔍Box Collider 2D		2D ボックスコライダーを含めこの３つが基本的なコライダーとなる　コライダーは同一の物体であれば重ねてもOK　コライダーを重ねてもいけばいろいろな形にできる
子オブジェクトでなくても親にコライダーをつけることもできるがゲットコンポーネントなどでコライダーを取得した時、どれを取得したか分からなくなってしまうので
オブジェクトを分けておくと安全

編集できるコライダーもある
🔍PolygonCollider2D	2D ポリゴンコライダー　	これは以前登場したやつ
🔍EdgeCollider2D		2D エッジコライダー		線で当たり判定を編集することができる　編集方法はポリゴンコライダー２Dと同じ
様々なコライダーがあるので複雑な敵を作ってもいけそう　コライダーをつけすぎると重くなるので付け過ぎには注意　ある程度全体を覆えれば大丈夫
さっき作った空のオブジェクトを削除
ずっと気になっていた名前を変更　 - player_stand　→Player	 - Untitled　→test　←プロジェクトシーンズ　対象右クリックで名前変更できた
現時点での動画との差異　		ファイルが種類別で表示されない

敵の当たり判定ができたら今度はその当たり判定を判別できるようにする
ヒエラルキーenemy_walk1を選択した状態でインスペクターのタグTag Untagged▼ータグを追加Add Tag… 
＋ー名前：Enemy  的だと解る名前にする　後は敵のゲームオブジェクトの名前を変更する　
ヒエラルキーenemy_walk1を選択した状態でインスペクターのタグTag Untagged▼ーEnemy 　※子オブジェクトもTagの変更が必要　子オブジェクトは作成していない
当たり判定に関するのことはできたので敵に物理演算を付与していく
インスペクターコンポーネントを追加からRigidbody2Dを追加　Rigidbody 2D ▼Constraints回転を固定Freeze Rotation☑Z　←回転しないように

プレイヤーのスクリプトを開く

プライベート変数の一番最後に書く
=====================
#region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private float jumpPos = 0.0f;
    private float dashTime, jumpTime;
    private float beforeKey;
    private string enemyTag = "Enemy";					//①先程のタグと同じ文字列を定義しておく
    #endregion
=====================
スクリプトの一番最後に追記
=====================
#region//接触判定									//⑤＋を付ける
    private void OnCollisionEnter2D(Collision2D collision)	//②オンコリジョンエンター２Dというメソッドを追加
    {
        if(collision.collider.tag == enemyTag)				//③③
        {
            Debug.Log("敵と接触した");						//④ログを出して確認
        }
    }
    #endregion										//⑤＋を付ける
=====================
↑メソッド名を一字一句間違えないようにする
<OnCollisionEnter2D> Unity側が呼ぶ特別なメソッド　物体が衝突した時に呼ばれる　接触判定の時のOnTriggerEnter2Dとは違う
OnTriggerEnter2Dでは引数が侵入してきた当たり判定のコライダーだったがOnCollisionEnter2Dでは衝突データが入っている
③衝突データから衝突相手を取得する　←衝突してきた相手のコライダーを取得　③コライダータグがEnemyだった場合、敵と衝突したとみなす

↑この状態で実行▶するとカエルちゃんがはっちゃんに当たると敵と衝突したログが出る

やること　接触判定が取れたので敵と接触したらプレイヤーがやられるようにしていく
プレイヤーのアニメーターウィンドウを開く　プレイヤーがダウンするアニメーションの名前を確認　player_down　アニメーションについて　＃３４

プレイヤーのスクリプトを開く
=====================
#region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private bool isDown = false;			//①ダウン用のフラグを用意
    private float jumpPos = 0.0f;
    private float dashTime, jumpTime;
    private float beforeKey;
    private string enemyTag = "Enemy";
    #endregion
=====================
↓そしてダウン中に動かないようにする
=====================
void FixedUpdate()
    {
        if (!isDown)							//②ダウンフラグがfalseの時のみ処理を行うようにする
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            rb.velocity = new Vector2(xSpeed, ySpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);	//③ダウン中は重力のみ適用　落下する以外の行動が出来なくなる
        }
    }
=====================
↓敵と接触した際　ダウンするようにしていく
=====================
#region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            anim.Play("player_down");				//④アニメーションを直接再生する
            isDown = true;						//⑤ダウンフラグをtrueにする
        }
    }
    #endregion
=====================
Animator.Play(“ステート名”)　ステート名で指定したアニメーションを矢印キーなどを無視して直接再生する

↑ステート名　アニメーション名とは違う　デフォルトだとアニメーション名と同じとなる　アニメーション名とは別物
プロジェクトAssetsーAnimationーplayer_downを選択した状態でインスペクターのループ時間☑を外す　最初から外れていたが
再生すると　アニメーションが一つ多かったので　４つから３つに変更した　ダウンアニメーションは用意したアニメーションだけで良い

↓この状態で実行▶すると敵にぶつかった時、ちゃんとダウンするようになる




＃４５	敵を作ってみよう・その２
Step15	衝突判定を切り分けてみよう

マリオのクリボーのような敵を作ってみよう
＜クリボーの特徴＞
・衝突するとプレイヤーはやられる　
・踏んづけるとプレイヤーはちょっと跳ねる　←今回はここ
・踏んづけると敵はやられる
・画面内に入ると動き出す
・動いている間一定方向に動く
・壁に当たると判定側へ動く

今のままでは踏んづけてもプレイヤーがやられてしまう　踏んづけた時はやられないようにしてちょっと跳ねるようにしてみる
踏んだ時跳ねるのは敵以外にも作りそうなので一工夫する　新たに衝突用のスクリプトを用意する
プロジェクトAssetsーScript右クリックー作成ーC#スクリプト　名前：ObjectCollision  スクリプトをダブルクリック　バーチャルスタジオで開く

void Start()とvoid Update()を削除する
↓新しく作成したオブジェクトコリジョンのスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    [Header("これを踏んだ時のプレイヤーが跳ねる高さ")] public float boundHeight;		//①プレイヤーが踏んだ時に設定するパラメーター　跳ねる高さ

    /// <summary>								//③サマリーを書く　②を書いてからじゃないと出現しない
    /// このオブジェクトをプレイヤーが踏んだかどうか
    /// </summary>
    [HideInInspector] public bool playerStepOn;		//②プレイヤーがこのオブジェクトを踏んだかどうかのフラグだけ持たせておく④ハイドインスペクターにする
}
=====================
↑スクリプトどう使うか：踏んづけたら跳ねるものにくっつけて使う　クリボーなど　役割：プレイヤーと踏んづけられた物の橋渡しをする
1　プレイヤーが何かを踏んづけた時にこのスクリプトが貼りついてきたら
2　跳ねる高さを取得し
3　踏んづけた側に　踏んづけたことを通知する

もっとスマートな方法もあるが今回は初心者向けで書いている
他のスクリプトから読めるようにpublicにしているが
public float boundHeight　	←インスペクターで編集してほしいパラメーター
public bool playerStepOn	←インスペクターで編集してほしくないパラメーター　踏んづけられたかどうかを編集できてしまったらおかしいから
↑アトリビュートのハイドインスペクターを使う
＜Attribute : HideInspector＞インスペクターにシリアライズ化されたものが表示されなくなるアトリビュート　
ただ単にインスペクターで表示されなくなるだけ　シリアライズ化はされている

オブジェクトコリジョンのスクリプトを敵に貼り付ける
ヒエラルキーenemy_walk1を選択した状態でObjectCollisionスクリプトをコンポーネントを追加へドラッグアンドドロップ

↑ヒエラルキーで踏んづけたかどうかのパラメーターは表示されていない

やること　プレイヤーの衝突に踏んづけたかどうかの判定をつける

プレイヤーのスクリプトを編集する　
Player.cs
=====================
#region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            foreach(ContactPoint2D p in collision.contacts)	//①
            {

            }

            anim.Play("player_down");
            isDown = true;
        }
    }
    #endregion
=====================
今回もCollision2Dは衝突データが入る
衝突地点の詳細データ
衝突地点のデータが配列　配列について　＃２２
何故　衝突地点のデータが配列か

↑もしこんな感じの敵を作った場合　複数衝突する可能性がある　複数なので配列　この場合プレイヤーはやられるべき　一箇所でもマズイ当たり方をしたらアウト
コアエーチでループさせて配列の中身を全て調べる必要がある
この中に一カ所でもマズイ位置で当たった（マズイデータ）らプレイヤーは、やられる必要がある
Player.cs
=====================
#region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            foreach(ContactPoint2D p in collision.contacts)
            {
                if (敵と衝突した位置が足元だったら)
                {
                    //もう一度跳ねる
                }
                else
                {
                    //ダウンする
                    anim.Play("player_down");
                    isDown = true;
                }
            }
        }
    }
    #endregion
=====================
↑衝突した位置によって判定を切り分けていく　敵と衝突した位置が足元だったらもう一度跳ねて、それ以外だったらダウンするようにする

衝突した位置が足元だったかどうかをどう判別するのか考えよう
Player.cs
=====================
#region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            foreach(ContactPoint2D p in collision.contacts)
            {
                p.point ←このデータの衝突した位置
                    これを使って足元だったらという条件を満たすには？

                if (p.point.y < transform.position.y) //衝突した位置が自分の中心位置くらい
                {
                    //もう一度跳ねる
                }
                else
                {
                    //ダウンする
                    anim.Play("player_down");
                    isDown = true;
                }
            }
        }
    }
    #endregion
=====================
衝突した位置のY座標が　＜　自分のY座標

↑しかしながらtransform.positionというのはデフォルトではスプライトの真ん中を指している
この位置のY座標より下とした場合　キャラクターの真ん中から下の範囲が足元ということになってしまう
ということはキャラクターより半分以下の大きさの敵は当たったとしても踏んづけた判定となってしまう

ちゃんと計算できるように情報を持ってくる

Player.cs
=====================
#region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;				//①カプセルコライダー２Dの変数を用意して
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private bool isDown = false;
    private float jumpPos = 0.0f;
    private float dashTime, jumpTime;
    private float beforeKey;
    private string enemyTag = "Enemy";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();		//②スタートでインスタンスを捕まえる　プレイヤーのコライダー
    }
=====================
#region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            foreach(ContactPoint2D p in collision.contacts)
            {
                p.point ←衝突した位置
                    足元だったらという条件を満たすには？

                if (p.point.y < transform.position.y - (capcol.size.y / 2f)) 	//③先程の条件からプレイヤーのコライダーのサイズの半分を切り取る
                {
                    //もう一度跳ねる
                }
                else
                {
                    //ダウンする
                    anim.Play("player_down");
                    isDown = true;
                }
            }
        }
    }
    #endregion
=====================

↑プレイヤーの中心位置からプレイヤーのコライダーのYのサイズつまり高さの半分の大きさを引くのでココより下で踏んづけた場合となる

↑これもちょっとまずい…　さらに計算するためのパラメーターを増やす
Player.cs
=====================
#region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("踏みつけ判定の高さの割合")] public float stepOnRate;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    #endregion
=====================
①踏みつけ判定の高さの割合をインスペクターで調整できるようにする
先程の調整用のパラメーターを駆使して計算を行う
=====================
#region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            foreach(ContactPoint2D p in collision.contacts)
            {
                //踏みつけ判定になる高さ
                float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

                //踏みつけ判定のワールド座標
                float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

                if (p.point.y < judgePos) 
                {
                    //もう一度跳ねる
                }
                else
                {
                    //ダウンする
                    anim.Play("player_down");
                    isDown = true;
                }
            }
        }
    }
    #endregion
=====================
②プレイヤーの高さに割合をかけることによってプレイヤーの高さの指定％までが踏みつけ判定になるようにする
これで踏みつけ判定の高さをインスペクターで調整できるようになる
（例）インスペクターで１０と設定するとこの変数の大きさはプレイヤーの高さの１０％ということになる
③ここからどの地点が踏みつけ判定になるのかを求めていく　ここまではさっきと一緒　これに先程の高さを足す
↓先程の高さをインスペクターで１０にした場合ココより下となる　コレでうまくいきそう

インスペクター１０は　どれくらいのたかさにするかはキャラクターによるので各自調整しろ
④p.point.y 　ループ分の中でしか使えないのはコレだけ　なので　他の計算はループの外にもっていく
ループの中で同じ計算を何回もするのは無駄になってしまうから

Player.cs
=====================
#region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos) 
                {
                    //もう一度跳ねる
                }
                else
                {
                    //ダウンする
                    anim.Play("player_down");
                    isDown = true;
                }
            }
        }
    }
    #endregion
 } 
=====================
↑これで踏みつけ判定の部分ができた
最後の } が一つ抜けていたのでエラーとなった　付けたら直った 　public class Player : MonoBehaviourの｛　の相方

やること　ちょっと跳ねる部分を作成

Player.cs
=====================
#region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime, jumpTime;
    private float beforeKey;
    private string enemyTag = "Enemy";
    #endregion
=====================
①何かを踏んだ時のジャンプは通常のジャンプとは違うので別のフラグとパラメーターを用意する
次に跳ねている時の処理を書いていく　ジャンプの処理とほとんど一緒なのでジャンプの処理をコピーしてくる
注意点：跳ねる処理は地面にいる時の処理より上にする　地面についた状態で動いてきた敵を踏んづける可能性があるため


=====================
/// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //ジャンプ中
        if (isOtherJump)	//②else if →if 　　　else if→ if		//③跳ねる処理用に変更する　上方向キーを消す
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)	//②if →else if 
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }
        
        if (isJump || isOtherJump)					//④ジャンプの速度設定を跳ねているときにも適用する
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }
=====================
これで跳ねる処理の部分は完成

やること　踏んづけた相手からどれくらい高く跳ねるのかを取得

Player.cs
=====================
#region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    //もう一度跳ねる
                    ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();　//①
                    if(o != null)
                    {
                        otherJumpHeight = o.boundHeight;		//②踏んづけたものから跳ねる高さを取得する
                        o.playerStepOn = true;          				//②踏んづけたものに対して踏んづけた事を通知する
                        jumpPos = transform.position.y; 			//②ジャンプした位置を記録する
                        isOtherJump = true;						//③各種フラグをセットする
                        isJump = false;							//③各種フラグをセットする
                        jumpTime = 0.0f;						//③各種フラグをセットする
                    }
                    else
                    {
                        Debug.Log("ObjectCollisionが付いてないよ！");
                    }
                }
                else
                {
                    //ダウンする
                    anim.Play("player_down");
                    isDown = true;
                    break;
                }
            }
        }
    }
    #endregion
=====================
敵との衝突判定のところに処理を書き足していく
①衝突したオブジェクトから冒頭で作った橋渡しをしているスクリプトを取得します
橋渡しをしているスクリプトにどれくらいの高さで跳ねるかのパラメーターがあるので、それをとってくれば跳ねる処理に渡すことができる
ObjectCollisionから跳ねる高さを取得

複雑な形の敵を作るときはコライダーを子オブジェクトにしたほうが良い　と前回解説
衝突したコライダーのゲームオブジェクトからコンポーネントを取得している
コライダーが付いている全ての子オブジェクトに橋渡しをしているスクリプトを貼り付けないといけない？　答えはNo
collision.gameObjectはRigidbody2Dがついているゲームオブジェクト　コレに一つだけつけておけばOK

 ObjectCollisionはループの外に出すべきでは？
スクリプトが必要になるのは足元で踏んづけた時のみ必要で足元で複数箇所衝突する可能性が低い為ループの中に入れてある

↑このような時はOnCollisionEnter2Dが２回呼ばれる

 //もう一度跳ねる
 ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();　
				 ↑
				 一つの敵から足元で複数箇所接触した場合にのみ何回も呼ばれる　踏んづけた時しか処理しないのでココに書いてある
 o.playerStepOn = true;	 //踏んづけたものに対して踏んづけた事を通知する
			       ↑
			       ループの中にあっても問題ない

break;　←ダウンが一回でもあった場合ループする意味がなくなるので　ブレイクでダウン時はループを抜ける

やること　跳ねた時もう一度ジャンプアニメーションするように設定する

Player.cs
=====================
private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);   //①アニメーションのジャンプを跳ねた時にもtrueになるようにする
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }
=====================

ヒエラルキーplayerを選択、アニメーターウィンドウのplayer_jump_down右クリックー遷移を作成Make Transition↑player_jump_up
(ジャンプ下降モーションからジャンプ上昇モーションへ矢印をつなぐ)
作成した矢印↑を選択した状態で終了時間ありHas Exit Time☑を外す
▼Settingsをクリックー遷移間隔(s)Transition Duratiorを0.25→0
Conditions リストは空です　＋を押下　条件を　jump trueにする　(ジャンプフラグがtrueの場合という意味)
↓最後に各種　インスペクターの設定を忘れずに
playerの踏みつけ判定の高さの割合を10にする
enemy_walk1を選択した状態でインスペクターのこれを踏んだ時のプレイヤーが跳ねる高さを3にする
この状態で実行▶すると　踏んだ時跳ねて　横から当たった時ちゃんとダウンするようになる



＃４６	敵を作ってみよう・その３
Step16	敵の挙動を作成してみよう

マリオのクリボーのような敵を作ってみよう
＜クリボーの特徴＞
・衝突するとプレイヤーはやられる　
・踏んづけるとプレイヤーはちょっと跳ねる　
・踏んづけると敵はやられる	←今回はここ
・画面内に入ると動き出す		←今回はここ
・動いている間一定方向に動く	←今回はここ
・壁に当たると判定側へ動く	←今回はここ

やること　敵用のスクリプトを作成　　今回は初心者用として簡単な方法で作成していく
プロジェクトーAssetsーScript右クリック作成ーC#スクリプトー名前：Enemy_Zako1
エネミーザコ１スクリプトをビジュアルスタジオで開く　画面内に入ったら動き出すを作成する

ヒエラルキーGridを選択した状態でウィンドウー２Dータイルパレットで地面を増やした　はっちゃんとカエルちゃんの距離をはなした

↑ヒエラルキーCameraColliderを選択した状態でインスペクターの要素0　X15→30　要素3　X15→30に変更した


C#スクリプトー名前：Enemy_Zako1
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako1 : MonoBehaviour
{
    private SpriteRenderer sr = null;				//①スプライトレンダラー型の変数を用意して

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();    	//②スタート内でゲットコンポーネントしてインスタンスを捕まえます
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.isVisible)							//③スプライトレンダラー.isビシブルと書く
        {
            Debug.Log("画面に見えている");			//④これが正しく機能しているか確認
        }    
    }
}
=====================
↓スプライトレンダラー　画面にスプライトを表示させているコンポーネント　キャラクターを表示させている

③〇〇Renderer.isVisibleとは画面内にそのオブジェクトが表示されていかを返すパラメータ　※SceneViewも含む
Unityの機能で実装されている名前にレンダラーがつくものは基本的にこのパラメータを持っている
ただしシーンビューで表示されていてもtrueで返ってくるので気をつける　シーンビューとゲームビューを同時に表示しているとゲーム内の挙動が通常と違う形になる

ヒエラルキーenemy_walk1を選択した状態でEnemy_Zako1スクリプトをコンポーネントの追加へドラッグアンドドロップしてスクリプトを貼り付ける
この状態で実行▶すると敵が画面に表示された時、画面に見えているとログが表示される　画面外に出るとログが表示されなくなり　表示されている時だけtrueとなる

C#スクリプトー名前：Enemy_Zako1
=====================
public class Enemy_Zako1 : MonoBehaviour
{
    [Header("画面外でも行動するか")] public bool nonVisible;

    private SpriteRenderer sr = null;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.isVisible || nonVisible)
        {
            //行動する
        }    
    }
}
=====================
↑敵キャラクターを画面外でも行動させたい場合もあると思うのでインスペクターから設定できるようにしておく

やること　移動を作成

C#スクリプトー名前：Enemy_Zako1
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako1 : MonoBehaviour
{
    #region//インスペクターで設定する						//①隠せるようにする　コメント書く
    [Header("移動速度")] public float speed;					//②移動速度のパラメータを用意
    [Header("重力")] public float gravity;						//③呪力のパラメータを用意
    [Header("画面外でも行動するか")] public bool nonVisible;
    #endregion											//①隠すエンド

    #region//プライベート変数								//④隠せるようにする　コメント書く
    private Rigidbody2D rb = null;							//⑤プレイヤーの時と同じようにリジッドボディ２Dで動かすのでそのインスタンスを捕まえる　変数
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;							//⑥右向き左向きのフラグを作成
    #endregion											//④隠すエンド

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();					//⑦リジッドボディ２Dをゲットコンポーネントする
    }

    // Update is called once per frame
    void FixedUpdate()									//⑩アップデートをフィックスドアップデートに変更　＃３９参照
    {
        if (sr.isVisible || nonVisible)
        {
            int xVector = -1;									//進む方向を決めて移動させる
            if (rightTleftF)									//⑧右向き左向きのフラグから
            {
                xVector = 1;									//進む方向を決めて移動させる
                transform.localScale = new Vector3(-1, 1, 1);			//敵の向きと　左右の反転はコライダーも反転する
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);			//敵の向きと　左右の反転はコライダーも反転する
            }
            rb.velocity = new Vector2(xVector * speed, -gravity);
        }
        else												//⑨画面に写っていない間、スリープ状態にする
        {
            rb.Sleep();
        }
    }
}
=====================
複雑な形のコライダーを設定した場合、オブジェクトを駆使して一番親が横幅の真ん中にくるように設定する
Rigidbody2D.Sleep()とはそのオブジェクトを一時的に物理演算から外すもの
画面に写っていない時、物理演算が働かないので負荷軽減になる
スリープは起こさないといけないのでは？　←動かすと勝手に起きる　 rb.velocity = new Vector2(xVector * speed, -gravity);　何かにぶつかっても勝手に起きる

Enemy_Zako1のインスペクターの　移動速度　重力を3に設定する
この状態で実行▶すると敵が画面内に入った時にちゃんと移動する

やること　アニメーションを作成
プロジェクトAssetsーAnimation右クリックー作成ーアニメーターコントローラー　名前：enemy_zako1 
アニメーションについて　＃３４

ヒエラルキーenemy_walk1を選択した状態でenemy_zako1 をインスペクターAnimatorのControllerコントローラーへドラッグアンドドロップ
これでキャラクターにアニメーションを付ける下準備ができた
Unity上のタブ　ウィンドウーアニメーションーアニメーションを選択　アニメーションウィンドウが開く
ヒエラルキーのキャラクターenemy_walk1を選択した状態でアニメーションウィンドウのCreate作成を押下  ←アニメーションファイル新規作成
作成するアニメーション名で保存　enemy_zako1_dead.anim（１つ）		enemy_zako1_walk.anim（３つ）			save

↑デフォルトから名前をwalk とdeadに変更
この状態で実行▶すると敵が歩く

やること　踏まれたらやられる


C#スクリプトー名前：Enemy_Zako1
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako1 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動するか")] public bool nonVisible;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;						//①やられたモーションを再生する為　アニメーターを
    private ObjectCollision oc = null;					//②橋渡をするスクリプト
    private BoxCollider2D col = null;						//③２Dコライダーの変数
    private bool rightTleftF = false;
    private bool isDead = false;						//④
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();				//上に合わせて
        sr = GetComponent<SpriteRenderer>();				//順番を入れ替えた
        anim = GetComponent<Animator>();				//⑤ゲットコンポーネント
        oc = GetComponent<ObjectCollision>();			//⑥
        col = GetComponent<BoxCollider2D>();			//⑦
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!oc.playerStepOn)							//⑧橋渡しするスクリプトからプレイヤーに踏まれたかどうか
        {
        
            if (sr.isVisible || nonVisible)
            {
                int xVector = -1;
                if (rightTleftF)
                {
                    xVector = 1;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                rb.velocity = new Vector2(xVector * speed, -gravity);
            }
            else
            {
                rb.Sleep();
            }
        }											//⑨踏まれた時の処理
        else											//
        {
            if(!isDead)									//フラグを一回しか通らないように
            {
                anim.Play("dead");							//敵は踏まれた時　下に落ちていく形にして当たり判定を消す
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
            }
        }
    }
}
=====================
(特定の)コンポーネント.enabledというのは　そのコンポーネントが有効かどうかを表す		col.enabled = false;
↑インスペクターで見た時、☑チェックマークがあるもの　☑Box Collider 2Dなど　←イネーブルドを使用できる　☑がないものは使用できない
col.enabled = false;←Box Collider 2Dを無効にしている

子オブジェクトにコライダーを持たせている場合は次のようにする
先ずコライダーを持たせている子オブジェクトを空のゲームオブジェクト（ColliderObj）を追加してその子にする

C#スクリプトー名前：Enemy_Zako1
=====================
 if(!isDead)								
            {
                anim.Play("dead");							
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
		Transform t = transform.Find(“ColliderObj”);		←追加
		if (t != null)								←
		{										←
			t.gameObject.SetActive(false);			←
		}										←
            }
=====================
↑スクリプトにトランスフォームでFindしてコライダーをまとめたゲームオブジェクトを非アクティブにする処理を追加する
これで子オブジェクトについていたコライダーをまとめて無効にできる
Transform.Find(“名前”)というのはそのゲームオブジェクトの子オブジェクトから指定した名前のゲームオブジェクトを取得するメソッド
ただし返り値はゲームオブジェクトではなくトランスフォームなので注意
以前紹介したGameObject.Find(“名前”)とは違うものになる

・GameObject.Find　シーン上にある全てのゲームオブジェクトを検索して名前が一致したゲームオブジェクトを取得する
使い方としてはGameObject.Find(“名前”);と書けばOK
			↑クラスから直接メソッドを呼び出している　クラスに直接アクセスして扱えるメソッドをスタティックメソッドと言う　※アクティブでないと取得できない

・Transform.Find　このインスタンスがついているゲームオブジェクトの子オブジェクトから名前が一致したゲームオブジェクトのTransformを返すものになる
使い方GameObject.Findとは違いインスタンスからアクセスする　transform.Find(“名前”);
													↑インスタンスが入っている変数
GameObject.Findは大文字でしたがtransform.Findは小文字　※非アクティブでも取得可能
これら２つは似ているが使い方がまったく違うので注意

ちょっとした演出を追加
C#スクリプトー名前：Enemy_Zako1
=====================
if(!isDead)
            {
                anim.Play("dead");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                Destroy(gameObject, 3f);				//②やられた時の処理で３秒後にこのゲームオブジェクトを削除する
            }
            else									//やられる際の処理が終わったら
            {
                transform.Rotate(new Vector3(0, 0, 5));		//①ゲームオブジェクトを３秒間くるくる回転させるメソッド
            }
=====================
①Transform.Rotateとはゲームオブジェクトを回転させるメソッド　このスプリクトの場合、Transfomのローテーションを５増やすという効果がある

この場合、FixedUpdateに書かれているのでくるくる回る
物理演算で動いているものをトランスフォームで操作すると再計算が走って重くなるのでしたよね　col.enabled = false;でコライダーを切っているので問題ない
コライダーが切られてしまって物理演算での重い処理が走らなくなったのでトランスフォームで操作しても問題ない

②Destroy(オブジェクト,時間)とは指定したオブジェクトを削除するメソッド　※時間指定があれば待つ
ゲームオブジェクトも削除できるしコンポーネントのみを削除することもできる　オブジェクト指定の後、時間を書くとその秒数後に削除を実行する
この時間指定は書いても書かなくてもいい　書かない場合は即座に削除される

この状態で実行すると敵がやられた時くるくる回って落ちるようになる　しかしながら敵がやられた時タイルマップの裏側に入ってしまう場合がある
今起きていなくてもPCを再起動させたりするとなったりする場合がある　Z軸を変えれば直るはずが　直らないケースがある　バグ？　なのでレイヤー分けします

ヒエラルキーTilemapを選択した状態で
インスペクターTilemap Rendererー▼追加設定Additional SettingsーソートレイヤーSorting LayerーDefault▼ Add Sorting Layerを押下
▼ソートレイヤーSorting Layers＋ー名前：TileMapを追加し順番を一番上にもってくる
ヒエラルキーTilemapに戻り　先程設定したソートレイヤーをTileMapに変更する
Sorting Layerとは2Dのオブジェクト同士の描写する順番を取り決めるもの　上にあればあるほど先に描画されるようになる
つまりTileMapを上にもってくることで奥に表示されるということ　ただしカメラからの距離が同じだった場合に限る
本来であれば座標マップを奥に持っていけば良いはずですが　このようにしないと直らない場合があったのでレイヤーでなんとかしているというわけです

やること　ぶつかったら折り返す処理
ヒエラルキーenemy_walk1を選択した状態で右クリックー空のオブジェクトを作成　名前：trigger
triggerを選択した状態でコンポーネントを追加から🔍BoxCollider2dで２Dボックスコライダーを追加する

ボックスコライダー２Dの形を細長くする　サイズXを0.07  Y 1.7 敵の前にもってくる

 ↑この中に何かが入ったら反転するようにする
Box Collider 2D　トリガーにするis Trigger☑を入れる

接地判定の時と同じようにチェックするためのスクリプトを作成する
スクリプトー作成ーC＃スクリプトー名前：EnemyCollisionCheck

C＃スクリプトー名前：EnemyCollisionCheck 　エネミーコリジョンチェック
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{
    /// <summary>									//②説明
    /// 判定内に敵か壁がある
    /// </summary>
    [HideInInspector] public bool isOn = false;				//①パブリックで他のスクリプトから読めるようにフラグを用意して

    private string groundTag = "Ground";					//③地面と
    private string enemyTag = "Enemy";					//④敵と

    #region//接触判定									//⑤↑と接触した時を判定する

    private void OnTriggerEnter2D(Collider2D collision)		//⑥オントリガーエンターと
    {
        if(collision.tag == groundTag || collision.tag == enemyTag)
        {
            isOn = true;									//フラグのオン
        }
    }

    private void OnTriggerExit2D(Collider2D collision)		//イクジットエンターで
    {
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            isOn = false;									//フラグのオフ
        }
    }
    #endregion
}
=====================
接地判定の時のように厳密に判定する必要はないのでステイでの判定は行いません。　ENTERとEXITのみ
これで判定する側のスクリプトは完成

今度は↑スクリプトを敵側のスクリプトで読み込むようにする

Enemy_Zako1
=====================
public class Enemy_Zako1 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動するか")] public bool nonVisible;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;		//インスペクターで設定できるようにしておく
    #endregion
=====================
void FixedUpdate()
    {
        if (!oc.playerStepOn)
        {
        
            if (sr.isVisible || nonVisible)
            {
                if (checkCollision.isOn)			//判定の中に敵か壁があった場合
                {
                    rightTleftF = !rightTleftF;		//左右を反転するようにする　!はbool型に付けると逆になる　フラグを反対にする
                }
                int xVector = -1;
                if (rightTleftF)
                {
=====================

ヒエラルキーtriggerを選択した状態でインスペクターコンポーネントを追加でEnemy Collision Check(スクリプト)を付ける　
ヒエラルキーenemy_walk1を選択した状態でインスペクターのEnemy_Zako1ー接触判定をtriggerに変更
動きが確認しやすいようにタイルマップで壁を作る　Tilemap選択ーウィンドウー２Dータイルパレット
enemy_walk1右クリックー複製で敵をもう一体追加する
この状態で実行すると敵がオブジェクトに当たった時、反転する



＃４７	シーンを切り替えてみよう
Step17	シーンをロードしてみよう

プロジェクトScenesーSampleScene右クリックー削除

titleScenes ー stage1で移動する
testシーンを保存して　stage1にリネーム　再ロード
titleScenesダブルクリックでタイトルシーンに切り替える　Titleスクリプトを開く　シーンの移動の命令を書くだけの状態となっている

Title スクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;			//①②を使用するにはコレを書く必要がある

public class Title : MonoBehaviour
{
    private bool firstPush = false;

    //スタートボタンを押されたら呼ばれる
    public void PressStart()
    {
        Debug.Log("Press Start!");

        if (!firstPush)
        {
            Debug.Log("Go Next Scene!");
            //ここに次のシーンへ行く命令を書く
            SceneManager.LoadScene("stage1");	//②ステージ１シーンへ移動する
            //
            firstPush = true;
        }
    }
}
=====================
② SceneManager.LoadScene(“シーンの名);は、そのシーンへ移動する
厳密には移動ではなくファイルのアンロード＆ロードとなる　シーンを場面とした場合、移動と言える
このメソッドは以前にボタンから呼び出せるようにしている　ボタンからの呼び出し設定済み

↑ヒエラルキーボタンのインスペクターボタンのクリック時
この状態で実行▶しスタートボタンを押すと下記のエラーとなる
Scene 'stage1' couldn't be loaded because it has not been added to the build settings or the AssetBundle has not been loaded.
To add a scene to the build settings use the menu File->Build Settings...　←シーンの登録を忘れているエラー
何故？　シーンのロードをする為には予めシーンの登録をする必要がある　基本的には　そのためロードできなかった

上メニューのファイルFileービルド設定Build Settings  ビルド設定ウィンドウが開く
シーンを追加Add Open Scenesをクリックすると 今開いてるシーンを登録するこができる　titleScenes
シーンファイルをドラッグアンドドロップすることでも登録することができる　stage1
間違えて登録してしまったものは右クリックで選択を削除Remove Selectionできる  登録解除
ドラッグアンドドロップでシーンの順番を変えることができる　ゲームとしてビルドした時に０番のシーンからゲームが始まる　タイトルシーンを０番に置く
これでシーンの登録は完了　この状態で実行▶するとスタートボタンを押した時、次のシーンへ以降できる


Step18	フェードを実装してみよう
フェードも無限どうりあるので１版簡単なものを実装　今回は一番簡単なやり方で実装していく　Pixelmatorなどで適当に真っ黒な画像を用意#000000
/Users/me-do/Desktop/unity/006		black.png
プロジェクトAssetsーTexture配下にblackを配置　インスペクター　テクスチャタイプをスプライトに　適用
ヒエラルキーCanvas配下にImageを作成　キャンバス右クリックーUIー画像　名前：Fadeに変更
Fadeを選択した状態でImageのソース画像Source Imageにblackをドラッグアンドドロップ
Rect Transform　幅960　高さ540に変更　以前決めた解像度の大きさに　解像度＃３２
Image 画像タイプImage Typeー埋めてあるFilledに変更　塗りつぶし方法Fill Methodー垂直方向Verticalに変更　縦フェードにする
塗りつぶし量Fill Amountを左右に調整すると画層を変化させることができる

やること　フェードをスクリプトから制御できるようにしていく
スクリプトを作成　名前：FadeImage

FadeImageスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;				//①UGUIを使用する時はこれを書く　今回はimageにアクセスするのでコレを書きます

public class FadeImage : MonoBehaviour
{
    private Image img = null;			//②イメージの変数を用意
    private int frameCount = 0;			//④このフェードのｹﾞｰﾑｵﾌﾞｼﾞｪｸﾄがｱｸﾃｨﾌﾞになってから何フレーム経ったのかをカウントする
    private float timer = 0.0f;			//⑦時間を計測する変数を用意
    private bool fadeIn = false;			//⑥フェードインのフラグを作成

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();	//③イメージの変数をゲットコンポーネントする

        //試しにフェードインさせてみる		//⑫一時的にフェードインする処理を追加
        img.color = new Color(1, 1, 1, 1);	//
        img.fillAmount = 1;				//
        img.raycastTarget = true;		//
        fadeIn = true;					//
    }

    // Update is called once per frame
    void Update()
    {
        //シーン移行時の処理の重さでTime.deltaTimeが大きくなってしまうから2フレーム待つ
        if(frameCount > 2)				//⑤２フレーム以上　経っているのかをカウントする
        {
            if (fadeIn)					//⑥
            {
                //フェード中				//⑨
                if (timer < 1f)				//⑦今回は１秒でフェードするようにしていく
                { 
                    img.color = new Color(1, 1, 1, 1 - timer);	//⑧タイマーが１秒以下の場合、白カラーと　画像の色とは違うパラメータ
                    img.fillAmount = 1 - timer;				//⑧フィルアマウントを１から減らしていきます　１は真っ黒
                }						//⑦
                //フェード完了				//⑨
                else									//⑩フェードが完了したら値を指定して
                {
                    img.color = new Color(1, 1, 1, 0);			//Time.deltaTimeの値は変わるので終わったらちゃんと値を指定
                    img.fillAmount = 0;					//０は透明
                    img.raycastTarget = false;				//Imageの当たり判定をオフ
                }
                timer += Time.deltaTime;				//⑪タイマーを動かす
            }							//⑥
        }
        ++frameCount;				//⑤
    }
}
=====================
⑤コレは何をしているかというと　これから時間が進むにつててフェードしていく形で作成
シーンの移動は重い処理なので前フレームからの通過時間が長くなりがち　そのため時間経過が解りづらいので２フレーム待っている　フレーム＃１４
・仮に１秒でフェードする場合
シーン移動←0.5秒かかったとする
↓
Maximun Allowed Timestep 0.3333333(デフォルトの場合)　ゲーム内時間　Time.delta Timeは0.3333333
※コンポーネントの初期化処理などの影響で２フレーム目も重くなりがち
シーン移動から1フレーム0.3333333２フレーム0.6666666経過していることになる　２フレームで７割近く終了
一気に時間が進むのでガクンガクンとフェードする　これはいただけないので２フレーム待つ
＜シーン移動時＞0.6666666秒いきなり進むことが多い　フェードに限らずシーン開始時、秒数で何かをする場合は注意が必要　ゲーム内時間＃３９

⑧Color(R, G, B, A)→(赤、緑、青、透明度)　(0, 0, 0, 1)黒	　(1, 1, 1, 1)白　　Aは0が近いほど透明
UGUIは元々の画像のRGBA ✕ Color(RGBA)=最終的な色を出している　画像(0, 0, 0, 1)黒 ✕ (1, 1, 1, 1)白 = (0, 0, 0, 1)黒  何も変わらない
今回の場合はRGBに何を入れても結果は変わりませんが1, 1, 1つまり白色は掛け算が１なのでもともとの画像と同じになる
白色にする＝元々の画像の色を使う
Aは0が透明であるので1秒かけて透明になる処理になっている

fillAmount とは　黒い画像を　動かせるバー　縦や横に動かせる　さっき動かしていたバー

raycastTargetとは当たり判定を持つことができる（設定が可能な）UGUIに当たり判定をつけるかどうか
フェードして透明になった→透明な画像が上に乗っかっている　透明なものの当たり判定がオンだと下にあるボタンが押すことが出来ない
当たり判定があるものにブロックされてしまうわけです　そのため当たり判定をオフにしています

↑のスクリプトができたらFade ImageスクリプトをヒエラルキーFadeを選択した状態でコンポーネントの追加にドラックアンドドロップ
この状態で実行するとタイトルシーンがフェードインする

フェード完了時にパラメータをセットする

FadeImageスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    private Image img = null;
    private int frameCount = 0;
    private float timer = 0.0f;
    private bool fadeIn = false;
    private bool compFadeIn = false;			//①フェードインが完了したというフラグを作成

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        //試しにフェードインさせてみる
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 1;
        img.raycastTarget = true;
        fadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //シーン移行時の処理の重さでTime.deltaTimeが大きくなってしまうから2フレーム待つ
        if(frameCount > 2)
        {
            if (fadeIn)
            {
                FadeInUpdate();    		//③フェードイン毎フレームの処理をメソッド化
            }
        }
        ++frameCount;
    }


    private void FadeInUpdate()	//③これからフェードアウトを作成するので見やすいようにメソッド化してスクリプトを移動させる
    {
        if (timer < 1f)
        {
            img.color = new Color(1, 1, 1, 1 - timer);
            img.fillAmount = 1 - timer;
        }
        else
        {
            FadeInComplete();		//④フェードイン完了した時の処理をメソッド化
        }
        timer += Time.deltaTime;
    }							//③

    private void FadeInComplete()	//④フェードコンプリート作成　移動
    {
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        img.raycastTarget = false;
        timer = 0.0f;				//②フェードが完了した時に各種フラグをセット
        fadeIn = false;
        compFadeIn = true;
    }							//④
}
=====================
処理をまとめられたところで今度はフェードアウトを作っていく

FadeImageスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    private Image img = null;
    private int frameCount = 0;
    private float timer = 0.0f;
    private bool fadeIn = false;
    private bool fadeOut = false;					//①フェードアウト用のフラグを作成
    private bool compFadeIn = false;
    private bool compFadeOut = false;				//①

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //シーン移行時の処理の重さでTime.deltaTimeが大きくなってしまうから2フレーム待つ
        if(frameCount > 2)
        {
            if (fadeIn)
            {
                FadeInUpdate();    
            }
            else if (fadeOut)							//②フェードアウト時の毎フレームの処理を作成していく
            {
                FadeOutUpdate();
            }
        }
        ++frameCount;
    }

    //フェードイン中								//③
    private void FadeInUpdate()
    {
        if (timer < 1f)
        {
            img.color = new Color(1, 1, 1, 1 - timer);
            img.fillAmount = 1 - timer;
        }
        else
        {
            FadeInComplete();
        }
        timer += Time.deltaTime;
    }


    private void FadeOutUpdate()					//④フェードインと違って今度は時間経過で１に近づいていく形にする
    {
        if(timer < 1f)
        {
            img.color = new Color(1, 1, 1, timer);
            img.fillAmount = timer;
        }
        else
        {
            FadeOutComplete();						//⑦メソッドを呼ぶ
        }
        timer += Time.deltaTime;
    }

    //フェードイン完了								//⑤
    private void FadeInComplete()
    {
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        img.raycastTarget = false;
        timer = 0.0f;
        fadeIn = false;
        compFadeIn = true;
    }

    //フェードアウト完了							//⑥上とほぼ同じ
    private void FadeOutComplete()
    {
        img.color = new Color(1, 1, 1, 1);				//1にする
        img.fillAmount = 1;							//1にする
        img.raycastTarget = false;
        timer = 0.0f;
        fadeOut = false;							//フラグの種類を変える
        compFadeOut = true;
    }
}
=====================
今度は別のスクリプトからフェードインとフェードアウトを呼び出せるようにする

FadeImageスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    [Header("最初からフェードインが完了しているかどうか")] public bool firstFadeInComp;	//⑪インスペクターで設定できるようにする

    private Image img = null;
    private int frameCount = 0;
    private float timer = 0.0f;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool compFadeIn = false;
    private bool compFadeOut = false;

    /// <summary>					//③
    /// フェードインを開始する
    /// </summary>
    public void StartFadeIn()			//①
    {
        if(fadeIn || fadeOut)
        {
            return;						//フェード中は新たにフェードを開始しない
        }
        fadeIn = true;					//②フェードを開始するための初期設定
        compFadeIn = false;
        timer = 0.0f;
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 1;				
        img.raycastTarget = true;		//Imageの当たり判定をオン（フェード中にボタンを押せないようにする）
    }								//UGUIの当たり判定はUGUIに対してのみ有効　プレイヤーにはフェードは当たらない

    /// <summary>					//⑤
    /// フェードインが完了したかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsFadeInComplete()		//④フェードインが完了したかどうかも他のスクリプトから読めるようにしておく
    {
        return compFadeIn;
    }

    /// <summary>					//⑧
    /// フェードアウトを開始する
    /// </summary>
    public void StartFadeOut()			//⑥フェードアウトも同様にしていく
    {
        if (fadeIn || fadeOut)			//⑦上からコピーしてフェードアウト用に変更する
        {
            return;
        }
        fadeOut = true;
        compFadeOut = false;
        timer = 0.0f;
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        img.raycastTarget = true;
    }

    /// <summary>					//⑩
    /// フェードアウトを完了したかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsFadeOutComplete()	//⑨
    {
        return compFadeOut;
    }

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();		
        if (firstFadeInComp)			//⑫スタートでシーン開始時に　
        {
            FadeInComplete();			//最初からフェードインが完了した状態で始まるか
        }
        else
        {
            StartFadeIn();				//フェードインを始めるかを切り分けて処理
        }
    }

    // Update is called once per frame
    void Update()
    {
        //シーン移行時の処理の重さでTime.deltaTimeが大きくなってしまうから2フレーム待つ
        if(frameCount > 2)
        {
            if (fadeIn)
            {
                FadeInUpdate();    
            }
            else if (fadeOut)
            {
                FadeOutUpdate();
            }
        }
        ++frameCount;
    }

    //フェードイン中
    private void FadeInUpdate()
    {
        if (timer < 1f)
        {
            img.color = new Color(1, 1, 1, 1 - timer);
            img.fillAmount = 1 - timer;
        }
        else
        {
            FadeInComplete();
        }
        timer += Time.deltaTime;
    }


    private void FadeOutUpdate()
    {
        if(timer < 1f)
        {
            img.color = new Color(1, 1, 1, timer);
            img.fillAmount = timer;
        }
        else
        {
            FadeOutComplete();
        }
        timer += Time.deltaTime;
    }

    //フェードイン完了
    private void FadeInComplete()
    {
        img.color = new Color(1, 1, 1, 0);
        img.fillAmount = 0;
        img.raycastTarget = false;
        timer = 0.0f;
        fadeIn = false;
        compFadeIn = true;
    }

    //フェードアウト完了
    private void FadeOutComplete()
    {
        img.color = new Color(1, 1, 1, 1);
        img.fillAmount = 1;
        img.raycastTarget = false;
        timer = 0.0f;
        fadeOut = false;
        compFadeOut = true;
    }
}
=====================
⑪⑫は　黒のフェードが置いてあると他のオブジェクトが見えなくなるので工夫する　このまま置いておくと邪魔
タイトル画面などシーン開始時にフェード演出が必要ないシーンもあるのでインスペクターから設定できるようにする

ヒエラルキーFadeをせんたくした状態でインスペクターの塗りつぶし量Fill Amountを0にする
最初からフェードインが完了しているかどうか☑する　タイトルシーンではフェードイン演出はいらないため
Canvas Renderer 透明メッシュをカリングCull Transparent Mesh☑する
<Cull Transparent Mesh> UGUIが透明な時、その描画をスキップする　透明のものは重い　透明になる可能性のあるUGUIは必ず☑を入れる


今度はスタートボタンを押したらフェードアウトするようにする
タイトルのスクリプトを編集

Titleスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;			//①インスペクターからフェードを設定できるようにする

    private bool firstPush = false;
    private bool goNextScene = false;					//②次のシーンへ行くフラグを作成

    //スタートボタンを押されたら呼ばれる
    public void PressStart()
    {
        Debug.Log("Press Start!");

        if (!firstPush)
        {
            Debug.Log("Go Next Scene!");
            fade.StartFadeOut();							//⑤ボタンを押したらフェードアウトが開始するようにする
            firstPush = true;
        }
    }

    private void Update()								//③スタートボタンを押したらフェードアウトするので　アップデートで
    {
        if (!goNextScene && fade.IsFadeOutComplete())		//フェードアウトの完了を監視する
        {
            SceneManager.LoadScene("stage1");			//④上からカットした。フェードアウトが完了したら
            goNextScene = true;							//次のシーンへ行くようにする　一回しか処理しないようにする
        }
    }
}
=====================
ヒエラルキーCanvasを選択した状態でTitleスクリプトのフェードにFade (Fade Image)スクリプトを選択する
この状態で実行するとタイトルボタンからフェードアウトしてシーン移動できるようになる

次はステージ側のシーンでフェードインするようにする

プロジェクトAssets配下で右クリックー作成ーフォルダ　名前：Prefab
ヒエラルキーFadeをPrefabフォルダへドラックアンドドロップしてFadeをプレハブにする　titleScenes右クリックーシーンを保存
プロジェクトAssetsーScenesーstage1をダブルクリックして作業シーンを切り替える

stage1シーンでの作業
ヒエラルキーで右クリックーUIーキャンバスグループを押下　するとCanvasとEventSystemが作成される
ヒエラルキーCanvasを選択した状態でインスペクターCanvasーレンダーモードをスクリーンスペースーカメラに変更
インスペクターレンダーカメラにヒエラルキーMain Cameraをドラックアンドドロップ
インスペクターCanvas ScalerのUIスケールモードを画面サイズに拡大Scale With Screen Sizeに変更
参照解像度　X960　Y540に変更

　　　　　↑ヒエラルキーCanvasを選択した状態でインスペクターCanvasの平面の距離Plane Distanceを5に変更する
プレイヤーのステージのZ軸が0の位置にある　カメラは−１０の位置　つまり距離は１０
これはキャンバスがカメラからどれくらいの距離に置くのかというものになる
これをカメラとプレイヤーのステージの間の値になるようにした　※真ん中にする必要はない

ヒエラルキーCanvasを一番下にもってくる
プロジェクトプレハブフォルダのFadeをCanvas配下に配置　キャンバスにドラックアンドドロップ
ヒエラルキーFadeを選択した状態でインスペクターの最初からフェードインが完了しているかどうか☑を外す　ステージシーンではフェードしてほしいから
ヒエラルキーstage1右クリックーシーンを保存してtitleSceneをダブルクリックして戻る

titleSceneシーンでの作業
これで実行▶してスタートボタンを押すとフェードアウトしてフェードインするようになった
Fadeをプレハブにしたので他のシーンでも使える



＃４８	ゲームマネージャー作成
Step19	シングルトンを実装してみよう

ゲームマネージャーを作成
＜ゲームマネージャーとは＞ゲームの進行管理　全体的なパラメータの管理　全ての場所に存在する　ただ一つしか無い　Unityの機能ではない
自分で作るもの　好きなように作ってOK　多くのシーンで使用する機能やパラメータをのせておくと便利
[例]２Dアクションの場合　ステージの進行状況　スコア管理　セーブデータの取り扱い　ゲームマネージャーは必須ではないがあると便利

ゲームマネージャーのスクリプトを作成　名前をGameManagerにすると何故かアイコンが変わる
スクリプトフォルダから右クリック作成ースクリプト　名前：GManager

ゲームマネージャーのスクリプト　GManager
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;		//①空箱
    public int score;							//⑥試しにパラメータをもたせてみる　スコア
    public int stageNum;						//ステージ
    public int continueNum;					//コンテニュー

    private void Awake()						//②Startによく似たメソッド
    {
        if (instance == null)						//③もしスタティックな変数が空箱だった場合
        {
            instance = this;						//このインスタンスのアドレスを入れる　空箱の中に中身を入れることができた
            DontDestroyOnLoad(this.gameObject);	//④このスクリプト(GManager)が張り付いているゲームオブジェクトはシーン移動で破棄されない
        }
        else									//⑤すでにインスタンスが存在する場合
        {
            Destroy(this.gameObject);				//このゲームオブジェクトを破棄するようにする
        }
    }
}
=====================
①static修飾子とは変数やメソッド、クラスにつけると　それが静的なものとして扱われる
＜静的な＞←動かないもの

動く場合　メモリ　オブジェクトをインスタンス化などで生成するとメモリにのる　
オブジェクトを作成するたびに繰り返されオブジェクトを破棄するとメモリが開放される
＜staticをつけない場合＞その時必要な分メモリに載せて使わなくなったらメモリを開放するもの
メリット：メモリ効率がいい　　デメリット：メモリに載ったり破棄されたりするのでメモリのどこにあるかわからない
(例)GetComponentで捕まえる必要がある等　どこにあるかわからないから探していた　メモリの場所を探す必要がある

動かない場合　メモリ　そのStaticなメソッドやクラスや変数を含む型にアクセスするとメモリに載る
その時、そのスタティックなオブジェクトを含む型のインスタンスが無くてもメモリに載る
今まではオブジェクトが生成されないとメモリに載りませんでしたがスタティックは違う　ちょっとでも触ったらメモリに載る
一度メモリに載ってしまうとゲーム終了時まで破棄されない　動かなくなる　１つしか存在しない

例えばこういうスクリプトを書いたとします
public class Test : MonoBehaviour
{
	int a;
	static int b;
}
↑これを沢山ゲームオブジェクトに貼り付けたとします　Test(Script)✕４　aは４つ　bは１つ　メモリ上
＜static修飾子な場合＞破棄されず、１つしか存在しないものになります
メリット：メモリの確保が最初のみ　メモリの場所が動かないのでアクセスが容易　ゲットコンポーネントなどで探す必要がない
デメリット：ずっとメモリを占有する　そのため使わなくなったら無駄でしか無いものになります

なぜこれをスタティックするのかというと
ゲームマネージャーはほとんどのシーンで使うならメモリを所有していても問題ない
アクセスしやすいのでどこからでも呼び出しやすい　これをpublicにすることでどのスクリプトからでも呼び出せるようにしている
↓丁寧に書くならこう書いたほうがいい
public static GManager Instance { get; private set;}  ゲットセットについては解説しておらず解説の内容がブレるのでこのままでいく

static にすると動かないメモリ領域を確保すると言いましたがnullを代入しています　なぜでしょう
これはstatic変数なのでいわゆる箱になります
これはGManager型なのでつまりこのスクリプトの型なのでスクリプトのインスタンスのアドレスの場所が入る箱となる
ゲームマネージャーそのものをスタティックにしたのではなくゲームマネージャーの場所を示す為の箱をスタティックにしている
この空箱は動かないのでこの中にインスタンスのアドレスを入れておけばどこからでもゲームマネージャーにアクセス可能となる
スタティック変数は確保している領域が動かないだけで中身は自由に動かすことができる

やること　このスタティックな空箱に中身を入れていく
②Awake
Unity側が呼ぶ特別なメソッドでインスタンス化された直後に呼ばれる 　Startによく似たメソッドでStartより先に呼ばれる
③初期化処理を書くことが多い
④＜DontDestroyOnLoad＞とはシーンを移動しても指定したオブジェクトは破棄されなくなる命令です
破棄されないので一回でもインスタンス化されたらデストロイDestroyなどで意図的に破棄しない限りずっと居続けます
①〜⑤このようなやり方をシングルトンと言う
＜シングルトン＞とは絶対に１つしか存在しないものを定義する手法
Unityの機能でもC#の機能でもなくプログラミングのやり方の一種です

＜シングルトンの意味＞なぜシングルトンを使うのか
C＃はオブジェクト指向なので設計図を元にいくらでも実体を作成可能です　しかしいくつも存在されては困るものがある
[例]ステージの進行状況やスコア等　沢山存在したら困ってしまう
というわけでただ１つのが保証されているというのは大事なのです　ではなぜこのように書くんとシングルトンになるのかというと
instanceはスタティックなので何個このスクリプト(GManger.cs)をインスタンス化しても箱は一緒のもの指す 箱の存在は変わらない
つまりGManger.cs１GManger.cs２GManger.cs３と作っていってもこの箱は同じものを指す
その箱が③空ならインスタンスを入れますが⑤既に入っている場合はデストロイする
最初の１つだけは箱に入るが２個めからは破棄されるので必ず１つしか存在しないというわけです
ただしゲームオブジェクトを破棄しているので同じゲームオブジェクトに複数つけると機能しません　※同じゲームオブジェクト複数つけないように注意
ゲームオブジェクトには１つしかつけないようにする

一度インスタンス化してしまえば　それ以降ずっと存在し続けるので全ての場所に存在し、ただ１つしか存在しないという部分を作成した
後は必要な機能をどんどん作って載せていけばOKとなる　⑥


⑥で作ったパラメータを試しに使ってみる

Enemy_Zako1.cs 敵スクリプトのやられた時の処理　※テスト用　次回直す
=====================
if(!isDead)
            {
                anim.Play("dead");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                GManager.instance.score += 10;
                Destroy(gameObject, 3f);
            }
            else
=====================
このように型.staticなものとするだけでアクセス可能　ゲットコンポーネントがいらない
※publicなので他のスクリプトからでもこうすればアクセス可能となる
instanceはスタティックでしたがscore はスタティックではないはず　何故アクセスできる？
instanceの中に実体がはいっているから
スタティックな箱に入っているアドレス→実体→実体の中のスコアにアクセスしている
そもそも実体にアクセスしているのでスタティックではなくてもアクセスすることができます


ゲームマネージャーをシーンに設置していく
titleScenes上のヒエラルキー右クリックー空のオブジェクトを作成　名前：GameManager
ヒエラルキーGameManagerを選択した状態でコンポーネントを追加にGManagerスクリプトをドラックアンドドロップ
ヒエラルキーのGameManagerをAssetsーPrefabにドラックアンドドロップしてプレハブにする　titleScenesを保存する
プレハブにしたGameManagerを全てのシーンにドラックアンドドロップする（今はstage1のみ）

ただ１つではんかったのでは？　２つ以上存在するとデストロイされるので問題ない　何故全シーンに置くのか　めんどいから
＜ゲームマネージャー＞は一度インスタンス化さえしてしまえばもう消えないので本来最初のシーンのみにあるべき
今回の場合はタイトルシーン　一回はインスタンス化する必要があるので毎回タイトルシーンから始める必要がる
ゲーム中であれば絶対タイトルから始まるが開発中はめんどくさい
どのシーンからスタートしてもいいようにプレハブ化して全部のシーンに置く　
インスタンスをデストロイするのではなくゲームオブジェクトごとデストロイしていた
無駄な処理が入るが開発が楽になる　試しに再生してみる　

実行▶すると
DontDestroyOnLoad
	GameManager
↑ゲームマネージャーは特別な扱いになる　これでシーン移動しても消えないものになっているのがわかる

↑２つあったのが１つになる
先程のスクリプトがちゃんと動いているかを確認する　敵をふんでみる

↑はっちゃん２匹ふんだのでスコアが２０となった　ちゃんと１０づつプラスされている
スコアを画面に表示等は次回解説



＃４９	スコア・残機・アイテム作成
Step20	画面に情報を表示しよう

前回ゲームマネージャーを作成したので　それを使って今回、スコアや残機を作成していく
確認：　stage1		ゲームビュー　解像度の設定　（960✕540） Canvasの設定　スクリーンスペース　メインカメラ　５　動画では19.87
↑これらをちゃんとしないとUIがズレる　解像度＃３２　キャンバス＃３３
確認：　titleScenes	Text　Font Sizeはなるべく揃えた方がいい　＃３３　これらの点に気をつけて開発していく
タイトルシーンのフォントサイズ大86→90（タイトル）　中60　小26→30（ボタン）に変更した

stage1	
テキストを配置していく
ヒエラルキーCanvasを選択した状態で右クリックーUiーテキスト 名前：Score
ヒエラルキーCanvas配下のTextを選択した状態でインスペクターText 水平オーバーフローをOverflow 垂直オーバーフローをOverflow
フォントサイズを90　色をイエローに変更する　整列の左は右端そえ　右は真ん中を選択  テキストはScoreに変更

　　　　  ↑右端揃えにすると数字の桁数が増えても位置がずれたりしなくなる

↑拡大/縮小を全て0.7に変更して右上はじにスコアテキストを配置する
プロジェクトScriptから新たにスクリプトを作成　名前：Score

スコア　スクリプトをビジュアルスタジオで開く
Score.cs　←名前はそのままにした
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;									//①UGUIのテキストを使用するので書く

public class Score : MonoBehaviour
{
    private Text scoreText = null;							//②スコアのテキスト変数
    private int oldScore = 0;								//③古いスコアを保存しておく変数

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();					//④ゲットコンポーネントでインスタンスを捕まえて
        if(GManager.instance != null)							//ゲームマネージャーがあるのかどうかをチェックする　置き忘れてるとデータが取れない
        {
            scoreText.text = "Score " + GManager.instance.score;	//⑤表示する文字を格納している変数　ここに表示する文字を入れていく
        }
        else												//
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");		//⑥ゲームマネージャーがないとこのスクリプトは動かない為、ログに出して
            Destroy(this);									//自身を消す
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(oldScore != GManager.instance.score)				//⑦現在のスコアが変わった時だけテキストを更新する
        {
            scoreText.text = "Score " + GManager.instance.score;	//
            oldScore = GManager.instance.score;				//
        }
    }
}
=====================

ヒエラルキーScoreを選択した状態でScoreスクリプトをコンポーネント追加にドラックアンドドロップしてスクリプトをスコアオブジェクトに貼り付ける
↓UIの表示をFadeより奥になるようにする

実行▶して確認すると特に問題なく動いている　スコアの表示ができた

やること　スコアを加算する物を作る　敵のスクリプトを編集する　前回ゲームマネージャーがちゃんと機能しているかを見るために簡単に作成したが、今回はちゃんと作る

Enemy_Zako1スクリプト
=====================
#region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;			//①加算するスコアをインスペクターで設定できるようにする
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動するか")] public bool nonVisible;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    #endregion
=====================
↓やられた時の処理
=====================
if(!isDead)
            {
                anim.Play("dead");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                if (GManager.instance != null)				//②インスペクターで設定したスコアを加算するようにすうる
                {
                    GManager.instance.score += myScore;	//
                }
                Destroy(gameObject, 3f);
            }
=====================
ヒエラルキーenemy_zako1を選択した状態でヒエラルキーEnemy_Zako1スクリプト　加算スコアを20にする　enemy_zako1（1）も同様にする
ヒエラルキーstage1　プロジェクトAssetsーTexture配下にあるpng画像を全てチェックする☑iOS用に上書き
titleBackGroundの画像が２のべき乗になっていない警告を消す為、形式をRGB(A) Compressed ASTC 4×4 blockに設定する　適用←警告が消える
画像の容量を抑えたい - ロバメモ - 素人のUnity覚書と奮闘記	unity only pot textures can be compressed  Unityではポットテクスチャのみ圧縮可能
２のべき乗　１，２，４，８，１６，３２，６４，１２８，２５６，５１２，１０２４，２０４８，４０９６


スコアアイテム作成
https://poromi-free.net/category/food-drink/sushi/
↑イラストの里からブリの画像を拝借　PixelmatorでPixelmatorで幅128→512 高さ128→512 解像度960に設定する

↑これをstar.pmgとして保存しTextureにドラックアンドドロップ　インスペクターでテクスチャタイプをスプライトにする
画像が大きいのでヒエラルキーのstarを選択した状態でインスペクター拡大/縮小を　X0.3　Y0.3　Z0.3にする

プレイヤーが判定内に入ったかどうかのスクリプトを作成する
名前：PlayerTriggerCheck　プレイヤートリガーチェック
敵の衝突判定のスクリプトをコピー　EnemyCollisionCheck とほとんど同じ
判定をプレイヤーに対して行うように変更する
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    /// <summary>
    /// 判定内にプレイヤーがいる
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string PlayerTag = "Player";

    #region//接触判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isOn = false;
        }
    }
    #endregion
}
=====================
↑これでプレイヤーが判定内に入っているかを取れるようになった
このスクリプトを使い回せばスコアアイテム以外のものにも流用できる

次にスコアアイテム自体のスクリプトを作成する　名前：ScoreItem

スコアアイテムのスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [Header("加算するスコア")] public int myScore;						//①インスペクターからスコアと
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;	//上のスクリプトを設定できるようにする

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが判定内に入ったら									//②
        if (playerCheck.isOn)										//
        {
            if (GManager.instance != null)								//プレイヤーが判定内に入ったら
            {
                GManager.instance.score += myScore;						//スコアをプラスして
                Destroy(this.gameObject);								//自分自身を破棄する
            }
        }
    }
}
=====================

ヒエラルキーplayerを選択した状態でインスペクター　タグをPlayerに変更

ヒエラルキーstarを選択した状態で
Score Item(Script)					加算するスコア　10入力	プレイヤーの判定　star
とPlayer Trigger Check (Script)					
とBox Collider 2Dを貼り付ける			トリガーにする　☑する　Is Trigger　

テスト用としてstar（ブリだけど）を2ケ複製して適当に並べる　ブリ３つ並べる
この状態で実行▶するとちゃんとスコアが加算される　敵をふんずけた場合もできている　スコアはこれで大丈夫そうだ

ステージ数と残機を表示
↓ステージテキストを表示
stage1ヒエラルキーScore右クリックーコピーー貼り付けー名前:Stage /Scoreの下に配置　インスペクター　テキスト：Stage 00 色：緑　として左上はじに置く
ハートアイコンを作成
色々な色のハートマークのイラスト - イラストの里からグリーンハートを拝借、PixelmatorでPixelmatorで幅512 高さ512 解像度960に設定する
グリーンハートpngを真ん中に貼り付けて、背景のレイヤーの☑を外し、pngで書き出す　006フォルダに保存
画像をプロジェクトTextureに配置　名前：hart インスペクター　テクスチャタイプ　スプライト　☑iOS用　適用
ヒエラルキーCanvas右クリックーUIー画像でImageで配置　ソース画像heart
ヒエラルキーStage右クリックー複製　Imageの子になるように配置し、Imageの名前をHeartに変更　複製したステージの名前はHeartTextにして下記のように配置する

UIとステージ内の物は分ける　(UGUIとSpriteRendererを使う)
UI（Canvas Score Stage）ゲーム内オブジェクト（Heart HeartText）は分けて配置する
残機の数値のテキスト部分はアイコンの子オブジェクトにしている（HeartText）これらはFadeより上に置く

↑スコアとステージの位置と大きさを小さくした　拡大/縮小 0.5
後はこれらを制御するスクリプトを書いていく　StageNum　ステージナムとHeart　ハートで作成が　先ずはゲームマネージャースクリプトを編集する

GManagerスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    public int score;
    public int stageNum;
    public int continueNum;
    public int heartNum;				//①ゲームマネージャーに残機用のパラメータを追加

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
=====================

残機とステージ数のスクリプトはScoreスクリプトとほぼ同じなのでスコアスプリクトをコピーする
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText = null;
    private int oldScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        if(GManager.instance != null)
        {
            scoreText.text = "Score " + GManager.instance.score;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(oldScore != GManager.instance.score)
        {
            scoreText.text = "Score " + GManager.instance.score;
            oldScore = GManager.instance.score;
        }
    }
}
=====================

①StageNumスクリプト(ステージ数)はヒエラルキーStageに追加する　Scoreスクリプトの☑を外す　スコアのコンポーネントを削除
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNum : MonoBehaviour
{
    private Text stageText = null;
    private int oldStageNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        stageText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            stageText.text = "Stage " + GManager.instance.stageNum;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oldStageNum != GManager.instance.stageNum)
        {
            stageText.text = "Stage " + GManager.instance.stageNum;
            oldStageNum = GManager.instance.stageNum;
        }
    }
}
=====================

②Heartスクリプト(残機)はヒエラルキーHeartTextに追加する　Scoreスクリプトの☑を外す　スコアのコンポーネントを削除
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private Text heartText = null;
    private int oldHeartNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        heartText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            heartText.text = "× " + GManager.instance.heartNum;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oldHeartNum != GManager.instance.heartNum)
        {
            heartText.text = "× " + GManager.instance.heartNum;
            oldHeartNum = GManager.instance.heartNum;
        }
    }
}
=====================

↑ヒエラルキーGameManagerを選択した状態でヒエラルキーのスクリプトを設定する
この状態で実行▶すると　とりあえず各種情報を表示することができる　中身については後々作っていく



＃５０	ステージを管理しよう
Step20	元の位置に戻る処理を作ろう

＜ステージ管理でやること＞
・スタート地点から始まる		←今回はココ
・やられたらコンテニュー		←今回はココ
・ゴール時の処理
・ゲームオーバー時の処理

ステージのスタート位置を決めよう　（プレイヤーがやられた時にもどってこられるようにする）
やること　スタート地点を示す目印を作ろう
ヒエラルキー右クリックー空のオブジェクトを作成Create Empty  スタート地点と分かるような名前：StartPos
ヒエラルキーStartPosを選択した状態でインスペクターの下記をクリック

緑色アイコンをクリックすると　あとでオレンジ色に変更した

選択したアイコンの中に名前が入っている状態でシーン上に表示される　シーンビューでしか表示されない　
ゲームオブジェクトにアイコンが付く→開発用の目印になる　これをスタート地点の目印する

↑プレイヤーの座標はデフォルトだと中心になっている　プレイヤーの座標をスタート地点に持っていきたいのでスタート地点は
プレイヤーの半分の長さより地面から高い位置に置く　そうしないと地面にめり込んで変な物理演算が働いた状態からスタートする　目印をつけることができた

やること　スクリプトでスタート地点から始まるようにする
新しいスクリプトを作成　名前：StageCtrl

StageCtrlスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCtrl : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;	//①プレイヤーを動かす為に設定
    [Header("コンテニュー位置")] public GameObject[] continuePoint;		//②目印を設定する為　配列＃２２

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=====================
①プレイヤーの位置をスタート地点に動かしたいのでプレイヤーのゲームオブジェクトをインスペクターから設定できるようにする
②目印にしたゲームオブジェクトを設定するための変数を用意する　
↓何故配列にしたか
空のゲームオブジェクトを作って　名前：StageCtrl　このスクリプト(Stage Ctrl)を貼り付ける
プレイヤーゲームオブジェクト　配列ではないと直接入れられる	Player
コンテニュー位置			配列の場合、変数の横に▶アイコンが付く　これをクリックすると数値を入れるところが出てくる	StartPos
試しに１を入れてみる　すると中身を入れる場所が出てくる
ドラックアンドドロップで各種ゲームオブジェクトを入れる
1の数値を変えると入れられる中身の数が変わる　０番目はスタート地点　Element 0
Element 1からをコンテニューする位置の目印に差し替えることによってコンテニューポイントを通過するごとに番号を1個ずつ増やしていけば復帰ポイントを切り替えられる
ToDo 復帰位置を変更する　コンテニューポイントを通過したとき復帰ポイントをずらしていかないといけない
↑コンテニュー用アイテムを作成した時に解説するので今回は仕組みだけつくっておく
今回は配列の数を１にしてスタート地点への移動だけを考える


StageCtrlスクリプトに戻り、ステージが始まった時プレイヤーをスタート地点へ持ってくるようにする

StageCtrlスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCtrl : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンテニュー位置")] public GameObject[] continuePoint;

    // Start is called before the first frame update
    void Start()
    {
        if(playerObj != null && continuePoint != null && continuePoint.Length > 0)		//①Headerの設定が足りているかどうかの判定
        {																//①
            playerObj.transform.position = continuePoint[0].transform.position;		//②プレイヤーの位置を0番目の目印（スタート地点）に
        }																//①
        else																//①
        {																//①
            Debug.Log("設定が足りてないよ！");									//①
        }																//①
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=====================
①設定が足りてないと困るので設定が足りているかどうかの判定をして足りていない場合はログを表示します
②プレイヤーのゲームオブジェクトを先程の配列の０番目に入れた目印つまりスタート地点に移動させれば初期配置は完了

これでプレイヤーが変な位置に居ても実行▶するとちゃんとスタート地点から始まります
うまくいかない場合はスタート地点のZ座標がタイルマップと同じ値か確認　←うまくいかなかった　StartPosのZ軸の値が違った　タイルマップと合わせたらうまくいった
スタート地点から始めることができるようになった

やること　やられたらスタート地点に復帰
「やられたら」の判定を作成　しかしながら今まで書いてきたプレイヤーのスクリプトの中にすでにやられた判定を作ってある　
private bool isDown = false;　←これはやられた瞬間trueになる　←ダウンアニメーションが終わったかどうかわからない
ダウンアニメーションが終わってないのにスタート地点に戻ると変なのでダウンアニメーションの終了判定を作る

プレイヤーのスクリプトに次のメソッドを追加していく

Playerのスクリプト
=====================
/// <summary> アニメーションを設定する
private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary>						//⑩サマリーを書く
    /// コンテニュー待機状態か				//
    /// </summary>						//
    /// <returns></returns>				//
    public bool IsContinueWaiting()			//⑨ダウンアニメーションが完了しているかどうか　publicで外から読めるようにする
    {									//このままではダウンアニメーションが完了しているかどうかの判定を直接返しているので
        return IsDownAnimEnd();			//あんまり意味のないメソッドになっているが
    }									//後々条件を追加するので下準備としてこのような形にしている
																	
    //ダウンアニメーションが完了しているかどうか//②
    private bool IsDownAnimEnd()			//①プレイヤーのスクリプトにメソッドを追加する
    {									//
        if(isDown && anim != null)			//③そもそもダウンしているかという判定とアニメーターを取得できているかの判定
        { 								//
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);	//⑤
            if (currentState.IsName("player_down"))								//⑥
            {																//
                if(currentState.normalizedTime >= 1)								//⑦
                {															//
                    return true;					//⑧条件に当てはまる時trueを返す
                }															//
            }																//
        }								//
        return false;						//④条件に当てはまらない場合はfalseを返す(ダウンアニメーションが完了していないという情報を返す)
    }									//

//接触判定
=====================
⑤アニメーターステートインフォ型の変数を用意しアニメーターからゲットカレントアニメーターステートインフォする
<AnimatorStateInfo>アニメーターの状態の情報を表す型　アニメーターの状態って何？

↑これの状態の情報　これがどのような状態になっているのかという情報を入れる型
その情報を入れる型の中にアニメーターからゲットカレントアニメーターステートインフォというメソッドを使って情報を入れている
<Animator.GetCurrentAnimatorStateInfo>現在再生中のステートの情報を取得するメソッド

↑現在再生中の1つの四角の情報を取得する　要するに現在再生しているアニメーションの情報を取得できる
(0)はアニメーターの0番目のレイヤーの情報を取得するという意味　0番目のレイヤーはデフォルトのもの
２Dでは0番目のレイヤー以外はほとんど使わないので特に深く考えず０と書いてOK　２Dではデフォルトレイヤーしかほとんど使わない

⑥IF文で切り分けて取得してきた情報から.IsNameで判定する

↑現在再生中のコレの名前が指定したものかどうかを判定するということ　player_downが再生中であれば良い
つまり現在再生中の名前がダウンアニメーションのものと一致していればよい
引数にダウンアニメーションの名前を入れてtrueが返ってきたらplayer_downを再生中ということになる

⑦カレントステート.ノーマライズドタイムは１以上という条件で判定する
<AfnimatorStatoInfo.normalizedTime>アニメーションの正規化された再生時間
＜正規化＞・データを扱いやすいように整理・変形すること　・Unity の場合だいたい０〜１の範囲にデータを整理している
<normalizedTime>の場合　再生時間が
0	…	0%再生
0.1	…	10%再生
0.2	…	20%再生
︙	
1	…	100%再生が完了している
>= 1　←コレは100%以上再生完了していた場合という意味になる　すなわちアニメーションが終わっているということ
１より上も判定しているが　これはアニメーションがループすると１より大きい値になるので一応こうしている
ちなみにこの判定方法はダウンアニメーション(player_down)から矢印が出ていないので可能になっている
矢印が出ていると次のアニメーションに移ってしまうので現在再生中のアニメーションが違うものになってしまいます
矢印が出ている場合は別の方法で判定する必要があるので注意

これでプレイヤーがダウンしている時の判定を作ることができた
次はステージ管理のほうでプレイヤーがダウンしていたらスタート地点に戻るようにする　今度はステージを管理するスクリプトを書いていく

StageCtrlスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCtrl : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンテニュー位置")] public GameObject[] continuePoint;

    private Player p;		//①

    // Start is called before the first frame update
    void Start()
    {
        if(playerObj != null && continuePoint != null && continuePoint.Length > 0)
        {
            playerObj.transform.position = continuePoint[0].transform.position;

            p = playerObj.GetComponent<Player>();		//プレイヤーのゲームオブジェクトからプレイヤーのスクリプト取得
            if(p == null)								//
            {
                Debug.Log("プレイヤーじゃない物がアタッチされているよ！");
            }
        }
        else
        {
            Debug.Log("設定が足りてないよ！");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(p != null && p.IsContinueWaiting())			//②プレイヤーが取得できていてコンテニュー待機状態の場合
        {
            if(continuePoint.Length > GManager.instance.continueNum)　//③コンテニューする位置の目印がちゃんと設定されているかをチェックする
            {
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;	//④
            }
            else
            {
                Debug.Log("コンテニューポイントの設定が足りてないよ！");
            }
        }
    }
}
=====================
④プレイヤーの位置をゲームマネージャーで管理しているコンテニュー番号の目印の位置へ移動させる（今回は０のみ）

この状態で実行▶するととりあえずやられたら元の位置にもどることができたが　かえるちゃんの位置が中に浮いていたのでStartPosの位置Yを-3に修正
これでは足りないので戻ってきたら復帰するようにする
プレイヤーのスクリプトに戻る

Playerのスクリプト
=====================
  	 return false;
    }

    /// <summary>
    /// コンテニューする
    /// </summary>
    public void ContinuePlayer()	//①コンテニューするメソッドを外から読めるようにpublicで作成
    {
        isDown = false;			//②ダウンから復帰する為にフラグ等のリセットなどをして状態を元の状態に戻す
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
    }

//接触判定
=====================

今度はステージを管理するスクリプトのほうで上のメソッドを呼び出します

StageCtrlスクリプト
=====================
// Update is called once per frame
    void Update()
    {
        if(p != null && p.IsContinueWaiting())
        {
            if(continuePoint.Length > GManager.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;
                p.ContinuePlayer();		//上のメソッドを読んで状態を復帰
            }
            else
            {
                Debug.Log("コンテニューポイントの設定が足りてないよ！");
            }
        }
    }
=====================
この状態で実行▶すると　とりあえず復帰することができた　しかしこのままでは何が起こっているかよく分からないので演出をつける

プレイヤーの絵を表示しているのはインスペクターのSprite Rendererというコンポーネントです
スプライトレンダラーをオン・オフすると絵を表示したり消したりできる　オン・オフを繰り返せば明滅する演出ができる　これをプログラムで動くようにする

プレイヤーのスクリプトに戻る
Player.cs
=====================
 #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;		//①必要な変数を追加
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;		//
    private float continueTime = 0.0f;	//
    private float blinkTime = 0.0f;		//
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime, jumpTime;
    private float beforeKey;
    private string enemyTag = "Enemy";
    #endregion

　    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();		//②スタートでスプライトレンダラーを取得
    }

    private void Update()						//③アップデートメソッドを追加
    {										//
        if (isContinue)							//④コンテニューフラグが立っている時　フラグがオンの時
        {									//
            //明滅　ついている時の戻る				//⑤↑時間経過でオンオフ切り替え
            if(blinkTime > 0.2f)					//
            {									//（オンオフ戻るを繰り返す）
                sr.enabled = true;					//３戻る
                blinkTime = 0.0f;					//
            }									//
            //明滅　消えている時					//
            else if(blinkTime > 0.1f)				//
            {									//
                sr.enabled = false;					//２オフ
            }									//
            //明滅　ついている時					//
            else								//
            {									//
                sr.enabled = true;					//１オン
            }									//
            //1秒たったら明滅終わり					//⑥
            if(continueTime > 1.0f)					//
            {									//
                isContinue = false;					//演出が終わったらリセット
                blinkTime = 0.0f;					//
                continueTime = 0.0f;				//
                sr.enabled = true;					//
            }									//
            else								//
            {									//
                blinkTime += Time.deltaTime;			//演出中は演出用の時間を進める
                continueTime += Time.deltaTime;		//
            }									//
        }									//
    }										//
=====================
③スプライトレンダラーをいじるのは物理演算とは関係ないかつ画面への表示に対する操作なのでフィックスドアップデートではなくアップデートに書く
=====================
/// <summary> コンテニューする
public void ContinuePlayer()
    {
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;						//⑦コンテニューする際に演出用のフラグをオンにする
    }
=====================
この状態で実行▶するとプレイヤーがやられると明滅してスタート地点に復帰することができた
後はやられた時、残機を減らして０でやられるとゲームオーバーを実装すれば大丈夫そうです



＃５１	ゲームオーバーを作ろう
Step21	残機の減算処理を実装しよう

↑空のゲームオブジェクトを作成して　名前：Object　はっちゃんとブリ寿司をその配下に入れた
やること　やられたら残機を減らす　
ゲームマネージャーに処理を追加していく

GManager.cs
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    [Header("スコア")] public int score;						//コメント追加
    [Header("現在のステージ")] public int stageNum;			//コメント追加
    [Header("現在の復帰位置")] public int continueNum;			//コメント追加
    [Header("現在の残機")] public int heartNum;				//コメント追加
    [Header("デフォルトの残機")] public int defaultHeartNum;		//①必要となる変数を追加
    [HideInInspector] public bool isGameOver;				//ゲームオーバーのフラグはインスペクターで表示されないようにする

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>				
    /// 残機を１つ増やす			
    /// </summary>				
    public void AddHeartNum()	//③残機を増やすメソッドを追加
    {							
        if(heartNum < 99)			//上限を超えないように
        {						
            ++heartNum;			
        }						
    }							

    /// <summary>				
    /// 残機を１減らす				
    /// </summary>				
    public void SubHeartNum()	//②残機を減らすメソッドを追加
    {							
        if(heartNum > 0)			
        {						
            --heartNum;			
        }						
        else						
        {						
            isGameOver = true;		//残機が0の状態で呼ばれるとゲームオーバーのフラグをオンにする
        }						
    }							
}
=====================
①デバッグしやすいようにプレイ中も編集可能に　ゲームオーバー用のフラグは編集されたら困るので見えないように

プレイヤーのスクリプトへ移動　 #region//接触判定 　敵と接触した時の処理
Player.cs
=====================
Debug.Log("ObjectCollisionが付いてないよ！");
                    }
                }
                else
                {
                    //ダウンする
                    anim.Play("player_down");
                    isDown = true;
                    GManager.instance.SubHeartNum();		//④上で作ったメソッドを呼び出す
                    break;
                }
=====================
この状態で実行▶すると敵に接触した場合、残機を減らすことができる


ゲームオーバーを実装していきたいのですが、このままだと敵に当たらないといけないのでデバッグが面倒　なので　やられ判定を追加
空のゲームオブジェクト作成　BoxCollider2Dをつける　トリガーする☑Is Trigger　地面の下に長く伸ばして配置　←落下した際のやられ判定にする

お絵かきソフトでトゲを作成　
牛刀包丁のイラスト - イラストの里　で牛刀の絵をパクる　サイズが600 × 519なので５１２でなく１０２４でPixelmatorで作成　名前：toge.png
取り込んでスプライトにしてシーンに配置  ボックスコライダー２D　トリガーする☑　コライダーの編集　包丁の刃に合わせる

タグの追加　DeadArea　HitArea  Tagを変更　落下判定＞DeadArea　トゲ＞HetArea　に変更する

プレイヤーのスクリプトを編集する
Player.cs
=====================
#region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;			//①変数追加
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime, jumpTime;
    private float beforeKey;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";	//
    private string hitAreaTag = "HitArea";		//
    #endregion
=====================
/// <summary> コンテニュー待機状態か			//以前作成したコンテニュー地点へ戻るための判定がダウンアニメーションをしたかどうかでしか
public bool IsContinueWaiting()				//判断していない為、条件を追加する
    {
        if (GManager.instance.isGameOver)		//⑥ゲームオーバーの時はコンテニューしないように
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;	//ダウンアニメーションをしない場合もコンテニューできるようにする
        }
    }
=====================
/// <summary>
    /// コンテニューする
    /// </summary>
    public void ContinuePlayer()
    {
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;					//⑦コンテニュー時　フラグをリセット
    }

    private void ReceiveDamage(bool downAnim)	//②やられる条件が増えたのでやられたときの処理をメソッド化する
    {
        if (isDown)							//④既にダウン状態でない時、引数からダウンアニメーションをするのかどうかのフラグを受け取り
        {
            return;
        }
        else
        {
            if (downAnim)						//⑤ダウンアニメーションをするか切り分け
            {
                anim.Play("player_down");			//③敵と接触した時のやられ処理を切り取ってこちらへ移動させた
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    //もう一度跳ねる
                    ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                    if(o != null)
                    {
                        otherJumpHeight = o.boundHeight;//踏んづけたものから跳ねる高さを取得する
                        o.playerStepOn = true;          //踏んづけたものに対して踏んづけた事を通知する
                        jumpPos = transform.position.y; //ジャンプした位置を記録する
                        isOtherJump = true;
                        isJump = false;
                        jumpTime = 0.0f;
                    }
                    else
                    {
                        Debug.Log("ObjectCollisionが付いてないよ！");
                    }
                }
                else
                {
                    ReceiveDamage(true);				//⑧敵に接触した際はダウンアニメーションをtrueにして先程のメソッドを呼び出します
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)		//⑨オントリガー２Dでやられ判定外に入った時を追加していく
    {
        if(collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);						//落下判定の時、ダウンアニメーションしない
        }
        else if(collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);						//トゲ判定の時、ダウンアニメーションする
        }
    }

    #endregion
}
=====================
この状態で実行▶するとトゲでダウンしてハートが減り　落ちてダウンせずにハートが減る　を実装できた
無料イラスト うに ウニもいれてみた　toge2

やること　ゲームオーバー作成
プロジェクトTexture配下に真っ黒な画像を用意する　前回作成したblackを流用した
ヒエラルキーCanvas配下で右クリックーUIー画像でImageを作成　名前：GameOver　ソース画像をblackにする　色のA（透明度）をいじって黒の透明度を作成する

blackの解像度は128×128　解像度については＃３２
GameOver配下で右クリックーUIーテキストを押下　Text：Game Over フォントサイズ90　整列２つとも真ん中　水平、垂直オーバーフロー：Overflow 色：赤
GameOver配下で右クリックーUIーX ボタンを押下　形を整える
Button配下で右クリックーUIーテキストを押下  Text：Retry フォントサイズ６０から少し小さくした　
整列２つとも真ん中　水平、垂直オーバーフロー：Overflow 色：黒
これでとりあえずゲームオーバーの表示を作ることができた　UGUIの作り方＃２７
作ったゲームオーバーはFadeより上にする　上にある方が奥に表示されるので　Fadeが上に重なるようにする

次にゲームマネージャーにリトライする為の処理を書いていく
GManager.cs
=====================
/// <summary>
    /// 残機を１減らす
    /// </summary>
    public void SubHeartNum()
    {
        if(heartNum > 0)
        {
            --heartNum;
        }
        else
        {
            isGameOver = true;
        }
    }

    /// <summary>
    /// 最初から始める時の処理
    /// </summary>
    public void RetryGmage()			//リトライした時、各種パラメータやフラグを元に戻す　リトライ時リセットする
    {
        isGameOver = false;
        heartNum = defaultHeartNum;
        score = 0;
        stageNum = 1;
        continueNum = 0;
    }
}
=====================

次にステージコントローラーで

StageCtrl.cs
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;							//⑩シーンに関する処理を書きたいのでこれを書く

public class StageCtrl : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンテニュー位置")] public GameObject[] continuePoint;
    [Header("ゲームオーバー")] public GameObject gameOverObj;		//①必要な変数を用意する
    [Header("フェード")] public FadeImage fade;					//

    private Player p;
    private int nextStageNum;									//
    private bool startFade = false;								//
    private bool doGameOver = false;							//
    private bool retryGame = false;								//
    private bool doSceneChange = false;							//

    // Start is called before the first frame update
    void Start()
    {
        if(playerObj != null && continuePoint != null && continuePoint.Length > 0 && gameOverObj != null && fade != null) //②設定項目チェック追加
        {
            gameOverObj.SetActive(false);							//③初期設定ではゲームオーバーは非アクティブに
            playerObj.transform.position = continuePoint[0].transform.position;
            p = playerObj.GetComponent<Player>();
            if(p == null)
            {
                Debug.Log("プレイヤーじゃない物がアタッチされているよ！");
            }
        }
        else
        {
            Debug.Log("設定が足りてないよ！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー時の処理								//④ゲームオーバーのフラグがtrueになったらゲームオーバーをアクティブにする
        if(GManager.instance.isGameOver && !doGameOver)		//
        {												//
            gameOverObj.SetActive(true);						//フラグがtrueになったらゲームオーバーをアクティブ
            doGameOver = true;								//
        }												//
        //プレイヤーがやられた時の処理							//
        else if(p != null && p.IsContinueWaiting() && !doGameOver)//⑤ゲームオーバーになっていたらプレイヤーがやられた時の処理を行わないようにする
        {
            if(continuePoint.Length > GManager.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;
                p.ContinuePlayer();
            }
            else
            {
                Debug.Log("コンテニューポイントの設定が足りてないよ！");
            }
        }

        //ステージを切り替える								//⑨
        if (fade != null && startFade && !doSceneChange)		//
        {												//
            if (fade.IsFadeOutComplete())						//フェードが完了した後、
            {												//
                //ゲームリトライ									//
                if (retryGame)									//
                {											//
                    GManager.instance.RetryGame();				//リトライの処理を完了する
                }											//
                //次のステージ									//
                else											//
                {											//
                    GManager.instance.stageNum = nextStageNum;	//次のステージへ行く場合の処理
                }											//
                SceneManager.LoadScene("stage" + nextStageNum);	//⑪リトライやステージ移動に(ステージ＋番号)でシーン移動するようにする
                doSceneChange = true;							//
            }												//
        }												//
    }

    /// <summary>									//⑧リトライを押した時はステージ１にシーン移動するようにする
    /// 最初から始める									//
    /// </summary>									//
    public void Retry()								//
    {												//
        ChangeScene(1); //最初のステージ１に戻るので１		//
        retryGame = true;								//
    }												//

    /// <summary>									//⑥シーンを移動するためのメソッドを用意
    /// ステージを切り替えます							//	
    /// </summary>									//
    /// <param name="num">ステージ番号</param>		//
    public void ChangeScene(int num)					//引数で番号を指定　番号を指定してシーンを移動するようにしている
    {												//
        if(fade != null)									//
        {											//
            nextStageNum = num;							//⑦シーン移動するための下準備とフェードの開始のみを行う
            fade.StartFadeOut();							//
            startFade = true;								//
        }											//
    }												//
}
=====================
⑧現在作成されているシーンは２つだけですが　ここからステージ２、ステージ３と増やす際にシーン名に規則性があるとプログラムから動かしやすい
stage2,stage3		stage + 番号　としているのでシーンの移動を番号で行うことが出来るようになります
ちなみに今開いているシーンを開き直すことも可能で開き直すとそのシーンは初期状態に戻る　ステージ１でリトライしても問題ない

プレイヤーのスクリプトに移動する

Player.cs
=====================
void FixedUpdate()
    {
        if (!isDown && !GManager.instance.isGameOver)		//①ゲームオーバー時　移動できないようにする
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            rb.velocity = new Vector2(xSpeed, ySpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);
        }
    }
=====================

インスペクターの設定をする
unity2へ続く

unity2
＃５１	ゲームオーバーを作ろう
Step21	残機の減算処理を実装しよう　の続き

=====================

インスペクターの設定をする
↓ヒエラルキーStageCtrlを選択した状態でインスペクターの下記項目を設定する　ゲームオーバー：GameOver  フェード：Fadeスクリプト

↓ヒエラルキーGameManagerを選択した状態でインスペクターのデフォルトの残機を３にする

↓ヒエラルキーGameOver配下のButtonを選択した状態でヒエラルキーのクリック時を下記のように設定する　＋　Runtime Only StageCtrl.Retry StageCtrl.cs


この状態で実行▶するとリトライした時、最初のステージに戻ることができた

↑ステージコントローラーとキャンバスをまとめてプレハブにしておくと後々ステージを作る時に便利かも
空のオブジェクト作成：ContinuePoint　上の状態へ配置移動させた　StageCtrlをプロジェクトのPrefabへ移動
次回はアセットストアを使う際の注意点について解説します



＃５２　yutube動画を追い越したのでブログを見て進める　30/9/2020時点
Unity Asset Storeを使う時注意すべき点 | ゲームの作り方！
UnityAssetStoreはゲーム制作に便利な素材やプログラム、またUnityをより使いやすくする機能を手にいれることができる
が、アセットを購入したのに、プロジェクトが動かなくなってしまう事がありますし、画面が真っピンクになる事もあります。
直し方を知っていればいいですが知らないと詰んでしまう事もあります。また著作権の問題など多くの注意点があ

＜ライセンスについて＞
アセットの作者さんのライセンス表記があるか		表記を記載してある場所が作者さんによってバラバラ
作者さんのライセンスが書いてあるかもしれない場所
１　概要欄

ちゃんと左下のShow Moreで全部表示させて確認
credit　〜〜　と書いてある場合、「作者の名前をどこかに記載してね」と書いてある事が多いです。
英語が苦手な人はポイントとして、「credit」「commercial」「not allow」「license」という記載がないかよく探して見るといいかと思います。creditは著作表記、commercialは商用利用について、not allowは許可しない事、licenseはそのままライセンスについて書いてある事が多いです。

２　パッケージの中

この中に「License」や「Read me」というファイルが存在する場合、そこにライセンス表記がされている場合があります。
これはダウンロードしないと見れません。ダウンロードしてみて中身を読みましょう。

３　コンテンツ欄

ここにライセンス表記は2019/7/5現在ではありません。
しかしながら、昔ここにライセンス表記がされていた事があり、アセットストアの見た目は日々アップデートしているので突然復活する可能性もあります。
ストアの見た目が不意に変わっている事が多々あるのでコンテンツ欄にLicenseという項目が増えていないかどうか、さらっと見てチェックしましょう。

４　作者さんのホームページ
Support横のVisit siteをクリックすると作者がサイトに飛ぶ

ライセンス表記がなかった場合
↓その場合、UnityAssetStoreが取り決めたライセンスが適用されます。
Unity – アセットストアの利用規約とEULA
「アセットを取り出せない形」での公開、配布、販売		○
商用・非商用									○
アセットの改変（アドオンカテゴリのサービスを含まない)	○
「アセットを取り出せる形」での公開、配布、販売		✗
アドオンカテゴリのサービスのアセットのSDKを改変		✗
アセットのバックアップ目的以外でのコピー				✗
人数分ライセンス取得が必要なアセットを複数人で使い回す	✗
「アセットを取り出せない形」「アセットを取り出せる形」というのは、そのままの意味で、ダウンロードしてきた素材が取り出せなければOKになります。
例えば自作のゲーム内にアセットを含めて、そのゲームの実行ファイル(exeやapp,ipa,apkなど）を公開した場合はOKになります。


↑アドオンカテゴリのサービスというのはストアの検索カテゴリの中のAdd-Ons＞Servicesになります。このカテゴリのアセットに含まれているSDKは改変禁止になっています。ただし、作者さん側から、こういう風に改変して使ってくれとかいてある場合があるので、そう書いてある変更については行う事ができます。

また、Unity側が使用OKとしてるコンテンツは以下の通りです。
ゲーム、映像、映画、動画、アニメ 医療・自動車・建設・製造業向けアプリケーション / シミュレーター デジタルアート（例：プロジェクションマッピング、メディアアート、ビジュアルジョッキー、その他） 電子書籍・漫画 ギャンブルコンテンツ（例：ビデオポーカーやビデオスロットマシン、その他) 業務アプリケーション
また、この利用規約は2020年4月13日に解釈変更がなされており、今まではそのアセットを使用する場合
（前）Unityで最終的なビルドをする、あるいはUnityをレンダリングエンジンとして使用しなければならない
（後）Unityに限らずゲームエンジンやオーサリングソフトウェアなどに取り込んで使用できる
という風に変わりました。これは使用可能範囲が広がってとてもありがたいですね。ただし、Unity外で使用する場合にはサポートの対象外になるのでご注意ください。
このようにライセンスは色々と複雑ですが、見落としたりしたらトラブルの元になってしまいますので細心の注意を払いましょう。特に追加ライセンスが未だにくっついているアセットには気を付けましょう。

＜エラーで動かなくなってしまう＞
アセットストアでダウンロードしてきたものの、エラーで動かなくなる事もあります。　

							　＜対象のUnityバージョンが違う＞
エラーが起きてしまったらバージョンアップ対応を自分でしないといけなくなります。バージョンアップ対応のやり方がわからない場合は、そのアセットを導入しないほうがいいかなと思います。もしくはそのバージョンのUnityを使用するかです。

Pluginと言う名前のフォルダが入っている
ダウンロードしてきた物の中にフォルダでPluginという名前のものがあった場合は注意が必要です。
Package Contentを参照してPluginというフォルダが無いか探してください。このプラグインというのはUnity外部の機能と連携して使う機能になります。
iOSやAndroid、WindowsやMacは日々目まぐるしくアップデートを行なっている為、Pluginの中に入っている機能が、アップデートについていけていない可能性があります。その為、Pluginというフォルダがあった場合、一度カラのプロジェクトにそのアセットのみを入れてビルドしてみるといいと思います。普通、ゲームが完成してから実際に携帯やゲーム機などに入れてプレイしてみると思うのですが、Pluginのフォルダが入っていた場合、動かなくなる可能性があるので、被害が少ないうちにテストしてみましょう。Pluginと名のつくフォルダを入れた場合、早急に実機でプレイした方がいいでしょう。例えカラのプロジェクトであっても大丈夫ですので一回入れてみてテストしましょう。ちなみに、Pluginを入れてしまって動かなくなってしまった際に入れる前の状態に戻す手段がないと入れたアセットを全て削除する作業を行う羽目になります。作者さんが１つのフォルダにまとめてくれているといいのですが、たくさんのファイルに分けてあった場合削除が大変になってしまいます。
導入する前の状態をバックアップすることをオススメします。

Editorという名前のフォルダが入っている
Editorという名前のフォルダがアセット内に含まれていた場合、Unity自体の機能を変えてしまいます。（正確には変更ではなく拡張なのですが、結果が変わってしまうのは事実です。）このEditorという名前のフォルダを持つアセットを１種類だけを導入した場合はほとんど問題はないと思いますが、たくさんの種類のアセットを導入した場合は問題が起こる事が多いです。違うアセットがUnityの同じ機能を変更しようとしてぶつかってしまう場合や、Unityの元々の機能を使用する事を想定していたのに別のアセットによって変更されていたり、無限ループに入ってしまって処理が終わらなくなったりします。
世に言う食い合わせが悪い状態に陥ってしまうのです。その為、「Editor」と言う名前がついたフォルダを持ったアセットを複数導入したい場合は、まずカラのプロジェクトにそれらを入れてみて、ちゃんと動くかどうか調べてみる必要があります。また、ちゃんと動いたとしてもUnity自体が重くなる事があります。編集中にやたら処理が走ったりする事もあります。動かしているゲームが重いのではなく、Unity自体がなんか重いなと感じたら、まず「Editor」と名前がついたフォルダの中身を疑ってみましょう。

指定しているPackageを導入していない
作者さんの中には、PackageManagerに封入されているアセットを導入していることを前提としたアセットを販売されている方もいます。
そういった作者さんはアセットの概要欄や、Read meやManualや自身のホームページで必要な初期設定を解説してくれているので、作者さんの指示に従いましょう。

＜アセットがピンク色になってしまう＞
アセットをダウンロードして来たはいいものの、アセットが真っピンクになってしまう事があります。この場合、シェーダーでエラーが起きています。エラーといっても種類が色々あります。
シェーダーのバージョンが古い
単にバージョンが古いので映らなかったりする事もあります。こちらも自分でバージョンアップ対応をする必要があります。バージョンアップのやり方がわからないのであれば、サポート対象外のUnityのバージョンを指定しているアセットは導入しないほうがいいと思います。もしくはそのバージョンのUnityを使うかです。

アセットのフォルダを移動させた
シェーダーの中には.cgincというファイルがある事があります。これの位置をシェーダープログラムとは別の場所に持って行ってしまうとエラーが起きる事があります。
また、人によってはAssetsフォルダからパスを指定している人もいるので移動によってエラーが起きる可能性があります。
作者さんが元々配置していた位置にフォルダを戻しましょう。

マテリアルが外れている
何らかの原因でマテリアルの参照が外れてしまう事があります。マテリアルがMissingになっていないかどうか確認してはめ直してください。

アセットがPhysically-based shadingだ
アセットの概要欄のところで「PBS」や「Physically-based shading」と記載されていた場合、Unityがデフォルトの状態だと真っピンクで表示されます。
これはRender Pipelineが違うから起きる現象です。これらのアセットを使用するにはプロジェクトを作成する時に、High-DefinitionRPかLightweight RPかVRLightweightRPを選ぶ必要があります。プロジェクトのテンプレートが2Dや３Dや3D With Extrasだとピンク
もしくは、プロジェクトにScriptRenderPipelineを使用するか、後からテンプレートの設定を適用する必要があります。
ちょっと難しい設定ですので、わからない方はそのアセットを導入しないか、大人しくマテリアルに適用されているシェーダーをStanderd Shaderに変更してしまいましょう。

＜モデルの見た目が思ってたのと違う＞
ストア内だととっても綺麗ですごいアセットだったのに、いざダウンロードしてみたら思ってたのと違う事があります。
これは、そのアセットの作者さんがPostProcessingを使うことを前提にしている事がある為です。
そういった作者さんはアセットの概要欄や、Read meやManualや自身のホームページで必要な設定を解説してくれているので、作者さんの指示に従いましょう。
ちゃんと設定通りにしないとショボイ見た目になって思ったのと違うことになってしまいます。

＜ライセンスがややこしい＞ ここからNew情報　
一番最初に見るべきポイントはそのアセットのライセンスです。実は2020年2月3日にライセンスの改定、2020年4月13日に利用規約の解釈の変更があり、いろいろな変化がありました。
そのため、この記事のようなUnityAssetStoreのライセンスについての解説はいつ書かれているのかによって中身が全然違う物になっているので、ご注意ください。この記事は2020/9/29に書かれています。以降改定されてないかをご確認ください。この解説も古くなっている可能性があります。
そして、2020年2月3日の改定が非常に大きく、それより前に出ていたアセットが今の状態と不整合があるものが出てきました。
改定前に購入したアセットには以前のライセンスが、改定後に購入したアセットには改定後のライセンスが適用されます。ですが、2020年2月3日より前のライセンス想定で出品されたアセットがストアに残ってしまい、ちょっとちぐはぐな状況が生まれてしまいました
実は以前は「追加ライセンス」というものがあり、UnityAssetStore本来のライセンスに加えて、アセットの制作者さんがそのアセットに対してライセンスを付与することができました。
例えば、UnityAssetStoreのライセンスではアセットの制作者さんのクレジットを表記する必要はありませんが、追加ライセンスに「名前をクレジットに表記してください」とあった場合、表記する必要がありました。

2020年2月3日より前に購入したアセットに関しては↓の追加ライセンスが適用される
この追加ライセンスは、改定によりなくなってしまったんですが、追加ライセンスが付与されているアセットがストアに残ってしまいました。2020/9/29日現在でもまだちらほら見ます。
これらのアセットについて公式は以下のように言っています
パブリッシャーが独自に規約を付けている場合
パブリッシャーが独自の規約を添付している場合、そのアセットは本来は審査を通過すべきアセットではありませんので下記お問い合わせ先からお知らせください。
自動的にアセットストアの利用規約が優先されたりパブリッシャーの独自利用規約が無効化されることはありません。当該アセットが適正な状態になるまでの間、一時的にアセットストアから削除するなどの措置を取るなどして、パブリッシャーに対して是正を手配します。

http://assetstore.info/notice/eulainterpretation20200413/
ということで、2020/2/3以降に追加ライセンスを持ったアセットを購入するのはちょっとマズイです。購入してしまった場合は、公式に報告して、返金処理をしてもらえないか相談した方がいいかなとお思います。
ただし、パブリッシャー独自のライセンスは廃止されたのですが、MITライセンス、BSD 3-Clause、Apacheライセンスを含むアセットの場合は、こちらが優先して適用されます。ストアの概要欄、readmeなどを確認しましょう。
そして、Unity公式が出している下記4アセットのみ、独自の利用規約、使用許諾があります。
“Unity-Chan!” Model
Unity-Chan License (UCL)の下に配布されています。
Lost Crypt 2D サンプルプロジェクト
Unity Companion Licenseの下に配布されているファイルを含みます。詳細についてはパッケージ内の ThirdPartyNotices.txt をご参照ください。
Book Of The Dead: Environment
プロジェクトに含まれる、カスタマイズ済みのポストプロセッシング、レンダーパイプラインのコア、および HD レンダーパイプラインは Unity Companion License の対象です。コードの各コンポーネントのライセンス情報の詳細についてはパッケージ内の ThirdPartyNotices.txt をご参照ください。
The Heretic: Digital Human
デジタルキャラクターは、教育と非商用目的に限ってUnityでのみお使いいただけます。当該パッケージで使われているデジタルヒューマン以外の部品については通常のアセットストアEULAが適用されます。

ストアから追加ライセンスが入ったものが完全になくなってくれれば、いちいちライセンスを確認する必要がなくなるので、便利なのですが、それまでは確認する必要があります。将来なんとかなることに期待ですね。

＜シートライセンス・サイトライセンス＞
↑の利用規約に加えて、UnityAssetStoreには購入時にシートライセンスとサイトライセンスという２種類のライセンスが適用されます。
これも2020年2月3日に改定されているので、前後で扱いが違います。2020年2月3日より前に購入したアセットは以前のライセンスが適用されるので、ご注意ください。といっても、2020年2月3日より前のアセットでシート購入した覚えがないアセットは個人（と同じ建物に住んでいる家族）、もしくは単一の法人（同一の拠点）内で使いまわせるので、使う範囲さえ広げなければ問題ないかと思います。改定後、そのアセットがシートライセンスに変わっていても追加でシートを購入する必要はありません。
2020年2月3日以降は下記のように変わっています。（改定前でシート購入したアセットも↓のシートライセンスを参照してください）
シートライセンスかサイトライセンスどちらが適用されているかは、カートにいれるボタンの近くを見ればわかると思います。

シートライセンス

購入時に付与されるライセンス　主にアセットの利用可能な範囲を示している
シートライセンスというのは簡単に言うと、原則として１人１つ購入する必要があるものになります。
Extension Assetと書かれている場合もシートベースになる
２人で開発するには２つ購入、３人で開発する場合は３つ購入する必要があります。
無料のものは、ライセンスのところにシートと書いてあるだけです。無料の物は何人居ようと各自でDLすればいい話なので、特に気にせず使えると思います。

有料のものは購入するところに購入数を決めるUIが出現するので、開発人数に合わせて購入してください。１つだけ購入して、みんなで使いまわすと利用規約違反になります。

また、シートライセンスの中には必ずしも１人１シートとは限らないものもあります。そういう場合は説明が書いてあると思うので、そちらを読みましょう


サイトライセンス
サイトライセンスが適用されている場合は、購入者がどの立場にあるのか選択する必要があります。
サイトライセンスが適用されているアセットは、その選択した範囲内で人数に関係なく無制限にアセットを利用できます。


Single Entity
「単一の法人」もしくは「Single Entity」と書かれているところを選択するとアセットの利用可能範囲が以下になります。
・個人（と同じ建物に住む家族） ・単一の法人（同一拠点内）
Multi Entity
「複数の法人」もしくは、「Multi Entity」と書かれているところを選択するとアセットの利用可能範囲が以下になります。
・法人または事業体の従業員 ・親会社、子会社、兄弟会社などからなる企業グループの従業員
また、法人または事業体と単一のプロジェクト単位で業務委託契約を結んで働く個人や企業の従業員も、契約対象のプロジェクトに限定してアセットを共用利用できます。
ただし、以下のケースは対象範囲に含まれないそうです。
・ジョイントベンチャー ・協力企業もしくは取引先など ・共同事業体 ・法人または事業体と単一のプロジェクトに制限せずに業務委託契約を結んで働く方
これらのケースはまたそれぞれで別途アセットを購入する必要があります。
また、プロジェクト単位で業務委託契約を結んで働く方が保有する「複数企業向けライセンス」のアセットを、業務委託契約相手である発注者と共用利用することはできません。

＜拡張キットだ＞
アセットの中には、〇〇アセットを更によりよくする拡張キットが売っている場合があります。この場合、そもそも元の〇〇アセットを持っていないと動かないケースもあるので、ストア概要欄をよく読みましょう。

＜アセットそのものが著作権違反だ＞
実は悲しいことに、UnityAssetStoreで出品されている商品の中にも著作権違反をしているものがたまに現れます。
これはストアに並んでいることがそもそもおかしいので、見つけたらUnityに違反報告をしましょう。
と言っても、公式も見逃してストアに並べてしまっているので、見分けるのは非常に困難です。
例えば、著作権違反のBGMが売られていたとしても、そのBGM自体を聞いたことないと、それが著作権違反の物であるのかというのは判別がつきません。
そのため、公式もこれらの違反を１００％完璧に排除するのは難しいと思いますし、我々も判別するのはかなり難しいです。
こればっかりはストアのレビューを見て判断するしかなさそうです。
ちょっと完全な回避策とは言えませんが ・なるべくレビューが少ないアセットは避ける ・レビューに変なことが書かれていないかよく読む ・BGM、キャラクターなどは特に気を付ける
これらを気を付けることによって、著作権違反のアセットを自分が踏むという状況は回避できるかもしれません。

＜追加ライセンス＞
許可されている追加ライセンスがある
・MITライセンス
・BSD　３-Clause
・Apacheライセンス


Unity 2Dアクションの作り方【BGM・SEをつけよう】 | ゲームの作り方！
＃５３かな？　＜アセットストアで素材を集めよう＞
今回は無料のものをダウンロード
仮のBGMとSE(効果音)をダウンロードして試しに当てはめてみるみたいな感じです。
アセットストアを開くには上部メニューのウィンドウWindow＞アセットストアAsset Storeから開きます。
アセットーオーディオ

The 8-bit Jukebox Lite - Music Pack　Package Size 397.7MB Supported Unity Versions 2019.4.1 or higher
マイアセットに追加する	Terms of Service 同意する	このアセットを 2020年9月30日 に購入しました　Unityで開く　Unity.appで開く　許可する
パッケージマネージャーが起動する　ダウンロード  

インポート

↑シートライセンス
インポート(BGM用)
プロジェクトAssets配下にCyberleaf Music - The 8-bit Jukebox Liteが入る
☑Override for iOS 適用する　全て　18個
titleScenesに空のオブジェクト作成　名前：BGM
コンポーネントを追加　🔍Audio Sourceオーディオソース　ループ☑
タイトルシーンではArcadeJam（BGM名）を選択
ステージ１では8BitNinjas（BGM名）を選択
BGMはつけることができたがタイトルシーンからいくと残機が０のままなのでGameManagerのインスペクター
現在のステージ1　現在の残機3　デフォルトの残機3に変更
タイトルとシーン１にBGMをつけることができた

次はSEをつけていく
アセットストアからSE音源をインポート

↑シートライセンス
Player
1 ジャンプする時に鳴らすSE	s_ef_ce_barrier
2 やられた鳴らすSE			s_ef_ce_mine_s
3 コンティニュー時に鳴らすSE	s_ef_ce_atfield
ScoreItem
4 アイテム取得時に鳴らすSE	s_ef_ce_yororo_e
StageCtrl 
5 ゲームオーバー時に鳴らすSE	s_ef_ce_mine_e
6 リトライ時に鳴らすSE		s_ef_cm_dm_umbrella_open
Title 
7 ゲームスタート時に鳴らすSE	s_ef_cm_dm_umbrella_def2
Enemy_Zako1
8 やられた時に鳴らすSE		s_ef_cm_dm_umbrella_def

音源を１つにするならばゲームマネージャーをくっつけてあるゲームオブジェクトにコンポーネントの追加から
Audio Sourceをくっつけましょう。ゲーム開始時に再生Play On Awake☑外す

ゲームマネージャーにSEを鳴らす機能を追加
GManager 
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    [Header("スコア")] public int score;
    [Header("現在のステージ")] public int stageNum;
    [Header("現在の復帰位置")] public int continueNum;
    [Header("現在の残機")] public int heartNum;
    [Header("デフォルトの残機")] public int defaultHeartNum;
    [HideInInspector] public bool isGameOver;

    private AudioSource audioSource = null;			//①くっつけたAudioSourceのインスタンスを捕まえる

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

　 private void Start()							//
    {											//
        audioSource = GetComponent<AudioSource>();	//
    }											//

    /// <summary>
    /// 残機を１つ増やす
    /// </summary>
    public void AddHeartNum()
    {
        if(heartNum < 99)
        {
            ++heartNum;
        }
    }

    /// <summary>
    /// 残機を１減らす
    /// </summary>
    public void SubHeartNum()
    {
        if(heartNum > 0)
        {
            --heartNum;
        }
        else
        {
            isGameOver = true;
        }
    }

    /// <summary>
    /// 最初から始める時の処理
    /// </summary>
    public void RetryGmage()
    {
        isGameOver = false;
        heartNum = defaultHeartNum;
        score = 0;
        stageNum = 1;
        continueNum = 0;
    }

　 /// <summary>									//②AudioSourceから音を鳴らすのをスクリプト
    /// SEを鳴らす									//で行う
    /// </summary>
    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);

        }
        else
        {
            Debug.Log("オーディオソースが設定されていません");
        }
    }
}
=====================
AudioClipはAudioSourceのインスペクターで設定したやつです。
AudioSourceは音源でAudioClipがSEのファイルになります。
PlayOneShotは1回だけ音を再生します。
後は音を鳴らしたいタイミングでこのメソッドを呼べばOKです。
これで、ゲームマネージャーを通してどこからでも音を鳴らす事が可能となったので、今まで作成してきたスクリプトに音の処理を追加します。


SEを鳴らす処理を追加したプレイヤーのスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("踏みつけ判定の高さの割合")] public float stepOnRate;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE; //New!
    [Header("やられた鳴らすSE")] public AudioClip downSE; //New
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;  //New
    #endregion

    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private bool isGround = false;　
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string hitAreaTag = "HitArea";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //明滅　ついている時の戻る
            if(blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えている時
            else if(blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついている時
            else
            {
                sr.enabled = true;
            }
            //1秒たったら明滅終わり
            if(continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDown && !GManager.instance.isGameOver)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            rb.velocity = new Vector2(xSpeed, ySpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //何かを踏んだ際のジャンプ
        if (isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (verticalKey > 0)
            {
	        if (!isJump)
                {
                    GManager.instance.PlaySE(jumpSE);  //New!
                }
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }
        
        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }

    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        beforeKey = horizontalKey;					//削除
        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary>
    /// コンテニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        if (GManager.instance.isGameOver)
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;
        }
    }

    //ダウンアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if(isDown && anim != null)
        { 
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if(currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// コンテニューする
    /// </summary>
    public void ContinuePlayer()
    {
        GManager.instance.PlaySE(continueSE);  //New! 
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;
    }

    //やられた時の処理
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
　　　  GManager.instance.PlaySE(downSE);  //New!
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    //もう一度跳ねる
                    ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                    if(o != null)
                    {
                        otherJumpHeight = o.boundHeight;//踏んづけたものから跳ねる高さを取得する
                        o.playerStepOn = true;          //踏んづけたものに対して踏んづけた事を通知する
                        jumpPos = transform.position.y; //ジャンプした位置を記録する
                        isOtherJump = true;
                        isJump = false;
                        jumpTime = 0.0f;
                    }
                    else
                    {
                        Debug.Log("ObjectCollisionが付いてないよ！");
                    }
                }
                else
                {
                    ReceiveDamage(true);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if(collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }

    #endregion
}
=====================
プレイヤーのスクリプトの部分だけ、ジャンプした時、１フレームで接地判定から抜けるかどうかわからないので、２重に鳴らないようにしています
↓PlayerのインスペクターのSEの設定


↓アイテムを取得した時にSEを鳴らすようにしたアイテムのスクリプト
ScoreItem
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [Header("加算するスコア")] public int myScore;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;
    [Header("アイテム取得時に鳴らすSE")] public AudioClip itemSE;

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが判定内に入ったら
        if (playerCheck.isOn)
        {
            if (GManager.instance != null)
            {
                GManager.instance.score += myScore;
                GManager.instance.PlaySE(itemSE);
                Destroy(this.gameObject);
            }
        }
    }
}
=====================
↓starのインスペクターのSEの設定


↓ゲームオーバー時のSEを鳴らすようにしたステージコントローラー
 StageCtrl
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCtrl : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンテニュー位置")] public GameObject[] continuePoint;
    [Header("ゲームオーバー")] public GameObject gameOverObj;
    [Header("フェード")] public FadeImage fade;
    [Header("ゲームオーバー時に鳴らすSE")] public AudioClip gameOverSE; //New!
    [Header("リトライ時に鳴らすSE")] public AudioClip retrySE; //New!

    private Player p;
    private int nextStageNum;
    private bool startFade = false;
    private bool doGameOver = false;
    private bool retryGame = false;
    private bool doSceneChange = false;

    // Start is called before the first frame update
    void Start()
    {
        if(playerObj != null && continuePoint != null && continuePoint.Length > 0 && gameOverObj != null && fade != null)
        {
            gameOverObj.SetActive(false);
            playerObj.transform.position = continuePoint[0].transform.position;
            p = playerObj.GetComponent<Player>();
            if(p == null)
            {
                Debug.Log("プレイヤーじゃない物がアタッチされているよ！");
            }
        }
        else
        {
            Debug.Log("設定が足りてないよ！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー時の処理
        if(GManager.instance.isGameOver && !doGameOver)
        {
            gameOverObj.SetActive(true);
            GManager.instance.PlaySE(gameOverSE); //New!
            doGameOver = true;
        }
        //プレイヤーがやられた時の処理
        else if(p != null && p.IsContinueWaiting() && !doGameOver)
        {
            if(continuePoint.Length > GManager.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;
                p.ContinuePlayer();
            }
            else
            {
                Debug.Log("コンテニューポイントの設定が足りてないよ！");
            }
        }

        //ステージを切り替える
        if (fade != null && startFade && !doSceneChange)
        {
            if (fade.IsFadeOutComplete())
            {
                //ゲームリトライ
                if (retryGame)
                {
                    GManager.instance.RetryGame();
                }
                //次のステージ
                else
                {
                    GManager.instance.stageNum = nextStageNum;
                }
                SceneManager.LoadScene("stage" + nextStageNum);
                doSceneChange = true;
            }
        }
    }

    /// <summary>
    /// 最初から始める
    /// </summary>
    public void Retry()
    {
        GManager.instance.PlaySE(retrySE); //New!
        ChangeScene(1); //最初のステージ１に戻るので１
        retryGame = true;
    }

    /// <summary>
    /// ステージを切り替えます
    /// </summary>
    /// <param name="num">ステージ番号</param>
    public void ChangeScene(int num)
    {
        if(fade != null)
        {
            nextStageNum = num;
            fade.StartFadeOut();
            startFade = true;
        }
    }
}
=====================
プロジェクト　Assets > Prefab プレハブにあるFade GameManager StageCtrlは
プレハブから設定すると全てのFade GameManager StageCtrlに適用されるのでプレハブから設定する
↓プレハブのStageCtrlインスペクターのSEの設定


↓ゲームスタートのSEを鳴らすようにしたタイトルのスクリプト
Title 
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;
    [Header("ゲームスタート時に鳴らすSE")] public AudioClip startSE;

    private bool firstPush = false;
    private bool goNextScene = false;

    /// <summary>
    /// スタートボタンを押されたら呼ばれる
    /// </summary>
    public void PressStart()
    {
        Debug.Log("Press Start!");
        if (!firstPush)
        {
            Debug.Log("Go Next Scene!"); //削除
            GManager.instance.PlaySE(startSE);
            fade.StartFadeOut();
            firstPush = true;
        }
    }

    private void Update()
    {
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("stage1");
            goNextScene = true;
        }
    }
}
=====================
titleScenesのCanvasのインスペクターのSEの設定


↓SEを鳴らす処理を追加した敵のスクリプト
Enemy_Zako1
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako1 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動するか")] public bool nonVisible;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("やられた時に鳴らすSE")] public AudioClip deadSE;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame  //削除
    void FixedUpdate()
    {
        if (!oc.playerStepOn)
        {
        
            if (sr.isVisible || nonVisible)
            {
                if (checkCollision.isOn)
                {
                    rightTleftF = !rightTleftF;
                }
                int xVector = -1;
                if (rightTleftF)
                {
                    xVector = 1;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                rb.velocity = new Vector2(xVector * speed, -gravity);
            }
            else
            {
                rb.Sleep();
            }
        }
        else
        {
            if(!isDead)
            {
                anim.Play("dead");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                if (GManager.instance != null)
                {
                    GManager.instance.PlaySE(deadSE);
                    GManager.instance.score += myScore;
                }
                Destroy(gameObject, 3f);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 5));
            }
        }
    }
}
=====================
enemy_walk1のインスペクターの設定

各種スクリプトに音を鳴らす処理を追加しました。どれも音を鳴らしたいタイミングで
GManager.instance.PlaySE(オーディオクリップ);
としているだけです。これで音を鳴らすことができます。



＃５４かな？　Unity 2Dアクションの作り方【動く床・落ちる床】【ギミック】
ウィンドウー２Dータイトルパレットで床を延長　かえるちゃんのジャンプする高さを3→5に変更
＜下からのみすり抜ける床＞
様々なギミックの床を作る前に、下から一方通行ですり抜ける床を作っておかないと各種ギミック床が下から乗ることができないので、まずは下からのみすり抜けられるようにします。
とりあえず、適当に下書きで書いた床を配置して、Box Collider 2Dをくっつけます。
※タイルマップではなく、スプライトを直接置いてください
Add ComponentでPlatform Effector 2Dというのを貼り付けます。
そしてボックスコライダーのインスペクターでエフェクターで使用Used By Effectorにチェックを入れましょう。
こうすることで、PlatformEffector2Dを使用することができるようになります。
このPlatformEffector2Dはコライダーを一方通行にしてくれる便利なコンポーネントです。これをくっつけるだけで一方通行になるのでUnity様様ですね。
↓のような感じになります。

↑の半円がなんなのかとか、パラメータをいじってみたい方は↓の記事を参考にしてください。
UnityのPlatformEffector2D【使い方とスクリプト】 | ゲームの作り方！

さて、Unityの機能によって、すり抜ける床になりましたが、現在のプレイヤーのスクリプトは頭に地面がぶつかったらジャンプをやめる処理が入っています。そのため、頭にある設置判定を、すり抜ける床に関しては反応しないようにしないといけません。
この床を判別するために、タグを追加しましょう。Add TagからGroundPlatformというのを追加します。そして、床のタグを GroundPlatform にします。

そして、接地判定のスクリプトで、頭の判定と、足の判定を分けなければいけないため、インスペクターでどっちか選択できるようにします。

GroundCheckスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("エフェクトがついた床を判定するか")] public bool checkPlatformGroud = true;

    private string groundTag = "Ground";
    private string platformTag = "GroundPlatform";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //物理判定の更新毎に呼ぶ必要がある 削除　接地判定を返すメソッド
    public bool IsGround()
    {
        if(isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
        else if (checkPlatformGroud && collision.tag == platformTag)
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
        else if (checkPlatformGroud && collision.tag == platformTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
        else if (checkPlatformGroud && collision.tag == platformTag)
        {
            isGroundExit = true;
        }
    }
}
=====================
ヒエラルキーCameraCollider インスペクター要素０X30→60　要素３X30→60 カメラの映る範囲を広げた
そして、頭の判定(HeadCheck)はインスペクターで、チェックを外し、足の方の判定(GroundCheck)はチェックをつけた状態にします。

一方通行にすり抜けることができた

落ちたら残機が減るオブジェクトの名前をDeadAreaにしてサイズXを70に変更して大きくした
ヒエラルキーObject配下にtogeとtoge2を移動させた

ポイントとして必ず下からのみすり抜ける床の当たり判定をプレイヤーの接地判定より薄くする事です。
こうしないと地面の中で足の判定の方が接地判定になってしまってストンと落ちたり地面の中で多段ジャンプができるようになってしまいます。


↑薄くしたが多段ジャンプは解消されなかった✗　が正常な動きかもしれないので放置

＜動く床＞
動く床のスクリプト解説
それでは動く床を実装していきます。
ただ床を動かすスクリプトを作っても汎用性に欠けるので、オブジェクトを指定した経路通りに動くスクリプトを作成します。
オブジェクトを指定した経路通りに動かすスクリプト

MoveObjectスクリプト　NEW
=====================
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class MoveObject : MonoBehaviour
 {
     [Header("移動経路")]public GameObject[] movePoint;
     [Header("速さ")]public float speed = 1.0f;
 
     private Rigidbody2D rb;
     private int nowPoint = 0;
     private bool returnPoint = false;
 
     private void Start()
     {
         rb = GetComponent<Rigidbody2D>();
         if (movePoint != null && movePoint.Length > 0 && rb != null)
         {
             rb.position = movePoint[0].transform.position;
         }
     }
 
     private void FixedUpdate()
     {
         if(movePoint != null && movePoint.Length > 1 && rb != null)
         {
             //通常進行
             if (!returnPoint)
             {
                 int nextPoint = nowPoint + 1;
 
                 //目標ポイントとの誤差がわずかになるまで移動
                 if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                 {
                     //現在地から次のポイントへのベクトルを作成
                     Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);
 
                     //次のポイントへ移動
                     rb.MovePosition(toVector);
                 }
                 //次のポイントを１つ進める
                 else
                 {
                     rb.MovePosition(movePoint[nextPoint].transform.position);
                     ++nowPoint;
 
                     //現在地が配列の最後だった場合
                     if (nowPoint + 1 >= movePoint.Length)
                     {
                         returnPoint = true;
                     }
                 }
             }
             //折返し進行
             else
             {
                 int nextPoint = nowPoint - 1;
 
                 //目標ポイントとの誤差がわずかになるまで移動
                 if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                 {
                     //現在地から次のポイントへのベクトルを作成
                     Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);
 
                     //次のポイントへ移動
                     rb.MovePosition(toVector);
                 }
                 //次のポイントを１つ戻す
                 else
                 {
                     rb.MovePosition(movePoint[nextPoint].transform.position);
                     --nowPoint;
 
                     //現在地が配列の最初だった場合
                     if (nowPoint <= 0)
                     {
                         returnPoint = false;
                     }
                 }
             }
         }
     }
 }
=====================
スクリプト内のコメントを読んでもらえればほぼわかると思いますが、一応解説すると
if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
Vector2.Distanceというのは２つの位置の距離を測るメソッドです。現在位置と次の位置との距離を測って、距離が小さくなければという判定をしています。
Time.deltaTimeを使用する場合、ぴったりな値になりづらく誤差が生じるのでこのようにちょっと幅を持たせています。
//現在地から次のポイントへのベクトルを作成
Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);
これはコメントに書いてある通りなんですが、現在地から次のポイントへのベクトルを作成しています。speed * Time.deltaTimeというのがここで生成される最大のベクトルの長さになるので、少しずつ移動することを表しています。
//次のポイントへ移動
rb.MovePosition(toVector);
さらに↑も重要ポイントです。動く床はコライダーを持っているのでTransform系で移動させると重くなってしまいます。その為物理演算系で移動させる為Rigidbody2Dで移動させています。
今までと同じようにvelocityを使いたいところですが、velocityだと「速さ」である為、正確に位置が取りづらい為MovePositionを使用しています。
MovePositionはその位置までオブジェクトを移動させるという意味になります。
ちなみに
rb.position
と
rb.MovePosition
の２種類が存在するのですが、上が空間転移で下が瞬間移動です。
瞬間移動の話は↓の記事でまとめてあります。興味があったら見てみてください。
ゲームのフレームとは【Unityゲーム制作基礎】 | ゲームの作り方！


ぴよった！！　シーンに何も表示されなくなった　解決法　シーンタブを追加する　元のシーンタブは削除
【Unity】Sceneビューに何も表示されなくなった時の解決法 - Qiita
ぴょった！！　map_ground2が消える　１２３４を子オブジェクトにしていたのが原因
下記のようにしたら動いて表示された

map_ground2にMoveObjectスクリプトとリジッドボディ２Dを追加して下記のように設定する

動く床のスクリプトの使用方法
では、このスクリプトの使い方を説明します。
ステージ管理の時に解説した事と同じことをします。
まずは、カラのゲームオブジェクトを作成し、ゲームオブジェクトの左上の灰色の箱みたいな奴をクリックしてください。
↓のようなメニューが出てきたと思います。

適当に好きな色の奴を選んでください。できたら上２段の横長の物がいいと思います。
そうすると、カラだったゲームオブジェクトがシーンビュー上で映るようになります。
床は、このゲームオブジェクトの位置を順番に移動するようになります。

↑のように設置しました。
設置したゲームオブジェクトをインスペクターで設定します↓

Rigidbody2Dもつけましょう。
回転しないようにFreezeRotationのZにもチェックを入れます。
ポイントとしては、Body TypeをKinematicにしましょう。
Kinematicについての解説は↓の記事で行なっていますので詳しく知りたい方は参考にしてみてください。
UnityのRigidbody【使い方とスクリプトとForce Mode】 | ゲームの作り方！

何故Kinematicにするのか
Kinematicというのは簡単に言うとその物体には物理演算が適用されません。そもそも動く床が物理の法則を無視しているので、適用しない方がいいですよね。
あれ？それって意味あるのって話ですが、「その物体には」物理演算が適用されないのであって、その物体は物理演算が適用されている物体には影響します。
この場合、動く床がプレイヤーにぶつかったとき、プレイヤーは動く床に押し出されますが、逆にプレイヤーが動く床にぶつかったとき、動く床はビクともしません。
動く床 → プレイヤー に対しては物理演算が適用されるが プレイヤー → 動く床 には物理演算は適用されないということです。
これで、プレイヤーが乗った重みなどで、動く床が沈んで行ってしまう等の物理演算をシカトしつつ、上に乗ることができます。
ちなみに、プレイヤーは物理演算の計算結果を無視するためにvelocityで動かしていると以前解説しましたが、このKinematicとは全く違うものになります。
プレイヤーをvelocityで動かすというのは物理演算は行うけど、速度に関する結果は破棄するという意味になります。つまり、衝突はするけど、衝突の際に発生した弾き飛ばし等のプレイヤーが速度をもってしまう結果を破棄しているということです。
Kinematicは相手が物理演算で動いていないと衝突さえしません。動く床同士や、動く床とタイルマップは重なってもすり抜けます。こういう違いがあるわけですね。
ちなみに、プレイヤーの物理演算を破棄している理由はこのような動く床などの物理の法則を無視したギミックが２Dアクションにはしばしば見られるからです。物理の法則を無視したヤツから物理的な介入を受けて予測不能な動きをしてしまうと困るからですね。

動く床を動作させてみる
設定が完了した状態で再生すると床が動く

さて、これでオブジェクトを指定した経路通りに動かす事はできました。これは床以外の物にも使用できるので便利です。
もし、床がガクガクして動く場合は床のRigidobody 2DのInterpolateのところをInterpolateにしてください。

物理演算と描画のズレを補間してくれます。
さて、これで動く床を作ることができました。
しかし、動く床で使用する場合、上に乗っているプレイヤーが滑ってしまっているのがわかるかと思います。
ちょっと動く床としてはアレなので動く床なりの工夫をします。

動く床で滑らないようにする
さて、動く床で滑らないようにする対策として、プレイヤーを床の子オブジェクトにするというやり方が有名です。
しかしながら、その対策だと下の動きに非常に弱くなります。あとこのサイトではキャラクターの反転をスケールでしているので子オブジェクトにしてしまうと大きさが変になってしまいます。
また、Surface Effector2Dを使う対策も存在するのですが、うまく動作しませんでした。
また、Physic Material 2Dで摩擦係数を上げて滑らなくする方法もあるのですが、これはプレイヤーが横に動きづらくなってしまいます。
その為、何か他のものに頼るのではなく、ちゃんと速度計算してあげる必要がありそうです。

速度計算を加えたオブジェクトを動かすスクリプト
MoveObject
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("移動経路")] public GameObject[] movePoint;
    [Header("速さ")] public float speed = 1.0f;

    private Rigidbody2D rb;
    private int nowPoint = 0;
    private bool returnPoint = false;
    private Vector2 oldPos = Vector2.zero;
    private Vector2 myVelocity = Vector2.zero;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (movePoint != null && movePoint.Length > 0 && rb != null)
        {
            rb.position = movePoint[0].transform.position;
            oldPos = rb.position;
        }
    }

    public Vector2 GetVelocity()
    {
        return myVelocity;
    }

    private void FixedUpdate()
    {
        if (movePoint != null && movePoint.Length > 1 && rb != null)
        {
            //通常進行
            if (!returnPoint)
            {
                int nextPoint = nowPoint + 1;

                //目標ポイントとの誤差がわずかになるまで移動
                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    //現在地から次のポイントへのベクトルを作成
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                    //次のポイントへ移動
                    rb.MovePosition(toVector);
                }
                //次のポイントを１つ進める
                else
                {
                    rb.MovePosition(movePoint[nextPoint].transform.position);
                    ++nowPoint;

                    //現在地が配列の最後だった場合
                    if (nowPoint + 1 >= movePoint.Length)
                    {
                        returnPoint = true;
                    }
                }
            }
            //折返し進行
            else
            {
                int nextPoint = nowPoint - 1;

                //目標ポイントとの誤差がわずかになるまで移動
                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    //現在地から次のポイントへのベクトルを作成
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);

                    //次のポイントへ移動
                    rb.MovePosition(toVector);
                }
                //次のポイントを１つ戻す
                else
                {
                    rb.MovePosition(movePoint[nextPoint].transform.position);
                    --nowPoint;

                    //現在地が配列の最初だった場合
                    if (nowPoint <= 0)
                    {
                        returnPoint = false;
                    }
                }
            }
            myVelocity = (rb.position - oldPos) / Time.deltaTime;
            oldPos = rb.position;
        }
    }
}
=====================
↓この２つの変数を追加して速度を求めます。
private Vector2 oldPos = Vector2.zero;
private Vector2 myVelocity = Vector2.zero;
oldPosに前のフレームの位置を保存します。そして現在の位置から引く事で進んだ距離が出せます。
myVelocity = (rb.position - oldPos) / Time.deltaTime;
速さ　＝　道のり / 時間　なので、Time.deltaTimeで割ってあげれば床の速さが出ます。
ここでタグを追加しましょう。Add Tagから

MoveFloorというのを追加します。
そして、動く床のタグをMoveFloorにします。
map_ground2のタグをGroundPlatform→MoveFloor


今度は接地判定にこのMoveFloorも地面だと認識させます。そして、プレイヤーの足元で床に触れた場合、その床の速度をとってくるようにします。

接地判定に動く床を認識させたスクリプト
GroundCheck
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundCheck : MonoBehaviour
{
    [Header("エフェクトがついた床を判定するか")] public bool checkPlatformGroud = true;

    private string groundTag = "Ground";
    private string platformTag = "GroundPlatform";
    private string moveFloorTag = "MoveFloor";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定を返すメソッド
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
        else if (checkPlatformGroud && (collision.tag == platformTag || collision.tag == moveFloorTag))
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
        else if (checkPlatformGroud && (collision.tag == platformTag || collision.tag == moveFloorTag))
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
        else if (checkPlatformGroud && (collision.tag == platformTag || collision.tag == moveFloorTag))

        {
            isGroundExit = true;
        }
    }
}
=====================

動く床の速度を加味したプレイヤーのスクリプト
Player 
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE; //New!
    [Header("やられた鳴らすSE")] public AudioClip downSE; //New
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;  //New
    #endregion

    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private MoveObject moveObj = null;　　//①
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private bool isRun = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string hitAreaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }
            //1秒たったら明滅終わり
            if (continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDown && !GManager.instance.isGameOver)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定　③取得した床から速度を持ってきて、プレイヤーの速度に加算してあげます。
            Vector2 addVelocity = Vector2.zero;
            if (moveObj != null)
            {
                addVelocity = moveObj.GetVelocity();
            }
            rb.velocity = new Vector2(xSpeed, ySpeed) + addVelocity;
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //何かを踏んだ際のジャンプ
        if (isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (verticalKey > 0)
            {
                if (!isJump)
                {
                    GManager.instance.PlaySE(jumpSE); 
                }
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }


    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }


    /// <summary>
    /// コンティニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        if (GManager.instance.isGameOver)
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;
        }
    }

    //ダウンアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if (isDown && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// コンティニューする
    /// </summary>
    public void ContinuePlayer()
    {
        GManager.instance.PlaySE(continueSE);  
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;
    }

    //やられた時の処理
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.PlaySE(downSE); 
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                    if (o != null)
                    {
                        otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                        o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                        jumpPos = transform.position.y; //ジャンプした位置を記録する
                        isOtherJump = true;
                        isJump = false;
                        jumpTime = 0.0f;
                    }
                    else
                    {
                        Debug.Log("ObjectCollisionが付いてないよ!");
                    }
                }
                else
                {
                    ReceiveDamage(true);
                    break;
                }
            }
        }
        //動く床	②接触判定でタグが動く床だった場合、足元で接触しているかどうかを見て、その床についているMoveObjectをとってくるようにしています。
        else if (collision.collider.tag == moveFloorTag)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));
            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;
            foreach (ContactPoint2D p in collision.contacts)
            {
                //動く床に乗っている
                if (p.point.y < judgePos)
                {
                    moveObj = collision.gameObject.GetComponent<MoveObject>();
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)　//④床から離れたらnullを入れてあげる事で加算する速度を無しにします。
    {
        if (collision.collider.tag == moveFloorTag)
        {
            //動く床から離れた
            moveObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if (collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }
    #endregion
}
=====================
これで動く床にちゃんと計算された形で乗る事ができるようになりました。
こういった物理法則を無視するオブジェクトにちゃんと対応できるようにするためにAddForceなどを使わずvelocityで計算していたわけですね。

カメラとデッドエリアを広げる　すり抜けるだけの床を再配置（右上）
Box Clooider 2Dエフェクターで使用☑　コライダーの編集　薄くする			 Platform Effector 2D　		タグGroundPlatform 


＜落ちる床＞
落ちる床を作成する際にする工夫
続いて落ちる床を実装していきます。
落ちる床を作る際にちょっとした工夫を施します。

↑のように２つのゲームオブジェクトに分けます。
このようにオブジェクトを分けるのは演出をする為です。
いきなりパッと落下されるとプレイヤーも困ると思うので、ちょっとふるふると震動してから落ちるようにしたいと思います。
この時、コライダーまで揺れてしまうと、プレイヤーも震動してしまうので、これを回避するために、コライダーとレンダラーを分けています。
ではこれらのゲームオブジェクトの設定を順に解説していきます。
まず、スプライトレンダラーで落ちる床の絵だけを表示するオブジェクトを作成します。
見た目だけ表示したいだけなのでSprite Rendererで絵を表示させて終わりです。
これを適当にカラのゲームオブジェクトをつくり、子オブジェクトにします。
次に↑のカラのゲームオブジェクト(FallFloor)にコライダーの判定をつけていきます。
動く床の時と同じようにBox Collider 2D　コライダーの編集とPlatform Effector 2DとRigidbody2Dをつけ、キネマティックKinematic　回転を固定☑Z
下準備の部分は動く床と一緒です。ただしSprite Rendererだけ無い状態です。
そして、ここに、以前作成したプレイヤーが踏んだことを通知するスクリプトをつけます。

以前作成したプレイヤーが踏んだことを通知するスクリプト
ObjectCollision 
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
	[Header("これを踏んだ時のプレイヤーが跳ねる高さ")] public float boundHeight;

	/// <summary>
	/// このオブジェクトをプレイヤーが踏んだかどうか
	/// </summary>
	[HideInInspector] public bool playerStepOn;
}
=====================
そして、↑のスクリプトから踏まれたことを検知して床を落下させるようにします。

床を落下させるスクリプト New
FallDownFloor
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownFloor : MonoBehaviour
{
    [Header("スプライトがあるオブジェクト")] public GameObject spriteObj;
    [Header("振動幅")] public float vibrationWidth = 0.05f;
    [Header("振動速度")] public float vibrationSpeed = 30.0f;
    [Header("落ちるまでの時間")] public float fallTime = 1.0f;
    [Header("落ちていく速度")] public float fallSpeed = 10.0f;
    [Header("落ちてから戻ってくる時間")] public float returnTime = 5.0f;

    private bool isOn;
    private bool isFall;
    private bool isReturn;
    private Vector3 spriteDefaultPos;
    private Vector3 floorDefaultPos;
    private Vector2 fallVelocity;
    private BoxCollider2D col;
    private Rigidbody2D rb;
    private ObjectCollision oc;
    private SpriteRenderer sr;
    private float timer = 0.0f;
    private float fallingTimer = 0.0f;
    private float returnTimer = 0.0f;
    private float blinkTimer = 0.0f;


    private void Start()
    {
        //初期設定
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        oc = GetComponent<ObjectCollision>();
        if (spriteObj != null && oc != null && col != null && rb != null)
        {
            spriteDefaultPos = spriteObj.transform.position;
            fallVelocity = new Vector2(0, -fallSpeed);
            floorDefaultPos = gameObject.transform.position;
            sr = spriteObj.GetComponent<SpriteRenderer>();
            if (sr == null)
            {
                Debug.Log("fallDownFloor インスペクターに設定し忘れがあります");
                Destroy(this);
            }
        }
        else
        {
            Debug.Log("fallDownFloor インスペクターに設定し忘れがあります");
            Destroy(this);
        }
    }

    private void Update()
    {
        //プレイヤーが1回でも乗ったらフラグをオンに
        if (oc.playerStepOn)
        {
            isOn = true;
            oc.playerStepOn = false;
        }

        //プレイヤーがのってから落ちるまでの間
        if (isOn && !isFall)
        {
            //震動する
            spriteObj.transform.position = spriteDefaultPos + new Vector3(Mathf.Sin(timer * vibrationSpeed) * vibrationWidth, 0, 0);

            //一定時間たったら落ちる
            if (timer > fallTime)
            {
                isFall = true;
            }

            timer += Time.deltaTime;
        }

        //一定時間たつと明滅して戻ってくる
        if (isReturn)
        {
            //明滅　ついている時に戻る
            if (blinkTimer > 0.2f)
            {
                sr.enabled = true;
                blinkTimer = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTimer > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }

            //1秒たったら明滅終わり
            if (returnTimer > 1.0f)
            {
                isReturn = false;
                blinkTimer = 0f;
                returnTimer = 0f;
                sr.enabled = true;
            }
            else
            {
                blinkTimer += Time.deltaTime;
                returnTimer += Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        //落下中
        if (isFall)
        {
            rb.velocity = fallVelocity;

            //一定時間たつと元の位置に戻る
            if (fallingTimer > fallTime)
            {
                isReturn = true;
                transform.position = floorDefaultPos;
                rb.velocity = Vector2.zero;
                isFall = false;
                timer = 0.0f;
                fallingTimer = 0.0f;
            }
            else
            {
                fallingTimer += Time.deltaTime;
                isOn = false;
            }
        }
    }
}
=====================
基本的にコメントを見ていただけるとほとんどわかると思いますが、プレイヤーが乗ったという判定を受け取ったら横に震動するようにします。
//震動する
spriteObj.transform.position = spriteDefaultPos + new Vector3(Mathf.Sin(timer * vibrationSpeed) * vibrationWidth,0,0);
ここで震動させています。Rigidbody2Dを使っていないのは、絵だけに分離したため物理的な挙動で動かす必要が無い為です。
Mathf.Sin(timer * vibrationSpeed)
これで震動させています。三角関数のSinは角度によって-1〜1の範囲をくるくる回る性質があります。
正弦波でググっていただけるとわかると思いますが、角度に時間を入れてあげることによって-1〜1の間で震動しているように見えます。
これに自分で設定した震動幅をかけてあげることによって震動を実装する事ができます。
一定時間震動したら、今度は落下します。
rb.velocity = fallVelocity;
落下はコライダーが関係するのでRigidbody2Dで動かします。FixedUpdateに書いている点にも注意が必要です。
コンティニューや戻ってしまう場合も考えて、落下してしばらくしたら位置を戻してあげなければいけません。
パッと戻られても困るので、プレイヤーの時と同じく明滅するようにします。

FallFloorにFallDownFloorスクリプトを追加　スプライトがあるオブジェクトをFloorSpriteにする
そして、新たにFallFloorというタグを作り、コライダーがついている方のゲームオブジェクトのタグを変更します。

そして、プレイヤーが落下床を踏んだ時、落下床に対して踏んづけた通知する処理を追加します。

落下床の判定を追加した接地判定
GroundCheck
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundCheck : MonoBehaviour
{
    [Header("エフェクトがついた床を判定するか")] public bool checkPlatformGroud = true;

    private string groundTag = "Ground";
    private string platformTag = "GroundPlatform";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定を返すメソッド
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
        else if (checkPlatformGroud && (collision.tag == platformTag || collision.tag == moveFloorTag  || collision.tag == fallFloorTag))
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
        else if (checkPlatformGroud && (collision.tag == platformTag || collision.tag == moveFloorTag  || collision.tag == fallFloorTag))
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
        else if (checkPlatformGroud && (collision.tag == platformTag || collision.tag == moveFloorTag  || collision.tag == fallFloorTag))
        {
            isGroundExit = true;
        }
    }
}
=====================


落下床に踏んだ判定を渡せるようにしたプレイヤー
Player 
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE;
    [Header("やられた鳴らすSE")] public AudioClip downSE;
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;
    #endregion


    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private MoveObject moveObj = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private bool isRun = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string hitAreaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }
            //1秒たったら明滅終わり
            if (continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
    }



    void FixedUpdate()
    {

        if (!isDown && !GManager.instance.isGameOver)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            Vector2 addVelocity = Vector2.zero;
            if (moveObj != null)
            {
                addVelocity = moveObj.GetVelocity();
            }
            rb.velocity = new Vector2(xSpeed, ySpeed) + addVelocity;
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //何かを踏んだ際のジャンプ
        if (isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (verticalKey > 0)
            {
                if (!isJump)
                {
                    GManager.instance.PlaySE(jumpSE);
                }
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }


    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary>
    /// コンティニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        if (GManager.instance.isGameOver)
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;
        }
    }

    //ダウンアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if (isDown && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// コンティニューする
    /// </summary>
    public void ContinuePlayer()
    {
        GManager.instance.PlaySE(continueSE);
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;
    }

    //やられた時の処理
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.PlaySE(downSE);
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                    if (o != null)
                    {
                        otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                        o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                        jumpPos = transform.position.y; //ジャンプした位置を記録する
                        isOtherJump = true;
                        isJump = false;
                        jumpTime = 0.0f;
                    }
                    else
                    {
                        Debug.Log("ObjectCollisionが付いてないよ!");
                    }
                }
                else
                {
                    ReceiveDamage(true);
                    break;
                }
            }
        }
        //動く床
        else if (collision.collider.tag == moveFloorTag)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));
            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;
            foreach (ContactPoint2D p in collision.contacts)
            {
                //動く床に乗っている
                if (p.point.y < judgePos)
                {
                    moveObj = collision.gameObject.GetComponent<MoveObject>();
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == moveFloorTag)
        {
            //動く床から離れた
            moveObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if (collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }
    #endregion
}
=====================
動く床の時と同じように踏んづけた判定を追加していくのですが、ちょっと多くなってきたのでまとめています。
 #region//接触判定
 private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemy = (collision.collider.tag == enemyTag);
        bool moveFloor = (collision.collider.tag == moveFloorTag);
        bool fallFloor = (collision.collider.tag == fallFloorTag);

        if (enemy || moveFloor || fallFloor)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    if (enemy || fallFloor)
                    {
                        ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                        if (o != null)
                        {
                            if (enemy)
                            {
                                otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                                o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                                jumpPos = transform.position.y; //ジャンプした位置を記録する
                                isOtherJump = true;
                                isJump = false;
                                jumpTime = 0.0f;
			    }
			    else if(fallFloor)
			    {
                                o.playerStepOn = true;
			    }
                        }
                        else
                        {
                            Debug.Log("ObjectCollisionが付いてないよ!");
                        }
		    }
		    else if(moveFloor)
		    {
                        moveObj = collision.gameObject.GetComponent<MoveObject>();
                    }
                }
                else
                {
                    if (enemy)
                    {
                        ReceiveDamage(true);
                        break;
                    }
                }
            }
        }
    }
    #endregion
=====================
ヒエラルキーFallFloorにObject Collisionスクリプトをはりつける
ヒエラルキーFallFloorにFall Down Floorスクリプトをはりつける
スプライトがあるオブジェクトをFloorSpriteにする
ヒエラルキーFloorSpriteのタグはGround
これで落ちる床を実装する事ができました。
ヒエラルキーにFloorオブジェクトを追加してフロア３つををまとめた
Floor				頭ぶつけないで上がれるフロア
MoveFloor MovePoint	頭ぶつけないで動くフロア
FallFloor				頭ぶつけないで落ちるフロア



＃５５かな？　	Unity 2Dアクションの作り方【コンティニュー・ステージクリア・メッセージ表示】
Unity 2Dアクションの作り方【コンティニュー・ステージクリア・メッセージ表示】 | ゲームの作り方！

＜メッセージを表示する＞
さて、まずはメッセージを表示する機能を作ってみます。
プレイヤーが特定の場所に近づいたらメッセージを表示する事で様々な事ができます。アクションゲームにストーリー性を持たせることもできますし、最初に操作方法を表示するなどチュートリアルも作成する事ができます。
まずは、プレイヤーが範囲内に入ったらという判定を作ります。といっても以前に作成したものを使えばうまくいきそうですね。

以前作成したプレイヤーの侵入を検知するスクリプト
PlayerTriggerCheckスクリプト

↑ヒエラルキー空のオブジェクトで作成　
PlayerTriggerIn
をプレハブにする
PlayerTriggerInインスペクターはBox Collider 2D☑トリガーにする　PlayerTriggerCheckスクリプト
単純にメッセージを表示するだけならプレイヤーが範囲内に入ったらSetActive(true)にしてあげればいいだけですが、パッと出てパッと消えるとちょっと無機質なので演出を加えます。

↑コライダーの編集をしてメッセージの下に合わせる

Canvas
レンダーモード　ワールド空間World Space 
イベントカメラ　Main Camera(Camera)

Panel
コンポーネント追加　Canvas Group
このコンポーネントはそのUGUIとその子オブジェクト全てのUGUIのアルファ値をコントロールする事ができます

Text

イメージの追加、バックグランドや文字の表示に苦労した
次に↓のスクリプトをCanvasにくっつけます。
範囲内に入るとメッセージを表示するスクリプト

FadeActiveUGUIスクリプト　NEW
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeActiveUGUI : MonoBehaviour
{
    [Header("フェードスピード")] public float speed = 1.0f;
    [Header("上昇量")] public float moveDis = 10.0f;
    [Header("上昇時間")] public float moveTime = 1.0f;
    [Header("キャンバスグループ")] public CanvasGroup cg;
    [Header("プレイヤー判定")] public PlayerTriggerCheck trigger;

    private Vector3 defaltPos;
    private float timer = 0.0f;

    private void Start()
    {
        //初期化
        if (cg == null && trigger == null)
        {
            Debug.Log("インスペクターの設定が足りません");
            Destroy(this);
        }
        else
        {
            cg.alpha = 0.0f;
            defaltPos = cg.transform.position;
            cg.transform.position = defaltPos - Vector3.up * moveDis;
        }
    }

    private void Update()
    {
        //プレイヤーが範囲内に入った
        if (trigger.isOn)
        {
            //上昇しながらフェードインする
            if (cg.transform.position.y < defaltPos.y || cg.alpha < 1.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position += Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer += speed * Time.deltaTime;
            }
            //フェードイン完了
            else
            {
                cg.alpha = 1.0f;
                cg.transform.position = defaltPos;
            }
        }
        //プレイヤーが範囲内にいない
        else
        {
            //下降しながらフェードアウトする
            if (cg.transform.position.y > defaltPos.y - moveDis || cg.alpha > 0.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position -= Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer -= speed * Time.deltaTime;
            }
            //フェードアウト完了
            else
            {
                timer = 0.0f;
                cg.alpha = 0.0f;
                cg.transform.position = defaltPos - Vector3.up * moveDis;
            }
        }
    }
}
=====================
FadeActiveUGUIスクリプトをCanvasに入れ下記のように設定する

インスペクターの値を設定します。上昇量というのはちょっと上に上がりながらフェードしてほしかったので入れています。上に上がる必要がなければ０を入れればOKです。
それと、このスクリプトを使う上で、注意が必要なところがあります。

PanelとTextのCanvas RendererのCull Transparent Meshに☑チェックを入れましょう。
透明なオブジェクトというのは存在するだけで重くなってしまうので、このように対策する必要があります。フェードアウトしている時は消えていただきましょう。

フェードしながらメッセージを表示する事ができました。


＜コンティニューポイント＞
続いてコンティニューポイントを作って行きます。
まぁ、メッセージの表示ができたならほぼ一緒です。



↑YとZをコンタクトポイントの座標に合わせる　かえるちゃんが変な場所からスタートしてた
最終的に
ContinuePoint		X0		Y0		Z0
StartPos			X0		Y-2.5	Z0
Continue1		X88		Y-2.5	Z0

↑YZを０にする　緑のコライダーが変な位置にいた

↑キャンバスをコピーして名前を変える(Continue1)
Fade Active UGUIスクリプトはコンテニュー１から削除する
↓かかしに差し替え

↓このスクリプトをContinue1に入れる
ContinuePointスクリプト　New
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePoint : MonoBehaviour
{
    [Header("コンティニュー番号")] public int continueNum;
    [Header("音")] public AudioClip se;
    [Header("プレイヤー判定")] public PlayerTriggerCheck trigger;
    [Header("スピード")] public float speed = 3.0f;
    [Header("動く幅")] public float moveDis = 3.0f;

    private bool on = false;
    private float kakudo = 0.0f;
    private Vector3 defaultPos;
    void Start()
    {
        //初期化
        if (trigger == null)
        {
            Debug.Log("インスペクターの設定が足りません");
            Destroy(this);
        }
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが範囲内に入った
        if (trigger.isOn && !on)
        {
            GManager.instance.continueNum = continueNum;
            GManager.instance.PlaySE(se);
            on = true;
        }

        if (on)
        {
            if (kakudo < 180.0f)
            {
                //sinカーブで振動させる
                transform.position = defaultPos + Vector3.up * moveDis * Mathf.Sin(kakudo * Mathf.Deg2Rad);

                //途中からちっちゃくなる
                if (kakudo > 90.0f)
                {
                    transform.localScale = Vector3.one * (1 - ((kakudo - 90.0f) / 90.0f));
                }
                kakudo += 180.0f * Time.deltaTime * speed;
            }
            else
            {
                gameObject.SetActive(false);
                on = false;
            }
        }
    }
}
=====================
プレイヤーが範囲内に入ったら音を鳴らして、コンティニュー位置をゲームマネージャーに報告します。
//プレイヤーが範囲内に入った
if (trigger.isOn && !on)
{
      GManager.instance.continueNum = continueNum;
      GManager.instance.PlaySE(se);
      on = true;
}
ステージコントローラーのインスペクターに追加してあげればコンティニューできるようになっています。

Element1に入っているのでインスペクターで自分のコンティニュー番号を１にしてあげればコンティニューポイントの位置からスタートします。

コンティニューポイントに接触した場合の演出をちょっと凝ってみました。
if (kakudo < 180.0f)
{
        //sinカーブで振動させる
        transform.position = defaultPos + Vector3.up * moveDis * Mathf.Sin(kakudo * Mathf.Deg2Rad);
                 
        //途中からちっちゃくなる
        if(kakudo > 90.0f)
        {
             transform.localScale = Vector3.one * (1 - ((kakudo - 90.0f) / 90.0f));
        }
        kakudo += 180.0f * Time.deltaTime * speed;
}
サインカーブを用いて上下させています。変数名がkakudoなのでわかりやすいと思いますが、Mathf.Sinの中にはラジアンを入れてあげなければいけません。
Mathf.Sin(kakudo * Mathf.Deg2Rad);
↑で角度をラジアンに直しています。角度にMathf.Deg2Radというものを掛ければOKです。
まぁ、わからなくても別に困ることではないので、わからなかったらなんかこんな方法もあるんだ程度に理解していただければと思います。

これでコンテニューかかしポイントを作ることができた

ヒエラルキーのキャンバスをメッセージに名前変更

＜ステージクリアー＞
次はステージクリアーを実装していきましょう。
コンティニューができれば正直新しく覚えることは特にありません。

クリアーを演出するスクリプト
ClearEffect   NEW
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClearEffect : MonoBehaviour
{
    [Header("拡大縮小のアニメーションカーブ")] public AnimationCurve curve;
    [Header("ステージコントローラー")] public StageCtrl ctrl;
    private bool comp = false;
    private float timer;
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (!comp)
        {
            if (timer < 1.0f)
            {
                transform.localScale = Vector3.one * curve.Evaluate(timer);
                timer += Time.deltaTime;
            }
            else
            {
                transform.localScale = Vector3.one;
                ctrl.ChangeScene(GManager.instance.stageNum + 1);
                comp = true;
            }
        }
    }
}
=====================

ステージクリアーを追加したゲームマネージャー
GManager
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    [Header("スコア")] public int score;
    [Header("現在のステージ")] public int stageNum;
    [Header("現在の復帰位置")] public int continueNum;
    [Header("現在の残機")] public int heartNum;
    [Header("デフォルトの残機")] public int defaultHeartNum;
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public bool isStageClear = false;


    private AudioSource audioSource = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 残機を１つ増やす
    /// </summary>
    public void AddHeartNum()
    {
        if (heartNum < 99)
        {
            ++heartNum;
        }
    }

    /// <summary>
    /// 残機を１つ減らす
    /// </summary>
    public void SubHeartNum()
    {
        if (heartNum > 0)
        {
            --heartNum;
        }
        else
        {
            isGameOver = true;
        }
    }

    /// <summary>
    /// 最初から始める時の処理
    /// </summary>
    public void RetryGame()
    {
        isGameOver = false;
        heartNum = defaultHeartNum;
        score = 0;
        stageNum = 1;
        continueNum = 0;
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);

        }
        else
        {
            Debug.Log("オーディオソースが設定されていません");
        }
    }
}
=====================


ステージクリアーを追加したステージコントローラー
StageCtrl
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCtrl : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンティニュー位置")] public GameObject[] continuePoint;
    [Header("ゲームオーバー")] public GameObject gameOverObj;
    [Header("フェード")] public FadeImage fade;
    [Header("ゲームオーバー時に鳴らすSE")] public AudioClip gameOverSE;
    [Header("リトライ時に鳴らすSE")] public AudioClip retrySE;
    [Header("ステージクリアーSE")] public AudioClip stageClearSE;		//publicがないとエラーになるのでパブリックを追記
    [Header("ステージクリア")] public GameObject stageClearObj;
    [Header("ステージクリア判定")] public PlayerTriggerCheck stageClearTrigger;

    private Player p;
    private int nextStageNum;
    private bool startFade = false;
    private bool doGameOver = false;
    private bool retryGame = false;
    private bool doSceneChange = false;
    private bool doClear = false;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0 && gameOverObj != null && fade != null && stageClearObj != null)
        {
            gameOverObj.SetActive(false);
            stageClearObj.SetActive(false);
            playerObj.transform.position = continuePoint[0].transform.position;
            p = playerObj.GetComponent<Player>();
            if (p == null)
            {
                Debug.Log("プレイヤーじゃない物がアタッチされているよ！");
            }
        }
        else
        {
            Debug.Log("設定が足りてないよ！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー時の処理
        if (GManager.instance.isGameOver && !doGameOver)
        {
            gameOverObj.SetActive(true);
            GManager.instance.PlaySE(gameOverSE); 
            doGameOver = true;
        }
        //プレイヤーがやられた時の処理
        else if (p != null && p.IsContinueWaiting() && !doGameOver)
        {
            if (continuePoint.Length > GManager.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;
                p.ContinuePlayer();
            }
            else
            {
                Debug.Log("コンティニューポイントの設定が足りてないよ！");
            }
        }
        else if (stageClearTrigger != null && stageClearTrigger.isOn && !doGameOver && !doClear)
        {
            StageClear();
            doClear = true;
        }

        //ステージを切り替える
        if (fade != null && startFade && !doSceneChange)
        {
            if (fade.IsFadeOutComplete())
            {
                //ゲームリトライ
                if (retryGame)
                {
                    GManager.instance.RetryGame();
                }
                //次のステージ
                else
                {
                    GManager.instance.stageNum = nextStageNum;
                }
                GManager.instance.isStageClear = false;
                SceneManager.LoadScene("stage" + nextStageNum);
                doSceneChange = true;
            }
        }
    }

    /// <summary>
    /// 最初から始める
    /// </summary>
    public void Retry()
    {
        GManager.instance.PlaySE(retrySE); //New!
        ChangeScene(1); //最初のステージに戻るので１
        retryGame = true;
    }

    /// <summary>
    /// ステージを切り替えます。
    /// </summary>
    /// <param name="num">ステージ番号</param>
    public void ChangeScene(int num)
    {
        if (fade != null)
        {
            nextStageNum = num;
            fade.StartFadeOut();
            startFade = true;
        }
    }

    /// <summary>
    /// ステージをクリアした
    /// </summary>
    public void StageClear()
    {
        GManager.instance.isStageClear = true;
        stageClearObj.SetActive(true);
        GManager.instance.PlaySE(stageClearSE);
    }
}
=====================

ステージクリアーを追加したプレイヤー
Player
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE;
    [Header("やられた鳴らすSE")] public AudioClip downSE;
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;
    #endregion


    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private MoveObject moveObj = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private bool isRun = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private bool isClearMotion = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string hitAreaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }
            //1秒たったら明滅終わり
            if (continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
    }



    void FixedUpdate()
    {

        if (!isDown && !GManager.instance.isGameOver  && !GManager.instance.isStageClear)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            Vector2 addVelocity = Vector2.zero;
            if (moveObj != null)
            {
                addVelocity = moveObj.GetVelocity();
            }
            rb.velocity = new Vector2(xSpeed, ySpeed) + addVelocity;
        }
        else
        {
            if (!isClearMotion && GManager.instance.isStageClear)
            {
                anim.Play("player_win”);			//名前はクリアではなくウィンなのでウィンに修正　クリアだとアニメーションしない　名前違い
                isClearMotion = true;
            }
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //何かを踏んだ際のジャンプ
        if (isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (verticalKey > 0)
            {
                if (!isJump)
                {
                    GManager.instance.PlaySE(jumpSE);
                }
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }


    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary>
    /// コンティニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        if (GManager.instance.isGameOver)
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;
        }
    }

    //ダウンアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if (isDown && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// コンティニューする
    /// </summary>
    public void ContinuePlayer()
    {
        GManager.instance.PlaySE(continueSE);
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;
    }

    //やられた時の処理
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown || GManager.instance.isStageClear)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.PlaySE(downSE);
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemy = (collision.collider.tag == enemyTag);
        bool moveFloor = (collision.collider.tag == moveFloorTag);
        bool fallFloor = (collision.collider.tag == fallFloorTag);

        if (enemy || moveFloor || fallFloor)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    if (enemy || fallFloor)
                    {
                        ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                        if (o != null)
                        {
                            if (enemy)
                            {
                                otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                                o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                                jumpPos = transform.position.y; //ジャンプした位置を記録する
                                isOtherJump = true;
                                isJump = false;
                                jumpTime = 0.0f;
                            }
                            else if (fallFloor)
                            {
                                o.playerStepOn = true;
                            }
                        }
                        else
                        {
                            Debug.Log("ObjectCollisionが付いてないよ!");
                        }
                    }
                    else if (moveFloor)
                    {
                        moveObj = collision.gameObject.GetComponent<MoveObject>();
                    }
                }
                else
                {
                    if (enemy)
                    {
                        ReceiveDamage(true);
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == moveFloorTag)
        {
            //動く床から離れた
            moveObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if (collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }
    #endregion
}
=====================

３日めに解決　ぴよりまくった　ステージクリアができなかった

エラーメッセージ
PlayOneShot was called with a null AudioClip.
UnityEngine.AudioSource:PlayOneShot(AudioClip)
GManager:PlaySE(AudioClip) (at Assets/Script/GManager.cs:82)
StageCtrl:StageClear() (at Assets/Script/StageCtrl.cs:128)
StageCtrl:Update() (at Assets/Script/StageCtrl.cs:71)

↑StageCtrlスクリプト 
[Header("ステージクリアーSE")] public AudioClip stageClearSE;
パブリックをつけてSEを選択できるようにした

Scene 'stage2' couldn't be loaded because it has not been added to the build settings or the AssetBundle has not been loaded.
To add a scene to the build settings use the menu File->Build Settings...
UnityEngine.SceneManagement.SceneManager:LoadScene(String)
StageCtrl:Update() (at Assets/Script/StageCtrl.cs:91)
シーン'stage2'がビルド設定に追加されていないか、AssetBundleがロードされていないため、シーン'stage2'をロードできませんでした。
ビルド設定にシーンを追加するには、メニューのFile->Build Settings...を使用します。

↑ステージ２を作成したらでなくなる　ステージ２のシーンを作成後、ファイルービルド設定ーシーンを追加


□ClearStage↑
Continue1をコピーして貼り付け　□ClearStageでキャンバスのレンダーモードをワールド空間　イベントカメラ　メインカメラ
スクリーンスペース - カメラではプレイヤートリガーチェックスクリプト及びボックスコライダー２Dが機能しない

■StagweClear↑
Box Collider 2Dのコライダーの編集でゴールに侵入判定を作る　プレイヤートリガーチェックスクリプトを配置


↑StageClearText
一旦、プレハブを展開　テキストをステージコントロール配下、ゲームオーバーより上に配置して

Clear Stageとテキストで書く　フォントサイズ９０　オーバーフロー×2　Clear Effectスクリプトを入れる　アニメーションカーブとステージコントローラーを設定

アニメーションカーブは0.5の時1.5にする　0/0　→　0.5/1.5　→1.0/1.0

StageCtrl

ステージクリアSE　	s_ef_at_huripen　あまってたSE
ステージクリア　	StageClearText →　ステージコントロール配下で作成したテキスト
ステージクリア判定	■StagweClear　→ステージコントロール外で最初に作成した■StagweClear

Message		メッセージを表示させる
Continue1	カカシ　コンテニューポイント１
ClearStage	ステージクリア
↑をPlayerTriggerという名前の空のオブジェクト配下にした　全てプレイヤーがトリガーで発生するイベントであるため

ステージクリアしてステージ２に移行できた

↑これまで作成したヒエラルキー



＃５6かな？	Unity 2Dアクションの作り方【ジャンプ台】
Unity 2Dアクションの作り方【ジャンプ台】【ギミック】 | ゲームの作り方！

ステージクリアをもっと奥に配置する

男子体操27-踏切板 の無料イラスト-イラストポップのスポーツクリップアートカット集
大きさ633なので１０２４
↓Pixelmatorで作成　テクスチャ配下に配置　スプライト　iOS用にする
jumpdai1.png　→シーンに配置　名前をjumpstep
jumpdai2.png

↑通常状態のアニメーションとジャンプ台が作動した時のアニメーションを作成します。　2色の色の踏み台を用意した

↑レイヤーではなくパラメーターで＋Triggerでonを作成

↑通常状態		→ジャンプ状態　	のところはonが入ったら遷移、Transition Durationを０　Conditions ＋　onを選択
ジャンプ状態	→通常状態　		のところはHas Exit Timeにチェック、Exit Timeを１にTransition Durationを０に設定

＜ジャンプ台を踏んだ時の制御を作成＞
では、ジャンプ台を踏んだ時の処理を追加していきましょう。でもその前に、ジャンプ台はジャンプ台と認識させなければいけないのでタグをつけましょう。

自分はJumpStepというタグを作って設定しました。
敵を踏んだ時に作ったものは高さを変える事ができましたが、速さは変えられなかったので速さを変えるパラメーターを追加します。で、踏んだ場合の制御を書いたジャンプ台のスクリプトを用意します。

ObjectCollision   何かを踏んだ時のスクリプトに速さを加えたもの
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    [Header("これを踏んだ時のプレイヤーが跳ねる高さ")] public float boundHeight;
    [Header("これを踏んだ時のプレイヤーが跳ねる速さ")] public float jumpSpeed;

    /// <summary>
    /// このオブジェクトをプレイヤーが踏んだかどうか
    /// </summary>
    [HideInInspector] public bool playerStepOn;
}
=====================

JumpObject ジャンプ台のスクリプト NEW
=====================
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 public class JumpObject : MonoBehaviour
 {
     private ObjectCollision oc;
     private Animator anim;

     // Start is called before the first frame update
     void Start()
     {
          oc = GetComponent<ObjectCollision>();
          anim = GetComponent<Animator>();
          if(oc == null || anim == null)
          {
              Debug.Log("ジャンプ台の設定が足りていません");
              Destroy(this);
          }
     }

     // Update is called once per frame
     void Update()
     {
          if (oc.playerStepOn)
          {
              anim.SetTrigger("on");
              oc.playerStepOn = false;
          }
     }
 }
=====================
これら２つのスクリプトをジャンプ台にくっつけ、BoxCollider2DとAnimatorもセットしましょう。


次はプレイヤー側がジャンプ台を踏んだことを認識し、跳べるようにします。

Player　　　跳べるようにしたプレイヤーのスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE;
    [Header("やられた鳴らすSE")] public AudioClip downSE;
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;
    #endregion


    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private MoveObject moveObj = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private bool isRun = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private bool isClearMotion = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float otherJumpSpeed = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string hitAreaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    private string jumpStepTag = "JumpStep";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }
            //1秒たったら明滅終わり
            if (continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
    }



    void FixedUpdate()
    {

        if (!isDown && !GManager.instance.isGameOver && !GManager.instance.isStageClear)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            Vector2 addVelocity = Vector2.zero;
            if (moveObj != null)
            {
                addVelocity = moveObj.GetVelocity();
            }
            rb.velocity = new Vector2(xSpeed, ySpeed) + addVelocity;
        }
        else
        {
            if (!isClearMotion && GManager.instance.isStageClear)
            {
                anim.Play("player_win");
                isClearMotion = true;
            }
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //何かを踏んだ際のジャンプ
        if (isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed =otherJumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (verticalKey > 0)
            {
                if (!isJump)
                {
                    GManager.instance.PlaySE(jumpSE);
                }
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }


    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary>
    /// コンティニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        if (GManager.instance.isGameOver)
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;
        }
    }

    //ダウンアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if (isDown && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// コンティニューする
    /// </summary>
    public void ContinuePlayer()
    {
        GManager.instance.PlaySE(continueSE);
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;
    }

    //やられた時の処理
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown || GManager.instance.isStageClear)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.PlaySE(downSE);
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemy = (collision.collider.tag == enemyTag);
        bool moveFloor = (collision.collider.tag == moveFloorTag);
        bool fallFloor = (collision.collider.tag == fallFloorTag);
        bool jumpStep = (collision.collider.tag == jumpStepTag);

        if (enemy || moveFloor || fallFloor || jumpStep)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    if (enemy || fallFloor || jumpStep)
                    {
                        ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                        if (o != null)
                        {
                            if (enemy || jumpStep)
                            {
                                otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                                otherJumpSpeed = o.jumpSpeed; //ジャンプするスピード
                                o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                                jumpPos = transform.position.y; //ジャンプした位置を記録する
                                isOtherJump = true;
                                isJump = false;
                                jumpTime = 0.0f;
                            }
                            else if (fallFloor)
                            {
                                o.playerStepOn = true;
                            }
                        }
                        else
                        {
                            Debug.Log("ObjectCollisionが付いてないよ!");
                        }
                    }
                    else if (moveFloor)
                    {
                        moveObj = collision.gameObject.GetComponent<MoveObject>();
                    }
                }
                else
                {
                    if (enemy)
                    {
                        ReceiveDamage(true);
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == moveFloorTag)
        {
            //動く床から離れた
            moveObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if (collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }
    #endregion
}
=====================
はい、完成しました。
ジャンプ台が跳べる高さや飛ぶ速さなどはインスペクターで調整してください。
また、敵についていたスクリプトをいじったので、敵のインスペクターも変更するのを忘れないでください。


敵を何体も置いてしまっている人は敵をプレハブ化して元を変更したら全部に変更が行き届くようにしましょう。

jumpstepはObject配下に置いた




＃５7かな？	Unity 2Dアクションの作り方【グラフィック差し替え】
Unity 2Dアクションの作り方【グラフィック差し替え】 | ゲームの作り方！

Broken text PPtr in file(Assets/UnityChan2D/Animations/UnityChan2D.controller). Local file identifier (110220483) doesn't exist!
ファイル(Assets/UnityChan2D/Animations/UnityChan2D.controller)内の壊れたテキストPPtr。ローカルファイル識別子(110220483)が存在しません!

Assets/UnityChan2D/Demo/Scripts/PointController.cs(7,12): error CS0619: 'GUIText' is obsolete: 'GUIText has been removed. Use UI.Text instead.'
Assets/UnityChan2D/Demo/Scripts/TimeController.cs(10,12): error CS0619: 'GUIText' is obsolete: 'GUIText has been removed. Use UI.Text instead.'
Assets/UnityChan2D/Demo/Scripts/PointController.cs(8,12): error CS0619: 'GUIText' is obsolete: 'GUIText has been removed. Use UI.Text instead.'
Assets/UnityChan2D/Demo/Scripts/PointController.cs(8,12): error CS0619: 'GUIText' is obsolete: 'GUITextは削除されました。代わりに UI.Text を使用してください。

API Update Required
This project contains scripts and/or assemblies that use obsolete APIs.
If you choose “Go Ahead”,Unity will automatically upgrade any scripts/assemblies in the Assets folder found using the old APIs. You should make a backup befor proceeding. (You con always run API Updater manually via the “Assets/Run API Updater” menu command.)

APIの更新が必要
このプロジェクトには、時代遅れの API を使用するスクリプトやアセンブリが含まれています。
Go Ahead "を選択した場合、古いAPIを使用しているAssetsフォルダ内のスクリプトやアセンブリは自動的にアップグレードされます。事前にバックアップを取っておく必要があります。(常に "Assets/Run API Updater "メニューコマンドを使って手動でAPI Updaterを実行してください)

まずバックアップをしたい　方法は３つ
Unityのプロジェクトをバックアップする方法 - Qiita

↑①バックアップは取れるが１Gまで無料　完璧に元の状態に戻るわけではない　あまり信用しないほうがいい

↑②古い拡張子が対応しておらずインポートが失敗したので削除した
③ローカルファイルバックアップ　/ユーザ/me-do/デスクトップ/unity/buckup/006/かえるちゃん

↑敵キャラをザコ１に置き換えたがアニメーションがハエのように小さく表示されたのでザコ１では不採用　☆で解決済み

↑ユニティちゃんをプレイヤーのアニメーションと置き換えたが、地面に潜り込む事象が発生　コライダーを微調整してちゃんと地面に接地するようになった

↑地面差し替えしたがぼやけてユニティちゃんがはなれた　ユニット毎のピクセル数を１５に変更したらきれいになった　☆おぽっさむは１０
新たにアセットを２つ追加した　動く床を雲に差し替えてコライダーを編集した　これで背景以外はとりあえず完了

unity3
ヒエラルキーGrid右クリックー２Dオブジェクトータイルマップ　名前：BackGroundTilemap
ウィンドウー２Dータイルパレット　新しいパレットを作成　名前：tree_grass　アクティブタイプ：BackGroundTilemap
4x（これならデフォルトで配置できる）　iOS用に上書き　RGB(A)4x4  木は大きくなるので離してタイルパレットへ配置する

飾りつけ用のタイルマップを作成する事ができたらステージと飾り付けの表示順番をちゃんとしてあげなくてはいけません。
Tilemap RendererのインスペクターでSorting Layerを選択して、

Add Sorting Layer…を押してください。

下の＋ボタンを押して、新しいレイヤーを追加してます。飾り付けを前に持ってきたかったらLayerを下の方に、奥に持っていきたかったら上の方にLayerを持ってきましょう。Tilemap RendererのSorting Layerを目的のものに設定すれば絵が重なってしまう部分が出てきても奥から手前に描画されてちゃんと表示されるようになります。

ソートレイヤー　　TileMap（コライダー付き） と　TileMap Back（コライダーなし）を作成し、
TileMap Backを一番上にもってくる　と一番うしろで表示されるようになる　雲のソートレイヤーもTileMapにした
これで木と草と花と石は配置できた　後は後ろの背景だ


＜背景を作ろう＞
次は背景を作っていきましょう。
背景の絵を描くのはちょっと難しいのですが、シームレステクスチャというものを描きます。
シームレステクスチャというのは繰り返し表示された時、つなぎ目に違和感が無いテクスチャです。↓のような感じです。
ステージの背景の場合はテクスチャの左側と右側が繋がるように作成します。
お絵かきソフトによってはワンクリックでシームレスにしてくれる機能を持っているソフトもあるので、自分で描く方は「お使いのソフト名　シームレス」などで検索してみるとやり方が出てくると思います、アセットストアでシームレステクスチャを探しても良いかもしれません。


2048×1536 メッシュタイプMesh Type　完全な短形Full Rect　ラップモードWrap Mode　繰り返しRepeat
　iOS用　2048 RGB(A) 4*4 テクスチャタイプ　スプライト
この背景をシーンにドラックアンドドロップするとヒエラルキーにBackgroundが出現

Backgroundのいインスペクターで　描画モードDraw Mode　タイル状Tiled　幅105.19 高さ15.36 拡大/縮小 X2 Y2 Z2　
ソートレイヤーSorting Layer　名前:BackGround　一番上にもってくる　一番うしろで表示



＃５９かな？	Unity 2Dアクションの作り方【スクショ・動画を撮ろう】
Unity Recorderの使い方【スクショ・動画を撮ろう】 | ゲームの作り方！
＜飛び道具を飛ばす敵を作ろう＞
さて、敵のバリエーションを増やすにあたって、ただ動くだけの敵ばかりだと面白くないので、飛び道具を飛ばしてくる敵を作ってみましょう。
とりあえず、ベースとなる敵の画像を描くか、アセットストアで素材を探してきましょう。
自分は↓のアセットを使わせていただきました。

↑このアセットを入れたら出たエラー一覧
Asset '': Transition 'walk -> idle' in state 'walk' doesn't have an Exit Time or any condition, transition will be ignored
アセット ''. 状態 'walk' のトランジション 'walk -> idle' が終了時間や条件を持たない場合、トランジションは無視されます。

Component at index 3 could not be loaded when loading game object 'Camera'. Removing it!
ゲームオブジェクト 'Camera' をロードする際に、インデックス 3 のコンポーネントがロードできない。削除してください。
ゲームオブジェクト 'Camera (1)' をロードする際に、インデックス 3 のコンポーネントをロードできませんでした。削除してください。
ゲームオブジェクト 'Camera' をロードする際に、インデックス 3 のコンポーネントがロードできない。削除してください。

Asset 'penguin': Transition 'walk -> idle' in state 'walk' doesn't have an Exit Time or any condition, transition will be ignored
UnityEditor.AssetPreviewUpdater:CreatePreviewForAsset(Object, Object[], String)
アセット 'ペンギン'。状態 'walk' のトランジション 'walk -> idle' が終了時間や条件を持たない場合、トランジションは無視されます。
UnityEditor.AssetPreviewUpdater:CreatePreviewForAsset(Object, Object[], String)

３Dを２Dにする方法は↓を参考にしてください。↓
＜Unity Recorderの導入の仕方＞
Unityはこれらスクリーンショットやgif、動画を制作するにあたってとても便利な機能を用意してくれています。
それがUnity Recorderです。
まずは、このUnity Recorderの機能をUnity内に入れましょう。Package Managerを開いてください。
Package ManagerからUnity Recorderを導入します。
2019/7/6現在、Unity RecorderはPreview版になっています。まだ正式版ではないのですが、十分使える上に、そもそもエディタ上でしか動作しないのでゲームに含める事ができない為、Preview版でも特に問題はないです。
Preview版を加えるにはPackage Managerの上の方にあるAdvancedをクリックし、Show preview packagesをクリックする必要があります。
通信が入る為、ちょっと待たなくてはいけませんが、しばらく待つとPreview版の機能が一覧に載ってきます。
そこにあるUnity Recorderをクリックして、右下にあるInstallを押しましょう。

Unity recorderとか標準アセットとかがno longer availableで激おこプンプン丸をどうにかする | せかいらぼ

Assertion failedアサーション失敗　パッケージマネージャーの設定☑したら起きるエラー　高度なやつ
UnityEngine.GUIUtility:ProcessEvent(Int32, IntPtr, Boolean&) (at /Users/builduser/buildslave/unity/build/Modules/IMGUI/GUIUtility.cs:189)

Working with the Unity Recorder - 2019.3 - Unity Learn

＜Unity Recorderの使い方＞
Installが完了したら上部メニューのWindow＞General＞Recorder＞Recorder WindowでUnity Recorderを開く事ができます。
すると↓のようなウィンドウが開くと思います。左側にあるAdd New Recordersをクリックしましょう。

すると↓のようなメニューが表示されます。

空のオブジェクトでカメラを作成　Cameraのタグを作成
３Dの花をシーンに持ってくる　←既に動く　カメラでイメージシーケンスを撮る　←動く分
Recorderの設定を↑のようにする　Include Alphaに☑があると背景なしになる　カメラとpngじゃないとできない
ここで、何を記録するのかを選択します。Animation Clipならアニメーションを、Movieなら動画を、Image SequenceがスクリーンショットでGIF AnimationはGIF動画で、なんとAudioで音を記録する事もできます。
凄すぎUnity！
この中で目的の機能を選択してください。
画像系の機能はカメラを使う
さて、では動画、スクリーンショット、GIFの記録方法を解説していきます。何故この３つかと言うと、画像系の記録方法はほとんど変わらない為、ひとまとめにしている感じです。
ではこれら画像系はどのように記録していくかと言うと、Unity Recorderは主にカメラを使います。（使わないパターンもあります）
初期設定の状態ではGame Viewに表示されているものを記録していく感じになります。
例えば、このホームページの看板娘の↓の画像もUnity Recorderで撮っているのですが、

これはこういう感じで撮っています。

カメラの設定をSolid Colorで背景を白色にしているので↑のような感じになります。
撮影したスクリーンショットのユニット毎のピクセル数　300

まぁ、ぶっちゃけ↑のような感じならPCの機能のスクショをとればいい話なんですが、Unity Recorderは透明でスクショを撮る事も可能なので、キャラ以外の部分を透明にしたい時などに便利です。
というわけで、動画やスクリーンショットを撮りたい場合は、カメラを撮りたい物に合わせて、ゲームビューに映るようにしましょう。

↑ゲーム▼+  512*512を作成　フラワーとカメラのXを合わせる　カメラのビューポート短形　W1　H1　カメラの視野　７６とすると正方形で撮影できる

↑撮影が済んだらカメラとフラワーの☑を外しておく
unity3d - ユニティの正射影カメラのサイズ変更

通常の状態→攻撃はattackのトリガーがオンになったら遷移します。Fixed Durationのチェックを外し、Transition Durationを０にします。
攻撃→通常の状態はHas Exit Timeにチェックをし、Exit Timeを１に、Fixed Durationのチェックを外し、Transition Durationを０にしています。
皆さんも自分で好みの形にしてみてください。自分で描いてみてもいいですし、気に入ったアセットを探してみるのもいいかもしれません。

Fixed Duration
固定間隔

Transition Duration
遷移間隔

Has Exit Time
終了時間あり

Exit Time
終了時間


＜攻撃を飛ばそう＞
次は飛ばす攻撃を作っていこうと思います。
↓自分は炎を飛ばしたかったので↓のアセットを使用させていただきました

アセットストアではエフェクトがプレハブになっている事が多いのでそれをシーンに持って来れば使えます
このオブジェクト(Fire_A)に攻撃用の設定を加えていきます。
まず、攻撃用のタグを用意して変更します。以前針を作ったときに作成したHitAreaというタグを使用しました。
次に攻撃の判定にあったコライダーを設定しましょう
自分は円形の攻撃判定を設定したかったのでCircle Collider 2Dを設定しました。
そして、Is Triggerにチェックを入れ、Radiusの数値を入れて大きさをちょうどよくします。
次にRigidbody 2Dを追加してBody TypeをKinematicに、Freeze RotationのZにチェックを入れます。

設定ができたら、敵の子オブジェクトに持ってきて非アクティブにします。はい、これでオブジェクトの準備は完了です。

＜敵のスクリプトを書こう＞
敵と飛び道具の準備ができたら新しい敵用のスクリプトを書いていきましょう。
敵２のスクリプト
Enemy_Zako2.cs     NEW
=====================
using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class Enemy_Zako2 : MonoBehaviour
 {
     [Header("攻撃オブジェクト")] public GameObject attackObj;
     [Header("攻撃間隔")] public float interval;

     private Animator anim;
     private float timer;

     // Start is called before the first frame update
     void Start()
     {
          anim = GetComponent<Animator>();
          if (anim == null || attackObj == null)
          {
              Debug.Log("設定が足りません");
              Destroy(this.gameObject);
          }
          else
          {
              attackObj.SetActive(false);
          }
     }

     // Update is called once per frame
     void Update()
     {
          AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

          //通常の状態
          if (currentState.IsName("idle"))
          {
              if(timer > interval)
              {
                  anim.SetTrigger("attack");
                  timer = 0.0f;
              }
              else
              {
                  timer += Time.deltaTime;
              }
          }
     }
 }
=====================
Parameter 'attack' does not exist.
UnityEngine.Animator:SetTrigger(String)
Enemy_Zako2:Update() (at Assets/Script/Enemy_Zako2.cs:38)

↑敵にこのようなコンポーネントをセットします。
Object Collisionは以前に作成したスクリプトです。
新たに作ったスクリプトは一定間隔でアニメーションを行うスクリプトになっています。
通常の状態になった時に時間をカウントして一定間隔たったらまた攻撃アニメーションに入るようにします。
さて、このままではアニメーションをループさせるだけなので、攻撃を発生させる処理を追加していきます。

＜アニメーションからスクリプトを呼ぼう＞
さて、攻撃を発生させる処理を追加したいのですが、単にスクリプトから呼ぶとアニメーションと合わない事が多いです。
そのため、今回はアニメーションに合わせて攻撃判定を発生させてみましょう。
まず、敵のスクリプトに↓のようなメソッドを追加します。
=====================
public void Attack()
{
　　　Debug.Log("攻撃");
}
=====================

次にヒエラルキーで敵を選択した状態でアニメーションウィンドウを開きます。
そして、攻撃をするタイミングのフレームを選択します。


そして、アニメーション名の右側にあるボタンの一番右のボタンを押します。
そうすると↓のようなものが追加されます。

もし、これを消したかったら選択した状態で右クリックでDeleteする事ができます。
この、追加されたものを選択している状態でインスペクターを見て下さい。

するとFunctionという項目があるので、ここをクリックすると先ほど敵に追加したメソッドが出てきます。
ここに出てくるのは、選択しているアニメーターと同じゲームオブジェクトについているスクリプトのメソッドになります。
これで、アニメーションからメソッドを呼ぶ事ができるので、アニメーションに合わせて攻撃判定を発生させる事ができそうです。

アニメーションに合わせてメソッドの呼び出すところまでできました。

＜攻撃判定を発生させよう＞
さて、いよいよ攻撃判定を発生させましょう。
Attackを↓のように書き換えます。

Enemy_Zako2.cs
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako2 : MonoBehaviour
{
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("攻撃間隔")] public float interval;

    private Animator anim;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null || attackObj == null)
        {
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        else
        {
            attackObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

        //通常の状態
        if (currentState.IsName("idle"))
        {
            if (timer > interval)
            {
                anim.SetTrigger("attack");
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    public void Attack()
    {
        GameObject g = Instantiate(attackObj);
        g.transform.SetParent(transform);
        g.transform.position = attackObj.transform.position;
        g.SetActive(true);
    }
}
=====================

Instantiateというのはインスタンスを作成するメソッドです。これはMonoBehaviourを継承しているから使用できる命令です。
最初の方で作成した飛び道具のゲームオブジェクトのインスタンス（実体）を作成するので、作成した飛び道具を元にして新たにゲームオブジェクトを作成します。
SetParentというのはスクリプトから親オブジェクトを変更する命令です。実体化したばかりのゲームオブジェクトは親を持たないので、自分自身を指定します。transformというのは自分自身のTransformです。
何故親子関係にするのかというと、この敵がどの方向を向いているのかわからないからです。
上向きかもしれないですし、横向きかもしれません。
しかし、子オブジェクトにすることによって、親の方向に合わせる事が可能になります。
また、Instantiateは元のゲームオブジェクトの情報をそのまま持ってくるので非アクティブになっています。そのため、元のオブジェクトは非アクティブなまま、新しく作成されたオブジェクトはアクティブにします。
次に発生した攻撃を移動させます。

飛び道具に貼り付けるスクリプト

EnemyAttack.cs      NEW
=====================
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 public class EnemyAttack : MonoBehaviour
 {
     [Header("スピード")] public float speed = 3.0f;
     [Header("最大移動距離")] public float maxDistance = 100.0f;

     private Rigidbody2D rb;
     private Vector3 defaultPos;

     // Start is called before the first frame update
     void Start()
     {
          rb = GetComponent<Rigidbody2D>();
          if(rb == null)
          {
              Debug.Log("設定が足りません");
              Destroy(this.gameObject);
          }
          defaultPos = transform.position;
     }

     // Update is called once per frame
     void FixedUpdate()
     {
          float d = Vector3.Distance(transform.position, defaultPos);

          //最大移動距離を超えている
          if (d > maxDistance)
          {
              Destroy(this.gameObject);
          }
          else
          {
              rb.MovePosition(transform.position += Vector3.up * Time.deltaTime * speed);
          }
     }

     private void OnTriggerEnter2D(Collider2D collision)
     {
          Destroy(this.gameObject);
     }
 }
=====================
ただ一定方向に進んでいくスクリプトで、何かにぶつかったら破棄されるようになっています。
ポイントとしては最大移動距離を設定する事です。
Vector3.Distanceというのは２つの位置の距離を算出してくれる便利なメソッドです。

敵から攻撃が一定間隔で出てくるので、何かにぶつからなければ無限に存在する事ができます。そうするとメモリを圧迫してしまうので、最大移動距離を設定して、それ以上移動したら消えるようにします。
Instantiateは新たに生成するものなので、作り続けてしまうと処理落ち、アプリ落ちの原因になるので使わないものはキッチリ破棄しましょう。
そして、何かにぶつかってしまうと破棄してしまうので、最初に生成される位置は敵自体のコライダーとぶつからないようにしましょう。

↑発射する元々のゲームオブジェクトの位置を離してあげると大丈夫です。


エフェクトが３つあるのでぶつかって一瞬でエフェクトが消えてしまうので
何かにぶつかってしまうと破棄する処理↓EnemyAttack.csの最後の記述を削除した　
private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

ちゃんとプレイヤーにも当たってますね。
もうそろそろステージをちゃんとした形で完成させる事ができそうです。というわけで次回はいよいよゲームを形作っていきましょう。 ←2020/10/21現在　ここまで　工事中　ページなし　先生不在　とりあえずマグロを飛ばしてみたい

マグロ完成したがバックアップでエラーが起きる
[Collab] CreateRevisionValidator::MissingFileError. 以下のハッシュがアップロードされたファイルとして見つかりませんでした。["e9db23f0a761b28a6c7d251fb03db65b"]. collabsupport@unity3d.com までご連絡ください。

無料イラスト マグロ　透過PNG
↑マグロを拝借して水からマグロを飛ばした　水を３つ付けた　アニメーションさせた　水の位置をデフォルトにし
物理的に少し前にもってきた　プレイヤーがちゃんと水に潜る形になる

stage1がとりあえず完成した


↑いじってるとソートレイヤーが消える

DontDestroyOnLoad only works for root GameObjects or components on root GameObjects.
UnityEngine.Object:DontDestroyOnLoad(Object)
GManager:Awake() (at Assets/Script/GManager.cs:24)
DontDestroyOnLoadはルートGameObjectまたはルートGameObject上のコンポーネントに対してのみ動作します。
UnityEngine.Object:DontDestroyOnLoad(Object)
GManager:Awake() (at Assets/Script/GManager.cs:24)
[Unity] 親要素を持つGameObjectをDontDestroyOnLoadさせる | Mono-Materials
ゲームマネージャーはルート配下に置かないとエラーになる

ゲームマネージャー以外をプレハブにしていっきにもってこないと設定がおかしくなる

コンテニューがおかしい　ステージ２

↑ステージ２はゲームマネージャーも２にする　コンテニューポイントも新しくする
Unable to find requested revision
UnityEngine.Debug:LogError(Object)
Unity.Cloud.Collaborate.Presenters.HistoryPresenter:OnSelectedRevisionReceived(IHistoryEntry) (at Library/PackageCache/com.unity.collab-proxy@1.3.9/Editor/Presenters/HistoryPresenter.cs:152)
Unity.Cloud.Collaborate.Models.HistoryModel:OnReceivedHistoryEntry(IHistoryEntry) (at Library/PackageCache/com.unity.collab-proxy@1.3.9/Editor/Models/HistoryModel.cs:108)
Unity.Cloud.Collaborate.Models.Providers.<>c__DisplayClass70_0:<RequestHistoryEntry>g__OnFetchRevisionCallback|0(Nullable`1) (at Library/PackageCache/com.unity.collab-proxy@1.3.9/Editor/Models/Providers/Collab.cs:519)
UnityEditor.Collaboration.RevisionsService:onFetchSingleRevision(IntPtr) (at /Users/builduser/buildslave/unity/build/Editor/Mono/Collab/RevisionsService.cs:75)
↑一晩あけて再生したら出たエラー
要求されたリビジョンが見つかりません


stage2をとりあえず作ったのでiosビルドに挑戦する
UnityでiPhoneアプリ（iOS）向けにビルドする方法【初心者向け】 | TechAcademyマガジン

カーソルに使用されているテクスチャが無効です - インポーターの設定またはテクスチャの作成を確認してください。テクスチャはRGBA32で、読み取り可能で、alphaIsTransparencyが有効になっていて、mipチェーンがないものでなければなりません。
UnityEngine.GUIUtility:ProcessEvent(Int32, IntPtr, Boolean&)

/ユーザ/me-do/デスクトップ/unity/006/006/ios_build
成功」の結果で完成したビルド
UnityEngine.GUIUtility:ProcessEvent(Int32, IntPtr, Boolean&) (/Users/builduser/buildslave/unity/build/Modules/IMGUI/GUIUtility.cs:189) (at /Users/builduser/buildslave/unity/build/Modules/IMGUI/GUIUtility.cs)

xcodeのエラー
Code Signing Error: "Unity-iPhone" requires a provisioning profile. Select a provisioning profile in the Signing & Capabilities editor.
コード署名エラーです。"Unity-iPhone "にはプロビジョニングプロファイルが必要です。Signing & Capabilities]エディタでプロビジョニングプロファイルを選択します。

Code signing is required for product type 'Application' in SDK 'iOS 14.0'
SDK 'iOS 14.0'のプロダクトタイプ'Application'にコード署名が必要です。

UnityでiOSビルドするとエラーが出る - おもちゃラボ

XCODEからiPhoneにアプリが送れなくなった - Qiita
iフォンアプリ送れない　←送れた　音出た
ipad遅れたがエラー↓
Could not launch “006”
操作を完了できませんでした。com.DefaultCompany.006 を起動できません。コード署名が無効であるか、エンタイトルメントが不適切であるか、またはそのプロファイルがユーザーによって明示的に信頼されていないので、起動できません。

インターネットに接続して　一般　デバイス管理　デベロッパAPP　信頼する　検証済み　
としたらゲームが起動された　が　ばぐだらけ

ボタンを配置しないと何もできない
Unityのゲームにスマホ向けなバーチャルパッドを追加する - テラシュールブログ
↑古い
【Unity】新しいインプットシステムで、バーチャルパッドに対応させる - テラシュールブログ
↑一年前の記事

ボタンの名前　バーチャルパッド　バーチャルキーボード

Unity超簡単！バーチャルパッドの実装方法 - YouTube
Standard Assets (for Unity 2018.4)
An error occurred (Unable to get purchase details because you may not have purchased this package.) See console for more details
エラーが発生しました（このパッケージを購入していない可能性があるため、購入の詳細を取得できません 詳細についてはコンソールを参照してください。


xcode エラー
Enable Base Internationalization
ベースの国際化を有効にする
Enabling Base Internationalization is recommended for all projects.
ベースの国際化を有効にすることは、すべてのプロジェクトで推奨されています。
Enable
有効化

Localization
Migrate “Japanese.lproj” (Deprecated)
Japanese.lproj "の移行 (非推奨)
Migrating the “Japanese, deprecated” localization to “Japanese” is recommended for all projects. This will ensure localized resources are placed in “ja.lproj” directories instead of deprecated “Japanese.lproj” directories.
すべてのプロジェクトで、"Japanese, deprecated" ローカライズを "Japanese" に移行することをお勧めします。これにより、ローカライズされたリソースが非推奨の "Japanese.lproj" ディレクトリではなく "ja.lproj" ディレクトリに置かれるようになります。
Migrate
移行

Migrate “English.lproj” (Deprecated)
English.lproj "の移行 (非推奨)
Migrating the “English, deprecated” localization to “English” is recommended for all projects. This will ensure localized resources are placed in “en.lproj” directories instead of deprecated “English.lproj” directories.
すべてのプロジェクトで、"English, deprecated" ローカライゼーションを "English" に移行することをお勧めします。これにより、ローカライズされたリソースが非推奨の "English.lproj" ディレクトリではなく "en.lproj" ディレクトリに置かれるようになります。

Migrate “French.lproj” (Deprecated)
French.lproj "の移行 (非推奨)
Migrating the “French, deprecated” localization to “French” is recommended for all projects. This will ensure localized resources are placed in “fr.lproj” directories instead of deprecated “French.lproj” directories.
French, deprecated" ローカライズを "French" に移行することをすべてのプロジェクトで推奨します。これにより、ローカライズされたリソースが非推奨の "French.lproj" ディレクトリではなく "fr.lproj" ディレクトリに置かれるようになります。

Migrate “German.lproj” (Deprecated)
German.lproj "の移行 (非推奨)
Migrating the “German, deprecated” localization to “German” is recommended for all projects. This will ensure localized resources are placed in “de.lproj” directories instead of deprecated “German.lproj” directories.
すべてのプロジェクトで、"Deutschland, deprecated" ローカライゼーションを "German" に移行することをお勧めします。これにより、ローカライズされたリソースが非推奨の "German.lproj" ディレクトリではなく "de.lproj" ディレクトリに置かれるようになります。

Could not launch “006”
006を起動できませんでした
The operation couldn’t be completed. Unable to launch com.DefaultCompany.006 because it has an invalid code signature, inadequate entitlements or its profile has not been explicitly trusted by the user.
操作を完了できませんでした。com.DefaultCompany.006 を起動できません。コード署名が無効であるか、エンタイトルメントが不適切であるか、またはそのプロファイルがユーザーによって明示的に信頼されていないので、起動できません。

Details

Could not launch “006”
Domain: IDEDebugSessionErrorDomain
Code: 3
Failure Reason: The operation couldn’t be completed. Unable to launch com.DefaultCompany.006 because it has an invalid code signature, inadequate entitlements or its profile has not been explicitly trusted by the user.
User Info: {
    DVTRadarComponentKey = 855031;
    RawLLDBErrorMessage = "The operation couldn\U2019t be completed. Unable to launch com.DefaultCompany.006 because it has an invalid code signature, inadequate entitlements or its profile has not been explicitly trusted by the user.";
}
--


System Information

macOS Version 10.15.7 (Build 19H2)
Xcode 12.0.1 (17220)
詳細

"006 "を起動できませんでした
ドメインを指定します。IDEDebugSessionErrorDomain
コードは？3
失敗理由 操作を完了できませんでした。com.DefaultCompany.006 が無効なコード署名を持っているか、不十分なエンタイトルメントを持っているか、またはそのプロファイルがユーザーによって明示的に信頼されていないため、起動できません。
ユーザー情報: {
    DVTRadarComponentKey = 855031.
    RawLLDBErrorMessage = "The operation couldnU2019t be completed. Unable to launch com.DefaultCompany.006 because it has an invalid code signature, inquade entitlements or its profile has not been explicitly trusted by user.".
}
--


システム情報

macOSバージョン10.15.7 (ビルド19H2)
Xcode 12.0.1 (17220)


音ならない　操作できないけど　iPhoneにアプリ００６を入れることができたが
警告が２０個くらいから9750個に増える

プロジェクト「Unity-iPhone」を閉じても大丈夫ですか？
このワークスペースを閉じると、「"Unity-iPhoneの実行 "タスク」が停止します。

↑モバイルシングルスティックコントロールをキャンバス配下に配置してキャンバスのレンダーモードをワールド空間
イベントカメラ　カメラ　ソートレイヤー　UIにするとゲーム画面に表示される

プレイヤーをバーチャルスティックで動かす為のスクリプトを作成
PlayerMovement.cs

Y 　上下
X　左右

Horizontal X
Vertical　Y

=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE;
    [Header("やられた鳴らすSE")] public AudioClip downSE;
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;
    #endregion


    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private MoveObject moveObj = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private bool isRun = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private bool isClearMotion = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float otherJumpSpeed = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string hitAreaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    private string jumpStepTag = "JumpStep";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }
            //1秒たったら明滅終わり
            if (continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
    }



    void FixedUpdate()
    {

        if (!isDown && !GManager.instance.isGameOver && !GManager.instance.isStageClear)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            Vector2 addVelocity = Vector2.zero;
            if (moveObj != null)
            {
                addVelocity = moveObj.GetVelocity();
            }
            rb.velocity = new Vector2(xSpeed, ySpeed) + addVelocity;
        }
        else
        {
            if (!isClearMotion && GManager.instance.isStageClear)
            {
                anim.Play("player_win");
                isClearMotion = true;
            }
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //何かを踏んだ際のジャンプ
        if (isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = otherJumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (verticalKey > 0)
            {
                if (!isJump)
                {
                    GManager.instance.PlaySE(jumpSE);
                }
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }


    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary>
    /// コンティニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        if (GManager.instance.isGameOver)
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;
        }
    }

    //ダウンアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if (isDown && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// コンティニューする
    /// </summary>
    public void ContinuePlayer()
    {
        GManager.instance.PlaySE(continueSE);
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;
    }

    //やられた時の処理
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown || GManager.instance.isStageClear)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.PlaySE(downSE);
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemy = (collision.collider.tag == enemyTag);
        bool moveFloor = (collision.collider.tag == moveFloorTag);
        bool fallFloor = (collision.collider.tag == fallFloorTag);
        bool jumpStep = (collision.collider.tag == jumpStepTag);

        if (enemy || moveFloor || fallFloor || jumpStep)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    if (enemy || fallFloor || jumpStep)
                    {
                        ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                        if (o != null)
                        {
                            if (enemy || jumpStep)
                            {
                                otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                                otherJumpSpeed = o.jumpSpeed; //ジャンプするスピード
                                o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                                jumpPos = transform.position.y; //ジャンプした位置を記録する
                                isOtherJump = true;
                                isJump = false;
                                jumpTime = 0.0f;
                            }
                            else if (fallFloor)
                            {
                                o.playerStepOn = true;
                            }
                        }
                        else
                        {
                            Debug.Log("ObjectCollisionが付いてないよ!");
                        }
                    }
                    else if (moveFloor)
                    {
                        moveObj = collision.gameObject.GetComponent<MoveObject>();
                    }
                }
                else
                {
                    if (enemy)
                    {
                        ReceiveDamage(true);
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == moveFloorTag)
        {
            //動く床から離れた
            moveObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if (collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }
    #endregion
}
=====================
using UnityStandardAssets.CrossPlatformInput;を追記
 InputをCrossPlatformInputManagerに変更

=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        Move(x, y);
        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }
    }
    void Move(float _x, float _y)
    {
        transform.position += new Vector3(_x, 0, _y);
    }

}
=====================

xcode ビルド　警告
Build folder already exists. Would you like to append or replace it?
Append
Enable replace 
Replace 
ビルドフォルダが既に存在します。追加または置換しますか？
追加
置換を有効にする 
置き換え 


↑まとこれの☑が外れていた　警告が１６になった　マジックキーボードを最初だけ触れる
そして消える　unityと同じであった　iPhoneでのテスト

Unity5版Standard Assetsを使って仮想ジョイスティックを実装 - Qiita

=====================
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
		public enum AxisOption
		{
			// Options for which axes to use
			Both, // Use both
			OnlyHorizontal, // Only horizontal
			OnlyVertical // Only vertical
		}

		public int MovementRange = 100;
		public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
		public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
		public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input

		Vector3 m_StartPos;
		bool m_UseX; // Toggle for using the x axis
		bool m_UseY; // Toggle for using the Y axis
		CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
		CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input

		void OnEnable()
		{
			CreateVirtualAxes();
		}

		void Start()
        {
			
			m_StartPos = transform.position;
        }

		void UpdateVirtualAxes(Vector3 value)
		{
			var delta = m_StartPos - value;
			delta.y = -delta.y;
			delta /= MovementRange;
			if (m_UseX)
			{
				m_HorizontalVirtualAxis.Update(-delta.x);
			}

			if (m_UseY)
			{
				m_VerticalVirtualAxis.Update(delta.y);
			}
		}

		void CreateVirtualAxes()
		{
			// set axes to use
			m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
			m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

			// create new axes based on axes to use
			if (m_UseX)
			{
				m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
			}
		}


		public void OnDrag(PointerEventData data)
		{
			Vector3 newPos = Vector3.zero;

			if (m_UseX)
			{
				int delta = (int)(data.position.x - m_StartPos.x);
				delta = Mathf.Clamp(delta, - MovementRange, MovementRange);
				newPos.x = delta;
			}

			if (m_UseY)
			{
				int delta = (int)(data.position.y - m_StartPos.y);
				delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
				newPos.y = delta;
			}
			transform.position = new Vector3(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z);
			UpdateVirtualAxes(transform.position);
		}


		public void OnPointerUp(PointerEventData data)
		{
			transform.position = m_StartPos;
			UpdateVirtualAxes(m_StartPos);
		}


		public void OnPointerDown(PointerEventData data) { }

		void OnDisable()
		{
			// remove the joysticks from the cross platform input
			if (m_UseX)
			{
				m_HorizontalVirtualAxis.Remove();
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis.Remove();
			}
		}
	}
}
=====================



UnityでJoystick（ジョイスティック）を追加する方法【初心者向け】 | TechAcademyマガジン
C# - UnityでJoystickを使用したキャラ移動を実現したい｜teratail
VS Codeでファイルを比較し、差分（diff）を表示するには：Visual Studio Code TIPS - ＠IT
VSC　上　表示　コマンドパレット


↑MobileJoystick　マウス操作すると操作した位置が動いてしまう　これをうごかないようにするか違うアセットにする
ジョイスティックパックがフリーであるのでそちらにしてみる
【UNITY】3Dオブジェクトをフリックやマウス操作で移動させる方法 | KKLOG
An error occurred (Unable to purchase details because you may not hobe purchased this package) see console for more details
エラーが発生しました（このパッケージを購入していない可能性があるため、詳細を購入することができません）詳細についてはコンソールを参照してください。

=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE;
    [Header("やられた鳴らすSE")] public AudioClip downSE;
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;
    #endregion


    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private MoveObject moveObj = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private bool isRun = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private bool isClearMotion = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float otherJumpSpeed = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string hitAreaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    private string jumpStepTag = "JumpStep";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }
            //1秒たったら明滅終わり
            if (continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
    }



    void FixedUpdate()
    {

        if (!isDown && !GManager.instance.isGameOver && !GManager.instance.isStageClear)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            Vector2 addVelocity = Vector2.zero;
            if (moveObj != null)
            {
                addVelocity = moveObj.GetVelocity();
            }
            rb.velocity = new Vector2(xSpeed, ySpeed) + addVelocity;
        }
        else
        {
            if (!isClearMotion && GManager.instance.isStageClear)
            {
                anim.Play("player_win");
                isClearMotion = true;
            }
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //何かを踏んだ際のジャンプ
        if (isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = otherJumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (verticalKey > 0)
            {
                if (!isJump)
                {
                    GManager.instance.PlaySE(jumpSE);
                }
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }


    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary>
    /// コンティニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        if (GManager.instance.isGameOver)
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;
        }
    }

    //ダウンアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if (isDown && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// コンティニューする
    /// </summary>
    public void ContinuePlayer()
    {
        GManager.instance.PlaySE(continueSE);
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;
    }

    //やられた時の処理
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown || GManager.instance.isStageClear)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.PlaySE(downSE);
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemy = (collision.collider.tag == enemyTag);
        bool moveFloor = (collision.collider.tag == moveFloorTag);
        bool fallFloor = (collision.collider.tag == fallFloorTag);
        bool jumpStep = (collision.collider.tag == jumpStepTag);

        if (enemy || moveFloor || fallFloor || jumpStep)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    if (enemy || fallFloor || jumpStep)
                    {
                        ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                        if (o != null)
                        {
                            if (enemy || jumpStep)
                            {
                                otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                                otherJumpSpeed = o.jumpSpeed; //ジャンプするスピード
                                o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                                jumpPos = transform.position.y; //ジャンプした位置を記録する
                                isOtherJump = true;
                                isJump = false;
                                jumpTime = 0.0f;
                            }
                            else if (fallFloor)
                            {
                                o.playerStepOn = true;
                            }
                        }
                        else
                        {
                            Debug.Log("ObjectCollisionが付いてないよ!");
                        }
                    }
                    else if (moveFloor)
                    {
                        moveObj = collision.gameObject.GetComponent<MoveObject>();
                    }
                }
                else
                {
                    if (enemy)
                    {
                        ReceiveDamage(true);
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == moveFloorTag)
        {
            //動く床から離れた
            moveObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if (collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }
    #endregion
}
=====================
↑プレイヤースクリプトを修正するのでバックアップ

  
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20.0f;
    public FloatingJoystick joystick;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var power = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        rb.AddForce(power * speed);
    }
}
=====================

なんか反応するがプレイヤーはうごかない　なーし


void Start()
		{
			CreateVirtualAxes();
		}
【Unity8】ジョイスティック(バーチャルパッド)でモバイル対応！Sample Asset【横スクロールユニティちゃん14】 - Unity(C#)初心者・入門者向けチュートリアル ひよこのたまご
↑これ解決しない

 やはり新しいやつにする
Unityのバーチャルパッドの追加｜npaka｜note

じゃyンプしかしていない

両方にしたらジャンプが優先されてジャンプしかしない
オンリー　ホリゾンタルにしたら移動だけする

2. ジョイスティックの種類
「JOYSTICK PACK」には、次の4種類のジョイスティックが用意されています。今回は、「Fixed Joystick」を使います。
・Fixed Joystick : 固定位置にとどまるジョイスティック。 ・Floating Joystick : ユーザーがタッチした場所から始まり、タッチが解除されるまで固定されたままになるジョイスティック。 ・Dynamic Joystick : ユーザーがタッチしたところから始まり、画面の周りをタッチして移動するジョイスティック。 ・Variable Joystick : これら3つのモードを切り替えることができるジョイスティック。
移動は固定にする

Graphic Raycaster
 

↑ジョイスティックなーし　普通のボタンにする



↑Player （ぱんちゃん）カプセルコライダー２DとGroundCheckのコライダーのサイズ

↑HeadCheckのサイズ

↑Enemy1のコライダーのサイズ


↓シェーダチャンネル Normal と Tangent は、ライティングで最もよく使用されます。これらのチャンネルは必要ないと思われます。

スタンダードアセッツの↑だけインポートする　ボタンのみで左右　上下にぱんちゃんを動かす　バーチャルステックは使わない


 float verticalKey = Input.GetAxis("Vertical");
 float horizontalKey = Input.GetAxis("Horizontal");


using UnityStandardAssets.CrossPlatformInput;
CrossPlatformInputManager.GetAxis("Vertical");
CrossPlatformInputManager.GetAxis("Horizontal");

On Screen Button
【Unity】CrossPlatformInputを使う その2 CarTiltControls編 - うら干物書き
ジャンプボタン３つで　ジャンプ　右左　を実装できた

JumpButton	Vertical
LeftButton	Horizontal -1
RightButton	Horizontal   1

Mobile Inputを無効にするとPCキーボードで操作可能　有効にするとマウス　iPhoneは操作可能となる
ゲーム中にステージ１からステージ２に行き　ステージ２のコンテニューポイントを通過していないのに　やられると
ステージ２のコンテニューポイントから始まるので　ステージ２にコンテニューポイント０を追加し　コライダーも接地　スクリプトの設定を０で音は無しとした
うまくいった　ステージ２の最初でやられるとステージ２のスタートポイントから始まるようになった　29/10/2020

やりたいこと
スコア１０００ポイントで１UPしたい　→ログイン　ハイスコアにするか
チュートリアル (Unity) : ログイン機能を作る | ニフクラ mobile backend
ぱんちゃんからサッカーボールを飛ばしたい

ハートを何かで増やしたい
HeartItem.cs NEW
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    [Header("加算するハート")] public int myHeart;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;
    [Header("アイテム取得時に鳴らすSE")] public AudioClip itemSE;

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが判定内に入ったら
        if (playerCheck.isOn)
        {
            if (GManager.instance != null)
            {
                GManager.instance.heartNum += myHeart;
                GManager.instance.PlaySE(itemSE);
                Destroy(this.gameObject);
            }
        }
    }
}
=====================
ScoreItem.csを流用して作成した

↓スコアを意味のあるものにしたい　ハイスコア
UnityでiOSのGameCenterを利用するためのサンプルコード - Qiita

チュートリアル (Unity) : ログイン機能を作る | ニフクラ mobile backend
【Unity】ランキング機能を自作してみたお話 | ゴマちゃんフロンティア
【Unity、WebGL】なるべく簡単にオンラインランキング機能をつけるサンプル - naichi's lab

スコアとハイスコアの表示をする - i-school
【Unity入門】スコアを保存!コピペで終わるPlayerPrefsの実装方法 | 侍エンジニア塾ブログ（Samurai Blog） - プログラミング入門者向けサイト
↑これでスコアの横にハイスコアを表示させてみる

=====================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText = null;
    private int oldScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        if(GManager.instance != null)
        {
            scoreText.text = "Score " + GManager.instance.score;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(oldScore != GManager.instance.score)
        {
            scoreText.text = "Score " + GManager.instance.score;
            oldScore = GManager.instance.score;
        }
    }
}
=====================
バックアップ↑

private int oldScore = 0;


// 初期化時の処理
void Start ()
{
    // スコアのロード
    oldScore = PlayerPrefs.GetInt ("SCORE", 0);
}
// 削除時の処理
void OnDestroy(){
    // スコアを保存
    PlayerPrefs.SetInt ("SCORE", oldScore);
    PlayerPrefs.Save ();
}


[Unity] ハイスコアの実装 & アプリを終了しても記録を残す方法 - Qiita
↑これでハイスコアを付けられた

=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText = null;
    private int oldScore = 0;
    public Text highScoreText; //ハイスコアを表示するText
    private int highScore; //ハイスコア用変数
    private string key = "HIGH SCORE"; //ハイスコアの保存先キー

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(key, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = "HighScore " + highScore.ToString();
        //ハイスコアを表示

        scoreText = GetComponent<Text>();
        if(GManager.instance != null)
        {
            scoreText.text = "Score " + GManager.instance.score;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ハイスコアより現在スコアが高い時
        if (oldScore > highScore)
        {

            highScore = oldScore;
            //ハイスコア更新

            PlayerPrefs.SetInt(key, highScore);
            //ハイスコアを保存

            highScoreText.text = "HighScore " + highScore.ToString();
            //ハイスコアを表示
        }

        if (oldScore != GManager.instance.score)
        {
            scoreText.text = "Score " + GManager.instance.score;
            oldScore = GManager.instance.score;
        }
    }
}
=====================

4.ハイスコアを削除する方法
このままではハイスコアをリセットすることができないので、PlayerPrefs内に保存されているハイスコアをリセットしたい時に、次のコードを書けばリセットすることができます。
PlayerPrefs.DeleteAll();

これをvoid startに書いて、一度再生すると、ハイスコアがリセットされます。
以上、unityでハイスコアを実装する方法でした。

カラーコード表
白　FFFFFF

↑ハイスコアを入れ　ステージ　ハイスコア　スコアのフォントサイズと色を修正した
unity4へ続く

unity4

↑[Unity] ハイスコアの実装 & アプリを終了しても記録を残す方法 - Qiita
スコアスクリプトを追記し、ハイスコアテキストを追加してハイスコアを表示させた　フォントサイズは９０から６０に変更した　色は白に統一した　FFFFFF
31/10/2020 stage1と2のプレハブも置いた

今度はiPhoneにはアプリが入ったがiPadに入らない

直らないので放置
花がやられるようにしたい

=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako2 : MonoBehaviour
{
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("攻撃間隔")] public float interval;

    private Animator anim;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null || attackObj == null)
        {
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        else
        {
            attackObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

        //通常の状態
        if (currentState.IsName("idle"))
        {
            if (timer > interval)
            {
                anim.SetTrigger("attack");
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    public void Attack()
    {
        GameObject g = Instantiate(attackObj);
        g.transform.SetParent(transform);
        g.transform.position = attackObj.transform.position;
        g.SetActive(true);
    }
}
=====================

NullReferenceException: Object reference not set to an instance of an object
UnityEditor.Graphs.Edge.WakeUp () (at /Users/builduser/buildslave/unity/build/Editor/Graphs/UnityEditor.Graphs/Edge.cs:114)
UnityEditor.Graphs.Graph.DoWakeUpEdges (System.Collections.Generic.List`1[T] inEdges, System.Collections.Generic.List`1[T] ok, System.Collections.Generic.List`1[T] error, System.Boolean inEdgesUsedToBeValid) (at /Users/builduser/buildslave/unity/build/Editor/Graphs/UnityEditor.Graphs/Graph.cs:387)
UnityEditor.Graphs.Graph.WakeUpEdges (System.Boolean clearSlotEdges) (at /Users/builduser/buildslave/unity/build/Editor/Graphs/UnityEditor.Graphs/Graph.cs:286)
UnityEditor.Graphs.Graph.WakeUp (System.Boolean force) (at /Users/builduser/buildslave/unity/build/Editor/Graphs/UnityEditor.Graphs/Graph.cs:272)
UnityEditor.Graphs.Graph.WakeUp () (at /Users/builduser/buildslave/unity/build/Editor/Graphs/UnityEditor.Graphs/Graph.cs:250)
UnityEditor.Graphs.Graph.OnEnable () (at /Users/builduser/buildslave/unity/build/Editor/Graphs/UnityEditor.Graphs/Graph.cs:245)

NullReferenceException。オブジェクト参照がオブジェクトのインスタンスに設定されていない
↑unityを再起動したら出なくなった…


=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako2 : MonoBehaviour
{
    [Header("加算スコア")] public int myScore;
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("攻撃間隔")] public float interval;
    [Header("重力")] public float gravity;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;

    private Rigidbody2D rb;
    private Animator anim;
    private float timer;
    private ObjectCollision oc;					//②橋渡をするスクリプト
    private BoxCollider2D col;						//③２Dコライダーの変数
    private bool isDead = false;						//④


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();			//⑥
        col = GetComponent<BoxCollider2D>();			//⑦
        if (anim == null || attackObj == null)
        {
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        else
        {
            attackObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!oc.playerStepOn)                           //⑧橋渡しするスクリプトからプレイヤーに踏まれたかどうか
        {

            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

            //通常の状態
            if (currentState.IsName("idle"))
            {
                if (timer > interval)
                {
                    anim.SetTrigger("attack");
                    timer = 0.0f;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        else											//⑨踏まれた時の処理
        {
            if (!isDead)									//フラグを一回しか通らないように
            {
                anim.Play("idle");							//敵は踏まれた時　下に落ちていく形にして当たり判定を消す
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                GManager.instance.score += myScore;
                Destroy(gameObject, 1f);				//3秒ではなく１秒後に消す　やられても火が飛び散るので
            }
            else									//やられる際の処理が終わったら
            {
                transform.Rotate(new Vector3(0, 0, 5));		//①ゲームオブジェクトを３秒間くるくる回転させるメソッド
            }
        }
    }

    public void Attack()
    {
        GameObject g = Instantiate(attackObj);
        g.transform.SetParent(transform);
        g.transform.position = attackObj.transform.position;
        g.SetActive(true);
    }
}
=====================
↑エネミー２のスクリプトを追記した

↑タグをエネミーにしているよ　　位置Zは３０くらいじゃないと消える　加算スコアは３０にした
リジッドボディはXYに☑　トリガーのボックスコライダーはトリガーにする☑　前と同じね

↑エネミー２（左）とトリガー（右）のボックスコライダー２D


9話 -1up機能を作ってみる-　超初心者でもアプリは作れるのか？Unityで作る非プログラマーのアプリ入門開発記!! : PolymorphicAds Official Blog
↑いまさら出てきた　１００コイン１UP

UnassignedReferenceException。FadeActiveUGUI の変数 cg が割り当てられていません。
おそらくインスペクタでFadeActiveUGUIスクリプトの変数cgを代入する必要があると思われます。
FadeActiveUGUI.Update () (at Assets/Script/FadeActiveUGUI.cs:55)

UnassignedReferenceException。FadeActiveUGUI の変数 cg が割り当てられていません。
おそらくインスペクタでFadeActiveUGUIスクリプトの変数cgを代入する必要があると思われます。
FadeActiveUGUI.Start () (at Assets/Script/FadeActiveUGUI.cs:26)
↑unity再起動したら出なくなった

やること　ハートをとったら１UPと表示させたい

FadeActiveUGUI_1UP.cs   NEW
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeActiveUGUI_1UP : MonoBehaviour
{
    [Header("フェードスピード")] public float speed = 1.0f;
    [Header("上昇量")] public float moveDis = 10.0f;
    [Header("上昇時間")] public float moveTime = 1.0f;
    [Header("キャンバスグループ")] public CanvasGroup cg;
    [Header("プレイヤー判定")] public PlayerTriggerCheck trigger;
    [Header("1UPオブジェクト")] public GameObject UPObj;

    private Vector3 defaltPos;
    private float timer = 0.0f;

    private void Start()
    {
        //初期化
        if (cg == null && trigger == null)
        {
            Debug.Log("インスペクターの設定が足りません");
            Destroy(this);
        }
        else
        {
            cg.alpha = 0.0f;
            defaltPos = cg.transform.position;
            cg.transform.position = defaltPos - Vector3.up * moveDis;
        }
    }

    private void Update()
    {
        //プレイヤーが範囲内に入った
        if (trigger.isOn)
        {
            //上昇しながらフェードインする
            if (cg.transform.position.y < defaltPos.y || cg.alpha < 1.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position += Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer += speed * Time.deltaTime;
            }
            //フェードイン完了
            else
            {
                cg.alpha = 1.0f;
                cg.transform.position = defaltPos;
                Destroy(gameObject, 1f);
            }
        }
    }
}
=====================
↑FadeActiveUGUIスクリプトを流用し　一番下に記載してあったフェードアウトを削除　オブジェクト削除を追記した

メッセージを表示させてるやつを複製した　上昇量を5にした　テキストはへんな感じになっているので
拡大縮小は   X0.3   Y0.5   Z0.5


動くハートの１UP表示が出ない　動くと難しいのか…
回転寿司を作った
[フリーイラスト] 江戸前寿司のお店 - パブリックドメインQ：著作権フリー画像素材集

スターとハート複製　寿司屋に　かえる寿しをテキスト入れた　ムーブオブジェクトスクリプトとリジッドボディ２Dを配置　２５個ムーブポイント作成　

↑歩くぱんちゃんがスムーズになった　回転寿司を完成させた　皿は乗れるようにして上の方にハートを配置した　4/11/20
ステージ２のスターをブリに変更　大きさも直した

エネミー２にやられた時の音をつけたいのと　回転をやめたい

↓エネミー２スクリプトのバックアップ
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako2 : MonoBehaviour
{
    [Header("加算スコア")] public int myScore;
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("攻撃間隔")] public float interval;
    [Header("重力")] public float gravity;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;

    private Rigidbody2D rb;
    private Animator anim;
    private float timer;
    private ObjectCollision oc;					//②橋渡をするスクリプト
    private BoxCollider2D col;						//③２Dコライダーの変数
    private bool isDead = false;						//④


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();			//⑥
        col = GetComponent<BoxCollider2D>();			//⑦
        if (anim == null || attackObj == null)
        {
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        else
        {
            attackObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!oc.playerStepOn)                           //⑧橋渡しするスクリプトからプレイヤーに踏まれたかどうか
        {

            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

            //通常の状態
            if (currentState.IsName("idle"))
            {
                if (timer > interval)
                {
                    anim.SetTrigger("attack");
                    timer = 0.0f;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        else											//⑨踏まれた時の処理
        {
            if (!isDead)									//フラグを一回しか通らないように
            {
                anim.Play("idle");							//敵は踏まれた時　下に落ちていく形にして当たり判定を消す
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                GManager.instance.score += myScore;
                Destroy(gameObject, 1f);
            }
            else									//やられる際の処理が終わったら
            {
                transform.Rotate(new Vector3(0, 0, 5));		//①ゲームオブジェクトを３秒間くるくる回転させるメソッド
            }
        }
    }

    public void Attack()
    {
        GameObject g = Instantiate(attackObj);
        g.transform.SetParent(transform);
        g.transform.position = attackObj.transform.position;
        g.SetActive(true);
    }
}
=====================
↓追加
[Header("やられた時に鳴らすSE")] public AudioClip deadSE;
GManager.instance.PlaySE(deadSE);
↑削除　  transform.Rotate(new Vector3(0, 0, 5));	


↑uni（ザコ１）を羊に変更した　スタジオで撮影　真横

本番用のステージ１を作る
Backgroundの幅は２０５にした　１００でコンテニューポイントだが　レースにしたいと思う

↑グランドを差し替えた　ピクセルは１２８　１２８×１２８を使用　iOS用☑してからタイルパレットへ移動させる

競争相手探し　NPCとはNon Player Characterの略で、プレイヤーが操作するキャラクター以外のキャラクター全般のこと
https://tinytech.jp/wp-content/uploads/2019/10/1605611e15e02c3c1d80925025932418.pdf
http://motoyama.hateblo.jp/entry/unet-10
↓ちとこれやってみる　Nav Mesh Agent 
https://qiita.com/aimy-07/items/d1fea617ab9cbb3bd1ed
https://xr-hub.com/archives/7639

https://qiita.com/Atsu30/items/b4493c356423a4626c17
NavMeshComponents
http://tsubakit1.hateblo.jp/entry/2019/11/10/180825

まさにこのエラーと同じのんがでた
https://teratail.com/questions/280255
https://teratail.com/questions/239469
Nav Mesh Source Tag 2D		Tilmap　　Area 0
Nav Mesh Builder 2D (Script)		Navi		更新方法　更新
Nav Controller					Charactor(花　もぐら　柳  Saw)   Egg   Player
NPC_Nav これはいらんかも

https://github.com/h8man/NavMeshPlus

NavController.cs
20行目
this.agent.enabled = true;

NavMeshに十分に近づいていないため、エージェントの作成に失敗しました。
UnityEngine.Behaviour:set_enabled(Boolean)
<スタート>d__3:MoveNext() (at Assets/Script/NavController.cs:20)
UnityEngine.GUIUtility:ProcessEvent(Int32, IntPtr, Boolean&)

これじゃないやつができた

タイルマップしか移動できない　せっかくなので　花に変えて使う　エラーは解決しない
https://qiita.com/Atsu30/items/b4493c356423a4626c17
https://robamemo.hatenablog.com/entry/2017/10/07/085336
var enemy = Instantiate(this);
↑をつけると↓みたく地獄になった

↓スタジオのカメラの撮影方法が間違っていた　投影方法を平行投影にするとちゃんと真横に撮影できる

ゲーム画面を　５１２✕５１２にしてから撮影する　でないと圧縮できなくて取り直しになる　なった…　二度手間
ウィンドウー一般ーレコーダーで記録する
フラワーのアニメーター　パラメーター　アタックにチェックするとアタックアニメーションがあった
ひつじは歩くの他にジャンプやスタンがある　歩くだけを採用

花のアタックができた　アイドルもできた

↑NEWスクリプト
Nav Mesh Agent  ☑外す　警告はでたまま Sawを追加　

Saw.cs　　NEW
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 5));
    }
}
=====================
↑くるくる回転させる　サークルコライダー２Dにする




https://teratail.com/questions/258283
また違うのみつけた　↑敵が発射する弾を横方向に発射させたい
弾についているスクリプトのFixedUpdate()内にある rb.MovePositionで弾を動かしているので、その引数にVector3.upではなくVector3.leftを 指定すれば左へ飛んでいきます。 rb.MovePosition(transform.position + Vector3.left * Time.deltaTime * speed);
もともとのコードで rb.MovePosition(transform.position += Vector3.up * Time.deltaTime * speed); +=にしているのは無駄に2重に移動することになってしまうのでやめたほうが良いです。

↓マグロを横に飛ばすことに成功

EnemyAttack2スクリプト　NEW
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttack2 : MonoBehaviour
{
    [Header("スピード")] public float speed = 3.0f;
    [Header("最大移動距離")] public float maxDistance = 100.0f;

    private Rigidbody2D rb;
    private Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float d = Vector3.Distance(transform.position, defaultPos);

        //最大移動距離を超えている
        if (d > maxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            rb.MovePosition(transform.position + Vector3.left * Time.deltaTime * speed);
        }
    }


}
=====================


コンピューターがほしい　再び探す　ほしい情報にたどり着く　正しい検索キーワードを探せ
NPC　		Non Player Character
CPU
COM
AI　			Artificial Intelligence 
ゲームAI　 	NPCの振る舞いに知能があるかのようにみせる

NPC
　NPCとは、Non Player Characterの略称であり、ゲーム上でプレイヤーが操作しないキャラクターのことを指す言葉です。1人用のゲームでは、プレイヤーが操作するキャラクター以外は全てNPCです。オンラインゲームでは、プレイヤーと他のプレイヤーが操作しているキャラクター以外のキャラクターであり、ゲームのコンピュータ側が操作しているキャラクターのことを指します。 　同様の言葉にCPUやCOMという言葉があります。CPUやCOMはNPCの一種ですが、主に対戦型ゲームにおいて、コンピュータが操作するプレイヤーを指しますが、CPUやCOMという言葉は敵キャラクターを指す場合が多く、またプレイヤーキャラクターと対等な立場のキャラクターを指す場合が多いです。一方で、NPCはRPGゲームの村人等の登場人物を指す等、敵キャラクターでもなく、プレイヤーと立場が対等でもありません。


https://learning.unity3d.jp/4207/
AddTorqueで制御する　収録　記録　バッファを再生　乱数
https://www.slideshare.net/KojiMorikawa/ai-63387256
https://moon-bear.com/2020/01/02/enemy-ai/　　Unity 敵 AI アセット
https://www.fast-system.jp/unity-asset-ranking-ai/　Unityのおすすめアセット ４選（ＡＩ編）
https://qiita.com/UpAllNight/items/43e1b24301eb6029f18b　【PUN2】Unityでオンラインマルチプレイを爆速で実装する
https://connect.unity.com/p/pun2deshi-meruonraingemukai-fa-ru-men-sono1  PUN2で始めるオンラインゲーム開発入門【その１】

とりあえず難易度が高いので保留にする　
ダッシュ　コイン３でハート１　敵を増やす　時間


ダッシュ
https://pasteldrops.com/2019/03/06/post-735/    [UNITY]アクションゲームを作る(キャラクターを動かす)[2]
https://docs.unity3d.com/ja/2018.4/Manual/ConventionalGameInput.html　　　一般的なゲーム入力
 value = Input.GetAxis ("Fire1");
https://nn-hokuson.hatenablog.com/entry/2017/11/29/192514　　Unityでマリオっぽいゲームを作るのに必要な５つのこと



Assets/Script/NavController.cs(8,40): warning CS0649: Field 'NavController.egg' is never assigned to, and will always have its default value null
Assets/Script/NavController.cs(8,40): warning CS0649: フィールド 'NavController.egg' は決して代入されず、常にデフォルト値の null を持ちます。


移動キーを素早く2回押して走るようにする機能の作成
https://gametukurikata.com/program/run

FPSを作ってみよう　ばぐった
https://gametukurikata.com/category/fps

やめた　ステージを増やす　敵を増やすにする　Background Foreground変えたい　アセット探し

↑２つのBackgroundアセットを購入
https://www.youtube.com/watch?v=WvZ8lCYRQic&feature=emb_logo　自分でレイヤー作って配置しろとのこと
↑いまいちだから　Pixelmatorで編集してただのBackgroundとする

↑だまされた大賞　これじゃ上がみえてしまう　細い  とつなぎ目をちゃんとしないと変になる　端と端の絵の高さを合わせる
Backgroundのサイズは2048✕1536  いやべき乗にしよう　2048*2048 成功！！

Y1909　下　が地面となる  いや下が足りないので🐸　Y1820にする

やはりコインを入れたい　3/3　コイン0/4
コインイメージ＝ハート
/4=スコアテキスト
0/=ハイスコア

CoinScore.cs  NEW  Score.csを流用した　/3は逆に配置
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    private Text CoinScoreText = null;
    private int CoinOldScore = 0;
    public Text CoinHighScoreText; //ハイスコアを表示するText
    private int CoinHighScore; //ハイスコア用変数
    private string key = "COIN HIGH SCORE"; //ハイスコアの保存先キー

    // Start is called before the first frame update
    void Start()
    {
        CoinHighScore = PlayerPrefs.GetInt(key, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        CoinHighScoreText.text = CoinHighScore.ToString() + "/3";
        //ハイスコアを表示

        CoinScoreText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            CoinScoreText.text = "× " + GManager.instance.coinscore;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ハイスコアより現在スコアが高い時
        if (CoinOldScore > CoinHighScore)
        {

            CoinHighScore = CoinOldScore;
            //ハイスコア更新

            PlayerPrefs.SetInt(key, CoinHighScore);
            //ハイスコアを保存

            CoinHighScoreText.text = CoinHighScore.ToString() + "/3";
            //ハイスコアを表示
        }

        if (CoinOldScore != GManager.instance.coinscore)
        {
            CoinScoreText.text = "× " + GManager.instance.coinscore;
            CoinOldScore = GManager.instance.coinscore;
        }
    }
}
=====================

CoinScoreItem.cs  NEW   ScoreItem.csを流用した
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScoreItem : MonoBehaviour
{
    [Header("加算するコインスコア")] public int CoinMyScore;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;
    [Header("アイテム取得時に鳴らすSE")] public AudioClip itemSE;

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが判定内に入ったら
        if (playerCheck.isOn)
        {
            if (GManager.instance != null)
            {
                GManager.instance.coinscore += CoinMyScore;
                GManager.instance.PlaySE(itemSE);
                Destroy(this.gameObject);
            }
        }
    }
}
=====================
GManager.csに書きを追記
[Header("コインスコア")] public int coinscore;


やること　タイマーも追加する　０でゲームオーバー

https://freesworder.net/unity-countdown-timer/
初心者でも簡単にできる！Unityでカウントダウンタイマーを作成する方法




https://gametukurikata.com/program/time
Unityで経過時間、制限時間を表示する機能を作成する
https://qiita.com/nonkapibara/items/edb497f60e991bcbfe98
【Unity】ゲーム中の残り時間カウントダウン表示する
↑２つでカウントダウンとゲームオーバーが実装できた

RemainTimer.cs  NEW
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RemainTimer : MonoBehaviour
{
    [SerializeField] float gameTime = 20.0f;        // ゲーム制限時間 [s]
    Text uiText;                                    // UIText コンポーネント
    float currentTime;                              // 残り時間タイマー

    void Start()
    {
        // Textコンポーネント取得
        uiText = GetComponent<Text>();
        // 残り時間を設定
        currentTime = gameTime;
    }

    void Update()
    {
        // 残り時間を計算する
        currentTime -= Time.deltaTime;

        // ゼロ秒以下にならないようにする
        if (currentTime <= 0.0f)
        {
            currentTime = 0.0f;
        }
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        int mseconds = Mathf.FloorToInt((currentTime - minutes * 60 - seconds) * 1000);
        uiText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, mseconds);

        if (currentTime <= 0f)
        {
            GManager.instance.SubHeartNum();
        }
    }
}
=====================
ミリセカンズはやかましいので削除した


CoinScore.cs このままでは全てのステージでコインが総合計０/3となるので　ステージ毎に分けたい
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    private Text CoinScoreText = null;
    private int CoinOldScore = 0;
    public Text CoinHighScoreText; //ハイスコアを表示するText
    private int CoinHighScore; //ハイスコア用変数
    private string key = "COIN HIGH SCORE"; //ハイスコアの保存先キー

    // Start is called before the first frame update
    void Start()
    {
        CoinHighScore = PlayerPrefs.GetInt(key + GManager.instance.stageNum, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        CoinHighScoreText.text = CoinHighScore.ToString() + "/3";
        //ハイスコアを表示

        CoinScoreText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            CoinScoreText.text = "× " + GManager.instance.coinscore;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ハイスコアより現在スコアが高い時
        if (CoinOldScore > CoinHighScore)
        {

            CoinHighScore = CoinOldScore;
            //ハイスコア更新

            PlayerPrefs.SetInt(key + GManager.instance.stageNum, CoinHighScore);
            //ハイスコアを保存

            CoinHighScoreText.text = CoinHighScore.ToString() + "/3";
            //ハイスコアを表示
        }

        if (CoinOldScore != GManager.instance.coinscore)
        {
            CoinScoreText.text = "× " + GManager.instance.coinscore;
            CoinOldScore = GManager.instance.coinscore;
        }
    }
}
=====================
key　+ GManager.instance.stageNumとしてステージ数毎保存することに成功したかのように見える
ステージ毎のゲームマネージャーの現在のステージの数を正しくいステージ数にする


やること　ステージ２を更地にする

ステージ２のザコ１はuni にした下記(アニメーター)も直さないとスクリプトが正常に動かない　
uni_walk →walk    uni_dead →dead

ゴールはいろいろやらないと機能しない　ムーブポイント　１UP　ハート　置くなら

ステージ３ シティ　のタイルマップを差し替えた　ピクセルは32

http://stickpan.hatenablog.com/entry/2014/02/13/173004   Unity　いきなりのNullReferenceExceptionの対処法
NullReferenceException: Object reference not set to an instance of an object
UnityEditor.GameObjectInspector.ClearPreviewCache () (at /Users/builduser/buildslave/unity/build/Editor/Mono/Inspector/GameObjectInspector.cs:214)
UnityEditor.GameObjectInspector.OnDisable () (at /Users/builduser/buildslave/unity/build/Editor/Mono/Inspector/GameObjectInspector.cs:201)
UnityEditor.Tilemaps.GridPaintPaletteClipboard:OnDisable() (at /Applications/Unity/2020.1.1f1/Unity.app/Contents/Resources/PackageManager/BuiltInPackages/com.unity.2d.tilemap/Editor/GridPaintPaletteClipboard.cs:347)
NullReferenceException。オブジェクト参照がオブジェクトのインスタンスに設定されていない

↑いつのまにか画像が荒くなっている  　iOSの品質をウルトラにして　文字を大きくした

↑ぱんちゃんの頭の当たり判定を小さくすると壁越しにジャンプでばぐらなくなる
ki1.pmgの足元を正確にPixelmatorで切り抜かないとぱんちゃんがちゃんと着地しない
ステージ２にツインタワーを作成

↑動く敵はこれも忘れずに

↑タイルパレット　stage1 のSunnylandアセットをタイルパレットにドラックアンドドロップする
Pixelmatorで編集するとぼやける　アセットをそのままドラックアンドドロップ　1ファイルごと保存先を聞かれる

タイルパレットの移動の仕方
編集→選択ボタン→画像を選択（オレンジ色の枠でかこわれる）→移動ボタン→画像をドラックアンドドロップ


kiがぼやけてる　撮影してキレイにする　stage1 のSunnyland　ピクセル数１５から15.9に変更


やること　動かないウニやミミズを動かしたい
https://teratail.com/questions/229219　　障害物を上下に移動させたい

↓上下にオブジェクトが移動するスクリプト
UeSita		NEWスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UeSita : MonoBehaviour
{
    public float MovingDistance = 2;
    private float StartPos;

    void Start()
    {
        StartPos = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, StartPos + Mathf.PingPong(Time.time * 2f, MovingDistance), transform.position.z);
    }
}
=====================

↑ミミズを上下移動させることができた

Capsule Collider 2D


Enemy_Zako3  NEW
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako3 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("やられた時に鳴らすSE")] public AudioClip deadSE;
    [Header("上下する移動範囲")] public float MovingDistance = 2;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private CapsuleCollider2D col = null;
    private bool isDead = false;
    private float StartPos;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<CapsuleCollider2D>();
        StartPos = transform.position.y;
    }

    void FixedUpdate()
    {
        if (!oc.playerStepOn)
        {
            if (sr.isVisible || nonVisibleAct)
            {
                transform.position = new Vector3(transform.position.x, StartPos + Mathf.PingPong(Time.time * 2f, MovingDistance), transform.position.z);
            }
            else                                                //⑨画面に写っていない間、スリープ状態にする
            {
                rb.Sleep();
            }
        }
            else
            {
                if (!isDead)
                {

                    anim.Play("dead");
                    rb.velocity = new Vector2(0, -gravity);
                    isDead = true;
                    col.enabled = false;
                    if (GManager.instance != null)
                {
                    GManager.instance.PlaySE(deadSE);
                    GManager.instance.score += myScore;
                }
                    Destroy(gameObject, 0.45f);
                }
                else
                {
                transform.Rotate(new Vector3(0, 0, 5));
                }
            }
    }
}
=====================


↑リジッドボディ２D　位置を固定X☑　回転を固定Z☑　
重力スケール０にしているので落ちていかないので　やられた時0.45秒間deadアニメーションを表示して消えるようにした
重力スケールを１にすると　徐々に下に下がってくる
移動速度　重力　画面外でも行動するは　機能しているか不明
カプセルコライダーにした　別にボックスコライダーでよかったかも

おちる床が　戻るのが早すぎる　直す
FallDownFloor.cs  fallTime → returnTimeに変更したらちゃんと５秒後に戻るようになった
=====================
 //一定時間たつと元の位置に戻る
            if (fallingTimer > returnTime)
            {
=====================

unity5
ステージ３　更地　完成
ぱんちゃん上下みじかく　ねこ入れた
EnemyAttack4.csは右向きにオブジェクト（火）を飛ばす  NEW
Vector3.right

head1_neck

↑ポリスを追加
アニメーションがなかった為
スタジオで頭と右腕と銃を動かしてアニメーションを作成
弾はザコ１を貼り付けてやられるようにした
弾を動かしているのはエネミーアタック２スクリプトなので
速さと最大移動距離で消える

↑デカ弾を作成
ポリスの弾のピクセル数は600だがこちらはデフォルトの１００
アニメーションもコントローラーもポリスとは別に作成
エネミーザコ１デカ弾スクリプトを新たに作成し
Polygonコライダーに対応させた (元はboxコライダー)

Enemy_Zako1_dekatama.cs   NEW
=====================
private PolygonCollider2D col = null;
col = GetComponent<PolygonCollider2D>();
=====================

ポリスの弾と同様　弾の重力は0

↑動く弾を配置　ビル１完成


https://baba-s.hatenablog.com/entry/2018/04/08/130000#タイルの回転
↑タイルパレット　タイルの回転
タイルパレットは { と ｝で回転する

↑Nav Mesh Source Tag 2DスクリプトをTilemapではなくBackGroundTilemapにつけて目標をゴールにすればCPU作れる可能性アリ

オブジェクトアイディア　その１
1	ポリス　弾３		OK
2	そる				OK
3	動く◁　横		OK　さんかく
4	動く△　上下		OK
5	かえるちゃん		OK　かえる　とり　まぐろ　mob
８	mawaru軍団　OK
13　FallFloor_Mace の横移動　ブルブルMace横		OK
	

https://am1.jp/tutorials/unity/2d-gk-enemy/
2D Game Kitの敵の動きを増やす

Chomperの思考3つのスクリプト
①Character Controller 2D
②Enemy Behaviour
* 		ChomperAttackSMB
* 		ChomperDeathSMB
* 		ChomperPatrolSMB　③
* 		ChomperRunToTargetSMB

ジャンプ処理
Ellenのジャンプ処理は、LocomotionSMB.csとLocomotionWithGunSMB.csで確認することができます。
m_MonoBehaviour.CheckForJumpInput()メソッドで操作を確認して、ジャンプする場合はm_MonoBehaviour.SetVerticalMovement()メソッドにジャンプ力を渡して呼び出しています。
m_MonoBehaviourにはPlayerCharacterが結び付けられていますので、そこから探すと処理が見つかります。それをEnemyBehaviourに移植していきましょう。

Assets/Package/2DGamekit/Scripts/Character/MonoBehaviours/EnemyBehaviour.cs(491,39): エラー CS0246。型または名前空間名 'Damageable' が見つかりませんでした (using ディレクティブまたはアセンブリ参照がありませんか？)
Damageable
Bullet
Damager
RandomAudioPlayer
BulletPool

http://raharu0425.hatenablog.com/entry/2014/01/20/190242
Unity2D入門 スクロールアクションゲームを作る 敵のAIを作成してみる
https://ameblo.jp/citron829/entry-12171550601.html
【Unity】ジャンプさせるスクリプトについてのメモ
https://miyagame.net/addforce-jump/
【初心者向け】Unityでオブジェクトをジャンプさせる方法【AddForce】

Failed PVRTC compression: Failed to launch Tools/PVRTexTool
exitcode:11
stderr:
Failed to allocate a 8192*8192 image
PVRTC 圧縮に失敗しました。ツール/PVRTexツールの起動に失敗
exitcode:11
stderr.
8192*8192 イメージの割り当てに失敗しました。

Import parameters got modified during import
インポート中にインポートパラメータが変更された

[Collab] ExternalAPI::Failure: A request to Unity accounts has failed with HTTP status 401 Unauthorized. Please try again. If you continue to see this error, please restart Unity.
[Collab] ExternalAPI::Failure。UnityアカウントへのリクエストはHTTPステータス401 Unauthorizedで失敗しました。再度お試しください。このエラーが表示され続ける場合は、Unityを再起動してください。

attempt to write a readonly database
読み取り専用のデータベースを書こうとする

Assets/Script/NavController.cs(8,40): warning CS0649: Field 'NavController.egg' is never assigned to, and will always have its default value null
Assets/Script/NavController.cs(8,40): warning CS0649: フィールド 'NavController.egg' は決して代入されず、常にデフォルト値の null を持ちます。

全部インポートしたら
ゲームがぶっこわれたので　エネミーらへんだけ入れますｄ


https://docs.unity3d.com/ja/2018.4/Manual/UnityCollaborateManageCloudStorage.html#archivingprojects
Storage Pack の購入
https://unity3d.com/jp/get-teams
Unity Teams を無料ではじめよう


https://dashboard.unity3d.com/organizations/9071290937190/projects/e8d2f202-24f1-44e7-93f5-014111ad444f/settings/general

https://id.unity.com/ja/subscriptions/9071340905566/seats/configure
unity ID

unity のクラウドが１GBを超えたのでバックアップ不可となった為　unity チーム　アドバンスドを購入　月額9ユーロ　ペイパル払い　ドイツバンク　n@new2d.com
クラウドストレージが25GBとなった　3/12/2020



NullReferenceException。オブジェクト参照がオブジェクトのインスタンスに設定されていない
UnityEditor.GameObjectInspector.ClearPreviewCache () (at /Users/builduser/buildslave/unity/build/Editor/Mono/Inspector/GameObjectInspector.cs:214)
UnityEditor.GameObjectInspector.OnDisable () (at /Users/builduser/buildslave/unity/build/Editor/Mono/Inspector/GameObjectInspector.cs:201)
UnityEditor.Tilemaps.GridPaintPaletteClipboard:OnDisable() (/Applications/Unity/2020.1.1f1/Unity.app/Contents/Resources/PackageManager/BuiltInPackages/com.unity.2d.tilemap/Editor/GridPaintPaletteClipboard.cs:347)

シーンを閉じるときに、いくつかのオブジェクトがクリーンアップされていませんでした。(OnDestroy から新しい GameObject をスポーンしましたか？)
以下のシーンGameObjectが見つかりました。
PersistentDataManager
 
エラーが止まらないのでなーし


Unity2D入門 スクロールアクションゲームを作る 敵のAIを作成してみる

こっちで攻撃を削除したスクリプトをワシにつけたら動いた　上下しながら進んでいく　浮く  🐸は重力２０と↑1高さ/0.03時間
マグロはなぜか飛ぶコースが決まっている

mob_AI.cs    NEW
=====================
using UnityEngine;
using System.Collections;

public class mob_AI : MonoBehaviour
{

    public GameObject firePrefab;

    private int move_type = 0;
    private Vector3 forward;

    private bool isIdle = true;
    private bool isAttack = false;
    private bool isWalk = false;
    private bool isJump = false;

    // JumpParams
    private float jumpPowor;
    public float jumpPoworConst = 0.8f;
    public float jumpGrvity = 0.05f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //アイドル状態
        if (isIdle)
        {
            // ランダムでモーション種類基準となる番号を取得
            move_type = Random.Range(0, 4);

            // 歩くフラグが立っていたら
        }
        else if (isWalk)
        {

            //playerオブジェクトをを取得して向きを決定
            GameObject player2 = GameObject.Find("player");
            Vector3 forward = player2.transform.position - transform.position;

            // 向きに対してモーションを行なう&向きも変える
            if (forward.x > 0)
            {
                transform.Translate(Vector3.right * 0.1f);
                transform.localScale = new Vector3(-2, 2, 2);
            }
            else
            {
                transform.Translate(Vector3.left * 0.1f);
                transform.localScale = new Vector3(2, 2, 2);
            }
            return;

            // ジャンプフラグが立っていたら
        }
        else if (isJump)
        {
            //ジャンプ力を計算
            jumpPowor = jumpPowor - jumpGrvity;
            transform.Translate(Vector3.up * jumpPowor);
            //地面に着地したら処理処理終了
            if (jumpPowor < 0 && transform.position.y <= 1)
            {
                isIdle = true;
                isJump = false;
            }
            return;
        }
        else
        {
            return;
        }

        // Jump
        if (move_type == 3)
        {
            isIdle = false;
            isJump = true;
            jumpPowor = jumpPoworConst;
        }

    }

    IEnumerator WaitFotAttack()
    {
        yield return new WaitForSeconds(2.0f);
        isIdle = true;
        isAttack = false;
    }

    IEnumerator WaitFotWalk()
    {
        yield return new WaitForSeconds(0.5f);
        isIdle = true;
        isWalk = false;
    }
}
=====================


↑トリガーを３つにして弾を３つ出すポリスを作成

↑さんかくを作成　あたるとだめ

↑なんか回るやつができた sawスクリプトがついているからだ（回るスクリプト）

↑上に乗れるさんかく２を作成　たまにななめから入るとやられる…

↑ソル軍団を作成

次はマグロつかおうかな

花の火とポリスのタマが右と左に飛んでいかずその場にとどまる事象が発生
いつのまにかリジッドボディ２Dがキネマティックに変更されていたのが原因？　もともとキネマティック動いてた？
ダイナミックにしたら正常に動くようになった

MAWARUを作成　右回転　左回転　スピード　大きさを変更可能

ジャンプステップを応用すれば　スピードが変わるアイテムが作れると思う

かえる寿司差し替えしないと　江戸前から能登前にした  yoshimiが

mob_AI
=====================
using UnityEngine;
using System.Collections;

public class mob_AI : MonoBehaviour {

    public GameObject firePrefab;

    private int move_type = 0;
    private Vector3 forward;
    
    private bool isIdle = true;
    private bool isAttack = false;
    private bool isWalk = false;
    private bool isJump = false;

    // JumpParams
    private float jumpPowor;
    public float jumpPoworConst = 0.8f;
    public float jumpGrvity = 0.05f;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {

        //アイドル状態
        if(isIdle){
            // ランダムでモーション種類基準となる番号を取得
            move_type = Random.Range(0, 4);

        // 歩くフラグが立っていたら
        }else if(isWalk){
            
            //playerオブジェクトをを取得して向きを決定
            GameObject player2 = GameObject.Find("player");
            Vector3 forward = player2.transform.position - transform.position;

            // 向きに対してモーションを行なう&向きも変える
            if(forward.x > 0){
                transform.Translate(Vector3.right * 0.1f);
                transform.localScale = new Vector3(-2, 2, 2);
            }else{
                transform.Translate(Vector3.left * 0.1f);
                transform.localScale = new Vector3(2, 2, 2);
            }
            return;

        // ジャンプフラグが立っていたら
        }else if(isJump){
            //ジャンプ力を計算
            jumpPowor = jumpPowor - jumpGrvity;
            transform.Translate(Vector3.up * jumpPowor);
            //地面に着地したら処理処理終了
            if(jumpPowor < 0 && transform.position.y <= 1){
                isIdle = true;
                isJump = false;
            }
            return;
        }else{
            return;
        }

        //Attack
        if(move_type == 1){
            isIdle = false;
            isAttack = true;

            //攻撃オブジェクトを生成
            GameObject fire = Instantiate(firePrefab, new Vector3(transform.position.x, transform.position.y - 0.5f, 1), Quaternion.identity) as GameObject;

            // 攻撃オブジェクトのタグを変える
            fire.gameObject.tag = "mob";

            // 攻撃向きと飛ばす方向を決める
            GameObject player2 = GameObject.Find("player");
            Vector3 forward = player2.transform.position - transform.position;

            if(forward.x > 0){
                fire.gameObject.SendMessage("setDirection", true);
                transform.localScale = new Vector3(-2, 2, 2);
            }else{
                fire.gameObject.SendMessage("setDirection", false);
                transform.localScale = new Vector3(2, 2, 2);
            }

            //スリープ
            StartCoroutine("WaitFotAttack");
        }

        // Walk
        if(move_type == 2){
            isIdle = false;
            isWalk = true;
            StartCoroutine("WaitFotWalk");
        }

        
        // Jump
        if(move_type == 3){
            isIdle = false;
            isJump = true;
            jumpPowor = jumpPoworConst;
        }

    }
    
    IEnumerator WaitFotAttack()
    {
        yield return new WaitForSeconds(2.0f);
        isIdle = true;
        isAttack = false;
    }

    IEnumerator WaitFotWalk()
    {
        yield return new WaitForSeconds(0.5f);
        isIdle = true;
        isWalk = false;
    }
}
=====================
↑これはまだ　修正すればいろいろ使えそう


↑振動幅を大きくして指定内にプレイヤーが入るとMaceが横運動をするようにした

↑振動幅を少なくして気付かれずらくした

https://www.illust-box.jp/sozai/141594/
手裏剣　クナイ　セット

EnemyAttack5 NEWスクリプト
右で回るやつ追加

めちゃ不規則に動く手裏剣ができた　これはこれで

静的なボディではベロシティが使えない。
UnityEngine.Rigidbody2D:set_velocity(Vector2)
Enemy_Zako2:Update() (at Assets/Script/Enemy_Zako2.cs:67)

手裏剣を倒せるようになったが、エネミー２のリジッドボディ２Dが必要で　静的でないと手裏剣が
ちゃんと右側へ移動しない　静的にすると倒した時、上記の警告がでる


ゲームオブジェクト 'Camera' をロードする際に、インデックス 3 のコンポーネントがロードできない。削除してください。

ライティングデータアセット「LightingData」は、現在のUnityバージョンと互換性がありません。Generate Lightingを使用してライティングデータを再構築してください。 リアルタイムグローバルイルミネーションは、照明データが再構築されるまで使用できません。

手裏剣アセットを入れたらでた警告

忍者に変更　右に手裏剣を投げる忍者は背が高いので　左に投げる忍者は腰を低く作ろう

↑ninjya2(左向き)neck配下にarmとthighを配置したら首と連動して右腕と右足が一緒に動く撮影ができた
png数も21ほどとなり撮影が楽でファイルも軽くなる　

↑ポリスカーとヘリコプターのアセットを使用　タイヤ2個でsaw回るスクリプトを置くと
こんな感じに回る　細長い棒を回せば　マリオの火の棒を作れそう
ポリゴンコライダー２D　タイヤ部分を削って地面をちゃんと走るようにした　こやつらは重力なし　浮いて進むしかないのである

https://dkrevel.com/unity-explain/unity-recorder/
Unity Recorderの使い方【スクショ・動画を撮ろう】
特に１枚だけスクショを撮りたい場合は何フレームも映されても困ります。そういった時はRecord Modeの設定を変えましょう
Record Mode Single Frame・・・記録するフレーム数を指定してその１フレームのみ記録します。

↑ポリスヘリに機関銃を追加　火エフェクトを追加　タマを追加　タマは一つずつ　動かして撮影して回るようにした
あとはヘリ自体の音と攻撃SEを追加せよ

Enemy_Zako2_heri.cs   NEWスクリプト
BoxCollider2D　→　PolygonCollider2D
ポリゴンコライダー用
 else
            {
                transform.Rotate(new Vector3(0, 0, -5));
            }
やられた時　右回転で回る　　ヘリのしっぽが弱点
Unityで敵キャラクター出現時に効果音を鳴らしてみる
https://gametukurikata.com/se/appearse

↑音源バラバラ音を確保　ゲーム開始時に再生☑ループ☑立体音響ブレンド３D　音が鳴る範囲を○調整

攻撃時も音ならしたい

↑ガンショット音を確保　ゲーム開始時に再生☑　立体音響ブレンド３D　音が鳴る範囲を○調整

パトカーの音も欲しい

↑エンジン07にした　BGMがうるさいので優先度100とボリュームを下げた0.05

↑タマゴを皿から動かさずに移動させることに成功　ポイントは皿の子供にする

ぱんちゃんをユニティちゃんの声じゃなくしたい　

プレイヤー
やっ　ジャンプ
https://soundeffect-lab.info/sound/anime/
効果音ラボ　ニュ　　nyu2


きゃ　やられた時
yarareta_system20

ステージコントロール
そんなー　ゲームオーバーの時
https://maoudamashii.jokersounds.com/archives/bgm_maoudamashii_8bit20.html
↑長すぎた
https://kodomosize.net/?p=1031
https://dova-s.jp/se/play553.html
↑やっぱこれにする


やったー　クリアした時
se_maoudamashii_jingle05
リトライ時
se_maoudamashii_onepoint17

羽音　鳥のエネミー  羽の音が小さい　tori 優先２００　最低８　BGMを０．０５に下げたら聞こえた　ループ☑

tama6
se_maoudamashii_se_escapeに変更した　逃げる音だが　機関銃の音に聞こえる



タマのオーディオはSE-Gun-002  立体音響ブレンド３D　最小距離３　最大距離500

https://baba-s.hatenablog.com/entry/2017/11/16/090000
【Unity】Unity でも使用できるサウンドがフリーで公開されているサイト様7件紹介




Errors were encountered while preparing your device for development. Please check the Devices and Simulators Window.
お使いのデバイスの開発準備中にエラーが発生しました。Devices and Simulators ウィンドウを確認してください。

https://gaprot.jp/2019/10/30/device-simulator/
Unity 2019.3「 Device Simulator 」で UI を配置してみた

https://helpdesk.unity3d.co.jp/hc/ja/articles/900002171066-Unity-2020-1-からパッケージマネージャで発見できなくなったパッケージのインストール方法

↑ビルドしなくても各デバイスの画面が見れる　ゲーム画面が変更される

↑このエラーが出てビルド失敗する　　　　↑これをやってみる

https://translate.google.com/translate?hl=ja&sl=en&u=https://stackoverflow.com/questions/64974291/xcode-12-3-beta-failed-to-prepare-device-for-development&prev=search&pto=aue

↑UnityのDevices Simulatorで画面を確認したところiPhone６ではコントローラーが表示されなくなっていたので
キャンバスのCanvas ScalerのスクリーンマッチモードをMatch Width Or HeightからExpandに変更した

↑Window -> Devices & Simulators　　←UnityのDevices SimulatorではなくXcodeのウィンドウにある設定のことだった
ここにエラーがあっては駄目　IOSフリー環境では３つのアプリしか入れられない為４つめのアプリは弾かれる
古いアプリは消す必要があり　Run in Xcodeのバージョンも合わせたほうがベターかも　WiFiもすべてONにする

これでipadとiphone6sにPANビルドが成功した　　2020/12/18

オブジェクトアイディア　その２
18　タマ四発縦並べて発射するヘリコプター	＝　OK
　　ゲームオーバーになってもタイマーが止まらない　直せ	OK							　　	　＝
19　ヘリ　機銃追加　OK
20　ヘリ　忍者　ポリス　idle 微妙に動かせ　ヘリOK　忍者２OK
21　ヘリ　機関銃　火花エフェクト　OK
22　エネミー攻撃した時のSE追加　ヘリOK
23 　ヘリ　音　バラバラバラ　OK
24　ステージを選択できるようにする　OK


タイトル画面とステージ選択画面の作り方
https://unity.moon-bear.com/escape-from-ruin/title-and-stageselect/#toc6


【Unity】ステージ選択をするスクリプトつくってみた！アクションゲームに使えるかも
https://clrmemory.com/programming/unity/stage-select-script/
Unityでステージ選択からキャラクター選択をし、ゲームを開始する機能を作成する
https://gametukurikata.com/program/selectstageandcharacter



①【Unity】ボタンを押したら任意のシーン（scene）を読み込みようにする方法
https://miyagame.net/button-read-scene/
②Unity でブロック崩しを作る際のステージ選択機能の仕組み
https://qiita.com/cayto_pr/items/ee75eaf1ea163d5a05c1

↑これで行こうと思う
https://github.com/sakura-crowd/sample_blockkuzushi/tree/master/Assets/Script
StageCommonConfig.cs

ボタンを押せない状態にする。
public Button button1;
button1.interactable = false;


GameFinish.cs   NEWスクリプト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1.UIシステムを使うときに必要なライブラリ
using UnityEngine.UI;
// 2.Scene関係の処理を行うときに必要なライブラリ
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
　[Header("現在のステージ")] public float stage;

    // 3.OnRetry関数が実行されたら、sceneを読み込む
    public void OnRetry()
    {
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("stage" + stage);
    }
}
=====================

↑キャンバスにGameFinishスクリプトを配置　ボタンにクリック時Runtime Only GameFinish.OnRetry Canvasを配置
インスペクターからステージ数を指定可能とする

↑ステージ選択ボタンはキャンバスのソートレイヤーを変更して表示させる
PAN→ステージ選択画面となるようにした

StageCtrlスクリプトを修正を下記に修正したら
ChangeScene(1); //最初のステージに戻るので１		を
SceneManager.LoadScene("ButtonScene”);		に

リトライボタンを押すとButtonSceneに飛ぶが　ステージを選択するとゲームオーバーから始まる　Gマネージャーを介さないといけないが
うまくいかん

StageCtrl BK 
=====================
    /// 最初から始める
    /// </summary>
    public void Retry()
    {
        GManager.instance.PlaySE(retrySE); //New!
        ChangeScene(1);　　　//stage1に行く
        retryGame = true;
        
    }
=====================
StageCtrl  修正
=====================
public void Retry()
    {
        GManager.instance.PlaySE(retrySE); //New!
        GManager.instance.RetryGame();			//GManagerの①を読み込み　ゲームオーバー画面　ハート、スコア等をリセット
        SceneManager.LoadScene("ButtonScene");	//ButtonSceneに飛ばす
        retryGame = true;
        
    }
=====================
GManagerの①
 /// <summary>
    /// 最初から始める時の処理
    /// </summary>
    public void RetryGame()
    {
        isGameOver = false;
        heartNum = defaultHeartNum;
        score = 0;
        stageNum = 1;
        continueNum = 0;
    }
=====================
↑これで　リトライ時にゲームオーバー画面で起動することなくリセットされた状態でゲームスタートできるようになった



【Unity】AutoSaveなら自動保存できる！Unityが落ちても安心だった！
https://clrmemory.com/programming/unity/project-save-autosave/
自動保存を導入した
Assets-Editor
AutoSave.cs
SceneBackup.cs
Unity-環境設定-自動保存　で設定変更
ファイル-バックアップでバックアップ
ファイル-バックアップーロールバックでリストア　らしい

StageCtrl 修正
=====================

//ゲームオーバー時の処理
        if (GManager.instance.isGameOver && !doGameOver)
        {
            gameOverObj.SetActive(true);
            GManager.instance.PlaySE(gameOverSE);
            Time.timeScale = 0f;	//一時停止
            doGameOver = true;
        }
=====================

GameFinish 修正
=====================

public void OnRetry()
    {
        Time.timeScale = 1f;		//開始
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("stage" + stage);
    }
=====================
↑ゲームオーバーになったら全オブジェクトを一時停止させて（手裏剣はなぜか動く）開始時に動くようにした
これでタイマー以外もゲームオーバー時に止まるようになった

Unityでゲームの中断が出来るようにする
https://gametukurikata.com/program/stop

オブジェクトアイディア　その3
6	めちゃ多い動く皿　	
7	凸凹コース	
１０	マグロ上下
１１	上下する床だらけ
１２	BackgroundタイルマップにNavしてスタート地点へ向かう🐝軍団　海めんなら🐟大群　目標は上下に動かせ
14　海メン　宇宙メン　空メン　プレイヤーの移動速度遅くする　ジャンプもっとできるようにする
15　縦だけ　横だけメン　ひたすら下るメン　ひたすら登るメン
16　コインを鍵にする　宝箱おく　キー３つとって宝箱探すと　ハート５個でてくるなど
17　回転する危ない棒　（ポリスカーのタイヤ）ファイヤーエフェクト回す
25　ステージ選択画面　ステージアイコン作成
26　ステージ選択画面　クリアしたら次のステージに行けるようにする
27　サッカーボール　追加

unity ボタン押す　攻撃
Unityで主人公キャラが敵を攻撃出来るようにする機能
https://gametukurikata.com/program/charaattackenemy
ButtonHandler　unity ボタン
【Unity入門】Buttonの作り方!押された判定はどう取るの?
https://www.sejuku.net/blog/56265
// ボタンが押された場合、今回呼び出される関数
public void OnClick()
// 移動させたいオブジェクトを取得
 GameObject obj = GameObject.Find("PlayerObject");
/ オブジェクトを移動
obj.transform.Translate(1.0f,0.0f,0.0f);
}

playerスクリプトをいじればサッカーボールが攻撃になるやも

UnityのRigidbodyとColliderで衝突判定
https://qiita.com/yando/items/0cd2daaf1314c0674bbe

サッカーボールは　とりあえず　できた　敵にあたると　敵がやられる
ball.cs NEWスクリプト　プレイヤースクリプトを削ったバージョン

↑サッカーボール用のボタン追加　押すと右に少しづつずれるだけのやーつまで完成
パンちゃんに⚽ついてこさせてみるか　いやむずいか
ボールをコンテニューポイントにするか

unity6
unity6

↑NavをBackgroundタイルマップにつけてみた　ポイントは
Tilemap Collider 2Dを付けてトリガーに☑を入れると動作する
Tilemap Rendererの☑を外すとタイルマップを消せる
Canvas Renderer 透明メッシュをカリン☑しとく

結論　サッカーボールに使うのは難しいかも

↑いくらに上下スクリプトを付けてエネミーに追わせれば下の１２ができる
鳥だと変な回転が入るの(頭から走る)で回ってもおかしくないやーつにする←↓半左下回転
手裏剣にSawスクリプトをつければOK
タマやミサイルがベストかな
現状あるタマは全て左横向きなので緑△が頭となる　アニメーションが直角方向のオブジェクトが必要　ミサイル作成せよ
↑攻撃↑
オブジェクトアイディア　その3
6	めちゃ多い動く皿　	
7	凸凹コース	
１０	マグロ上下
１１	上下する床だらけ
１２	BackgroundタイルマップにNavしてスタート地点へ向かう🐝軍団　海めんなら🐟大群　目標は上下に動かせ
28　直角のミサイル
14　海メン　宇宙メン　空メン　プレイヤーの移動速度遅くする　ジャンプもっとできるようにする
15　縦だけ　横だけメン　ひたすら下るメン　ひたすら登るメン
16　コインを鍵にする　宝箱おく　キー３つとって宝箱探すと　ハート５個でてくるなど
17　回転する危ない棒　（ポリスカーのタイヤ）ファイヤーエフェクト回す
25　ステージ選択画面　ステージアイコン作成
26　ステージ選択画面　クリアしたら次のステージに行けるようにする
27　サッカーボール　追加

サッカーボールに戻る

https://codegenius.org/open/courses/18/sections/42
重力をつける／バウンドさせる

https://www.ame-name.com/archives/2250
【Unity】一度に一発ずつ弾を発射する

BallButton.cs↓これを変更する　BK
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    public GameObject soccerBall;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnClick();
        }
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        // 移動させたいオブジェクトを取得
        GameObject obj = GameObject.Find("soccerBall");
        // オブジェクトを移動
        obj.transform.Translate(1.0f, 0.0f, 0.0f);
    }
}
=====================
// プレイヤーのスクリプト
PlayerStateMachine sm_player;
// Start()
sm_player = animator.GetBehaviour<PlayerStateMachine>(); // 冒頭のStateMachineBehaviourを取得
sm_player.player = transform; // プレイヤーのトランスフォームを設定

=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    public GameObject soccerBall;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnClick();
        }
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        // CubeプレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load("soccerBall");
        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(obj, new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        
    }
}
=====================

↑のスクリプトでボタンを押すとサッカーボールを生成することができる
Resourcesフォルダを作成しそこにsoccerBallプレハブを配置
https://www.sejuku.net/blog/54672
【Unity入門】オブジェクトを動的生成!prefabを使いこなそう!

=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    public GameObject soccerBall;

    void Start()
    {
        GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);

        // 取得した戻り値の活用例
        cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
        cloneObject.transform.parent = this.transform; // GameManagerを親に指定
        cloneObject.transform.position = new Vector3(2.0f, 0.0f, 0.0f); // 座標を変更
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnClick();
        }
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        // CubeプレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load("soccerBall");
        // Cubeプレハブを元に、インスタンスを生成
        GameObject cloneObject = Instantiate(obj, this.transform.position, Quaternion.identity);
    }
}
=====================

↑サッカーボール２がぱんちゃんについてくる
ボタンを押すとボタンからサッカーボールでる
https://www.sejuku.net/blog/48180
【Unity入門】Instantiateを使いこなそう!使い方・使用例まとめ!

ムーブ　戻ってくる　スクリプトをさがせ　リジッドボディ使わないタイプの

【Unity】スクリプトで親要素を動的に変更する方法
https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&cad=rja&uact=8&ved=2ahUKEwjYzMOmzuvtAhUCKewKHebeAmsQFjAAegQIARAC&url=https%3A%2F%2Ftama-lab.net%2F2017%2F08%2F%25E3%2580%2590unity%25E3%2580%2591%25E3%2582%25B9%25E3%2582%25AF%25E3%2583%25AA%25E3%2583%2597%25E3%2583%2588%25E3%2581%25A7%25E8%25A6%25AA%25E8%25A6%2581%25E7%25B4%25A0%25E3%2582%2592%25E5%258B%2595%25E7%259A%2584%25E3%2581%25AB%25E5%25A4%2589%25E6%259B%25B4%25E3%2581%2599%25E3%2582%258B%25E6%2596%25B9%25E6%25B3%2595%2F&usg=AOvVaw2xbdCCMHJb_9cEfCGspBTd


PlayerC.cs  NEWスクリプト　プレイヤー子オブジェクト
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
	

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "Player")
		{
			this.gameObject.transform.parent = col.gameObject.transform; //プレイヤーを親要素に設定
			this.gameObject.tag = "Player";
		}
	}
}
=====================

↑上記スクリプト（ボールをプレイヤーの子要素にする）をボールに追加して
サッカーボールの速度を５　パンちゃんを１０にしたら　ボールがぱんちゃんから離れなくなった

=====================
if (col.gameObject.tag == "Player")
		{
			this.gameObject.transform.parent = col.gameObject.transform; //プレイヤーを親要素に設定
			this.gameObject.tag = "Player";
			transform.localScale = new Vector3(-1, 1, 1); //向きを反転する
			transform.localPosition = new Vector3(1f, 0, 0); //位置をプレイヤーの前に変更
		}
=====================
↑を追加してボールスピードを１にした　ボールが跳ねてドリブルするようになった　ボールタグをプレイヤーにした
ジャンプすると離れる

https://lanstar-blog.hatenablog.com/entry/444840631.html
ボタンを生成してオブジェクトを前後左右に移動させる方法

BallButton BK ボール跳ねる　ボタン押す　ボール右に瞬間移動の状態
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallButton : MonoBehaviour
{
    public GameObject soccerBall;
    
    void Start()
    {
        GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);

        // 取得した戻り値の活用例
        cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
        cloneObject.transform.parent = this.transform; // GameManagerを親に指定
        cloneObject.transform.position = new Vector3(2.0f, 0.0f, 0.0f); // 座標を変更
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnClick();
        }
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        // 移動させたいオブジェクトを取得
        GameObject obj = GameObject.Find("soccerBall2");
        // オブジェクトを移動
        obj.transform.position += new Vector3(10 * Time.deltaTime, 0, 0);

        // CubeプレハブをGameObject型で取得
        //GameObject obj = (GameObject)Resources.Load("soccerBall");
        // Cubeプレハブを元に、インスタンスを生成
        //GameObject cloneObject = Instantiate(obj, this.transform.position, Quaternion.identity);
    }
}
=====================


https://am1tanaka.hatenablog.com/entry/20111109/1320846783
(5)ボールを動かす




https://maku.blog/p/53o7p8p/
ローカル座標での位置 (Transform.localPosition)
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    public GameObject soccerBall;
    
    void Start()
    {
        GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);

        // 取得した戻り値の活用例
        cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
        cloneObject.transform.parent = this.transform; // GameManagerを親に指定
        cloneObject.transform.position = new Vector3(2.0f, 0.0f, 0.0f); // 座標を変更

        // 移動させたいオブジェクトを取得
        GameObject parent = GameObject.CreatePrimitive(PrimitiveType.Quad);
        GameObject child1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
        child1.transform.parent = parent.transform;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnClick();
        }
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {

        // 移動させたいオブジェクトを取得
        GameObject obj = GameObject.Find("soccerBall2");

        // オブジェクトを移動
        obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 0, 0);

        // CubeプレハブをGameObject型で取得
        //GameObject obj = (GameObject)Resources.Load("soccerBall");
        // Cubeプレハブを元に、インスタンスを生成
        //GameObject cloneObject = Instantiate(obj, this.transform.position, Quaternion.identity);
    }
}
=====================

↑左を向いたら左側にボールが進むようになったが　ぱんちゃんとの距離毎にボールが離れる


 void Update()
    {
        this.transform.position += new Vector3(0.1f, 0, 0);
    }

https://yutateno.hatenablog.jp/entry/2019/11/01/105744
【Unity】UIのボタンでオブジェクト動かしたい

https://yokubari.online/unity/how-to-transform-position-add-blowoff-effect/
こんなやり方もあり？Unity入門2Dゲームでダメージアクション

// 敵の位置を取得   
Vector3 enemyTFP = Enemy.transform.position;  
// プレイヤー自身の位置を取得
Vector3 playerTFP = transform.position;


if (enemyTFP.x - playerTFP.x > 0) 
// 敵がプレイヤーより右側にいる時の処理
playerTFP = enemyTFP + new Vector3 (-2, 1, 0);
transform.position = playerTFP;
} else if (enemyTFP.x - playerTFP.x <= 0) {
// 敵がプレイヤーより左側にいる時の処理
playerTFP = enemyTFP + new Vector3 (2, 1, 0);
transform.position = playerTFP;


FPS作成--(9)手榴弾を投げる
http://unity-xeion.seesaa.net/article/416612126.html

Vector3 pos = transform.position + transform.TransformDirection(Vector3.forward);		// プレイヤー位置　+　プレイヤー正面にむけて１進んだ距離
		GameObject bom = Instantiate(prefab_bom , pos , Quaternion.identity) as GameObject;		// 手榴弾を作成

		Vector3 bom_speed = transform.TransformDirection(Vector3.forward)  * 5;		// 手榴弾の移動速度。『プレイヤー正面に向けての速度ベクトル』を５。
		bom_speed += Vector3.up * 5;			// 手榴弾の『高さ方向の速度』を加算
		bom.GetComponent< Rigidbody >().velocity = bom_speed;		// 手榴弾の速度を代入

		bom.GetComponent< Rigidbody >().angularVelocity = Vector3.forward * 7;	// 手榴弾を回転速度を代入.


https://www.sejuku.net/blog/83762
【Unity】Invokeの使い方!実行タイミングを自在に操ろう


 public void OnClick()
    {
        // 移動させたいオブジェクトを取得
        GameObject obj = GameObject.Find("soccerBall2");
        // オブジェクトを移動
        obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 0, 0);
        InvokeRepeating("OnClick", 0, 0);

↑これを追加したらボールが走るようになった
0秒後に0秒ごとOnClickを続ける　　2021/1/6





https://nopitech.com/2018/07/02/post-700/
【Unity】何秒後に実行する

BallButtonスクリプト　追記
=====================
// ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        // 移動させたいオブジェクトを取得
        GameObject obj = GameObject.Find("soccerBall2");
        // オブジェクトを移動
        obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 0, 0);
        //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
        InvokeRepeating("OnClick", 0, 0);
        //Invokeを止める
        Invoke("Cancel", 3); 
    }

    void Cancel()
    {
        //Invokeで実行しているOnClick関数を3秒後に停止する
        CancelInvoke("OnClick");
        //関数名を記述しなければInvoke系全てを停止する
        //CancelInvoke();
    }
=====================
↑3秒後ボール止める　OK


プレイヤーに接触している時　ボールを蹴れる

↑設定判定をつけて　ボールがぱんちゃんから離れると動かなくなったが
判定を出たらサッカーボールは動かなくなる

PlayerC 追記
=====================
/// <summary>
    /// 判定内にプレイヤーがいる
    /// </summary>
    [HideInInspector] public bool isOn = false;

    public string PlayerTag = "Player";

    #region//接触判定
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isOn = true;
            Debug.Log("プレイヤーが判定に入り続けています");

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isOn = false;
            Debug.Log("プレイヤーが判定を出ました");
        }
    }
    #endregion
=====================
BallButton  追記

private PlayerC sc;
sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();
 if (sc.isOn)
=====================


=====================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    public GameObject soccerBall;
    private ObjectCollision oc;
    private PlayerC sc;

    private bool on = false;

    void Start()
    {　
        GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
       
        // 取得した戻り値の活用例
        cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
        cloneObject.transform.parent = this.transform; // GameManagerを親に指定
        cloneObject.transform.position = new Vector3(2.0f, 0.0f, 0.0f); // 座標を変更

        // 移動させたいオブジェクトを取得
        GameObject parent = GameObject.CreatePrimitive(PrimitiveType.Quad);
        GameObject child1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
        child1.transform.parent = parent.transform;
        //1秒後に呼び出され、2秒ごとに呼び出される

        //soccerBall2オブジェクトのクラスを参照
        oc = GameObject.Find("soccerBall2").GetComponent<ObjectCollision>();
        sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();
        //CubeScriptの変数にアクセスする
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnClick();
        }
    }

    

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        

        if (sc.isOn)
        {
            
            // 移動させたいオブジェクトを取得
            GameObject obj = GameObject.Find("soccerBall2");
            // オブジェクトを移動
            obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 0, 0);
            //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
            InvokeRepeating("OnClick", 0, 0);
            on = true;
        }
        else if (sc.isPlayerExit)
        {
            // 移動させたいオブジェクトを取得
            GameObject obj = GameObject.Find("soccerBall2");
            // オブジェクトを移動
            obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 0, 0);
            //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
            InvokeRepeating("OnClick", 0, 0);

            //Invokeを止める
            Invoke("Cancel", 1);
           
        }
    }

    void Cancel()
    {
        //Invokeで実行しているOnClick関数を3秒後に停止する
        CancelInvoke("OnClick");
        //関数名を記述しなければInvoke系全てを停止する
        //CancelInvoke();
        on = false;
        sc.isPlayerExit = false;
    }
}





//bom.GetComponent<Rigidbody2D>().angularVelocity = Vector3.forward * 7;	// 手榴弾を回転速度を代入.

// CubeプレハブをGameObject型で取得
//GameObject obj = (GameObject)Resources.Load("soccerBall");
// Cubeプレハブを元に、インスタンスを生成
//GameObject cloneObject = Instantiate(obj, this.transform.position, Quaternion.identity);
=====================

=====================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerC : MonoBehaviour
{
    
    private CircleCollider2D col;
    private Rigidbody2D physics = null;
    private BallButton bb = null;
    

    /// <summary>
    /// 判定内にプレイヤーがいる
    /// </summary>
    [HideInInspector] public bool isOn = false;
    [HideInInspector] public bool isPlayerExit = false;

    public string PlayerTag = "Player";

    void Start()
    {
        
        bb = GetComponent<BallButton>();
    }

    

    #region//接触判定
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent = col.gameObject.transform; //プレイヤーを親要素に設定
            //this.gameObject.tag = "Player";
            transform.localScale = new Vector3(-1, 1, 1); //向きを反転する
            transform.localPosition = new Vector3(1f, 0, 0); //位置をプレイヤーの後ろに変更
        }

        if (col.tag == PlayerTag)
        {
            isOn = true;
            Debug.Log("プレイヤーが判定に入り続けています");

        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isOn = false;
            isPlayerExit = true;							//⑤それぞれのフラグをそれぞれのメソッドでtrueにする（trueになったらこのメソッドを通ったとみなす）
            Debug.Log("プレイヤーが判定を出ました");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == PlayerTag)
        {
            
            							
            Debug.Log("プレイヤーが判定に入りました");
        }
    }
    #endregion

    public void Awake()
    {
        this.physics = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("bb"))
        {
            this.Flip(new Vector3(3f, 6f, 0));
        }
    }

    /// <summary>
    /// ボールをはじく
    /// </summary>
    /// <param name="force"></param>
    public void Flip(Vector3 force)
    {
        // 瞬間的に力を加えてはじく
        this.physics.AddForce(force, (ForceMode2D)ForceMode.Impulse);
    }

   

    internal static void Flip()
    {
        throw new NotImplementedException();
    }
}  
=====================
↑ボールに近づいた時だけボールを蹴れる
ステイ（OnTriggerStay2D）をとおりすぎてもボールがとまならないようにする
□のリジッドボディ２Dを２つつけて　できるだけボールがぱんちゃんに接触するようにした
多すぎてもだめ　
 Invoke("Cancel", 1);　時間は一秒にした


BallButtonスクリプト
=====================
public string PlayerTag = "Player";

    void Start()
    {
        GameObject ContentItem = GameObject.Find("Player");
        GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
        // 取得した戻り値の活用例
        cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
        cloneObject.transform.parent = ContentItem.transform;
        cloneObject.transform.position = new Vector3(2.0f, 0.0f, 0.0f); // 座標を変更
    }
=====================
↑親をゲームオブジェクトではなくプレイヤーにしたが動きは変わらなかった（パンちゃんの向きを変えるとサッカーボールが瞬間移動する）
とりあえず　画面外にでるのでこのままでいく　他をすすめることにする





BallButton.cs BK
=====================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    public GameObject soccerBall;
    private ObjectCollision oc;
    private PlayerC sc;
    private CircleCollider2D col;

    private bool on = false;
    public string PlayerTag = "Player";

    void Start()
    {
        GameObject ContentItem = GameObject.Find("Player");
        GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
        // 取得した戻り値の活用例
        cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
        cloneObject.transform.parent = ContentItem.transform;
        cloneObject.transform.position = new Vector3(2.0f, 0.0f, 0.0f); // 座標を変更

        //cloneObject.transform.parent = this.transform; // GameManagerを親に指定
        // 移動させたいオブジェクトを取得
        //GameObject parent = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //GameObject child1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //child1.transform.parent = parent.transform;


        //soccerBall2オブジェクトのクラスを参照
        oc = GameObject.Find("soccerBall2").GetComponent<ObjectCollision>();
        sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();
        //CubeScriptの変数にアクセスする
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnClick();
        }
    }

    

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        

        if (sc.isOn)
        {
            
            // 移動させたいオブジェクトを取得
            GameObject obj = GameObject.Find("soccerBall2");
            // オブジェクトを移動
            obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 10, 0);
            //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
            InvokeRepeating("OnClick", 0, 0);
            on = true;
        }
        else if (sc.isPlayerExit)
        {
            // 移動させたいオブジェクトを取得
            GameObject obj = GameObject.Find("soccerBall2");
            // オブジェクトを移動
            obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 10, 0);
            //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
            InvokeRepeating("OnClick", 0, 0);

            //Invokeを止める
            Invoke("Cancel", 1);
           
        }
    }

    void Cancel()
    {
        //Invokeで実行しているOnClick関数を3秒後に停止する
        CancelInvoke("OnClick");
        //関数名を記述しなければInvoke系全てを停止する
        //CancelInvoke();
        on = false;
        sc.isPlayerExit = false;
    }
}

//bom.GetComponent<Rigidbody2D>().angularVelocity = Vector3.forward * 7;	// 手榴弾を回転速度を代入.

// CubeプレハブをGameObject型で取得
//GameObject obj = (GameObject)Resources.Load("soccerBall");
// Cubeプレハブを元に、インスタンスを生成
//GameObject cloneObject = Instantiate(obj, this.transform.position, Quaternion.identity);
=====================

↑コンテニューポイントのかかしをサッカーボールに変更しBallButtonスクリプトの一部をコンテニューポイントスクリプトに移植したらコンテニューポイント通過後　スタート地点にサッカーボールが重なって出現した　2021/1/8

ContinuePoint .cs
=====================
 if (kakudo < 180.0f)
            {
                //sinカーブで振動させる
                transform.position = defaultPos + Vector3.up * moveDis * Mathf.Sin(kakudo * Mathf.Deg2Rad);

                //途中からちっちゃくなる
                if (kakudo > 90.0f)
                {
                    transform.localScale = Vector3.one * (1 - ((kakudo - 90.0f) / 90.0f));
                }
                kakudo += 180.0f * Time.deltaTime * speed;

                GameObject ContentItem = GameObject.Find("Player");
                GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
                // 取得した戻り値の活用例
                cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
                cloneObject.transform.parent = ContentItem.transform;
                cloneObject.transform.position = new Vector3(2.0f, 0.0f, 0.0f); // 座標を変更
            }
=====================




cloneObject.transform.parent = ContentItem.transform;
↑だと⚽がスタート位置になるため↓に戻す
cloneObject.transform.parent = this.transform; // GameManagerを親に指定

もとい

 GameObject ContentItem = GameObject.Find("Continue1-1");
                GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
                // 取得した戻り値の活用例
                cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
                sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();
                cloneObject.transform.parent = ContentItem.transform;
                //cloneObject.transform.parent = this.transform; // GameManagerを親に指定
                cloneObject.transform.position = new Vector3(315.0f, 0.0f, 0.0f); // 座標を変更

↑コンテニュー１−１のX軸が３１５の位置にあるので
座標を３１５にしたらコンテニュー１−１に⚽が８個出現した　なぜ８個でる？

https://qiita.com/Kenji__SHIMIZU/items/db3b2f04b29575f78f13
Unityで親を設定する方法

https://miyagame.net/one-method/
【Unity】一回しか処理を実行させない２つの方法
↑で解決
ContinuePoint
=====================
bool test = true;  //宣言

if (test == true)
 {
	処理
	test = false;
 }
=====================

BallButton
=====================
public void OnClick()
    {
        sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();
=====================
↑これをスタートからオンクリックに移動　正常に作動した
これで　コンテニューポイントを通過後⚽出現　⚽正常作動となった　うそでした

https://vaikong.hatenadiary.jp/entry/2015/04/26/143127
特定のオブジェクトが存在するか確認してあったら削除するコード

GameObject search = GameObject.Find ("Emanu(Clone)");
		bool n = (bool)search;


		if (n == true) {
			Destroy (prefab);
			n = false;

			return;
		}

BallButton　修正
=====================
public void OnClick()
    {
        GameObject search = GameObject.Find("soccerBall2");
        bool n = (bool)search;


        if (n == true)
        {
            sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();

            if (sc.isOn)
            {

                // 移動させたいオブジェクトを取得
                GameObject obj = GameObject.Find("soccerBall2");
                // オブジェクトを移動
                obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 0, 0);
                //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
                InvokeRepeating("OnClick", 0, 0);
                on = true;
            }
            else if (sc.isPlayerExit)
            {
                // 移動させたいオブジェクトを取得
                GameObject obj = GameObject.Find("soccerBall2");
                // オブジェクトを移動
                obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 0, 0);
                //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
                InvokeRepeating("OnClick", 0, 0);

                //Invokeを止める
                Invoke("Cancel", 1);

            }
            n = false;
            return;
        }
        else
        {
            Debug.Log(false);
        }
    }
=====================
↑ボール２がない場合ファルスとなり　あったら正常稼働するようになった

https://atelier-aomi.hatenablog.com/entry/2020/01/19/152217
Unityスクリプト編 #1 -動的に親子関係を作成/解除する-
=====================

 if (isPlayerExit == false)
        {
            this.gameObject.transform.parent = null;
        }
=====================
↑にするとなったりならなかったりする　ボールの反転　大幅移動が



=====================

BallButton
sc.isSbExit = true;

PlayerC
if (collision.tag == PlayerTag　&& isSbExit == true)
        {
            this.gameObject.transform.parent = null;
        }
↑にすると右は成功　左はボールが右にいきたがる
=====================
=====================

BallButton
sc.isPlayerExit = true;

PlayerC
if (collision.tag == PlayerTag && isSbExit == true)
        {
            this.gameObject.transform.parent = null;
        }
↑にすると右左成功　ボールはとんでいかない
=====================



=====================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    public GameObject soccerBall;
    private ObjectCollision oc;
    private PlayerC sc;
    private CircleCollider2D col;

    private bool on = false;
    public string PlayerTag = "Player";
    

    void Start()
    {
        //GameObject ContentItem = GameObject.Find("Player");
        //GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
        // 取得した戻り値の活用例
        //cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
        //cloneObject.transform.parent = ContentItem.transform;
        //cloneObject.transform.parent = this.transform; // GameManagerを親に指定
        //cloneObject.transform.position = new Vector3(2.0f, 0.0f, 0.0f); // 座標を変更

        
        // 移動させたいオブジェクトを取得
        //GameObject parent = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //GameObject child1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //child1.transform.parent = parent.transform;


        //soccerBall2オブジェクトのクラスを参照
        //oc = GameObject.Find("soccerBall2").GetComponent<ObjectCollision>();
        
        //CubeScriptの変数にアクセスする
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnClick();
        }
    }

    

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        GameObject search = GameObject.Find("soccerBall2");
        bool n = (bool)search;


        if (n == true)
        {
            sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();

            if (sc.isOn)
            {

                // 移動させたいオブジェクトを取得
                GameObject obj = GameObject.Find("soccerBall2");
                // オブジェクトを移動
                obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 0, 0);
                //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
                InvokeRepeating("OnClick", 0, 0);
                on = true;
            }
            else if (sc.isPlayerExit)
            {
                // 移動させたいオブジェクトを取得
                GameObject obj = GameObject.Find("soccerBall2");
                // オブジェクトを移動
                obj.transform.localPosition += new Vector3(10 * Time.deltaTime, 0, 0);
                //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
                InvokeRepeating("OnClick", 0, 0);

                //Invokeを止める
                Invoke("Cancel", 1);

            }
            n = false;
            return;
        }
        else
        {
            Debug.Log(false);
        }
    }

    void Cancel()
    {
        //Invokeで実行しているOnClick関数を3秒後に停止する
        CancelInvoke("OnClick");
        //関数名を記述しなければInvoke系全てを停止する
        //CancelInvoke();
        on = false;
        sc.isPlayerExit = false;

        if (sc.isSbExit == true)
        {
            // 移動させたいオブジェクトを取得
            GameObject obj = GameObject.Find("soccerBall2");
            obj.gameObject.transform.parent = null;
        }

    }
}





//bom.GetComponent<Rigidbody2D>().angularVelocity = Vector3.forward * 7;	// 手榴弾を回転速度を代入.

// CubeプレハブをGameObject型で取得
//GameObject obj = (GameObject)Resources.Load("soccerBall");
// Cubeプレハブを元に、インスタンスを生成
//GameObject cloneObject = Instantiate(obj, this.transform.position, Quaternion.identity);
=====================
=====================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerC : MonoBehaviour
{
    
    private CircleCollider2D col;
    private Rigidbody2D physics = null;
    private BallButton bb = null;

    [HideInInspector] public bool isSb = false;
    [HideInInspector] public bool isSbEnter, isSbStay, isSbExit;	//②3つのフラグを作成する

    /// <summary>
    /// 判定内にプレイヤーがいる
    /// </summary>
    [HideInInspector] public bool isOn = false;
    [HideInInspector] public bool isPlayerExit = false;

    public string PlayerTag = "Player";

    void Start()
    {
        
        bb = GetComponent<BallButton>();
    }

    public bool IsSb()								//⑥プレイヤーのスクリプトから読めるようにpublicでメソッドを書いていく　返り値として地面にちゃんと設置しているかを返す
    {
        if (isSbEnter || isSbStay)					//⑦EnterもしくはStayを通っていた場合、接地判定をtrueにする
        {
            isSb = true;
        }
        else if (isSbExit)							//⑧Exitを通っていた場合、接地判定をfalseにする　Exitを通っていた場合でもEnterかStayが呼ばれたら、地面に着いているとみなす
        {											//またelse文が無い為、どのメソッドも通っていない場合、isGround(接地判定フラグ)はそのままとなる
            isSb = false;							//キャラクターがしばらく止まるなどしてStayが呼ばれない状態となったとしても対応できる
        }

        isSbEnter = false;							//⑨呼び出されたら各種フラグをfalseにして元の状態に戻す
        isSbStay = false;
        isSbExit = false;
        return isSb;								//⑩接地判定を返す
    }


    #region//接触判定
    public void OnTriggerStay2D(Collider2D col)
    {
       //if (col.gameObject.tag == "Player")
       //{
           //this.gameObject.transform.parent = col.gameObject.transform; //プレイヤーを親要素に設定
                
           //this.gameObject.tag = "Player";
           //transform.localScale = new Vector3(-1, 1, 1); //向きを反転する
           //transform.localPosition = new Vector3(1f, 0, 0); //位置をプレイヤーの後ろに変更
       //}

       if (col.tag == PlayerTag)
       {
           isOn = true;
           this.gameObject.transform.parent = col.gameObject.transform; //プレイヤーを親要素に設定
            
            Debug.Log("プレイヤーが判定に入り続けています");

       }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isOn = false;
            isPlayerExit = true;
            isSbExit = true;                            //⑤それぞれのフラグをそれぞれのメソッドでtrueにする（trueになったらこのメソッドを通ったとみなす）

            Debug.Log("プレイヤーが判定を出ました");
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == PlayerTag)
        {
            isSbEnter = true;							//③それぞれのフラグをそれぞれのメソッドでtrueにする（trueになったらこのメソッドを通ったとみなす）							
            Debug.Log("プレイヤーが判定に入りました");
        }
    }
    #endregion

    public void Awake()
    {
        this.physics = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("bb"))
        {
            this.Flip(new Vector3(3f, 6f, 0));
        }
    }

    /// <summary>
    /// ボールをはじく
    /// </summary>
    /// <param name="force"></param>
    public void Flip(Vector3 force)
    {
        // 瞬間的に力を加えてはじく
        this.physics.AddForce(force, (ForceMode2D)ForceMode.Impulse);
    }

   

    internal static void Flip()
    {
        throw new NotImplementedException();
    }
}  
=====================
https://www.sejuku.net/blog/99719
【C#入門】if文で条件分岐をしよう！基礎知識まとめ


 ↑Invokeを止めた後に親オブジェクトをNULLにするようにしたら成功した

１がプレイヤーが右にけった後　すぐに左を向くとサッカーボールが左に瞬間移動する
これもなんとかしたい

コンテニューポイントもインスペクターからサッカーボール出現位置を設定できるよにしないとだめ

https://www.sejuku.net/blog/51251
【Unity】transform.positionを変更してオブジェクトを移動させよう!

obj.transform.localPosition += new Vector3(3 * Time.deltaTime, 0.08f, 0);
↑ボールスピードと角度を調整した




タイトル画面　スタートボタンを透明にして画面全体にした
アニメータはアニメーションの最後のコマだけopn_endに配置してアニメーションがループしないようにした

https://tokidoki-web.com/2013/01/『スマホ・タブレットのサイズ解像度一覧作って/

↑フェードの幅と高さが960×540では　デバイスによって見切れるので1000×800に全変更した ←後に2000×2000に変更

Player.cs BK
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE;
    [Header("やられた鳴らすSE")] public AudioClip downSE;
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;
    #endregion


    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private MoveObject moveObj = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private bool isRun = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private bool isClearMotion = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float otherJumpSpeed = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string hitAreaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    private string jumpStepTag = "JumpStep";
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }
            //1秒たったら明滅終わり
            if (continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
    }



    void FixedUpdate()
    {

        if (!isDown && !GManager.instance.isGameOver && !GManager.instance.isStageClear)
        {
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

            //移動速度を設定
            Vector2 addVelocity = Vector2.zero;
            if (moveObj != null)
            {
                addVelocity = moveObj.GetVelocity();
            }
            rb.velocity = new Vector2(xSpeed, ySpeed) + addVelocity;
        }
        else
        {
            if (!isClearMotion && GManager.instance.isStageClear)
            {
                anim.Play("player_win");
                isClearMotion = true;
            }
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = CrossPlatformInputManager.GetAxis("Vertical");
        float ySpeed = -gravity;

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
        }

        //何かを踏んだ際のジャンプ
        if (isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = otherJumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (verticalKey > 0)
            {
                if (!isJump)
                {
                    GManager.instance.PlaySE(jumpSE);
                }
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }


    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {
        float horizontalKey = CrossPlatformInputManager.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
    }

    /// <summary>
    /// コンティニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        if (GManager.instance.isGameOver)
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;
        }
    }

    //ダウンアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if (isDown && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// コンティニューする
    /// </summary>
    public void ContinuePlayer()
    {
        GManager.instance.PlaySE(continueSE);
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isContinue = true;
        nonDownAnim = false;
    }

    //やられた時の処理
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown || GManager.instance.isStageClear)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.PlaySE(downSE);
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemy = (collision.collider.tag == enemyTag);
        bool moveFloor = (collision.collider.tag == moveFloorTag);
        bool fallFloor = (collision.collider.tag == fallFloorTag);
        bool jumpStep = (collision.collider.tag == jumpStepTag);

        if (enemy || moveFloor || fallFloor || jumpStep)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    if (enemy || fallFloor || jumpStep)
                    {
                        ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                        if (o != null)
                        {
                            if (enemy || jumpStep)
                            {
                                otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                                otherJumpSpeed = o.jumpSpeed; //ジャンプするスピード
                                o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                                jumpPos = transform.position.y; //ジャンプした位置を記録する
                                isOtherJump = true;
                                isJump = false;
                                jumpTime = 0.0f;
                            }
                            else if (fallFloor)
                            {
                                o.playerStepOn = true;
                            }
                        }
                        else
                        {
                            Debug.Log("ObjectCollisionが付いてないよ!");
                        }
                    }
                    else if (moveFloor)
                    {
                        moveObj = collision.gameObject.GetComponent<MoveObject>();
                    }
                }
                else
                {
                    if (enemy)
                    {
                        ReceiveDamage(true);
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == moveFloorTag)
        {
            //動く床から離れた
            moveObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if (collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }
    #endregion
}
=====================

GManager.cs BK
=====================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    [Header("スコア")] public int score;
    [Header("コインスコア")] public int coinscore;
    [Header("現在のステージ")] public int stageNum;
    [Header("現在の復帰位置")] public int continueNum;
    [Header("現在の残機")] public int heartNum;
    [Header("デフォルトの残機")] public int defaultHeartNum;
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public bool isStageClear = false;

    private AudioSource audioSource = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 残機を１つ増やす
    /// </summary>
    public void AddHeartNum()
    {
        if (heartNum < 99)
        {
            ++heartNum;
        }
    }

    /// <summary>
    /// 残機を１つ減らす
    /// </summary>
    public void SubHeartNum()
    {
        if (heartNum > 0)
        {
            --heartNum;
        }
        else
        {
            isGameOver = true;
        }
    }

    /// <summary>
    /// 最初から始める時の処理
    /// </summary>
    public void RetryGame()
    {
        isGameOver = false;
        heartNum = defaultHeartNum;
        score = 0;
        stageNum = 1;
        continueNum = 0;
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);

        }
        else
        {
            Debug.Log("オーディオソースが設定されていません");
        }
    }
}
=====================

BallButton.cs BK
=====================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    public GameObject soccerBall;
    private ObjectCollision oc;
    private PlayerC sc;
    private CircleCollider2D col;

    private bool on = false;
    public string PlayerTag = "Player";
    

    void Start()
    {
        //GameObject ContentItem = GameObject.Find("Player");
        //GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
        // 取得した戻り値の活用例
        //cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
        //cloneObject.transform.parent = ContentItem.transform;
        //cloneObject.transform.parent = this.transform; // GameManagerを親に指定
        //cloneObject.transform.position = new Vector3(2.0f, 0.0f, 0.0f); // 座標を変更

        
        // 移動させたいオブジェクトを取得
        //GameObject parent = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //GameObject child1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //child1.transform.parent = parent.transform;


        //soccerBall2オブジェクトのクラスを参照
        //oc = GameObject.Find("soccerBall2").GetComponent<ObjectCollision>();
        
        //CubeScriptの変数にアクセスする
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnClick();
        }
    }

    

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        GameObject search = GameObject.Find("soccerBall2");
        bool n = (bool)search;


        if (n == true)
        {
            sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();

            if (sc.isOn)
            {

                // 移動させたいオブジェクトを取得
                GameObject obj = GameObject.Find("soccerBall2");
                // オブジェクトを移動
                obj.transform.localPosition += new Vector3(3 * Time.deltaTime, 0.08f, 0);
                //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
                InvokeRepeating("OnClick", 0, 0);
                on = true;
            }
            else if (sc.isPlayerExit)
            {
                // 移動させたいオブジェクトを取得
                GameObject obj = GameObject.Find("soccerBall2");
                // オブジェクトを移動
                obj.transform.localPosition += new Vector3(3 * Time.deltaTime, 0.08f, 0);
                //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
                InvokeRepeating("OnClick", 0, 0);

                //Invokeを止める
                Invoke("Cancel", 1);

            }
            n = false;
            return;
        }
        else
        {
            Debug.Log(false);
        }
    }

    void Cancel()
    {
        //Invokeで実行しているOnClick関数を3秒後に停止する
        CancelInvoke("OnClick");
        //関数名を記述しなければInvoke系全てを停止する
        //CancelInvoke();
        on = false;
        sc.isPlayerExit = false;

        if (sc.isSbExit == true)
        {
            // 移動させたいオブジェクトを取得
            GameObject obj = GameObject.Find("soccerBall2");
            obj.gameObject.transform.parent = null;
        }

    }
}





//bom.GetComponent<Rigidbody2D>().angularVelocity = Vector3.forward * 7;	// 手榴弾を回転速度を代入.

// CubeプレハブをGameObject型で取得
//GameObject obj = (GameObject)Resources.Load("soccerBall");
// Cubeプレハブを元に、インスタンスを生成
//GameObject cloneObject = Instantiate(obj, this.transform.position, Quaternion.identity);
=====================
↑サッカーボール蹴るアニメーション入れる前のスクリプトバックアップ



↓パクるやーつプレイヤースタンド（Player.cs）
anim.Play("player_stand");
anim.Play("player_keri”);

↓↑がなにやってるか（Player.cs）
private Animator anim = null;
anim = GetComponent<Animator>();

↓ゲームオブジェクトを探してスクリプトをゲットコンポーネントするやつ(BallButton.cs)
private PlayerC sc;
sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();
 if (sc.isOn)

↓置き換えるとこーなる(BallButton.cs)






















































































