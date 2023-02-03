import json

import pandas as pd

EXCEL_PATH = "Assets/Resources/Configs/Cards.xlsx"
TMP_PATH = "Assets/Resources/Configs/card_config.json"
JSON_PATH = "Assets/Resources/Configs/cards.json"


def excel_to_json():
    df = pd.read_excel(EXCEL_PATH, header=0)
    # 去除空行
    df.dropna(axis=0, how="any", inplace=True)
    # 数据类型转换
    df["Id"] = df["Id"].astype('int32')
    df["Energy"] = df["Energy"].astype('int32')
    df["Values"] = df["Values"].astype('str')
    df["ActionIds"] = df["Values"].astype('str')
    df.replace({
        "Common": 0,
        "Uncommon": 1,
        "Rare": 2,
        "Attack": 0,
        "Skill": 1,
        "Power": 2,
        "Ironclad": 0,
        "Silent": 1,
        "Defect": 2,
        "Watcher": 3,
    }, inplace=True)
    print(df)
    with open(TMP_PATH, "w") as f:
        df.transpose().to_json(f)


def json_dict_to_list():
    with open(TMP_PATH, "rb") as f:
        tables = json.load(f)

    json_lst = []
    for k, v in tables.items():
        json_lst.append(v)

    with open(JSON_PATH, "w") as f:
        json.dump(json_lst, f)


if __name__ == "__main__":
    excel_to_json()
    json_dict_to_list()
