
using System;

namespace PikNiMi.Forms
{
    partial class MainForm
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
            this.tableUpperLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateProductButton = new System.Windows.Forms.Button();
            this.AddNewProductButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.CancelSearchButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ProductTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.tableBottomLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TripExpensesTextBox = new System.Windows.Forms.TextBox();
            this.DiscountButton = new System.Windows.Forms.Button();
            this.AddNewProductTypeButton = new System.Windows.Forms.Button();
            this.Historybutton = new System.Windows.Forms.Button();
            this.CountFullOrderDiscountButton = new System.Windows.Forms.Button();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.tableUpperLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            this.tableBottomLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableUpperLayoutPanel
            // 
            this.tableUpperLayoutPanel.ColumnCount = 6;
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.Controls.Add(this.UpdateProductButton, 1, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.AddNewProductButton, 0, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.SearchTextBox, 3, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.CancelSearchButton, 5, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.SearchButton, 4, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.ProductTypeComboBox, 2, 0);
            this.tableUpperLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableUpperLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableUpperLayoutPanel.Name = "tableUpperLayoutPanel";
            this.tableUpperLayoutPanel.RowCount = 2;
            this.tableUpperLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUpperLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUpperLayoutPanel.Size = new System.Drawing.Size(800, 100);
            this.tableUpperLayoutPanel.TabIndex = 0;
            // 
            // UpdateProductButton
            // 
            this.UpdateProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateProductButton.Location = new System.Drawing.Point(99, 3);
            this.UpdateProductButton.Name = "UpdateProductButton";
            this.UpdateProductButton.Size = new System.Drawing.Size(90, 44);
            this.UpdateProductButton.TabIndex = 2;
            this.UpdateProductButton.TabStop = false;
            this.UpdateProductButton.Text = "Atnaujinti produktą";
            this.UpdateProductButton.UseVisualStyleBackColor = true;
            // 
            // AddNewProductButton
            // 
            this.AddNewProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewProductButton.Location = new System.Drawing.Point(3, 3);
            this.AddNewProductButton.Name = "AddNewProductButton";
            this.AddNewProductButton.Size = new System.Drawing.Size(90, 44);
            this.AddNewProductButton.TabIndex = 1;
            this.AddNewProductButton.TabStop = false;
            this.AddNewProductButton.Text = "Pridėti naują produktą";
            this.AddNewProductButton.UseVisualStyleBackColor = true;
            this.AddNewProductButton.Click += new System.EventHandler(this.AddNewProductButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(515, 3);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(90, 20);
            this.SearchTextBox.TabIndex = 3;
            this.SearchTextBox.TabStop = false;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            this.SearchTextBox.GotFocus += new System.EventHandler(this.SearchTextBox_GotFocus);
            this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyDown);
            this.SearchTextBox.LostFocus += new System.EventHandler(this.SearchTextBox_LostFocus);
            // 
            // CancelSearchButton
            // 
            this.CancelSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelSearchButton.Location = new System.Drawing.Point(707, 3);
            this.CancelSearchButton.Name = "CancelSearchButton";
            this.CancelSearchButton.Size = new System.Drawing.Size(90, 44);
            this.CancelSearchButton.TabIndex = 5;
            this.CancelSearchButton.TabStop = false;
            this.CancelSearchButton.Text = "atšaukti";
            this.CancelSearchButton.UseVisualStyleBackColor = true;
            this.CancelSearchButton.Click += new System.EventHandler(this.CancelSearchButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(611, 3);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(90, 44);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.TabStop = false;
            this.SearchButton.Text = "ieškoti";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ProductTypeComboBox
            // 
            this.ProductTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductTypeComboBox.FormattingEnabled = true;
            this.ProductTypeComboBox.Location = new System.Drawing.Point(195, 3);
            this.ProductTypeComboBox.Name = "ProductTypeComboBox";
            this.ProductTypeComboBox.Size = new System.Drawing.Size(314, 21);
            this.ProductTypeComboBox.TabIndex = 0;
            this.ProductTypeComboBox.TabStop = false;
            this.ProductTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductTypeComboBox_SelectedIndexChanged);
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.AllowUserToAddRows = false;
            this.ProductDataGridView.AllowUserToDeleteRows = false;
            this.ProductDataGridView.AllowUserToResizeColumns = false;
            this.ProductDataGridView.AllowUserToResizeRows = false;
            this.ProductDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.Location = new System.Drawing.Point(3, 106);
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.Size = new System.Drawing.Size(794, 264);
            this.ProductDataGridView.TabIndex = 1;
            this.ProductDataGridView.TabStop = false;
            // 
            // tableBottomLayoutPanel
            // 
            this.tableBottomLayoutPanel.ColumnCount = 6;
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.Controls.Add(this.TripExpensesTextBox, 4, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.DiscountButton, 2, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.AddNewProductTypeButton, 1, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.Historybutton, 0, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.CountFullOrderDiscountButton, 5, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.DateTextBox, 3, 0);
            this.tableBottomLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableBottomLayoutPanel.Location = new System.Drawing.Point(0, 376);
            this.tableBottomLayoutPanel.Name = "tableBottomLayoutPanel";
            this.tableBottomLayoutPanel.RowCount = 2;
            this.tableBottomLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBottomLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBottomLayoutPanel.Size = new System.Drawing.Size(800, 74);
            this.tableBottomLayoutPanel.TabIndex = 2;
            // 
            // TripExpensesTextBox
            // 
            this.TripExpensesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TripExpensesTextBox.Location = new System.Drawing.Point(535, 3);
            this.TripExpensesTextBox.Name = "TripExpensesTextBox";
            this.TripExpensesTextBox.Size = new System.Drawing.Size(127, 20);
            this.TripExpensesTextBox.TabIndex = 10;
            this.TripExpensesTextBox.TabStop = false;
            this.TripExpensesTextBox.GotFocus += new System.EventHandler(this.TripExpensesTextBox_GotFocus);
            this.TripExpensesTextBox.LostFocus += new System.EventHandler(this.TripExpensesTextBox_LostFocus);
            // 
            // DiscountButton
            // 
            this.DiscountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscountButton.Location = new System.Drawing.Point(269, 3);
            this.DiscountButton.Name = "DiscountButton";
            this.DiscountButton.Size = new System.Drawing.Size(127, 31);
            this.DiscountButton.TabIndex = 8;
            this.DiscountButton.TabStop = false;
            this.DiscountButton.Text = "Nuolaidos";
            this.DiscountButton.UseVisualStyleBackColor = true;
            // 
            // AddNewProductTypeButton
            // 
            this.AddNewProductTypeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewProductTypeButton.Location = new System.Drawing.Point(136, 3);
            this.AddNewProductTypeButton.Name = "AddNewProductTypeButton";
            this.AddNewProductTypeButton.Size = new System.Drawing.Size(127, 31);
            this.AddNewProductTypeButton.TabIndex = 7;
            this.AddNewProductTypeButton.TabStop = false;
            this.AddNewProductTypeButton.Text = "Naujas produkto tipas";
            this.AddNewProductTypeButton.UseVisualStyleBackColor = true;
            // 
            // Historybutton
            // 
            this.Historybutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Historybutton.Location = new System.Drawing.Point(3, 3);
            this.Historybutton.Name = "Historybutton";
            this.Historybutton.Size = new System.Drawing.Size(127, 31);
            this.Historybutton.TabIndex = 6;
            this.Historybutton.TabStop = false;
            this.Historybutton.Text = "Istorija";
            this.Historybutton.UseVisualStyleBackColor = true;
            // 
            // CountFullOrderDiscountButton
            // 
            this.CountFullOrderDiscountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CountFullOrderDiscountButton.Location = new System.Drawing.Point(668, 3);
            this.CountFullOrderDiscountButton.Name = "CountFullOrderDiscountButton";
            this.CountFullOrderDiscountButton.Size = new System.Drawing.Size(129, 31);
            this.CountFullOrderDiscountButton.TabIndex = 9;
            this.CountFullOrderDiscountButton.TabStop = false;
            this.CountFullOrderDiscountButton.Text = "Skaičiuoti savikainą";
            this.CountFullOrderDiscountButton.UseVisualStyleBackColor = true;
            // 
            // DateTextBox
            // 
            this.DateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTextBox.Location = new System.Drawing.Point(402, 3);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(127, 20);
            this.DateTextBox.TabIndex = 6;
            this.DateTextBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableBottomLayoutPanel);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.tableUpperLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableUpperLayoutPanel.ResumeLayout(false);
            this.tableUpperLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            this.tableBottomLayoutPanel.ResumeLayout(false);
            this.tableBottomLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableUpperLayoutPanel;
        private System.Windows.Forms.ComboBox ProductTypeComboBox;
        private System.Windows.Forms.Button AddNewProductButton;
        private System.Windows.Forms.Button UpdateProductButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button CancelSearchButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableBottomLayoutPanel;
        private System.Windows.Forms.Button CountFullOrderDiscountButton;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.Button DiscountButton;
        private System.Windows.Forms.Button AddNewProductTypeButton;
        private System.Windows.Forms.Button Historybutton;
        private System.Windows.Forms.TextBox TripExpensesTextBox;
    }
}

