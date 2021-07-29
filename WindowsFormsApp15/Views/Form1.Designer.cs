
namespace WindowsFormsApp15
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Заводоуправление");
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblOpenUpdateForm = new System.Windows.Forms.Label();
            this.lblRemoveNode = new System.Windows.Forms.Label();
            this.lblOpenAddForm = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pickerAdoptionDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPatronomyc = new System.Windows.Forms.TextBox();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 381);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lblOpenAddForm);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.treeView2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 381);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblOpenUpdateForm);
            this.panel4.Controls.Add(this.lblRemoveNode);
            this.panel4.Location = new System.Drawing.Point(55, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(55, 28);
            this.panel4.TabIndex = 14;
            // 
            // lblOpenUpdateForm
            // 
            this.lblOpenUpdateForm.AutoSize = true;
            this.lblOpenUpdateForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblOpenUpdateForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblOpenUpdateForm.Location = new System.Drawing.Point(3, 6);
            this.lblOpenUpdateForm.Name = "lblOpenUpdateForm";
            this.lblOpenUpdateForm.Size = new System.Drawing.Size(19, 13);
            this.lblOpenUpdateForm.TabIndex = 11;
            this.lblOpenUpdateForm.Text = "✏️";
            this.lblOpenUpdateForm.Click += new System.EventHandler(this.lblOpenUpdateForm_Click);
            // 
            // lblRemoveNode
            // 
            this.lblRemoveNode.AutoSize = true;
            this.lblRemoveNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblRemoveNode.ForeColor = System.Drawing.Color.Red;
            this.lblRemoveNode.Location = new System.Drawing.Point(30, 0);
            this.lblRemoveNode.Name = "lblRemoveNode";
            this.lblRemoveNode.Size = new System.Drawing.Size(23, 25);
            this.lblRemoveNode.TabIndex = 12;
            this.lblRemoveNode.Text = "☓";
            this.lblRemoveNode.Click += new System.EventHandler(this.lblRemoveNode_Click);
            // 
            // lblOpenAddForm
            // 
            this.lblOpenAddForm.AutoSize = true;
            this.lblOpenAddForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblOpenAddForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblOpenAddForm.Location = new System.Drawing.Point(25, 4);
            this.lblOpenAddForm.Name = "lblOpenAddForm";
            this.lblOpenAddForm.Size = new System.Drawing.Size(24, 25);
            this.lblOpenAddForm.TabIndex = 10;
            this.lblOpenAddForm.Text = "+";
            this.lblOpenAddForm.Click += new System.EventHandler(this.lblOpenAddForm_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtSurname);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.pickerAdoptionDate);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtPatronomyc);
            this.panel3.Location = new System.Drawing.Point(185, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 298);
            this.panel3.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Отчество:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(102, 8);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(165, 20);
            this.txtSurname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Фамилия:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(102, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 20);
            this.txtName.TabIndex = 3;
            // 
            // pickerAdoptionDate
            // 
            this.pickerAdoptionDate.Location = new System.Drawing.Point(102, 117);
            this.pickerAdoptionDate.Name = "pickerAdoptionDate";
            this.pickerAdoptionDate.Size = new System.Drawing.Size(165, 20);
            this.pickerAdoptionDate.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Имя:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Дата принятия:";
            // 
            // txtPatronomyc
            // 
            this.txtPatronomyc.Location = new System.Drawing.Point(102, 81);
            this.txtPatronomyc.Name = "txtPatronomyc";
            this.txtPatronomyc.Size = new System.Drawing.Size(165, 20);
            this.txtPatronomyc.TabIndex = 5;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(12, 31);
            this.treeView2.Name = "treeView2";
            treeNode2.Name = "readonlyCoreNode";
            treeNode2.Tag = "0";
            treeNode2.Text = "Заводоуправление";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView2.Size = new System.Drawing.Size(167, 298);
            this.treeView2.TabIndex = 0;
            this.treeView2.Tag = "0";
            this.treeView2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Фамилия";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(285, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 381);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Структура подразделения";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker pickerAdoptionDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPatronomyc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblRemoveNode;
        private System.Windows.Forms.Label lblOpenUpdateForm;
        private System.Windows.Forms.Label lblOpenAddForm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button button1;
    }
}

