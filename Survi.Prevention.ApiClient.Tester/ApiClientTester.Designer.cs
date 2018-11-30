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
			// ApiClientTester
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.TransferPreventionButton);
			this.Name = "ApiClientTester";
			this.Text = "Transfert Prevention";
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton TransferPreventionButton;
	}
}

