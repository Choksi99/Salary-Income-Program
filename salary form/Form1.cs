using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salary_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double d_HourWorked;
        double d_PayRate;
        double d_TaxRate;
        double d_LoanRate;
        double d_KiwiSaverEmployeeRate;
        double d_KiwiSaverEmployerRate = 3 / 100;

        double d_GrossPay;
        double d_Loan;
        double d_Tax;
        double d_KiwiSaverEmployee;
        double d_KiwiSaverEmployer;
        double d_NetPay;

        private void GetDataFromUser()
        {
            double.TryParse(txtKiwiSaverEmployeeRate.Text, out d_KiwiSaverEmployeeRate);
            double.TryParse(txtHoursWorked.Text, out d_HourWorked);
            double.TryParse(txtWageRate.Text, out d_PayRate);
            double.TryParse(txtTaxRate.Text, out d_TaxRate);
            double.TryParse(txtLoanRate.Text, out d_LoanRate);

        }

        private void CalcNetpay()
        {
            d_GrossPay = d_HourWorked* d_PayRate;
            d_Tax = d_GrossPay* d_TaxRate /100.0;

            if (chkLoan.Checked) { d_Loan = d_GrossPay * d_LoanRate / 100; }
            else { d_Loan = 0;}
            
            if(chkKiwiSaverEmployee.Checked) { d_KiwiSaverEmployee = d_GrossPay * d_KiwiSaverEmployeeRate / 100;}
            else { d_KiwiSaverEmployee = 0;}
            
            if(chkKiwiSaverEmployer.Checked) {d_KiwiSaverEmployer = d_GrossPay * d_KiwiSaverEmployerRate /100;}
            else { d_KiwiSaverEmployer = 0; }

            d_NetPay = d_GrossPay - d_Tax - d_Loan - d_KiwiSaverEmployee - d_KiwiSaverEmployer;
          
        }


        private void btnCalc_Click(object sender, EventArgs e)
        {
            GetDataFromUser();
            CalcNetpay();
            LblResult.Text = d_NetPay.ToString();

        }

      
    }
}
