using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("输入需要产生的等式个数：");
            int n = Convert.ToInt32(Console.ReadLine());
            Formula formula1 = new Formula();
            for (int i = 0; i < n; i++)
            {
                formula1.MakeFormula();
                formula1.Print();
            }
            Console.WriteLine("所有的等式已保存到指定文件夹！");
            Console.Read();
        }
    }

    public class Formula
    {
        DataTable dt = new DataTable();
        public int strnum;
        public string str;
        public string equation = "";
        string[] symbol = { "+", "-", "*", "/" };
        object sum = null;
        public string MakeSym()//制造符号
        {
            Random ran0 = new Random(Guid.NewGuid().GetHashCode());
            return symbol[ran0.Next(0, 4)];
        }
        public int MakeNum()//制造数字
        {
            Random ran1 = new Random(Guid.NewGuid().GetHashCode());
            return ran1.Next(0, 101);

        }
        public string MakeFormula()//制造等式
        {
            start: int j = 0;
            equation = "";
            Random ran2 = new Random(Guid.NewGuid().GetHashCode());
            strnum = ran2.Next(2, 4);//等式符号个数
            do
            {
                equation += Convert.ToString(MakeNum());
                equation += MakeSym();
                j++;
            } while (j < strnum);

            MakeNum();
            equation += Convert.ToString(MakeNum());//等式左边的制造    
            sum = dt.Compute(equation, "");//等式右边的制造(计算结果)
            equation = equation + "=" + Convert.ToString(sum); //等式的制造

            if (Convert.ToString(sum).Contains(".") || Convert.ToString(sum).Contains("-") || equation.Contains("/0"))
            {
                goto start;
            }//去除不和规则的等式
            return equation;
        }

        public int Sum()//返回sum的值
        {
            return Convert.ToInt32(sum);
        }

        public void Print() //写入文件、输出
        {
            StreamWriter sw = new StreamWriter(@"E:\result\resultprint2.txt", true);
            sw.WriteLine(equation);
            Console.WriteLine(equation);
            sw.Flush();
            sw.Close();
        }
    }
}