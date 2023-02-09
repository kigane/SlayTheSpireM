# SlayTheSpireM

尝试复刻杀戮尖塔

## 问题记录

打包后游戏无法开始。在编辑器内正常，build and run 正常，只有 build 后再打开 exe 文件时有问题。原因是读取 Sqlite 数据库文件失败，Assets 目录只在编辑器中存在，build and run 时也存在。build 后就不存在了。因此找不到文件。

解决方法：
将 Sqlite 的读取路径"Data Source=Assets/DB/SlayTheSpire.db"中的 Assets 用 Application.dataPath 代替，并且手动复制 DB/SlayTheSpire.db 文件到打包后生成的 #GameName_Data 目录下。
