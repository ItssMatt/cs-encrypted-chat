
namespace client
{
	partial class Form1
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listclients = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.disconnectbtn = new System.Windows.Forms.Button();
			this.connectbox = new System.Windows.Forms.Button();
			this.namebox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.portbox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ipbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.infolabel = new System.Windows.Forms.Label();
			this.clearbtn = new System.Windows.Forms.Button();
			this.sendbtn = new System.Windows.Forms.Button();
			this.sendtext = new System.Windows.Forms.TextBox();
			this.logbox = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.listclients);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(97, 323);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Users";
			// 
			// listclients
			// 
			this.listclients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.listclients.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listclients.FullRowSelect = true;
			this.listclients.GridLines = true;
			this.listclients.HideSelection = false;
			this.listclients.Location = new System.Drawing.Point(3, 16);
			this.listclients.MultiSelect = false;
			this.listclients.Name = "listclients";
			this.listclients.Size = new System.Drawing.Size(91, 304);
			this.listclients.TabIndex = 12;
			this.listclients.UseCompatibleStateImageBehavior = false;
			this.listclients.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 87;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.disconnectbtn);
			this.groupBox2.Controls.Add(this.connectbox);
			this.groupBox2.Controls.Add(this.namebox);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.portbox);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.ipbox);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(97, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(431, 88);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Settings";
			// 
			// disconnectbtn
			// 
			this.disconnectbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.disconnectbtn.Location = new System.Drawing.Point(216, 55);
			this.disconnectbtn.Name = "disconnectbtn";
			this.disconnectbtn.Size = new System.Drawing.Size(209, 30);
			this.disconnectbtn.TabIndex = 7;
			this.disconnectbtn.Text = "DISCONNECT";
			this.disconnectbtn.UseVisualStyleBackColor = true;
			this.disconnectbtn.Click += new System.EventHandler(this.disconnectbtn_Click);
			// 
			// connectbox
			// 
			this.connectbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.connectbox.Location = new System.Drawing.Point(3, 55);
			this.connectbox.Name = "connectbox";
			this.connectbox.Size = new System.Drawing.Size(209, 30);
			this.connectbox.TabIndex = 6;
			this.connectbox.Text = "CONNECT";
			this.connectbox.UseVisualStyleBackColor = true;
			this.connectbox.Click += new System.EventHandler(this.connectbox_Click);
			// 
			// namebox
			// 
			this.namebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.namebox.Location = new System.Drawing.Point(354, 26);
			this.namebox.Name = "namebox";
			this.namebox.Size = new System.Drawing.Size(71, 21);
			this.namebox.TabIndex = 5;
			this.namebox.Text = "F0X";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(300, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Name:";
			// 
			// portbox
			// 
			this.portbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.portbox.Location = new System.Drawing.Point(237, 25);
			this.portbox.Name = "portbox";
			this.portbox.Size = new System.Drawing.Size(57, 21);
			this.portbox.TabIndex = 3;
			this.portbox.Text = "87";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(196, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port:";
			// 
			// ipbox
			// 
			this.ipbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ipbox.Location = new System.Drawing.Point(35, 25);
			this.ipbox.Name = "ipbox";
			this.ipbox.Size = new System.Drawing.Size(155, 21);
			this.ipbox.TabIndex = 1;
			this.ipbox.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.infolabel);
			this.panel1.Controls.Add(this.clearbtn);
			this.panel1.Controls.Add(this.sendbtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(449, 88);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(79, 235);
			this.panel1.TabIndex = 2;
			// 
			// infolabel
			// 
			this.infolabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infolabel.Location = new System.Drawing.Point(0, 0);
			this.infolabel.Name = "infolabel";
			this.infolabel.Size = new System.Drawing.Size(79, 163);
			this.infolabel.TabIndex = 2;
			this.infolabel.Text = "Users: \r\nPing: \r\nAdmin: \r\nHost: \r\n";
			this.infolabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// clearbtn
			// 
			this.clearbtn.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.clearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearbtn.Location = new System.Drawing.Point(0, 163);
			this.clearbtn.Name = "clearbtn";
			this.clearbtn.Size = new System.Drawing.Size(79, 36);
			this.clearbtn.TabIndex = 1;
			this.clearbtn.Text = "CLEAR";
			this.clearbtn.UseVisualStyleBackColor = true;
			this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
			// 
			// sendbtn
			// 
			this.sendbtn.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sendbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sendbtn.Location = new System.Drawing.Point(0, 199);
			this.sendbtn.Name = "sendbtn";
			this.sendbtn.Size = new System.Drawing.Size(79, 36);
			this.sendbtn.TabIndex = 0;
			this.sendbtn.Text = "SEND";
			this.sendbtn.UseVisualStyleBackColor = true;
			this.sendbtn.Click += new System.EventHandler(this.sendbtn_Click);
			// 
			// sendtext
			// 
			this.sendtext.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sendtext.Location = new System.Drawing.Point(97, 303);
			this.sendtext.Name = "sendtext";
			this.sendtext.Size = new System.Drawing.Size(352, 20);
			this.sendtext.TabIndex = 3;
			// 
			// logbox
			// 
			this.logbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logbox.Location = new System.Drawing.Point(97, 88);
			this.logbox.Name = "logbox";
			this.logbox.ReadOnly = true;
			this.logbox.Size = new System.Drawing.Size(352, 215);
			this.logbox.TabIndex = 4;
			this.logbox.Text = "";
			// 
			// Form1
			// 
			this.AcceptButton = this.sendbtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 323);
			this.Controls.Add(this.logbox);
			this.Controls.Add(this.sendtext);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Saitan Chat - Client";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button sendbtn;
		private System.Windows.Forms.TextBox sendtext;
		private System.Windows.Forms.RichTextBox logbox;
		private System.Windows.Forms.ListView listclients;
		private System.Windows.Forms.Button clearbtn;
		private System.Windows.Forms.TextBox portbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ipbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox namebox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label infolabel;
		private System.Windows.Forms.Button disconnectbtn;
		private System.Windows.Forms.Button connectbox;
	}
}

