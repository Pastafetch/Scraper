# Scraper

あるニュースサイトの記事を全て収集しようとするプログラム。
Abotライブラリを使ってクローリングを行い、記事URLを判別してデータベースに格納していく


問題：
Author nameのスクレイピングがうまくいっていない
再起動した場合、訪問済みURLも再度クローリングしてしまう。（DBには入れないようにしてあるがクロールはやっちゃってる...)
一記事ごとにコネクションブチブチしてるけどいいの？


To do:
Webアプリとして閲覧できるようにしたい
クローラの設定は外部fileに書く

