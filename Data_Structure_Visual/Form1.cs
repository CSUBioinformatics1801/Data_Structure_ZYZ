using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using System.Reflection;
using Data_Structure_Exp;

namespace Data_Structure_Visual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable dt;
        UserInfo[] userInfos;
        bool seq=true;//desc=1;asc=0;
        int alg_slt = 0;
        public bool[] sequenced = new bool[5] { false, false, false, false, false };
        /// <summary>
        /// input file and initiate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                CSVReader.readCSV(file, out dt);
                userInfos = new UserInfo[dt.Rows.Count];
                userInfos=TransStruc.trans_dt_to_userInfos(dt);
                dataGridView_dp.DataSource = userInfos;
                dataGridView_dp.Columns[1].Width = 30;
                dataGridView_dp.Columns[2].Width = 30;
                dataGridView_dp.Columns[3].Width = 120;
                dataGridView_dp.Refresh();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    comboBox_column.Items.Add(dt.Columns[i].ToString().Trim());
                }
                string []alg_names = new string[] { "Insert Sort", "Bubble Sort", "Simple Select Sort" ,"Quick Sort","Shell Sort","Merge Sort","Heap Sort"};
                foreach (var name in alg_names)
                {
                    comboBox_alg.Items.Add(name);
                }
                string[] sch_names = new string[] { "Sequential Search", "BinarySearch" };
                foreach(var name in sch_names)
                {
                    comboBox_sch_alg.Items.Add(name);
                }
            }
        }
        /// <summary>
        /// sort
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_sort_Click(object sender, EventArgs e)
        {
            if (dt != null && userInfos != null)
            {
                switch (alg_slt)
                {
                    case 0:
                        userInfos = TransStruc.InsertSort_St(userInfos, comboBox_column.SelectedIndex, seq);
                        MessageBox.Show("Successfully sorted after " + userInfos.Length + " epoch!");
                        break;
                    case 1:
                        userInfos = TransStruc.BubbleSort_St(userInfos, comboBox_column.SelectedIndex, seq);
                        MessageBox.Show("Successfully sorted after " + userInfos.Length + " epoch!");
                        break;
                    case 2:
                        userInfos = TransStruc.SimpleSelectSort_St(userInfos, comboBox_column.SelectedIndex, seq);
                        MessageBox.Show("Successfully sorted after " + userInfos.Length + " epoch!");
                        break;
                    case 3:
                        userInfos = TransStruc.QuickSort_St(userInfos, comboBox_column.SelectedIndex,0, userInfos.Length, seq);
                        MessageBox.Show("Successfully sorted after " + userInfos.Length + " epoch!");
                        break;
                    case 4:
                        userInfos = TransStruc.ShellSort_St(userInfos, comboBox_column.SelectedIndex, seq);
                        MessageBox.Show("Successfully sorted after " + userInfos.Length + " epoch!");
                        break;
                    case 5:
                        MessageBox.Show("Oops! The algorithm is still under construction!");
                        return;
                    case 6:
                        MessageBox.Show("Oops! The algorithm is still under construction!");
                        return;

                }
                for (int i = 0; i < comboBox_column.Items.Count; i++)
                {
                    if (i == comboBox_column.SelectedIndex) sequenced[i] = true;
                    else sequenced[i] = false;
                }
            }
            dataGridView_dp.Refresh();
        }
        /// <summary>
        /// choose sort algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_asc_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_asc.Checked == true) seq = false;
            else seq = true;
        }
        private void button_savefile_Click(object sender, EventArgs e)
        {
            string w_str = "";
            foreach (var s in userInfos)
            {
                w_str += s.Output() + "\n";
            }
            SaveFileDialog sfd = new SaveFileDialog();
            //设置保存文件对话框的标题
            sfd.Title = "请选择要保存的文件路径";
            //初始化保存目录，默认exe文件目录
            sfd.InitialDirectory = Application.StartupPath;
            //设置保存文件的类型
            sfd.Filter = "文本文件|*.txt|分隔符文件|*.csv|所有文件|*.*";
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //获得保存文件的路径
                string filePath = sfd.FileName;
                //保存
                using (FileStream fsWrite = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.Default.GetBytes(w_str);
                    fsWrite.Write(buffer, 0, buffer.Length);
                }
            }
        }
        /// <summary>
        /// search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_sch_Click(object sender, EventArgs e)
        {
            int add_i=0;//default
            if (textBox_schstr.Text.Trim() == "") 
            {
                MessageBox.Show("No null search!"); 
                return; 
            }
            switch (comboBox_sch_alg.SelectedIndex) 
            {
                case 0:
                    UserInfo[] sched_ss = Search.SeqSearch(userInfos, comboBox_column.SelectedIndex, textBox_schstr.Text.Trim(),out add_i);
                    dataGridView_dp.DataSource = sched_ss;
                    break;
                case 1:
                    if (!sequenced[comboBox_column.SelectedIndex]) 
                    {
                        MessageBox.Show("The column has not been sequenced yet!");
                        return;
                    }
                    UserInfo []sched_bs = Search.BinarySearch(userInfos, comboBox_column.SelectedIndex, textBox_schstr.Text.Trim(), out add_i);
                    dataGridView_dp.DataSource = sched_bs;
                    break;
            }
            if (add_i != 0)
            {
                for (int i = 0; i < dataGridView_dp.Rows.Count; i++)
                {
                    if (i >= add_i) dataGridView_dp.Rows[i].Visible = false;
                    else dataGridView_dp.Rows[i].DefaultCellStyle.Font = new Font("黑体", 9F, FontStyle.Bold | FontStyle.Underline);
                }
            }
        }
        private void button_reset_Click(object sender, EventArgs e)
        {
            dataGridView_dp.DataSource = userInfos;
        }
    }
    /// <summary>
    /// 用户信息结构
    /// </summary>
    public struct UserInfo 
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Patient_id { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Registering_date { get; set; }
        /// <summary>
        /// 临床指征
        /// </summary>
        public float Clinic_charge { get; set; }
        public string Output()
        {
            string tmp = Patient_id.ToString() + ",";
            tmp += Sex ? "女," : "男,";
            tmp += Age.ToString() + ",";
            tmp += Registering_date.ToUniversalTime().ToString()+",";
            tmp += Clinic_charge.ToString();
            return tmp;
        }
    }
    //public class CSVFileHelper
    //{
    //    /// <summary>
    //    /// 将DataTable中数据写入到CSV文件中
    //    /// </summary>
    //    /// <param name="dt">提供保存数据的DataTable</param>
    //    /// <param name="fileName">CSV的文件路径</param>
    //    public static void SaveCSV(DataTable dt, string fullPath)
    //    {
    //        FileInfo fi = new FileInfo(fullPath);
    //        if (!fi.Directory.Exists)
    //        {
    //            fi.Directory.Create();
    //        }
    //        FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
    //        //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
    //        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
    //        string data = "";
    //        //写出列名称
    //        for (int i = 0; i < dt.Columns.Count; i++)
    //        {
    //            data += dt.Columns[i].ColumnName.ToString();
    //            if (i < dt.Columns.Count - 1)
    //            {
    //                data += ",";
    //            }
    //        }
    //        sw.WriteLine(data);
    //        //写出各行数据
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            data = "";
    //            for (int j = 0; j < dt.Columns.Count; j++)
    //            {
    //                string str = dt.Rows[i][j].ToString();
    //                str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
    //                if (str.Contains(',') || str.Contains('"')
    //                    || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中
    //                {
    //                    str = string.Format("\"{0}\"", str);
    //                }

    //                data += str;
    //                if (j < dt.Columns.Count - 1)
    //                {
    //                    data += ",";
    //                }
    //            }
    //            sw.WriteLine(data);
    //        }
    //        sw.Close();
    //        fs.Close();
    //        DialogResult result = MessageBox.Show("CSV文件保存成功！");
    //        if (result == DialogResult.OK)
    //        {
    //            System.Diagnostics.Process.Start("explorer.exe", Common.PATH_LANG);
    //        }
    //    }

    //    /// <summary>
    //    /// 将CSV文件的数据读取到DataTable中
    //    /// </summary>
    //    /// <param name="fileName">CSV文件路径</param>
    //    /// <returns>返回读取了CSV数据的DataTable</returns>
    //    public static DataTable OpenCSV(string filePath)
    //    {
    //        Encoding encoding = Common.GetType(filePath); //Encoding.ASCII;//
    //        DataTable dt = new DataTable();
    //        FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

    //        //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
    //        StreamReader sr = new StreamReader(fs, encoding);
    //        //string fileContent = sr.ReadToEnd();
    //        //encoding = sr.CurrentEncoding;
    //        //记录每次读取的一行记录
    //        string strLine = "";
    //        //记录每行记录中的各字段内容
    //        string[] aryLine = null;
    //        string[] tableHead = null;
    //        //标示列数
    //        int columnCount = 0;
    //        //标示是否是读取的第一行
    //        bool IsFirst = true;
    //        //逐行读取CSV中的数据
    //        while ((strLine = sr.ReadLine()) != null)
    //        {
    //            //strLine = Common.ConvertStringUTF8(strLine, encoding);
    //            //strLine = Common.ConvertStringUTF8(strLine);

    //            if (IsFirst == true)
    //            {
    //                tableHead = strLine.Split(',');
    //                IsFirst = false;
    //                columnCount = tableHead.Length;
    //                //创建列
    //                for (int i = 0; i < columnCount; i++)
    //                {
    //                    DataColumn dc = new DataColumn(tableHead[i]);
    //                    dt.Columns.Add(dc);
    //                }
    //            }
    //            else
    //            {
    //                aryLine = strLine.Split(',');
    //                DataRow dr = dt.NewRow();
    //                for (int j = 0; j < columnCount; j++)
    //                {
    //                    dr[j] = aryLine[j];
    //                }
    //                dt.Rows.Add(dr);
    //            }
    //        }
    //        if (aryLine != null && aryLine.Length > 0)
    //        {
    //            dt.DefaultView.Sort = tableHead[0] + " " + "asc";
    //        }

    //        sr.Close();
    //        fs.Close();
    //        return dt;
    //    }
    //}
    class CSVReader
    {
        static public bool readCSV(string filePath, out DataTable dt)//从csv读取数据返回table
        {
            dt = new DataTable();
            try
            {
                System.Text.Encoding encoding = Encoding.Default;//GetType(filePath);DataTable dt = new DataTable();
                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open,System.IO.FileAccess.Read);
                System.IO.StreamReader sr = new System.IO.StreamReader(fs, encoding);
                //记录每次读取的一行记录
                string strLine = "";
                //记录每行记录中的各字段内容
                string[] aryLine = null;
                string[] tableHead = null; 
                //标示列数
                int columnCount = 0;
                //标示是否是读取的第一行
                bool IsFirst = true;
                //逐行读取CSV中的数据
                while ((strLine = sr.ReadLine()) != null)
                {
                    if (IsFirst == true)
                    {
                        tableHead = strLine.Split(',');
                        IsFirst = false;
                        columnCount = tableHead.Length;
                        //创建列
                        for (int i = 0; i < columnCount; i++)
                        {
                            DataColumn dc = new DataColumn(tableHead[i]);
                            dt.Columns.Add(dc);
                        }
                    }
                    else
                    {
                        aryLine = strLine.Split(',');
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < columnCount; j++)
                        {
                            dr[j] = aryLine[j];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                if (aryLine != null && aryLine.Length > 0)
                {
                    dt.DefaultView.Sort = tableHead[0] + " " + "asc";
                }
                sr.Close();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public static class DataTableExtend
    {
        /// <summary>
        /// DataTable转成List
        /// </summary>
        public static List<T> ToDataList<T>(this DataTable dt)
        {
            var list = new List<T>();
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            foreach (DataRow item in dt.Rows)
            {
                T s = Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info != null)
                    {
                        try
                        {
                            if (!Convert.IsDBNull(item[i]))
                            {
                                object v = null;
                                if (info.PropertyType.ToString().Contains("System.Nullable"))
                                {
                                    v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(info.PropertyType));
                                }
                                else
                                {
                                    v = Convert.ChangeType(item[i], info.PropertyType);
                                }
                                info.SetValue(s, v, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }

        /// <summary>
        /// DataTable转成实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T ToDataEntity<T>(this DataTable dt)
        {
            T s = Activator.CreateInstance<T>();
            if (dt == null || dt.Rows.Count == 0)
            {
                return default(T);
            }
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                if (info != null)
                {
                    try
                    {
                        if (!Convert.IsDBNull(dt.Rows[0][i]))
                        {
                            object v = null;
                            if (info.PropertyType.ToString().Contains("System.Nullable"))
                            {
                                v = Convert.ChangeType(dt.Rows[0][i], Nullable.GetUnderlyingType(info.PropertyType));
                            }
                            else
                            {
                                v = Convert.ChangeType(dt.Rows[0][i], info.PropertyType);
                            }
                            info.SetValue(s, v, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                    }
                }
            }
            return s;
        }

        /// <summary>
        /// List转成DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entities">实体集合</param>
        public static DataTable ToDataTable<T>(List<T> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                return null;
            }

            var result = CreateTable<T>();
            FillData(result, entities);
            return result;
        }

        /// <summary>
        /// 创建表
        /// </summary>
        private static DataTable CreateTable<T>()
        {
            var result = new DataTable();
            var type = typeof(T);
            foreach (var property in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                var propertyType = property.PropertyType;
                if ((propertyType.IsGenericType) && (propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    propertyType = propertyType.GetGenericArguments()[0];
                result.Columns.Add(property.Name, propertyType);
            }
            return result;
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        private static void FillData<T>(DataTable dt, IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                dt.Rows.Add(CreateRow(dt, entity));
            }
        }

        /// <summary>
        /// 创建行
        /// </summary>
        private static DataRow CreateRow<T>(DataTable dt, T entity)
        {
            DataRow row = dt.NewRow();
            var type = typeof(T);
            foreach (var property in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                row[property.Name] = property.GetValue(entity) ?? DBNull.Value;
            }
            return row;
        }
    }
    public static class TransStruc
    {
        public static DataTable Transabledt(DataTable old_dt)
        {

            for (int i = 0; i < old_dt.Rows.Count; i++)
            {
                old_dt.Rows[i][0] = int.Parse((string)old_dt.Rows[i][0]);//Patient_id
                old_dt.Rows[i][1] = ((string)old_dt.Rows[i][1] == "男") ? 0 : 1;//male 0,female 1
                old_dt.Rows[i][2] = int.Parse((string)old_dt.Rows[i][2]);//age
                string tmp = (string)old_dt.Rows[i][3];//datetime
                DateTime temp_dateTime;
                DateTime.TryParse(tmp, out temp_dateTime);
                DateTime sDate = Convert.ToDateTime("1900-01-01 00:00:00");
                TimeSpan ts = temp_dateTime - sDate;
                old_dt.Rows[i][3] = ts.TotalSeconds;
                old_dt.Rows[i][4] = double.Parse((string)old_dt.Rows[i][4]);//clinic_charge
            }
            return old_dt;
        }
        public static UserInfo[] trans_dt_to_userInfos(DataTable old_dt)
        {
            UserInfo[] userInfos = new UserInfo[old_dt.Rows.Count];
            if (old_dt != null)
            {
                for (int i = 0; i < old_dt.Rows.Count; i++)
                {                    
                    int temp_ptid = int.Parse((string)old_dt.Rows[i][0]);
                    userInfos[i].Patient_id = temp_ptid;
                    userInfos[i].Sex=((string)old_dt.Rows[i][1] == "男") ? false : true;
                    userInfos[i].Age= int.Parse((string)old_dt.Rows[i][2]);
                    string tmp = (string)old_dt.Rows[i][3];//datetime
                    DateTime temp_dateTime;
                    DateTime.TryParse(tmp, out temp_dateTime);
                    userInfos[i].Registering_date = temp_dateTime;
                    userInfos[i].Clinic_charge = float.Parse((string)old_dt.Rows[i][4]);
                }
            }
            return userInfos;
        }
        /// <summary>
        /// don't use the following function InsertSortDT, it's totally a waste of time
        /// </summary>
        public static DataTable InsertSortDT(DataTable old_dt, int columname)
        {
            for (int i = 1; i < old_dt.Rows.Count; i++)
            {
                float temp_i, temp_i_1, temp_j;
                float.TryParse((string)old_dt.Rows[i][columname], out temp_i);
                float.TryParse((string)old_dt.Rows[i-1][columname], out temp_i_1);
                if (temp_i< temp_i_1)
                {
                    float temp;
                    float.TryParse((string)old_dt.Rows[i][columname], out temp);
                    float.TryParse((string)old_dt.Rows[i][columname], out temp_j);
                    int j = 0;
                    for(j=i-1;j>=0 && temp< temp_j; --j)
                    {
                        old_dt.Rows[j + 1][columname] = old_dt.Rows[j][columname];//make place
                    }
                    old_dt.Rows[j + 1][columname] = temp;
                }
            }
            return old_dt;
        }
        public static UserInfo[] InsertSort_St(UserInfo[] userInfos, int colomnindex, bool seq = true)//[o(n),o(n^2)]
        {
            /// <summary>
            /// colomnindex=排序号，seq=true：顺序，seq=flase，逆序
            /// </summary>
            for (int i = 1; i < userInfos.Length; ++i)
            {
                switch (colomnindex)
                {
                    case 0://Patient_id
                        if (userInfos[i].Patient_id < userInfos[i - 1].Patient_id)
                        {
                            UserInfo temp = userInfos[i];
                            int j;
                            for (j = i - 1; j >= 0 && temp.Patient_id < userInfos[j].Patient_id; --j)
                            {
                                userInfos[j + 1] = userInfos[j];//make place
                            }
                            userInfos[j + 1] = temp;
                        }
                        break;
                    case 1://Sex
                        if (!userInfos[i].Sex && userInfos[i - 1].Sex)
                        {
                            UserInfo temp = userInfos[i];
                            int j;
                            for (j = i - 1; j >= 0 && !temp.Sex && userInfos[j].Sex; --j)
                            {
                                userInfos[j + 1] = userInfos[j];//make place
                            }
                            userInfos[j + 1] = temp;
                        }
                        break;
                    case 2://Age
                        if (userInfos[i].Age < userInfos[i - 1].Age)
                        {
                            UserInfo temp = userInfos[i];
                            int j;
                            for (j = i - 1; j >= 0 && temp.Age < userInfos[j].Age; --j)
                            {
                                userInfos[j + 1] = userInfos[j];//make place
                            }
                            userInfos[j + 1] = temp;
                        }
                        break;
                    case 3://Registering_date
                        if (userInfos[i].Registering_date < userInfos[i - 1].Registering_date)
                        {
                            UserInfo temp = userInfos[i];
                            int j;
                            for (j = i - 1; j >= 0 && temp.Registering_date < userInfos[j].Registering_date; --j)
                            {
                                userInfos[j + 1] = userInfos[j];//make place
                            }
                            userInfos[j + 1] = temp;
                        }
                        break;
                    case 4://clinic_charge
                        if (userInfos[i].Clinic_charge < userInfos[i - 1].Clinic_charge)
                        {
                            UserInfo temp = userInfos[i];
                            int j;
                            for (j = i - 1; j >= 0 && temp.Clinic_charge < userInfos[j].Clinic_charge; --j)
                            {
                                userInfos[j + 1] = userInfos[j];//make place
                            }
                            userInfos[j + 1] = temp;
                        }
                        break;
                }
            }
            if (seq) userInfos = inversion(userInfos);
            return userInfos;
        }
        public static UserInfo[] BubbleSort_St(UserInfo[] userInfos, int colomnindex, bool seq = true)//[o(n),o(n^2)]
        {
            /// <summary>
            /// colomnindex=排序号，seq=true：顺序，seq=flase，逆序
            /// </summary>
            for (int i = 0; i < userInfos.Length; ++i)
            {
                for (int j = userInfos.Length - 1; j >= i; --j)
                {
                    switch (colomnindex)
                    {
                        case 0://Patient_id                           
                            if (userInfos[j + 1].Patient_id < userInfos[j].Patient_id)
                            {
                                UserInfo temp = userInfos[j + 1];
                                userInfos[j + 1] = userInfos[j];//make place
                                userInfos[j] = temp;//insert
                            }
                            break;
                        case 1://Sex
                            if (!userInfos[j + 1].Sex && userInfos[j].Sex)
                            {
                                UserInfo temp = userInfos[j + 1];
                                userInfos[j + 1] = userInfos[j];//make place
                                userInfos[j] = temp;//insert
                            }
                            break;
                        case 2://Age
                            if (userInfos[j + 1].Age < userInfos[j].Age)
                            {
                                UserInfo temp = userInfos[j + 1];
                                userInfos[j + 1] = userInfos[j];//make place
                                userInfos[j] = temp;//insert
                            }
                            break;
                        case 3://Registering_date
                            if (userInfos[j + 1].Registering_date < userInfos[j].Registering_date)
                            {
                                UserInfo temp = userInfos[j + 1];
                                userInfos[j + 1] = userInfos[j];//make place
                                userInfos[j] = temp;//insert
                            }
                            break;
                        case 4://clinic_charge
                            if (userInfos[j + 1].Clinic_charge < userInfos[j].Clinic_charge)
                            {
                                UserInfo temp = userInfos[j + 1];
                                userInfos[j + 1] = userInfos[j];//make place
                                userInfos[j] = temp;//insert
                            }
                            break;
                    }
                }
            }
            if (seq) userInfos = inversion(userInfos);
            return userInfos;
        }
        public static UserInfo[] SimpleSelectSort_St(UserInfo[] userInfos, int colomnindex, bool seq = true)//o(n(n-1)/2)
        {
            /// <summary>
            /// colomnindex=排序号，seq=true：顺序，seq=flase，逆序
            /// </summary>
            for (int i = 0; i < userInfos.Length; ++i)
            {
                int t = i; UserInfo temp;
                for (int j = i + 1; j <= userInfos.Length; j++)
                {
                    switch (colomnindex)
                    {
                        case 0://Patient_id
                            if (userInfos[t].Patient_id > userInfos[j].Patient_id) t = j;
                            break;
                        case 1://Sex
                            if (userInfos[t].Sex && !userInfos[j].Sex) t = j;
                            break;
                        case 2://Age
                            if (userInfos[t].Age > userInfos[j].Age) t = j;
                            break;
                        case 3://Registering_date
                            if (userInfos[t].Registering_date > userInfos[j].Registering_date) t = j;
                            break;
                        case 4://clinic_charge
                            if (userInfos[t].Clinic_charge > userInfos[j].Clinic_charge) t = j;
                            break;
                    }
                }       
                temp = userInfos[i];
                userInfos[i] = userInfos[t];
                userInfos[t] = temp;
            }
            if (seq) userInfos = inversion(userInfos);
            return userInfos;
        }
        public static UserInfo[] QuickSort_St(UserInfo[] userInfos, int colomnindex, int low, int high, bool seq = true)//[o(n*log2(n)),o(n^2)],[total bitree-total,right tree]
        {
            int i = low, j = high;
            switch (colomnindex)
            {
                case 0://Patient_id
                    int temp_ptid = userInfos[low].Patient_id;
                    while (low < high)
                    {
                        while ((low < high) && (userInfos[high].Patient_id >= temp_ptid))
                        {
                            --high;
                        }
                        userInfos[low] = userInfos[high];
                        ++low;
                        while ((low < high) && (userInfos[high].Patient_id <= temp_ptid))
                        {
                            ++low;
                        }
                        userInfos[high] = userInfos[low];
                        --high;
                        userInfos[low].Patient_id = temp_ptid;
                        if (i < low - 1) QuickSort_St(userInfos,colomnindex, i, low - 1);
                        if (low + 1 < j) QuickSort_St(userInfos, colomnindex,low + 1, j);
                    }
                    break;
                case 1://Sex
                    bool temp_sex = userInfos[low].Sex;
                    while (low < high)
                    {
                        while ((low < high) && (userInfos[high].Sex && !temp_sex))
                        {
                            --high;
                        }
                        userInfos[low] = userInfos[high];
                        ++low;
                        while ((low < high) && (!userInfos[high].Sex && temp_sex))
                        {
                            ++low;
                        }
                        userInfos[high] = userInfos[low];
                        --high;
                        userInfos[low].Sex = temp_sex;
                        if (i < low - 1) QuickSort_St(userInfos, colomnindex, i, low - 1);
                        if (low + 1 < j) QuickSort_St(userInfos, colomnindex, low + 1, j);
                    }
                    break;
                case 2://Age
                    int temp_age = userInfos[low].Age;
                    while (low < high)
                    {
                        while ((low < high) && (userInfos[high].Age >= temp_age))
                        {
                            --high;
                        }
                        userInfos[low] = userInfos[high];
                        ++low;
                        while ((low < high) && (userInfos[high].Age <= temp_age))
                        {
                            ++low;
                        }
                        userInfos[high] = userInfos[low];
                        --high;
                        userInfos[low].Age = temp_age;
                        if (i < low - 1) QuickSort_St(userInfos, colomnindex, i, low - 1);
                        if (low + 1 < j) QuickSort_St(userInfos, colomnindex, low + 1, j);
                    }
                    break;
                case 3://Registering_date
                    DateTime temp_dt = userInfos[low].Registering_date;
                    while (low < high)
                    {
                        while ((low < high) && (userInfos[high].Registering_date >= temp_dt))
                        {
                            --high;
                        }
                        userInfos[low] = userInfos[high];
                        ++low;
                        while ((low < high) && (userInfos[high].Registering_date <= temp_dt))
                        {
                            ++low;
                        }
                        userInfos[high] = userInfos[low];
                        --high;
                        userInfos[low].Registering_date = temp_dt;
                        if (i < low - 1) QuickSort_St(userInfos, colomnindex, i, low - 1);
                        if (low + 1 < j) QuickSort_St(userInfos, colomnindex, low + 1, j);
                    }
                    break;
                case 4://clinic_charge
                    float temp_cc = userInfos[low].Clinic_charge;
                    while (low < high)
                    {
                        while ((low < high) && (userInfos[high].Clinic_charge >= temp_cc))
                        {
                            --high;
                        }
                        userInfos[low] = userInfos[high];
                        ++low;
                        while ((low < high) && (userInfos[high].Clinic_charge <= temp_cc))
                        {
                            ++low;
                        }
                        userInfos[high] = userInfos[low];
                        --high;
                        userInfos[low].Clinic_charge = temp_cc;
                        if (i < low - 1) QuickSort_St(userInfos, colomnindex, i, low - 1);
                        if (low + 1 < j) QuickSort_St(userInfos, colomnindex, low + 1, j);
                    }
                    break;
            }         
            if (seq) userInfos = inversion(userInfos);
            return userInfos;
        }
        public static UserInfo[] ShellSort_St(UserInfo[] userInfos, int colomnindex, bool seq = true)//time:O(n^(1.3—2));space:o(1)
        {
            int gap = userInfos.Length / 2;
            while (1 <= gap)
            {
                // collect items as a group when the distance equals to gap, scan these groups
                for (int i = gap; i < userInfos.Length; i++)
                {
                    int j; UserInfo temp = userInfos[i];
                    // sort items when the distance equals to gap
                    switch (colomnindex)
                    {
                        case 0://Patient_id
                            for (j = i - gap; j >= 0 && temp.Patient_id < userInfos[j].Patient_id; j -= gap)
                            {
                                userInfos[j + gap] = userInfos[j];
                            }
                            break;
                        case 1://Sex
                            for (j = i - gap; j >= 0 && !temp.Sex && userInfos[j].Sex; j -= gap)
                            {
                                userInfos[j + gap] = userInfos[j];
                            }
                            break;
                        case 2://Age
                            for (j = i - gap; j >= 0 && temp.Age < userInfos[j].Age; j -= gap)
                            {
                                userInfos[j + gap] = userInfos[j];
                            }
                            break;
                        case 3://Registering_date
                            for (j = i - gap; j >= 0 && temp.Registering_date < userInfos[j].Registering_date; j -= gap)
                            {
                                userInfos[j + gap] = userInfos[j];
                            }
                            break;
                        case 4://clinic_charge
                            for (j = i - gap; j >= 0 && temp.Clinic_charge < userInfos[j].Clinic_charge; j -= gap)
                            {
                                userInfos[j + gap] = userInfos[j];
                            }
                            break;
                    }
                    userInfos[j + gap] = temp;
                }
                gap /= 2; // cut increment
            }
            if (seq) userInfos = inversion(userInfos);
            return userInfos;
        }
        public static UserInfo[] inversion(UserInfo[] userInfos)
        {
            for (int i = 0; i < userInfos.Length / 2; i++)
            {
                UserInfo temp = userInfos[i];
                userInfos[i] = userInfos[(userInfos.Length - 1) - i];
                userInfos[(userInfos.Length - 1) - i] = temp;
            }
            return userInfos;
        }
    }
    public static class Search 
    {
        public static UserInfo[] SeqSearch(UserInfo[] UF,int column_num, string data,out int add_i)//o(n)
        {
            int i; add_i=0;
            UserInfo[] nulluf=new UserInfo[UF.Length];
            switch (column_num)
            {
                case 0://Patient_id
                    int sd_ptid=int.Parse(data);
                    for (i = 0; i < UF.Length; i++)
                    {
                        if (UF[i].Patient_id == sd_ptid) 
                        {
                            nulluf[add_i] = UF[i];
                            add_i++;
                        }
                    }
                    break;
                case 1://Sex
                    bool sd_sex = (data == "男") ? false : true;
                    for (i = 0; i < UF.Length; i++)
                    {
                        if (UF[i].Sex == sd_sex)
                        {
                            nulluf[add_i] = UF[i];
                            add_i++;
                        }
                    }
                    break;
                case 2://Age
                    int sd_age = int.Parse(data);
                    for (i = 0; i < UF.Length; i++)
                    {
                        if (UF[i].Age == sd_age)
                        {
                            nulluf[add_i] = UF[i];
                            add_i++;
                        }
                    }
                    break;
                case 3://Registering_date
                    DateTime sd_dt = DateTime.Parse(data);
                    for (i = 0; i < UF.Length; i++)
                    {
                        if (UF[i].Registering_date == sd_dt)
                        {
                            nulluf[add_i] = UF[i];
                            add_i++;
                        }
                    }
                    break;
                case 4://clinic_charge
                    float sd_cc = float.Parse(data);
                    for (i = 0; i < UF.Length; i++)
                    {
                        if (UF[i].Clinic_charge == sd_cc)
                        {
                            nulluf[add_i] = UF[i];
                            add_i++;
                        }
                    }
                    break;
            }
            if (add_i == 0) MessageBox.Show("Not found!");
            else MessageBox.Show("Search successfully!");
            return nulluf;
        }
        public static UserInfo[] BinarySearch(UserInfo[] UF, int column_num, string data, out int add_i)//o(n)
        {
            UserInfo[] nulluf = new UserInfo[UF.Length];
            int mid = 0, flag = -1, low = 1, high = UF.Length; add_i = 0;
            switch (column_num)
            {
                case 0://Patient_id
                    UF[0].Patient_id = int.Parse(data);
                    while (low <= high)
                    {
                        mid = (low + high) / 2;
                        if (UF[0].Patient_id == UF[mid].Patient_id)
                        {
                            flag = mid;
                            break;
                        }
                        else if (UF[0].Patient_id < UF[mid].Patient_id) high = mid - 1;
                        else low = mid + 1;
                    }
                    break;
                case 1://Sex
                    UF[0].Sex = (data == "男") ? false : true;
                    while (low <= high)
                    {
                        mid = (low + high) / 2;
                        if (UF[0].Sex == UF[mid].Sex)
                        {
                            flag = mid;
                            break;
                        }
                        else if (!UF[0].Sex && UF[mid].Sex) high = mid - 1;
                        else low = mid + 1;
                    }
                    break;
                case 2://Age
                    UF[0].Age = int.Parse(data);
                    while (low <= high)
                    {
                        if (UF[0].Age == UF[mid].Age)
                        {
                            flag = mid;
                            break;
                        }
                        else if (UF[0].Age < UF[mid].Age) high = mid - 1;
                        else low = mid + 1;
                    }
                    break;
                case 3://Registering_date
                    UF[0].Registering_date = DateTime.Parse(data);
                    while (low <= high)
                    {
                        if (UF[0].Registering_date == UF[mid].Registering_date)
                        {
                            flag = mid;
                            break;
                        }
                        else if (UF[0].Registering_date < UF[mid].Registering_date) high = mid - 1;
                        else low = mid + 1;
                    }
                    break;
                case 4://clinic_charge
                    UF[0].Clinic_charge = float.Parse(data);
                    while (low <= high)
                    {
                        if (UF[0].Clinic_charge == UF[mid].Clinic_charge)
                        {
                            flag = mid;
                            break;
                        }
                        else if (UF[0].Clinic_charge < UF[mid].Clinic_charge) high = mid - 1;
                        else low = mid + 1;
                    }
                    break;
            }
            if (flag > 0) 
            {
                nulluf[add_i] = UF[flag];
                add_i++;
            }
            if (add_i == 0) MessageBox.Show("Not found!");
            else MessageBox.Show("Search successfully!");
            return nulluf;
        }
    }
}
