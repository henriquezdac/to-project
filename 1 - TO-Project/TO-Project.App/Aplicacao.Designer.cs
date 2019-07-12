namespace TO_Project.App
{
    partial class Aplicacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorCredito = new System.Windows.Forms.MaskedTextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtDataPrimeiroVencimento = new System.Windows.Forms.MaskedTextBox();
            this.txtQtdParcelas = new System.Windows.Forms.MaskedTextBox();
            this.cmbTipoCredito = new System.Windows.Forms.ComboBox();
            this.txtRetorno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor do crédito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo do crédito";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "QuantidadeParcelas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data do primeiro vencimento";
            // 
            // txtValorCredito
            // 
            this.txtValorCredito.Location = new System.Drawing.Point(38, 51);
            this.txtValorCredito.Mask = "$\\ 9999999.00";
            this.txtValorCredito.Name = "txtValorCredito";
            this.txtValorCredito.Size = new System.Drawing.Size(134, 22);
            this.txtValorCredito.TabIndex = 4;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(38, 216);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 5;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.BtnCalcular_Click);
            // 
            // txtDataPrimeiroVencimento
            // 
            this.txtDataPrimeiroVencimento.Location = new System.Drawing.Point(38, 188);
            this.txtDataPrimeiroVencimento.Mask = "00/00/0000";
            this.txtDataPrimeiroVencimento.Name = "txtDataPrimeiroVencimento";
            this.txtDataPrimeiroVencimento.Size = new System.Drawing.Size(100, 22);
            this.txtDataPrimeiroVencimento.TabIndex = 6;
            this.txtDataPrimeiroVencimento.ValidatingType = typeof(System.DateTime);
            // 
            // txtQtdParcelas
            // 
            this.txtQtdParcelas.Location = new System.Drawing.Point(38, 143);
            this.txtQtdParcelas.Mask = "99";
            this.txtQtdParcelas.Name = "txtQtdParcelas";
            this.txtQtdParcelas.Size = new System.Drawing.Size(100, 22);
            this.txtQtdParcelas.TabIndex = 7;
            // 
            // cmbTipoCredito
            // 
            this.cmbTipoCredito.FormattingEnabled = true;
            this.cmbTipoCredito.Location = new System.Drawing.Point(38, 96);
            this.cmbTipoCredito.Name = "cmbTipoCredito";
            this.cmbTipoCredito.Size = new System.Drawing.Size(121, 24);
            this.cmbTipoCredito.TabIndex = 8;
            // 
            // txtRetorno
            // 
            this.txtRetorno.Location = new System.Drawing.Point(258, 51);
            this.txtRetorno.Multiline = true;
            this.txtRetorno.Name = "txtRetorno";
            this.txtRetorno.ReadOnly = true;
            this.txtRetorno.Size = new System.Drawing.Size(389, 188);
            this.txtRetorno.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Retorno";
            // 
            // Aplicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 269);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRetorno);
            this.Controls.Add(this.cmbTipoCredito);
            this.Controls.Add(this.txtQtdParcelas);
            this.Controls.Add(this.txtDataPrimeiroVencimento);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtValorCredito);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Aplicacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtValorCredito;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.MaskedTextBox txtDataPrimeiroVencimento;
        private System.Windows.Forms.MaskedTextBox txtQtdParcelas;
        private System.Windows.Forms.ComboBox cmbTipoCredito;
        private System.Windows.Forms.TextBox txtRetorno;
        private System.Windows.Forms.Label label5;
    }
}

