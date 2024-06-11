using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Common.Security;
using Microsoft.Extensions.Configuration;

namespace Common.SecurityTool
{
    public partial class frmSecurity : Form
    {
        private readonly IConfiguration configuration;
        private SecurityBase security;
        public frmSecurity()
        {
            InitializeComponent();
            this.configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setKey_IV_Value(this.cmbAlgorithm.SelectedValue!.ToString());
            switch(this.cmbAlgorithm.SelectedValue.ToString())
            {
                case "MD5":
                    this.lblMsg.Text = "MD5 �t��k�L�k�ϸѱK�I";
                    break;
                case "DES":
                    this.lblMsg.Text = "�[�K���_KEY(8�Ӧr��) �A��l�ƦV�qIV(8�Ӧr��)\n�p�G�S���wIV�ȡA��KEY ��IV�I";
                    break;
                case "AES":
                    this.lblMsg.Text = $"�[�K���_KEY(32�Ӧr��) �A��l�ƦV�qIV(16�Ӧr��)\n�p�G�S���wIV�ȡA��KEY �e16�X��IV�I";
                    break;
                case "Base64":
                default:
                    break;
            }
        }

        private void frmSecurity_Load(object sender, EventArgs e)
        {
            this.cmbAlgorithm.DataSource = this.getComboboxSource();

        }

        protected void setKey_IV_Value(string ddl)
        {
            this.lblMsg.Text = "";
            this.txtKey.Text = "";
            this.txtIV.Text = "";
            this.txtKey.Text = this.configuration.GetSection($"{ddl}Settings")["KEY"];
            this.txtIV.Text = this.configuration.GetSection($"{ddl}Settings")["IV"];
        }

        private List<string> getComboboxSource()
        {
            List<string> list;
            list = this.configuration.GetSection("AppSettings").GetSection("Algorithm").GetChildren().Select(x => x.Value).ToList<string>();
            list.Insert(0, "�п��...");
            return list;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if(this.validAlgorithm())
            {
                this.GetSecurityInstanse();
                this.txtOutput.Text = this.security.Eecrypt(this.txtInput.Text);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if(this.validAlgorithm())
            {
                this.GetSecurityInstanse();
                this.txtOutput.Text = this.security.Decrypt(this.txtInput.Text);
            }
        }

        private void GetSecurityInstanse()
        {
            string className = $"Common.Security.{this.cmbAlgorithm.SelectedValue.ToString()}Provider";
            Assembly assembly = typeof(SecurityBase).Assembly;
            var classInstance = assembly.CreateInstance(className);
            if(classInstance is SecurityBase)
                this.security = classInstance as SecurityBase;

            this.security.SetKey(this.txtKey.Text, this.txtIV.Text);
        }

        private Boolean validAlgorithm()
        {
            Boolean flag = true;
            this.errorPrd.Clear();
            switch(this.cmbAlgorithm.SelectedValue!.ToString())
            {
                case "DES":
                    flag = this.validAlgorithm(8, 8);
                    break;
                case "AES":
                    flag = this.validAlgorithm(32, 16);
                    break;
            }
            return flag;
        }
        private Boolean validAlgorithm(int keyLenth, int ivLenth)
        {
            Boolean flag = true;
            if(this.txtKey.Text.Length != keyLenth)
            {
                flag = false;
                this.alertErrorMsg($"�[�K���_KEY�A���� {keyLenth} �Ӧr���I", this.txtKey);
            }
            if(this.txtIV.Text.Length > 0 && this.txtIV.Text.Length != ivLenth)
            {
                flag = false;
                this.alertErrorMsg($"�[�K���_IV�A���� {ivLenth} �Ӧr���I", this.txtIV);
            }
            return flag;
        }


        private void alertWarningMsg(string msg, Control control = null)
        {
            if(control != null)
                this.errorPrd.SetError(control, msg);
            MessageBox.Show(this, msg, "Warning�I", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void alertErrorMsg(string msg, Control control = null)
        {
            if(control != null)
                this.errorPrd.SetError(control, msg);
            MessageBox.Show(this, msg, "Warning�I", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void alertMsg(string msg)
        {
            MessageBox.Show(this, msg, "Informat�I", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
