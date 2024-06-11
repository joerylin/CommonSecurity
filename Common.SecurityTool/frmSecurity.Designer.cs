using System.Security.Cryptography;

namespace Common.SecurityTool
{
    partial class frmSecurity
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSecurity));
            label1 = new Label();
            btnEncrypt = new Button();
            txtInput = new TextBox();
            label2 = new Label();
            txtOutput = new TextBox();
            btnDecrypt = new Button();
            label3 = new Label();
            label4 = new Label();
            txtKey = new TextBox();
            txtIV = new TextBox();
            label5 = new Label();
            cmbAlgorithm = new ComboBox();
            errorPrd = new ErrorProvider(components);
            lblMsg = new Label();
            ((System.ComponentModel.ISupportInitialize)errorPrd).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 19);
            label1.TabIndex = 0;
            label1.Text = "輸入文字：";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(523, 318);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(94, 29);
            btnEncrypt.TabIndex = 1;
            btnEncrypt.Text = "加密";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(27, 31);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(719, 106);
            txtInput.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 331);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 3;
            label2.Text = "輸出文字：";
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(27, 353);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(719, 106);
            txtOutput.TabIndex = 4;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(652, 318);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(94, 29);
            btnDecrypt.TabIndex = 5;
            btnDecrypt.Text = "解密";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 210);
            label3.Name = "label3";
            label3.Size = new Size(50, 19);
            label3.TabIndex = 6;
            label3.Text = "KEY：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 251);
            label4.Name = "label4";
            label4.Size = new Size(38, 19);
            label4.TabIndex = 7;
            label4.Text = "IV：";
            // 
            // txtKey
            // 
            txtKey.Location = new Point(85, 207);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(661, 27);
            txtKey.TabIndex = 8;
            // 
            // txtIV
            // 
            txtIV.Location = new Point(85, 248);
            txtIV.Name = "txtIV";
            txtIV.Size = new Size(661, 27);
            txtIV.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 163);
            label5.Name = "label5";
            label5.Size = new Size(69, 19);
            label5.TabIndex = 10;
            label5.Text = "演算法：";
            // 
            // cmbAlgorithm
            // 
            cmbAlgorithm.FormattingEnabled = true;
            cmbAlgorithm.Location = new Point(87, 163);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(287, 27);
            cmbAlgorithm.TabIndex = 11;
            cmbAlgorithm.SelectedIndexChanged += cmbAlgorithm_SelectedIndexChanged;
            // 
            // errorPrd
            // 
            errorPrd.ContainerControl = this;
            // 
            // lblMsg
            // 
            lblMsg.AutoSize = true;
            lblMsg.ForeColor = Color.Blue;
            lblMsg.Location = new Point(87, 289);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(0, 19);
            lblMsg.TabIndex = 12;
            // 
            // frmSecurity
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 466);
            Controls.Add(lblMsg);
            Controls.Add(cmbAlgorithm);
            Controls.Add(label5);
            Controls.Add(txtIV);
            Controls.Add(txtKey);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnDecrypt);
            Controls.Add(txtOutput);
            Controls.Add(label2);
            Controls.Add(txtInput);
            Controls.Add(btnEncrypt);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSecurity";
            Text = "Security Tool";
            Load += frmSecurity_Load;
            ((System.ComponentModel.ISupportInitialize)errorPrd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnEncrypt;
        private TextBox txtInput;
        private Label label2;
        private TextBox txtOutput;
        private Button btnDecrypt;
        private Label label3;
        private Label label4;
        private TextBox txtKey;
        private TextBox txtIV;
        private Label label5;
        private ComboBox cmbAlgorithm;
        private ErrorProvider errorPrd;
        private Label lblMsg;
    }
}
