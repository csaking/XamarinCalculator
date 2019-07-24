using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entry = XamCalc.Models.Entry;

namespace XamCalc
{
    public partial class Calculator : ContentPage
    {
        //variable used to see if there is an operator in the string or not
        private bool _opCheck = false;

        //variable used to see if a successful operation has just been done
        private bool _sumDone = false;

        //get the value of opCheck
        public bool GetOpCheck()
        {
            return _opCheck;
        }

        //flip the value of opCheck
        void ToggleOpCheck()
        {
            //if getOpCheck() returns a value of false, change to true.  Else, change to false
            if (!GetOpCheck())
            {
                _opCheck = true;
            }
            else
            {
                _opCheck = false;
            }
        }

        //get value of sumDone
        bool GetSumDone()
        {
            return _sumDone;
        }

        //flip the value of sumDone
        void ToggleSumDone()
        {
            //if getSumDone() returns a value of false, change to true.  Else, change to false
            if (!GetSumDone())
            {
                _sumDone = true;
            }
            else
            {
                _sumDone = false;
            }
        }

        //enter 1 to text if a sum has not just been completed
        void OnNumberButtonClick1(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 1;
            }
        }
        //enter 2 to text if a sum has not just been completed
        void OnNumberButtonClick2(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 2;
            }
        }
        //enter 3 to text if a sum has not just been completed
        void OnNumberButtonClick3(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 3;
            }
        }
        //enter 4 to text if a sum has not just been completed
        void OnNumberButtonClick4(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 4;
            }
        }
        //enter 5 to text if a sum has not just been completed
        void OnNumberButtonClick5(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 5;
            }
        }
        //enter 6 to text if a sum has not just been completed
        void OnNumberButtonClick6(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 6;
            }
        }
        //enter 7 to text if a sum has not just been completed
        void OnNumberButtonClick7(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 7;
            }
        }
        //enter 8 to text if a sum has not just been completed
        void OnNumberButtonClick8(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 8;
            }
        }
        //enter 9 to text if a sum has not just been completed
        void OnNumberButtonClick9(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 9;
            }
        }
        //enter 0 to text if a sum has not just been completed
        void OnNumberButtonClick0(object sender, EventArgs e)
        {
            if (!GetSumDone())
            {
                EntryLabel.Text += 0;
            }
        }
        //enter + to text and toggle opCheck to true if a sum has not just been completed
        void OnNumberButtonClickP(object sender, EventArgs e)
        {
            if (!GetOpCheck() && (EntryLabel.Text.Length >= 1) && (!GetSumDone()))
            {
                EntryLabel.Text += "+";
                ToggleOpCheck();
            }
        }
        //enter - to text and toggle opCheck to true if a sum has not just been completed
        void OnNumberButtonClickS(object sender, EventArgs e)
        {
            if (!GetOpCheck() && (EntryLabel.Text.Length >= 1) && (!GetSumDone()))
            {
                EntryLabel.Text += "-";
                ToggleOpCheck();
            }
        }
        //enter * to text and toggle opCheck to true if a sum has not just been completed
        void OnNumberButtonClickM(object sender, EventArgs e)
        {
            if (!GetOpCheck() && (EntryLabel.Text.Length >= 1) && (!GetSumDone()))
            {
                EntryLabel.Text += "*";
                ToggleOpCheck();
            }
        }
        //enter / to text and toggle opCheck to true if a sum has not just been completed
        void OnNumberButtonClickD(object sender, EventArgs e)
        {
            if (!GetOpCheck() && (EntryLabel.Text.Length >= 1) && (!GetSumDone()))
            {
                EntryLabel.Text += "/";
                ToggleOpCheck();
            }
        }
        //enter ^ to text and toggle opCheck to true if a sum has not just been completed
        void OnNumberButtonClickPOW(object sender, EventArgs e)
        {
            if (!GetOpCheck() && (EntryLabel.Text.Length >= 1) && (!GetSumDone()))
            {
                EntryLabel.Text += "^";
                ToggleOpCheck();
            }
        }
        //enter % to text and toggle opCheck to true if a sum has not just been completed
        void OnNumberButtonClickSQRT(object sender, EventArgs e)
        {
            if (!GetOpCheck() && (EntryLabel.Text.Length >= 0) && (!GetSumDone()))
            {
                EntryLabel.Text += "%";
                ToggleOpCheck();
            }
        }

        //run calculation function on button click
        void OnNumberButtonClickE(object sender, EventArgs e)
        {
            RunCalculation();
        }

        void RunCalculation()
        {
            //strings to store the values as parameters for the function that saves to the database
            string pText, pResult;

            //get the position of the operator
            int opPos = GetOperator();

            //if operator exists in the string
            if (opPos != -1)
            {
                //set original string value as text parameter
                pText = EntryLabel.Text;
                //if operator is a standard arithmetic operator
                if ((EntryLabel.Text[opPos] != '^') && (EntryLabel.Text[opPos] != '%') && (opPos + 1 != EntryLabel.Text.Length))
                {
                    //get the operands from the string
                    int num1 = System.Convert.ToInt32(EntryLabel.Text.Substring(0, opPos));
                    int num2 = System.Convert.ToInt32(EntryLabel.Text.Substring(opPos + 1, EntryLabel.Text.Length - (opPos + 1)));
                    //do calculation depending on operator
                    switch (EntryLabel.Text[opPos])
                    {
                        //subtraction
                        case '-':
                            EntryLabel.Text = System.Convert.ToString(num1 - num2);
                            break;
                        //addition
                        case '+':
                            EntryLabel.Text = System.Convert.ToString(num1 + num2);
                            break;
                        //division
                        case '/':
                            double div = System.Convert.ToDouble(num1) / System.Convert.ToDouble(num2);
                            EntryLabel.Text = div.ToString("N2");
                            break;
                        //multiplication
                        case '*':
                            EntryLabel.Text = System.Convert.ToString(num1 * num2);
                            break;
                    }
                    //flip sumDone to true
                    ToggleSumDone();
                    //assign value for pResult parameter to be sent to the database
                    pResult = EntryLabel.Text;
                    //save result and original calculation to database
                    SaveCalculation(pResult, pText);
                }
                //else operator is non standard operator
                else
                {
                    //get the number from the string
                    int num1 = System.Convert.ToInt32(EntryLabel.Text.Substring(0, opPos));
                    switch (EntryLabel.Text[opPos])
                    {
                        //find the square of the number
                        case '^':
                            EntryLabel.Text = System.Convert.ToString(num1 * num1);
                            break;
                        //find the square root of the number
                        case '%':
                            EntryLabel.Text = System.Convert.ToString(Math.Round(Math.Sqrt(num1), 2));
                            break;
                    }
                    //flip sumDone to true
                    ToggleSumDone();
                    //assign value for pResult parameter to be sent to the database
                    pResult = EntryLabel.Text;
                    //save result and original calculation to database
                    SaveCalculation(pResult, pText);
                }
            }
        }
        //remove the last character from the string if a sum has not just been completed
        void OnNumberButtonClickC(object sender, EventArgs e)
        {
            //check if the length of the string is at least 1 character long, and that sumDone is false
            if ((EntryLabel.Text.Length > 0) && (!GetSumDone()))
            {
                //check if the last character in the text is an operator, if it is then toggle the opCheck from true to false
                if (((EntryLabel.Text[EntryLabel.Text.Length - 1] == '+') ||
                    (EntryLabel.Text[EntryLabel.Text.Length - 1] == '-') ||
                    (EntryLabel.Text[EntryLabel.Text.Length - 1] == '/') ||
                    (EntryLabel.Text[EntryLabel.Text.Length - 1] == 'x') ||
                    (EntryLabel.Text[EntryLabel.Text.Length - 1] == '^') ||
                    (EntryLabel.Text[EntryLabel.Text.Length - 1] == '%'))
                    && (GetOpCheck()))
                {
                    ToggleOpCheck();
                }
                //remove the last character in the string from the string
                EntryLabel.Text = EntryLabel.Text.Substring(0, EntryLabel.Text.Length - 1);
            }
        }

        void OnNumberButtonClickCA(object sender, EventArgs e)
        {
            //clear all: check if text has operator and if it does toggle the opCheck, then check if a sum has been done then toggle the value if it has, then clear all text regardless of opCheck status
            if (GetOpCheck())
            {
                ToggleOpCheck();
            }
            if (GetSumDone())
            {
                ToggleSumDone();
            }
            EntryLabel.Text = "";
        }

        int GetOperator()
        {
            int x;
            //nest if to search operators and return x.  x is integer position of the operator in the label text
            //addition
            x = EntryLabel.Text.IndexOf('+');
            if (x == -1)
            {
                //subtraction
                x = EntryLabel.Text.IndexOf('-');
                if (x == -1)
                {
                    //multiplication
                    x = EntryLabel.Text.IndexOf('*');
                    if (x == -1)
                    {
                        //division
                        x = EntryLabel.Text.IndexOf('/');
                        if (x == -1)
                        {
                            //SQUARE
                            x = EntryLabel.Text.IndexOf('^');
                            if (x == -1)
                            {
                                //SQUARE ROOT
                                x = EntryLabel.Text.IndexOf('%');
                            }
                        }
                    }
                }
            }
            return x;
        }
        //closes the calculator and saves the calculation, then returns to the root(main) page
        async void PopBackPage(object sender, EventArgs e)
        {
            //confirm whether or not the calculation should be stored
            var answer = await DisplayAlert("Exit?", "Do you want to save this calculation?", "Yes", "No");
            if (answer)
            {
                //compute and store calculation
                RunCalculation();
            }
            //navigate to root(main) menu
            await Navigation.PopAsync();
        }
        //saves the calculation to the database.  Takes result and entry text as parameters, database generates date and pkID
        async void SaveCalculation(string pResult, string pText)
        {
            var entry = (Entry)BindingContext;
            entry.Date = DateTime.UtcNow;
            entry.Text = pText;
            entry.Result = pResult;
            await App.Database.SaveEntryAsync(entry);
        }
        //deletes the currently opened calculation from the database, then returns to the root(main) page
        async void PopBackPageDelete(object sender, EventArgs e)
        {
            //bind the properties of Entry class
            var entry = (Entry)BindingContext;
            //delete the entry
            await App.Database.DeleteEntryAsync(entry);
            //navigate to root(main) menu
            await Navigation.PopAsync();
        }
        //constructor
        public Calculator()
        {
            InitializeComponent();
        }
    }
}

