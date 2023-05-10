using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tosen2
{
    public class basicInfo
    {
        public int setaiNo { set; get; }
        public string zipCode { set; get; }
        public string address { set; get; }
        public string name { set; get; }
        public string nameRubi { set; get; }
        private dbClass db { set; get; }
        public basicInfo()
        {
            this.db = new dbClass();
        }

        public void get(int setaiNo)
        {
            string mSql = "";

            this.db.cn = new MySql.Data.MySqlClient.MySqlConnection(this.db.cnnStr);
            mSql = string.Format("select setaiNo, zipCode, address, name, nameRubi from {0}.baseAddr where setaiNo={1} ",this.db.database,setaiNo);

            using(var cmd = this.db.cn.CreateCommand())
            {
                try
                {
                    this.db.cn.Open();
                    cmd.CommandText = mSql;
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        this.setaiNo = int.Parse(reader[0].ToString());
                        this.zipCode = reader[1].ToString();
                        this.address = reader[2].ToString();
                        this.name = reader[3].ToString();
                        this.nameRubi = reader[4].ToString();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Boolean check(int setaiNo)
        {
            Boolean retVal = false;
            string mSql = "";
            int mCnt = 0;

            this.db.cn = new MySql.Data.MySqlClient.MySqlConnection(this.db.cnnStr);
            mSql = string.Format("select count(*) from {0}.baseAddr where setaiNo={1} ", this.db.database, setaiNo);

            using(var cmd = this.db.cn.CreateCommand())
            {
                try
                {
                    this.db.cn.Open();
                    cmd.CommandText = mSql;
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        mCnt = int.Parse(reader[0].ToString());

                        if (mCnt != 0)
                        {
                            retVal = true;
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

            return retVal;
        }

        public int length(int setaiNo)
        {
            int retVal = 0;
            string mSql = "";

            this.db.cn = new MySql.Data.MySqlClient.MySqlConnection(this.db.cnnStr);
            mSql = string.Format("select count(*) from {0}.baseAddr where setaiNo={1} ", this.db.database, setaiNo);

            using(var cmd = this.db.cn.CreateCommand())
            {
                try
                {
                    this.db.cn.Open();
                    cmd.CommandText = mSql;
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal = int.Parse(reader[0].ToString());
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return retVal;
        }

        public Boolean add()
        {
            Boolean retVal = false;
            string mSql = "";

            this.db.cn = new MySql.Data.MySqlClient.MySqlConnection(this.db.cnnStr);
            mSql = string.Format("insert into {0}.baseAddr(setaiNo,zipCode, address, name, nameRubi) values({1}, '{2}', '{3)', '{4}', '{5}') ");

            using(var cmd = this.db.cn.CreateCommand())
            {
                try
                {
                    this.db.cn.Open();
                    cmd.CommandText = mSql;
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

            return retVal;
            
        }

    }
}
