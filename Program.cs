using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Formula formula1 = new Formula(n);
            formula1.MakeFormula(n);
            Console.Read();
        }
    }

    class Formula
    {
        int n, num, strnum;
        string str;
        string equation = "";
        string[] symbol = { "+", "-", "*", "/" };
        public Formula(int a)
        {
            this.n = a;
        }
        public void MakeSym()//制造符号
        {
            Random ran0 = new Random(Guid.NewGuid().GetHashCode());
            str = symbol[ran0.Next(0, 4)];
        }
        public void MakeNum()//制造数字
        {
            Random ran1 = new Random(Guid.NewGuid().GetHashCode());
            num = ran1.Next(0, 101);

        }
        public void MakeFormula(int n)//制造等式
        {
            int i, j = 0;
            object sum = null;
            DataTable dt = new DataTable();
            for (i = 0; i < n; i++)//等式个数
            {
                j = 0;
                equation = "";
                Random ran2 = new Random(Guid.NewGuid().GetHashCode());
                strnum = ran2.Next(2, 4);//等式符号个数
                do
                {
                    MakeNum();
                    equation += Convert.ToString(num);
                    MakeSym();
                    equation += str;
                    j++;
                } while (j < strnum);
                MakeNum();
                equation += Convert.ToString(num);//等式左边的制造    

                sum = dt.Compute(equation, "");//等式右边的制造(计算结果)

                if (Convert.ToString(sum).Contains(".") || Convert.ToString(sum).Contains("-") || equation.Contains("/0"))
                {
                    i--;
                }//去除不和规则的等式
                else
                {
                    StreamWriter sw = new StreamWriter(@"E:\result\resultprint.txt", true);
                    sw.WriteLine(equation + "=" + Convert.ToString(sum));
                    sw.Flush();
                    sw.Close();
                }//写入文件

            }

        }


    }
}
