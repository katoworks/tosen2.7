using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tosen2
{
    class dbAccDAO
    {
        public memberInfoDTO mBase { set; get; }
        public famiInfoDTO mFami { set; get; }
        public comInfoDTO mCom { set; get; }
        public List<chgSrchDTO> mSrch { set; get; }
        public basicInfo basInfo { set; get; }
        public List<famiAddr> famiInfo { set; get; }
        public List<comInfoDTO> comInfo { set; get; }
        public List<chgSrchDTO> readInfo { set; get; }
        public cominfo cominfoData { set; get; }

        public string ipaddr { set; get; }
        public string userid { set; get; }
        public string pasword { set; get; }
        public string database { set; get; }
        public string cnnStr;
        public MySqlConnection cn;
        private string listFileName = @".\conf\tosen.txt";

        public dbAccDAO()
        {
            // 設定ファイル読み込み
            confInit();

            cnnStr = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Charset=utf8;",
                this.ipaddr,
                this.database,
                this.userid,
                this.pasword);
        }
        private void confInit()
        {
            char[] sep = { '=' };
            string mLineBuff;

            // ファイルの読み込み
            System.IO.StreamReader sr = new System.IO.StreamReader(listFileName,Encoding.GetEncoding("shift_jis"));

            while ((mLineBuff = sr.ReadLine()) != null)
            {
                var mTmpSpl = mLineBuff.Split(sep);
                switch (mTmpSpl[0])
                {
                    case "host":
                        this.ipaddr = mTmpSpl[1];
                        break;
                    case "user":
                        this.userid = mTmpSpl[1];
                        break;
                    case "pass":
                        this.pasword = mTmpSpl[1];
                        break;
                    case "db":
                        this.database = mTmpSpl[1];
                        break;
                }
            }
            sr.Close();
        }

        public List<chgSrchDTO> Get(string name, string nameRubi, string addr)
        {
            List<chgSrchDTO> retVal = new List<chgSrchDTO>();
            string mStr = "select a.setaiNo,a.name,a.nameRubi, a.zipCode, a.address, b.comName, d.kind, d.kindName";
            mStr += " from {0}.baseaddr a left join {0}.comtable b on a.setaiNo=b.setaiNo ";
            mStr += " left join {0}.famiaddr c on a.setaiNo=c.setaiNo";
            mStr += " left join {0}.kind d on c.kind=d.kind";
            mStr += " where ";
            mStr += " a.name Like '%{1}%' and";
            mStr += " a.nameRubi Like '%{2}%' and";
            mStr += " a.address Like '%{3}%'";
            mStr += " group by ";
            mStr += "  a.setaiNo, a.name, a.nameRubi, a.zipCode, a.address";
            mStr += " order by a.setaiNo";
            string sql = string.Format(mStr, this.database, name, nameRubi, addr);

            int mCnt = 0;
            string kindName = "地区世話人";
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chgSrchDTO tmpDAO = new chgSrchDTO();
                            tmpDAO.setaiNo = int.Parse(reader[0].ToString());
                            tmpDAO.name = reader[1].ToString();
                            tmpDAO.nameRubi = reader[2].ToString();
                            tmpDAO.zip1 = reader[3].ToString().Substring(0, 3);
                            string mTmpStr = reader[3].ToString().Substring(4);
                            if (mTmpStr.Length < 4)
                            {
                                tmpDAO.zip2 = "0" + mTmpStr;
                            }
                            else
                            {
                                mTmpStr = reader[3].ToString().Substring(4, 4);
                            }
                            tmpDAO.zip2 = mTmpStr;
                            tmpDAO.address = reader[4].ToString();
                            tmpDAO.comName = reader[5].ToString();
                            if (reader[6].ToString().Length == 0) 
                            {
                                tmpDAO.kind = 0;
                                tmpDAO.kindName = kindName;
                            }
                            else
                            {
                                tmpDAO.kind = int.Parse( reader[6].ToString());
                                tmpDAO.kindName = reader[7].ToString();
                            }
                            retVal.Add(tmpDAO);
                            mCnt++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }

            return retVal;
        }

        public basicInfo getBase(int setaiNo)
        {
            basicInfo retVal = new basicInfo();

            string sql = string.Format("select setaiNo, zipCode, address, name, nameRubi from {0}.baseAddr where setaiNo={1}", database, setaiNo);
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        retVal.setaiNo = int.Parse(reader[0].ToString());
                        retVal.zipCode = reader[1].ToString();
                        retVal.address = reader[2].ToString();
                        retVal.name = reader[3].ToString();
                        retVal.nameRubi = reader[4].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }

            return retVal;
        }
        public List<chgSrchDTO> getFami(int setaiNo)
        {
            List<chgSrchDTO> retVal = new List<chgSrchDTO>();
            this.readInfo = new List<chgSrchDTO>();
            string mTmpSql = "select a.setaiNo,b.famiNo, b.name, b.nameRubi, b.tel, a.zipCode, a.address, c.comName, b.kind, d.kindName, comTel, c.comZip, c.comKata, c.comAddr";
            mTmpSql += " from {0}.baseaddr a";
            mTmpSql += "  inner join {0}.famiaddr b on a.setaiNo=b.setaiNo";
            mTmpSql += "   left join {0}.comtable c on (a.setaiNo=c.setaiNo And b.famiNo=c.famiNo)";
            mTmpSql += "   inner join {0}.kind d on b.kind=d.kind";
            mTmpSql += " where a.setaiNo={1} ";
            mTmpSql += " group by a.setaiNo,b.famiNo, b.name, b.nameRubi, a.zipCode, a.address, c.comName, b.kind, d.kindName, comTel, c.comZip, c.comKata, c.comAddr;";

            string sql = string.Format(mTmpSql, database, setaiNo);
            try
            {
                this.cn = new MySqlConnection(this.cnnStr);
                this.cn.Open();
                using (var cmd = this.cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chgSrchDTO tmpFM = new chgSrchDTO();
                            tmpFM.setaiNo = int.Parse(reader[0].ToString());
                            tmpFM.famiNo = int.Parse(reader[1].ToString());
                            tmpFM.name = reader[2].ToString();
                            tmpFM.nameRubi = reader[3].ToString();
                            tmpFM.tel = reader[4].ToString();
                            tmpFM.zip1 = reader[5].ToString().Substring(0, 3);
                            tmpFM.zip2 = reader[5].ToString().Substring(4, 4);
                            tmpFM.address = reader[6].ToString();
                            tmpFM.comName = reader[7].ToString();
                            tmpFM.kind = int.Parse(reader[8].ToString());
                            tmpFM.kindName = reader[9].ToString();
                            if (reader[7].ToString() != "")
                            {
                                tmpFM.conpanyFlg = true;
                                tmpFM.comTel = reader[10].ToString();
                                tmpFM.comZip1 = reader[11].ToString().Substring(0, 3);
                                tmpFM.comZip2 = reader[11].ToString().Substring(4, 4);
                                tmpFM.comKata = reader[12].ToString();
                                tmpFM.comAddr = reader[13].ToString();
                            }
                            else
                            {
                                tmpFM.conpanyFlg = false;
                            }
                            retVal.Add(tmpFM);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.cn.Close();
            }

            this.readInfo = retVal;

            Set();
            return retVal;
        }
        private void Set()
        {
            this.basInfo = new basicInfo();
            this.famiInfo = new List<famiAddr>();
            this.comInfo = new List<comInfoDTO>();

            //memberInfoDTOに振り分け
            this.basInfo.setaiNo = this.readInfo[0].setaiNo;
            this.basInfo.zipCode = this.readInfo[0].zip1 + "-" + this.readInfo[0].zip2;
            this.basInfo.address = this.readInfo[0].address;
            this.basInfo.name = this.readInfo[0].name;
            this.basInfo.nameRubi = this.readInfo[0].nameRubi;

            //famiAddrに振り分け
            foreach(chgSrchDTO tmpReadData in this.readInfo)
            {
                famiAddr tmpFami = new famiAddr();
                tmpFami.setaiNo = tmpReadData.setaiNo;
                tmpFami.famiNo = tmpReadData.famiNo;
                tmpFami.name = tmpReadData.name;
                tmpFami.nameRubi = tmpReadData.nameRubi;
                tmpFami.tel = tmpReadData.tel;
                tmpFami.kind = tmpReadData.kind;
                if (tmpReadData.comName != "")
                {
                    tmpFami.conpnyFlg = true;
                    
                    //comInfo作成
                    comInfoDTO tmpCom = new comInfoDTO();
                    tmpCom.setaiNo = tmpReadData.setaiNo;
                    tmpCom.famiNo = tmpReadData.famiNo;
                    tmpCom.comName = tmpReadData.comName;
                    tmpCom.tel = tmpReadData.comTel;
                    tmpCom.comKata = tmpReadData.comKata;
                    tmpCom.comZip1 = tmpReadData.comZip1;
                    tmpCom.comZip2 = tmpReadData.comZip2;
                    this.comInfo.Add(tmpCom);

                    // 会社情報取得
                    this.cominfoData = new cominfo();
                    this.cominfoData.setaiNo = tmpReadData.setaiNo;
                    this.cominfoData.famiNo = tmpReadData.famiNo;
                    this.cominfoData.comName = tmpReadData.comName;
                    this.cominfoData.comTel = tmpReadData.comTel;
                    this.cominfoData.comKata = tmpReadData.comKata;
                    this.cominfoData.comZip = tmpReadData.comZip1 + "-" + tmpReadData.comZip2;
                    this.cominfoData.comAddr = tmpReadData.address;
                }
                else
                {
                    tmpFami.conpnyFlg = false;
                }
                tmpFami.katagaki = tmpReadData.comKata;
                this.famiInfo.Add(tmpFami);
            }
        }
    }
}
