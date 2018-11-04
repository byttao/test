using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace testform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Data> datas = new List<Data>();//定义1个列表用于保存结果
            HtmlWeb hw = new HtmlWeb();
            hw.OverrideEncoding = Encoding.GetEncoding("UTF-8");
            HtmlDocument htmlDocument = hw.Load(@"D:\lenovo\Desktop\税金.html");
            HtmlNodeCollection collection = htmlDocument.DocumentNode.SelectSingleNode("//table[@id='frm_dfsf']").ChildNodes;//跟Xpath一样，轻松的定位到相应节点下
            foreach (HtmlNode node in collection)
            {
                
                //去除\r\n以及空格，获取到相应td里面的数据13
                string[] line = node.InnerText.Split(new char[] { '\r', '\n','\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                //如果符合条件，就加载到对象列表里面
                if (line.Length == 18)
                    datas.Add(new Data()
                    {
                        申报方式 = line[0],
                        税票号 = line[1],
                        征收项目 = line[2],
                        征收品目 = line[3],
                        申报日期 = line[4],
                        税款所属期始 = line[5],
                        税款所属期止 = line[6],
                        计税依据 = line[7],
                        税率 = line[8],
                        应纳税额 = line[9],
                        已缴税额 = line[10],
                        实际应缴税额 = line[11],
                        缴款日期 = line[12],
                        处理状态 = line[13],
                        扣款返回信息 = line[14],
                        缴款方式 = line[15],
                        银行帐号 = line[16],
                        入库日期 = line[17],
                    });
            }

            //循环输出查看结果是否正确
            foreach (var v in datas)
            {
                richTextBox1.Text=richTextBox1.Text + System.Environment.NewLine + string.Join(",", v.申报方式, v.税票号, v.征收项目, v.征收品目, v.申报日期, v.税款所属期始, v.税款所属期止, v.计税依据,
                    v.税率, v.应纳税额, v.已缴税额, v.实际应缴税额, v.缴款日期, v.处理状态, v.扣款返回信息, v.缴款方式, v.银行帐号, v.入库日期
                );
            }
        }
    }
    /// <summary>
    /// 定义的实体类用于接收数据
    /// </summary>
    public class Data
    {
        public string 申报方式 { get; set; }
        public string 税票号 { get; set; }
        public string 征收项目 { get; set; }
        public string 征收品目 { get; set; }
        public string 申报日期 { get; set; }
        public string 税款所属期始 { get; set; }
        public string 税款所属期止 { get; set; }
        public string 计税依据 { get; set; }
        public string 税率 { get; set; }
        public string 应纳税额 { get; set; }
        public string 已缴税额 { get; set; }
        public string 实际应缴税额 { get; set; }
        public string 缴款日期 { get; set; }
        public string 处理状态 { get; set; }
        public string 扣款返回信息 { get; set; }
        public string 缴款方式 { get; set; }
        public string 银行帐号 { get; set; }
        public string 入库日期 { get; set; }

    }
}
