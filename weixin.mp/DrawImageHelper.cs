using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace weixin.mp
{
    public static class DrawImageHelper
    {
        /// <summary>
        /// 表格列名
        /// </summary>
        private static readonly string[] tableColumnNames = new string[]
        {
            "第一列名","第二列名","第三列名","第四列名"
        };

        /// <summary>
        /// 生成图片
        /// </summary>
        public static void InitImage()
        {
            var currentDir=Environment.CurrentDirectory;
            var year =DateTime.Now.Year;
            if (!Directory.Exists(Path.Combine(currentDir, year.ToString())))
            {
                Directory.CreateDirectory(Path.Combine(currentDir, year.ToString()));
            }
            var imgName = Path.Combine(currentDir, year.ToString(), $"{Guid.NewGuid().ToString("N")}.png");
            File.WriteAllBytes(imgName, GenerateImage());
        }

        /// <summary>
        /// 绘图
        /// </summary>
        /// <returns></returns>
        private static byte[] GenerateImage()
        {
            Bitmap bitmap = InitBitmap();
            var model = InitModel();
            if (model.data.Count > 19)
            {
                int height = 32 * (model.data.Count + 2);
                bitmap = InitBitmap(600, height);
            }
            Graphics graphics = InitGraphics(bitmap);
            InitTableColumn(graphics, model);
            InitTableTop1Border(bitmap, graphics, model);
            InitTableDataBorder(bitmap, graphics, model);

            for (int i = 0; i < model.data.Count; i++)
            {
                Font tableCellFont = new Font(FontFamily.GenericSerif, 14, FontStyle.Regular, GraphicsUnit.Pixel);

                graphics.DrawString(model.data[i].student_name, tableCellFont, new SolidBrush(Color.Black), 0, (i + 2) * 35);
                graphics.DrawString(model.data[i].createtime, tableCellFont, new SolidBrush(Color.Black), 1 * 32 * model.colunms[1].remark.Length, (i + 2) * 35);
                graphics.DrawString(model.data[i].user_name, tableCellFont, new SolidBrush(Color.Black), 2 * 32 * model.colunms[2].remark.Length, (i + 2) * 35);
                graphics.DrawString(model.data[i].driving_school, tableCellFont, new SolidBrush(Color.Black), 3 * 32 * model.colunms[3].remark.Length, (i + 2) * 35);
            }
            using var ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private static byte[] GenerateImage(TableModel model)
        {
            Bitmap bitmap = InitBitmap();
            if (model.data.Count > 19)
            {
                int height = 32 * (model.data.Count + 2);
                bitmap = InitBitmap(600, height);
            }
            Graphics graphics = InitGraphics(bitmap);
            InitTableColumn(graphics, model);
            InitTableTop1Border(bitmap, graphics, model);
            InitTableDataBorder(bitmap, graphics, model);

            for (int i = 0; i < model.data.Count; i++)
            {
                Font tableCellFont = new Font(FontFamily.GenericSerif, 14, FontStyle.Regular, GraphicsUnit.Pixel);
                graphics.DrawString(model.data[i].student_name, tableCellFont, new SolidBrush(Color.Black), 0, (i + 2) * 35);
                graphics.DrawString(model.data[i].createtime, tableCellFont, new SolidBrush(Color.Black), 1 * 32 * model.colunms[1].remark.Length, (i + 2) * 35);
                graphics.DrawString(model.data[i].user_name, tableCellFont, new SolidBrush(Color.Black), 2 * 32 * model.colunms[2].remark.Length, (i + 2) * 35);
                graphics.DrawString(model.data[i].driving_school, tableCellFont, new SolidBrush(Color.Black), 3 * 32 * model.colunms[3].remark.Length, (i + 2) * 35);
            }
            using var ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public static Bitmap InitBitmap(int imageWidth = 600, int imageHeight = 600)
        {
            Bitmap bitmap = new Bitmap(imageWidth, imageHeight);
            return bitmap;
        }

        public static Graphics InitGraphics(Bitmap bitmap, int imageWidth = 600, int imageHeight = 600)
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, imageWidth, imageHeight);
            return graphics;
        }

        /// <summary>
        /// 表头行列名
        /// </summary>
        /// <param name="graphics"></param>
        public static void InitTableColumn(Graphics graphics, TableModel data)
        {
            Font tableColumnFont = new Font(FontFamily.GenericSerif, 20, FontStyle.Regular, GraphicsUnit.Pixel);

            for (int i = 0; i < data.colunms.Count; i++)
            {
                //首行表头画图
                graphics.DrawString(
                    data.colunms[i].remark,
                    tableColumnFont,
                    new SolidBrush(Color.Black),
                    i * 32 * data.colunms[i].remark.Length,
                    35);
            }
        }

        /// <summary>
        /// 表格表头边框线
        /// </summary>
        /// <param name="graphics"></param>
        public static void InitTableTop1Border(Bitmap bitmap, Graphics graphics, TableModel data)
        {
            using (Pen pen = new Pen(new SolidBrush(Color.LightGray), 1))
            {
                //横线
                graphics.DrawLine(pen, new Point(0, 1 * 30), new Point(bitmap.Width, 1 * 30));

                for (int i = 0; i < data.colunms.Count(); i++)
                {
                    //竖线
                    graphics.DrawLine(pen,
                        new Point((i + 1) * 32 * data.colunms[i].remark.Length, 1 * 32),
                        new Point((i + 1) * 32 * data.colunms[i].remark.Length, 2 * 32)
                        );
                }
            }
        }

        /// <summary>
        /// 表格数据区边框线
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="data"></param>
        public static void InitTableDataBorder(Bitmap bitmap, Graphics graphics, TableModel data)
        {
            using (Pen pen = new Pen(new SolidBrush(Color.LightGray), 1))
            {
                for (int i = 0; i < data.data.Count(); i++)
                {
                    //横线
                    graphics.DrawLine(pen,
                    new Point(0, (i + 2) * 32),
                    new Point(bitmap.Width, (i + 2) * 32)
                    );

                    //竖线
                    for (int j = 0; j < data.colunms.Count(); j++)
                    {
                        //竖线
                        graphics.DrawLine(pen,
                            new Point((j + 1) * 32 * data.colunms[j].remark.Length, (i + 2) * 32),
                            new Point((j + 1) * 32 * data.colunms[j].remark.Length, (i + 3) * 32)
                            );
                    }
                }
            }
        }

        public static TableModel InitModel()
        {
            var model = new TableModel()
            {
                colunms = new List<Colunm>(),
                data = new List<Student>()
            };

            model.colunms.Add(InitColunm("student_name", "报名学员"));
            model.colunms.Add(InitColunm("createtime", "分配时间"));
            model.colunms.Add(InitColunm("user_name", "分配教练"));
            model.colunms.Add(InitColunm("driving_school", "隶属校区"));

            model.data.Add(InitStudent("张三", "2021-12-29 11:11:11", "王教练", "安亭驾校"));
            model.data.Add(InitStudent("王五", "2021-12-29 12:11:11", "张教练", "安亭驾校"));

            return model;
        }

        public static Colunm InitColunm(string name, string remark)
        {
            return new Colunm()
            {
                name = name,
                remark = remark
            };
        }

        public static Student InitStudent(string studentName, string createTime, string userName, string schoolName)
        {
            if (DateTime.TryParse(createTime, out DateTime createDateTime))
            {
                createTime = createDateTime.ToString("MM-dd HH:mm");
            }

            return new Student()
            {
                student_name = studentName,
                createtime = createTime,
                user_name = userName,
                driving_school = schoolName
            };
        }

        public class TableModel
        {
            public List<Student> data { get; set; }

            public List<Colunm> colunms { get; set; }
        }

        public class Student
        {

            /// <summary>
            /// 报名学员
            /// </summary>
            public string student_name { get; set; }

            /// <summary>
            /// 分配/创建时间
            /// </summary>
            public string createtime { get; set; }

            /// <summary>
            /// 教练姓名
            /// </summary>
            public string user_name { get; set; }

            /// <summary>
            /// 学员学校
            /// </summary>
            public string driving_school { get; set; }

        }

        public class Colunm
        {
            /// <summary>
            /// 列名备注
            /// </summary>
            public string remark { get; set; }
            /// <summary>
            /// 列名 
            /// </summary>
            public string name { get; set; }
        }
    }
}
