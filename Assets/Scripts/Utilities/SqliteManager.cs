using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;

namespace SlayTheSpireM
{
    public class SqliteManager
    {
        static readonly string ConnectionString = "Data Source=Assets/DB/SlayTheSpire.db";

        public static List<CardConfig> QueryCardConfigByRole(int roleType)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            List<CardConfig> cardConfigs = new();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Card as c INNER JOIN CardEffect AS ce on c.Id = ce.CardId WHERE Role=@type or Role=0 ORDER by Id";
                command.Parameters.AddWithValue("@type", roleType);
                command.Prepare();

                using IDataReader reader = command.ExecuteReader();
                CardConfig currConfig = null;
                CardConfig prevConfig = null;
                while (reader.Read())
                {
                    currConfig = new CardConfig()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Energy = reader.GetInt32(2),
                        SpritePath = reader.GetString(3),
                        Rarity = reader.GetInt32(4),
                        CardType = reader.GetInt32(5),
                        RoleType = reader.GetInt32(6),
                        EffectIds = reader.GetInt32(8).ToString(),
                        Values = reader.GetInt32(9).ToString(),
                    };

                    if (prevConfig == null)
                    {
                        prevConfig = currConfig;
                        continue;
                    }

                    if (currConfig.Id == prevConfig.Id)
                    {
                        // 合并同Id的多行记录
                        currConfig.EffectIds += "," + prevConfig.EffectIds;
                        currConfig.Values += "," + prevConfig.Values;
                    }
                    else
                    {
                        cardConfigs.Add(prevConfig);
                    }
                    prevConfig = currConfig;
                }
                // 添加最后一个记录
                cardConfigs.Add(currConfig);
                reader.Close();
            }

            connection.Close();
            return cardConfigs;
        }
    }
}
