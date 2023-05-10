using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tosen2
{
    public class kindInfoDTO
    {
        public string kindName { set; get; }
        public int kind { set; get; }
        private dbClass db { set; get; }
        public List<kindInfoDTO> kindDat { set; get; }
        public kindInfoDTO()
        {
            this.db = new dbClass();

        }

        public void refresh()
        {
            // 所属データの読み込み
            getAllList();
        }

        public int find(string line)
        {
            int retVal = 999;
            int mCnt = 0;
            int mMax = 0;
            mMax = this.kindDat.Count();

            if (mCnt != mMax)
            {
                for (mCnt = 0; mCnt < mMax; mCnt++)
                {
                    if (this.kindDat[mCnt].kindName == line)
                    {
                        retVal = mCnt;
                        break;
                    }
                }
            }

            return retVal;
        }
        public string find(int line)
        {
            return this.kindDat[line].kindName;
        }
        public List<kindInfoDTO> getList()
        {
            List<kindInfoDTO> retVal = new List<kindInfoDTO>();
            string mSql = "";

            this.db.cn = new MySql.Data.MySqlClient.MySqlConnection(this.db.cnnStr);
            mSql = string.Format("select kind, kindName from {0}.kind order by kind", this.db.database);

            using(var cmd = this.db.cn.CreateCommand())
            {
                try
                {
                    this.db.cn.Open();
                    cmd.CommandText = mSql;
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kindInfoDTO mDat = new kindInfoDTO();
                            mDat.kind = int.Parse(reader[0].ToString());
                            mDat.kindName = reader[1].ToString();
                            retVal.Add(mDat);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            this.kindDat = retVal; 
            return retVal;
        }
        private void getAllList()
        {
            List<kindInfoDTO> retVal = new List<kindInfoDTO>();
            string mSql = "";

            this.db.cn = new MySql.Data.MySqlClient.MySqlConnection(this.db.cnnStr);
            mSql = string.Format("select kind, kindName from {0}.kind order by kind", this.db.database);

            using(var cmd = this.db.cn.CreateCommand())
            {
                try
                {
                    this.db.cn.Open();
                    cmd.CommandText = mSql;
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kindInfoDTO mDat = new kindInfoDTO();
                            mDat.kind = int.Parse(reader[0].ToString());
                            mDat.kindName = reader[1].ToString();
                            retVal.Add(mDat);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            this.kindDat = retVal; 
        }
    }
}
