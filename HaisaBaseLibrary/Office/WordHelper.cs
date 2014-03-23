using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HaisaBaseLibrary.Office
{
    public class WordHelper
    {
        public static void Export(DataGridView dgv, string data1, string data2, object strFileName)
        {
            Microsoft.Office.Interop.Word.Application myWord = null;// new Microsoft.Office.Interop.Word.ApplicationClass();
            Microsoft.Office.Interop.Word.Document myDoc;

            myDoc = myWord.Documents.Add();
            #region 文本内容
            //第一段
            Microsoft.Office.Interop.Word.Paragraph par1;
            par1 = myDoc.Content.Paragraphs.Add();
            par1.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            par1.Range.Bold = 1;
            par1.Range.Font.Size = 22;
            par1.Range.Text = "关于对赴朝作业渔船未按规定开通卫星定位系统情况的通报（第二批）\r\n";
            //第二段
            Microsoft.Office.Interop.Word.Paragraph par2;
            par2 = myDoc.Content.Paragraphs.Add();
            par2.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            par2.Range.Bold = 0;
            par2.Range.Font.Size = 15;
            par2.Range.Text = "沿海市海洋与渔业局，厅直有关单位：\r\n";

            //第三段
            Microsoft.Office.Interop.Word.Paragraph par3;
            par3 = myDoc.Content.Paragraphs.Add();
            par3.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            par3.Range.Bold = 0;
            par3.Range.Font.Size = 15;
            par3.Range.Text = "    2012年8月3日，省总队对赴朝鲜东部海域作业渔船卫星定位设备开通情况进行了检查，发现有24艘渔船未按规定开启卫星定位设备（见附表）。根据《山东省赴朝鲜东部海域生产项目管理暂行办法》（下称〈暂行办法〉）有关规定，通报如下：\r\n";
            //第四段
            Microsoft.Office.Interop.Word.Paragraph par4;
            par4 = myDoc.Content.Paragraphs.Add();
            par4.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            par4.Range.Bold = 0;
            par4.Range.Font.Size = 15;
            par4.Range.Text = "    一、对" + data1 + "艘第一次未开通卫星定位设备渔船予以警告。\r\n";
            //第五段
            Microsoft.Office.Interop.Word.Paragraph par5;
            par5 = myDoc.Content.Paragraphs.Add();
            par5.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            par5.Range.Bold = 0;
            par5.Range.Font.Size = 15;
            par5.Range.Text = "    二、对" + data2 + "艘渔船由所在县市区渔政机构进行调查，对非故障原因不按规定开通卫星定位设备的按照《暂行办法》有关规定处以5000元罚款。\r\n";
            //第六段
            Microsoft.Office.Interop.Word.Paragraph par6;
            par6 = myDoc.Content.Paragraphs.Add();
            par6.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            par6.Range.Bold = 0;
            par6.Range.Font.Size = 15;
            par6.Range.Text = "    三、赴朝作业渔船代理企业应加强对本公司渔船及代理渔船的管理，确保其严格遵守《渔业法》、《远洋渔业管理规定》及《暂行办法》的规定，全程开通卫星定位系统，依法生产。\r\n";
            //第七段
            Microsoft.Office.Interop.Word.Paragraph par7;
            par7 = myDoc.Content.Paragraphs.Add();
            par7.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
            par7.Range.Bold = 0;
            par7.Range.Font.Size = 15;
            string a = "\r\n" + DateTime.Now.ToString() + "\r\n";
            par7.Range.Text = a;
            #endregion
            
            #region 保存文档
            object filename = strFileName + "\\开机统计通报.doc";
            myDoc.SaveAs(ref filename);
            //关闭
            myDoc.Close(true);
            //退出
            myWord.Quit(true);
            #endregion

            ExcelHelper.Export(new List<DataGridView> { dgv }, "开机统计(附件)",  "\\开机统计(附件).xls");

        }
    }
}
