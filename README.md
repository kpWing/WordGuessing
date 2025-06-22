# 単語当てゲーム

## 実行方法
* publish以下にOSプラットフォーム別のコンパイル済アプリケーションが配置してあります。
* Windows用実行ファイルのみ動作確認済です。Linux/MacOS向けのアプリケーションは確認可能環境が用意できず、動作未確認です。

### 実行イメージ
![image-fail](https://github.com/user-attachments/assets/c8cc43dd-3726-4ec8-87ce-b8e8acf369e3)
<br/>
![image-success](https://github.com/user-attachments/assets/91a1b963-d010-42c4-869f-db4de9a5b200)

## ソース概要
* Applicationフォルダ
  * 実行形式(ネイティブアプリ、Web、コンソール等)に依存しない、ゲーム自体の基幹ロジック・制御処理のレイヤ。
* Interfacesフォルダ
  * UIの実装変更を想定し、具体的な実装を差し替え可能にするためのインターフェース群。
* Modelsフォルダ
  * 処理を持たないモデルクラス。
* UIフォルダ
  * コンソールでの実行に依存する処理。今回はコンソール画面のI/Oによるユーザとのやり取りを担う。(Interfaces以下にあるインターフェースの実装)
