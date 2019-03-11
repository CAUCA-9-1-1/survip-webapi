namespace Survi.Prevention.ApiClient.Tester
{
	partial class ApiClientTester
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
            this.TransferPreventionButton = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // TransferPreventionButton
            // 
            this.TransferPreventionButton.Location = new System.Drawing.Point(40, 12);
            this.TransferPreventionButton.Name = "TransferPreventionButton";
            this.TransferPreventionButton.Size = new System.Drawing.Size(158, 39);
            this.TransferPreventionButton.TabIndex = 0;
            this.TransferPreventionButton.Text = "Transférer vers la prévention";
            this.TransferPreventionButton.Click += new System.EventHandler(this.TransferPreventionButton_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(40, 70);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(174, 39);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Mettre à jour depuis la Prévention";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(343, 70);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(117, 39);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Données transférées";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(220, 70);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(117, 39);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "MAJ idextern";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // ApiClientTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.TransferPreventionButton);
            this.Name = "ApiClientTester";
            this.Text = "Transfert Prevention";
            this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton TransferPreventionButton;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}

