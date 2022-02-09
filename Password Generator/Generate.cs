using System;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class Generate : Form
    {

        public String U, L, S, N;
        public bool Upper, Lower, Both, Num, Syb, H;
        public int sz;


        Random r = new Random();
        public Generate()
        {
            InitializeComponent();
        }
        private void BasicStat()
        {
            textBox1.Text = "";
            // ONLY UPPER CASE
            U = "ABCDEFGHIJKLMNOPQRSTUVWXZ";
            // ONLY LOWER CASE
            L = U.ToLower();
            // NUMBERS
            N = "0123456789";
            // Symbols
            S = "#$@!?_";

            Upper = Lower = Both = Num = Syb = false;
        }

        // Checking whether the curr generated pass match with user requirements
        private bool Valid_Generated_Pass(string pass, int type)
        {

            bool upper, lower, both, num, syb;
            upper = lower = both = num = syb = false;

            if (type == 0) //Upper with Lower
            {
                for (int i = 0; i < pass.Length; i++)
                    H = (pass[i] >= 'a' && pass[i] <= 'z') ? lower = true : upper = true;

                return (upper == true && lower == true);
            }

            else if (type == 1) //Upper With Numbers
            {
                for (int i = 0; i < pass.Length; i++)
                    H = (pass[i] >= 'A' && pass[i] <= 'Z') ? upper = true : num = true;

                return (num == true && upper == true);
            }

            else if (type == 2) //Lower With Numbers
            {
                for (int i = 0; i < pass.Length; i++)
                    H = (pass[i] >= 'a' && pass[i] <= 'z') ? lower = true : num = true;

                return (num == true && lower == true);
            }

            else if (type == 3) // Lower ,Upper,Numbers
            {
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass[i] >= 'a' && pass[i] <= 'z') lower = true;
                    else if (pass[i] >= 'A' && pass[i] <= 'Z') upper = true;
                    else num = true;


                }
                return (upper == true && lower == true && num == true);
            }

            else if (type == 4) // Upper, Symbols
            {
                for (int i = 0; i < pass.Length; i++)
                    H = (pass[i] >= 'A' && pass[i] <= 'Z') ? upper = true : syb = true;

                return (syb == true && upper == true);
            }
            else if (type == 5)// Lower, Symbols
            {
                for (int i = 0; i < pass.Length; i++)
                    H = (pass[i] >= 'a' && pass[i] <= 'z') ? lower = true : syb = true;

                return (syb == true && lower == true);
            }
            else if (type == 6) // Upper,Lower,Symbols
            {
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass[i] >= 'a' && pass[i] <= 'z') lower = true;
                    else if (pass[i] >= 'A' && pass[i] <= 'Z') upper = true;
                    else syb = true;


                }
                return (upper == true && lower == true && syb == true);
            }
            else if (type == 7) //Upper,Numbers,Symbols
            {
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass[i] >= 'A' && pass[i] <= 'Z') upper = true;
                    else if (pass[i] >= '0' && pass[i] <= '9') num = true;
                    else syb = true;


                }
                return (upper == true && num == true && syb == true);
            }
            else if (type == 8) // Lower,Numbers,Symbols
            {
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass[i] >= 'a' && pass[i] <= 'z') lower = true;
                    else if (pass[i] >= '0' && pass[i] <= '9') num = true;
                    else syb = true;


                }
                return (num == true && lower == true && syb == true);
            }
            else
            {
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass[i] >= 'a' && pass[i] <= 'z') lower = true;
                    else if (pass[i] >= 'A' && pass[i] <= 'Z') upper = true;
                    else if (pass[i] >= '0' && pass[i] <= '9') num = true;
                    else syb = true;


                }
                return (upper == true && lower == true && syb == true && num == true);
            }

        }


        // We use it to help us make the basic string matchs user's choices

        // that we gonna randomly choose chracters from it

        // also specifiy  the type that used in (valid_generated_pass) function

        private String Get_Type(int op)
        {
            String Basic = "", type = "10";

            if (Lower == true && Num == false && Syb == false)//Lower
                Basic = L;

            else if (Lower == true && Num == true && Syb == false)//Lower ,Numbers
            {
                Basic = L + N;
                type = "2";
            }
            else if (Lower == true && Num == false && Syb == true)//Lower,Symbols
            {
                Basic = L + S;
                type = "5";
            }
            else if (Lower == true && Num == true && Syb == true)// Lower,Symbols,Numbers
            {
                Basic = L + N + S;
                type = "8";
            }
            else if (Upper == true && Num == false && Syb == false)// Upper Only
                Basic = U;

            else if (Upper == true && Num == true && Syb == false)// Upper ,Numbers
            {
                Basic = U + N;
                type = "1";
            }
            else if (Upper == true && Num == false && Syb == true)// Upper,Symbols
            {
                Basic = U + S;
                type = "4";
            }
            else if (Upper == true && Num == true && Syb == true)// Upper,Symbols,Numbers
            {
                Basic = U + N + S;
                type = "7";
            }
            else if (Both == true && Num == false && Syb == false)// Lower ,Upper
            {
                Basic = L + U;
                type = "0";
            }
            else if (Both == true && Num == true && Syb == false)//Lower ,Upper,Numbers
            {
                Basic = L + N + U;
                type = "3";
            }
            else if (Both == true && Num == false && Syb == true)// Upper,Lower,Symbols
            {
                Basic = L + S + U;
                type = "6";
            }
            else if (Both == true && Num == true && Syb == true)// Upper,Lower,Symbols,Numbers
            {
                Basic = L + N + U + S;
                type = "9";
            }

            // op == 0  means we need the string containing our usable elements
            // op == 1  means we need the value that refers to each type

            return (op == 0 ? Basic : type);
        }

        private String Create_Final_Pass()
        {
            String ans = "", IdealString = Get_Type(0), temp = IdealString;

            int type = Convert.ToInt32(Get_Type(1));

            while (type == 10 || Valid_Generated_Pass(ans, type) == false)
            {

                int copy_sz = sz;
                ans = "";
                IdealString = temp;

                while (copy_sz != 0)
                {
                    int id = r.Next(0, IdealString.Length);
                    ans += IdealString[id];
                    IdealString = IdealString.Remove(id, 1);
                    copy_sz--;
                }

                if (type == 10) // Upper or Lower no need to check validaty
                    break;

                copy_sz = sz;
            }
            return ans;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Return to base case
            BasicStat();

            // Checking which radiobox is checked to specify pass size
            foreach (RadioButton el in groupBox1.Controls)
                if (el.Checked == true)
                    sz = Convert.ToInt32(el.Text);

            // Checking which radiobox is checked to specify characters type
            foreach (RadioButton el in groupBox2.Controls)
                if (el.Checked == true)
                    H = (el.Name == "R1" ? Upper = true : el.Name == "R2" ? Lower = true : Both = true);

            // Checking whether a checkbox is checked to add numbers or symbols or both in pass
            foreach (CheckBox el in groupBox3.Controls)
                if (el.Checked == true)
                    H = (el.Name == "C1" ? Num = true : Syb = true);

            // final pass
            textBox1.Text = Create_Final_Pass();
        }

        //Exit Button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
