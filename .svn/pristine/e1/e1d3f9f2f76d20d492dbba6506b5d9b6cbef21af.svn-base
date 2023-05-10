using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tosen2
{
    public class printInfoBeen
    {
        // 印刷用の宛名「様/ご家族様/ご一同様」をつける定数。
        public const int sama = 0;
        public const int kazoku = 1;
        public const int gotiti = 2;

        // 印刷用の記憶クラス
        public string prtName { set; get; }
        public string prtAddr { set; get; }
        public string prtZip { set; get; }
        public string prtComp { set; get; }
        public string prtAteName { set; get; }
        public long prtSetaiCnt { set; get; }
        public void setPrtName(int line)
        {
            switch (line)
            {
                case 0: //様
                    this.prtAteName = "様";
                    break;
                case 1: //ご家族様
                    this.prtAteName = "ご家族様";
                    break;
                case 2: //ご一同様
                    this.prtAteName = "ご一同様";
                    break;
            }
        }
    }
}
