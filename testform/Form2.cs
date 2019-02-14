using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace testform
{
    public partial class Form2 : Form
    {
        private Bitmap stbig =new Bitmap( @"E:\信息化建设\电子税务局登陆\1.jpg");

        private Bitmap stsmall =new Bitmap( @"E:\信息化建设\电子税务局登陆\1.png");

        private string token_yzm;
        HttpHelper _httpHelper;
        HttpItem _httpItem;
        HttpResult _httpResult;
        private decimal trail_x;
        List<string> _cookie = new List<string>();
        string StrUserAgent =
            "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 10.0; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729";

        public Form2()
        {
            InitializeComponent();
        }

        //0.10433227661300084
        //0.6707072836513124
        private void button1_Click(object sender, EventArgs e)
        {
            shibie();
        }

        void shibie()
        {

            Bitmap big = new Bitmap(stbig);
            Bitmap small = new Bitmap(stsmall);
            //获取图像的BitmapData对像 
            BitmapData data = small.LockBits(new Rectangle(5, 0, 1, small.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            //循环处理
            int hang = 0;
            int shu = 0;
            unsafe
            {
                byte* ptr = (byte*) (data.Scan0);
                for (int i = 0; i < data.Height; i++)
                {
                    if (ptr[0] != 0 || ptr[1] != 0 || ptr[2] != 0)
                    {
                        hang = i + 2;
                        break;
                    }
                    ptr += data.Stride;
                }
            }

            small.UnlockBits(data);
            smallheng(hang);
            hang += 10;
            data = big.LockBits(new Rectangle(0, hang, big.Width, 1), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* ptr = (byte*) (data.Scan0);
                for (int i = 0; i < data.Width; i++)
                {
                    if (ptr[0] > 250 && ptr[1] > 250 && ptr[2] > 250)
                    {
                        shu = i;
                        break;
                    }
                    ptr += 3;
                }
            }

            shu += 10;
            bigshu(shu, hang);
            trail_x = (shu / 590m * 358m) * (358m - 40m - 15m) / (358m - 40m) / 358m;
            //MessageBox.Show(trail_x.ToString("0.#################"));

        }

        void smallheng(int heng)
        {

            Bitmap bmp = new Bitmap(stsmall);
            Graphics g = Graphics.FromImage(bmp);
            //直接用Clear函数清除绘图表面而不用像素填充
            Pen black_pen = new Pen(Color.Black, 1);
            g.DrawLine(black_pen, 0, heng, bmp.Width-1, heng);//x坐标轴
            //相对于pictureBox1,而不是相对于form1,在0,0处绘制
            g.DrawImage(bmp, 0, 0);
            pSmall.Image = bmp;
            g.Dispose();
        }

        void bigshu(int shu,int heng)
        {

            Bitmap bmp = new Bitmap(stbig);
            Graphics g = Graphics.FromImage(bmp);
            //直接用Clear函数清除绘图表面而不用像素填充
            Pen black_pen = new Pen(Color.Black, 1);
            g.DrawLine(black_pen, 0, heng, bmp.Width-1, heng);//x坐标轴
            g.DrawLine(black_pen, shu, 0, shu, bmp.Height-1);//x坐标轴
            //相对于pictureBox1,而不是相对于form1,在0,0处绘制
            g.DrawImage(bmp, 0, 0);
            pBig.Image = bmp;
            g.Dispose();
        }

        Bitmap Base64toImage(string strbase64)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                return (Bitmap)Image.FromStream(ms);
                
            }
            catch
            {

            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {           _httpHelper = new HttpHelper();

            _httpItem = new HttpItem()
            {
                URL = "https://wsbsfwt2.xmtax.gov.cn/tlogin/index.do", //访问首页
                IsToLower = false, //得到的HTML代码是否转成小写     可选项默认转小写
                UserAgent = StrUserAgent,
            };
            _httpResult = _httpHelper.GetHtml(_httpItem);
            _cookie.Add(_httpResult.Cookie); //cookieA

            Getchecktjts("", _cookie[0]);
            _httpItem = new HttpItem()
            {
                URL = "https://wsbsfwt2.xmtax.gov.cn/tlogin/getImgTrailCode.do", //访问首页
                Method="Post",
                Referer = "https://wsbsfwt2.xmtax.gov.cn/tlogin/index.do", //来源URL     可选项
                IsToLower = false, //得到的HTML代码是否转成小写     可选项默认转小写
                Cookie = _cookie[0],
                UserAgent = StrUserAgent,
            };
            _httpItem.Header.Add("x-requested-with", "XMLHttpRequest");
            _httpResult = _httpHelper.GetHtml(_httpItem);
            JObject rss = JObject.Parse(_httpResult.Html);
            stbig=Base64toImage( (string)rss["base64image"]);
            stsmall = Base64toImage((string)rss["base64image_slide"]);
            token_yzm = (string) rss["token_yzm"];
            shibie();

            _httpItem = new HttpItem()
            {
                URL = "https://wsbsfwt2.xmtax.gov.cn/tlogin/checkImgTrailCode.do", //访问首页
                Method = "Post",
                Referer = "https://wsbsfwt2.xmtax.gov.cn/tlogin/index.do", //来源URL     可选项
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8", //返回类型    可选项有默认值
                IsToLower = false, //得到的HTML代码是否转成小写     可选项默认转小写
                Cookie = _cookie[0],
                UserAgent = StrUserAgent,
                Postdata= $"trail_x={trail_x.ToString("0.#################")}&trail_token={token_yzm}"
            };
            _httpItem.Header.Add("x-requested-with", "XMLHttpRequest");
            _httpResult = _httpHelper.GetHtml(_httpItem);
            rss = JObject.Parse(_httpResult.Html);
            MessageBox.Show((string)rss["msg"]);
        }

        /// <summary>
        /// 税务局认证网址
        /// </summary>
        /// <param name="referer">提交网址</param>
        /// <param name="cookie">传入cookie</param>
        private void Getchecktjts(string referer, string cookie)
        {
            _httpItem = new HttpItem
            {
                URL = "https://wsbsfwt2.xmtax.gov.cn/common/checktjts.do", //URL     必需项
                Method = "post", //URL     可选项 默认为Get
                Cookie = cookie,
                IsToLower = false, //得到的HTML代码是否转成小写     可选项默认转小写
                UserAgent = StrUserAgent,
                Postdata = @"tjlx=DLXZ", //Post数据
            };
            if (referer != "")
            {
                _httpItem.Referer = referer;
            }
            _httpResult = _httpHelper.GetHtml(_httpItem);
        }
    }
}
